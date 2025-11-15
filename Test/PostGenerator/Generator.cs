using Microsoft.AspNetCore.Mvc.Testing;
using NUglify;
using NUglify.Css;
using NUglify.Html;
using NUglify.JavaScript;
using System.IO.Compression;

namespace BrowserAPI.Test.PostGenerator;

public static class Generator {
    private readonly struct Core(Config config) {
        public readonly List<string> ErrorList { get; } = [];


        public void GenerateFiles() {
            using WebApplicationFactory<ClientHost.Program.IAssemblyMarker> webApplicationFactory = new();
            using HttpClient httpClient = webApplicationFactory.CreateClient();

            if (config.GenerateHtmlPage) {
                HtmlSettings htmlSettings = new() {
                    RemoveComments = false,
                    RemoveOptionalTags = false
                };

                using HttpResponseMessage response = httpClient.GetAsync("").GetAwaiter().GetResult();
                string htmlContent = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                UglifyResult minifyResult = Uglify.Html(htmlContent, htmlSettings);
                if (minifyResult.HasErrors) {
                    ErrorList.Add($"HTML Minification error:");
                    foreach (UglifyError error in minifyResult.Errors)
                        ErrorList.Add(error.Message);
                }

                string fileName = $"{config.PageFolderPath}/index.html";
                Directory.CreateDirectory(Path.GetDirectoryName(fileName)!);
                File.WriteAllText(fileName, minifyResult.Code);
            }

            foreach (string filePath in config.GenerateFiles) {
                using HttpResponseMessage response = httpClient.GetAsync(filePath).GetAwaiter().GetResult();
                string content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                string absoluteFilePath = $"{config.WorkingDirectory}/{filePath}";
                Directory.CreateDirectory(Path.GetDirectoryName(absoluteFilePath)!);
                File.WriteAllText(absoluteFilePath, content);
            }
        }

        public void CreateRobotsTxt() {
            File.WriteAllTextAsync($"{config.WorkingDirectory}/robots.txt", $"User-agent: *\nSitemap: {config.SiteUrl}/sitemap.xml\n");
        }

        public void CreateSiteMap() {
            string siteMapContent = $"""
                <?xml version="1.0" encoding="UTF-8"?>
                <urlset
                      xmlns="http://www.sitemaps.org/schemas/sitemap/0.9"
                      xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
                      xsi:schemaLocation="http://www.sitemaps.org/schemas/sitemap/0.9 http://www.sitemaps.org/schemas/sitemap/0.9/sitemap.xsd">
                  <url>
                    <loc>{config.SiteUrl}/</loc>
                  </url>
                </urlset>

                """;
            File.WriteAllText($"{config.WorkingDirectory}/sitemap.xml", siteMapContent);
        }

        public void RemoveFiles() {
            foreach (string folder in config.RemoveFileList.folders) {
                string path = $"{config.WorkingDirectory}/{folder}";
                if (Directory.Exists(path))
                    Directory.Delete(path, true);
            }

            foreach (string file in config.RemoveFileList.files) {
                string path = $"{config.WorkingDirectory}/{file}";
                if (File.Exists(path))
                    File.Delete(path);
            }
        }

        public void MinifyCssJs() {
            Config configRef = config;
            string[] files = Directory.GetFiles(config.WorkingDirectory, "*", SearchOption.AllDirectories);

            IEnumerable<string> cssFileList = files.Where((string file) => {
                string fileRelative = file[(configRef.WorkingDirectory.Length + 1)..];

                foreach (string startsWith in configRef.MinifyExcludeList.startsWith)
                    if (fileRelative.StartsWith(startsWith))
                        return false;

                foreach (string endsWith in configRef.MinifyExcludeList.endsWith)
                    if (fileRelative.EndsWith(endsWith))
                        return false;

                return file.EndsWith(".css") && !file.EndsWith(".min.css");
            });
            CssSettings cssSettings = new() {
                CommentMode = CssComment.None
            };

            foreach (string file in cssFileList) {
                string fileContent = File.ReadAllText(file);

                UglifyResult minifyResult = Uglify.Css(fileContent, cssSettings);
                if (minifyResult.HasErrors) {
                    ErrorList.Add($"Css Minification error at file {file}:");
                    foreach (UglifyError error in minifyResult.Errors)
                        ErrorList.Add(error.Message);
                }

                File.WriteAllText(file, minifyResult.Code);
            }


            IEnumerable<string> jsFileList = files.Where((string file) => {
                string fileRelative = file[(configRef.WorkingDirectory.Length + 1)..];

                foreach (string startsWith in configRef.MinifyExcludeList.startsWith)
                    if (fileRelative.StartsWith(startsWith))
                        return false;

                foreach (string endsWith in configRef.MinifyExcludeList.endsWith)
                    if (fileRelative.EndsWith(endsWith))
                        return false;

                return file.EndsWith(".js") && !file.EndsWith(".min.js");
            });
            CodeSettings jsSettings = new();

            foreach (string file in jsFileList) {
                string fileContent = File.ReadAllText(file);

                UglifyResult minifyResult = Uglify.Js(fileContent, jsSettings);
                if (minifyResult.HasErrors) {
                    ErrorList.Add($"Js Minification error at file {file}:");
                    foreach (UglifyError error in minifyResult.Errors)
                        ErrorList.Add(error.Message);
                }

                File.WriteAllText(file, minifyResult.Code);
            }
        }

        public void ZipFiles() {
            Config configRef = config;
            string[] files = Directory.GetFiles(configRef.WorkingDirectory, "*", SearchOption.AllDirectories);
            IEnumerable<string> fileList = files.Where((string file) => {
                string fileRelative = file[(configRef.WorkingDirectory.Length + 1)..];

                foreach (string startsWith in configRef.ZipExcludeList.startsWith)
                    if (fileRelative.StartsWith(startsWith))
                        return false;

                foreach (string endsWith in configRef.ZipExcludeList.endsWith)
                    if (fileRelative.EndsWith(endsWith))
                        return false;

                return true;
            });

            List<Task> tasklist = new(files.Length);
            foreach (string filePath in fileList) {
                Task zipTask = ZipAsync(filePath);
                tasklist.Add(zipTask);

                static async Task ZipAsync(string filePath) {
                    byte[] fileContent = await File.ReadAllBytesAsync(filePath);
                    using MemoryStream originalStream = new(fileContent, false);

                    // compress gzip
                    {
                        using FileStream fileStream = File.Create($"{filePath}.gz");
                        using GZipStream gZipStream = new(fileStream, CompressionLevel.SmallestSize);
                        await originalStream.CopyToAsync(gZipStream);
                    }

                    originalStream.Seek(0, SeekOrigin.Begin);

                    // compress brotli
                    {
                        using FileStream fileStream = File.Create($"{filePath}.br");
                        using BrotliStream brotliStream = new(fileStream, CompressionLevel.SmallestSize);
                        await originalStream.CopyToAsync(brotliStream);
                    }
                }
            }
            Task.WhenAll(tasklist).GetAwaiter().GetResult();
        }
    }

    public static List<string> Generate(Config config) {
        Core core = new(config);


        if (config.GenerateHtmlPage || config.GenerateFiles.Length > 0) {
            Console.WriteLine("Generating files...");
            core.GenerateFiles();
            Console.WriteLine("Done file generating.\n");
        }
        else
            Console.WriteLine("Skip html pages.\n");

        if (config.CreateRobotsTxt) {
            Console.WriteLine("Creating robots.txt...");
            core.CreateRobotsTxt();
            Console.WriteLine("Done robots.txt.\n");
        }
        else
            Console.WriteLine("Skip robots.txt.\n");

        if (config.CreateSitemapXml) {
            Console.WriteLine("Creating sitemap.xml...");
            core.CreateSiteMap();
            Console.WriteLine("Done sitemap.xml.\n");
        }
        else
            Console.WriteLine("Skip sitemap.xml.\n");

        if (config.RemoveFiles) {
            Console.WriteLine("Removing exceeding files...");
            core.RemoveFiles();
            Console.WriteLine("Done removing exceeding files.\n");
        }
        else
            Console.WriteLine("Skip removing exceeding files.\n");

        if (config.MinifyCssJs) {
            Console.WriteLine("Minify css and js files...");
            core.MinifyCssJs();
            Console.WriteLine("Done minifying.\n");
        }
        else
            Console.WriteLine("Skip minifying.\n");

        if (config.ZipFiles) {
            Console.WriteLine("Zipping files...");
            core.ZipFiles();
            Console.WriteLine("Done zipping.\n");
        }
        else
            Console.WriteLine("Skip zipping.\n");


        return core.ErrorList;
    }
}

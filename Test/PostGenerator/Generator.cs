using Microsoft.AspNetCore.Mvc.Testing;
using NUglify;
using NUglify.Css;
using NUglify.Html;
using NUglify.JavaScript;
using System.IO.Compression;

namespace BrowserAPI.Test.PostGenerator;

public static class Generator {
    private struct Core(Config config) {
        public List<string> ErrorList { get; private set; } = [];


        public async Task GenerateFiles() {
            using WebApplicationFactory<ClientHost.Program.IAssemblyMarker> webApplicationFactory = new();
            using HttpClient httpClient = webApplicationFactory.CreateClient();

            if (config.GenerateHtmlPage) {
                HtmlSettings htmlSettings = new() {
                    RemoveComments = false,
                    RemoveOptionalTags = false
                };

                using HttpResponseMessage response = await httpClient.GetAsync("");
                string htmlContent = await response.Content.ReadAsStringAsync();

                UglifyResult minifyResult = Uglify.Html(htmlContent, htmlSettings);
                if (minifyResult.HasErrors) {
                    ErrorList.Add($"HTML Minification error:");
                    foreach (UglifyError error in minifyResult.Errors)
                        ErrorList.Add(error.Message);
                }

                string fileName = $"{config.PageFolderPathWithTrailingSlash}index.html";
                Directory.CreateDirectory(Path.GetDirectoryName(fileName)!);
                await File.WriteAllTextAsync(fileName, minifyResult.Code);
            }

            foreach (string filePath in config.GenerateFiles) {
                using HttpResponseMessage response = await httpClient.GetAsync(filePath);
                string content = await response.Content.ReadAsStringAsync();

                string absoluteFilePath = $"{config.WorkingDirectoryWithTrailingSlash}{filePath}";
                Directory.CreateDirectory(Path.GetDirectoryName(absoluteFilePath)!);
                await File.WriteAllTextAsync(absoluteFilePath, content);
            }
        }

        public async Task CreateRobotsTxt() {
            await File.WriteAllTextAsync($"{config.WorkingDirectoryWithTrailingSlash}robots.txt", $"User-agent: *\nSitemap: {config.SiteUrl}/sitemap.xml\n");
        }

        public async Task CreateSiteMap() {
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
            await File.WriteAllTextAsync($"{config.WorkingDirectoryWithTrailingSlash}sitemap.xml", siteMapContent);
        }

        public void RemoveFilesList() {
            foreach (string folder in config.RemoveFileList.folders) {
                string path = $"{config.WorkingDirectoryWithTrailingSlash}{folder}";
                if (Directory.Exists(path))
                    Directory.Delete(path, true);
            }

            foreach (string file in config.RemoveFileList.files) {
                string path = $"{config.WorkingDirectoryWithTrailingSlash}{file}";
                if (File.Exists(path))
                    File.Delete(path);
            }
        }

        public async Task MinifyCssJs() {
            Config configRef = config;
            string[] files = Directory.GetFiles(config.WorkingDirectory, "*", SearchOption.AllDirectories);

            IEnumerable<string> cssFileList = files.Where((string file) => {
                string fileRelative = file[configRef.WorkingDirectoryWithTrailingSlash.Length..];

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
                string fileContent = await File.ReadAllTextAsync(file);

                UglifyResult minifyResult = Uglify.Css(fileContent, cssSettings);
                if (minifyResult.HasErrors) {
                    ErrorList.Add($"Css Minification error at file {file}:");
                    foreach (UglifyError error in minifyResult.Errors)
                        ErrorList.Add(error.Message);
                }

                await File.WriteAllTextAsync(file, minifyResult.Code);
            }


            IEnumerable<string> jsFileList = files.Where((string file) => {
                string fileRelative = file[configRef.WorkingDirectoryWithTrailingSlash.Length..];

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
                string fileContent = await File.ReadAllTextAsync(file);

                UglifyResult minifyResult = Uglify.Js(fileContent, jsSettings);
                if (minifyResult.HasErrors) {
                    ErrorList.Add($"Js Minification error at file {file}:");
                    foreach (UglifyError error in minifyResult.Errors)
                        ErrorList.Add(error.Message);
                }

                await File.WriteAllTextAsync(file, minifyResult.Code);
            }
        }

        public async Task ZipFiles() {
            Config configRef = config;
            string[] files = Directory.GetFiles(configRef.WorkingDirectory, "*", SearchOption.AllDirectories);
            IEnumerable<string> fileList = files.Where((string file) => {
                string fileRelative = file[configRef.WorkingDirectoryWithTrailingSlash.Length..];

                foreach (string startsWith in configRef.ZipExcludeList.startsWith)
                    if (fileRelative.StartsWith(startsWith))
                        return false;

                foreach (string endsWith in configRef.ZipExcludeList.endsWith)
                    if (fileRelative.EndsWith(endsWith))
                        return false;

                return true;
            });

            ParallelOptions parallelOptions = new() { MaxDegreeOfParallelism = Environment.ProcessorCount };
            await Parallel.ForEachAsync(fileList, parallelOptions, async ValueTask (string filePath, CancellationToken token) => {
                byte[] fileContent = await File.ReadAllBytesAsync(filePath, token);
                using MemoryStream originalStream = new(fileContent, false);

                // compress gzip
                {
                    using FileStream fileStream = File.Create($"{filePath}.gz");
                    using GZipStream gZipStream = new(fileStream, CompressionLevel.SmallestSize);
                    await originalStream.CopyToAsync(gZipStream, token);
                }

                originalStream.Seek(0, SeekOrigin.Begin);

                // compress brotli
                {
                    using FileStream fileStream = File.Create($"{filePath}.br");
                    using BrotliStream brotliStream = new(fileStream, CompressionLevel.SmallestSize);
                    await originalStream.CopyToAsync(brotliStream, token);
                }
            });
        }
    }

    public static async Task<List<string>> Generate(Config config) {
        Core core = new(config);


        if (config.GenerateHtmlPage || config.GenerateFiles.Length > 0) {
            Console.WriteLine("Generating files...");
            await core.GenerateFiles();
            Console.WriteLine("Done file generating.\n");
        }
        else
            Console.WriteLine("Skip html pages.\n");

        if (config.CreateRobotsTxt) {
            Console.WriteLine("Creating robots.txt...");
            await core.CreateRobotsTxt();
            Console.WriteLine("Done robots.txt.\n");
        }
        else
            Console.WriteLine("Skip robots.txt.\n");

        if (config.CreateSitemapXml) {
            Console.WriteLine("Creating sitemap.xml...");
            await core.CreateSiteMap();
            Console.WriteLine("Done sitemap.xml.\n");
        }
        else
            Console.WriteLine("Skip sitemap.xml.\n");

        if (config.RemoveFiles) {
            Console.WriteLine("Removing exceeding files...");
            core.RemoveFilesList();
            Console.WriteLine("Done removing exceeding files.\n");
        }
        else
            Console.WriteLine("Skip removing exceeding files.\n");

        if (config.MinifyCssJs) {
            Console.WriteLine("Minify css and js files...");
            await core.MinifyCssJs();
            Console.WriteLine("Done minifying.\n");
        }
        else
            Console.WriteLine("Skip minifying.\n");

        if (config.ZipFiles) {
            Console.WriteLine("Zipping files...");
            await core.ZipFiles();
            Console.WriteLine("Done zipping.\n");
        }
        else
            Console.WriteLine("Skip zipping.\n");


        return core.ErrorList;
    }
}

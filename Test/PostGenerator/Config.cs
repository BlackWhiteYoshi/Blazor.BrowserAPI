using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Nodes;

namespace BrowserAPI.Test.PostGenerator;

/** config.json hints
 * 
 * working directory:
 *   path to published core folder
 * 
 * remove folder list:
 *   remove exceeding folders: "folderPath1, folderPath2, ..."
 *
 * remove file list:
 *   remove exceeding files: "filePath1, filePath2, ..."
 * 
 * zip exclude list startsWith:
 *   skips zipping paths that begins with given pattern: "startsWith1, startsWith2, ..."
 * 
 * zip exclude list endsWith:
 *   skips zipping paths that ends with given pattern: "endsWith1, endsWith2, ..."
 *
 */

file static class JsonNodeExtension {
    internal static JsonNode Get(this JsonNode node, string key) => node[key] ?? throw new ArgumentException($"Cannot find key '{key}' in json config.");
    internal static string GetString(this JsonNode node, string key) => (string?)node.Get(key) ?? throw new ArgumentException($"key '{key}' must be a string.");
    internal static bool GetBool(this JsonNode node, string key) => (bool?)node.Get(key) ?? throw new ArgumentException($"key '{key}' must be a boolean.");
    internal static string[] AsStringArray(this JsonNode node) => node.AsArray().Select((JsonNode? node) => (string?)node ?? throw new ArgumentException($"key '{node}' must be a string.")).ToArray();
}

public sealed class Config {
    public required string WorkingDirectory { get; init; }
    public required string WorkingDirectoryWithTrailingSlash { get; init; }
    public required string PageFolderPath { get; init; }
    public required string PageFolderPathWithTrailingSlash { get; init; }

    public required string SiteUrl { get; init; }

    public required bool GenerateHtmlPage { get; init; }
    public required string[] GenerateFiles { get; init; }

    public required bool CreateRobotsTxt { get; init; }

    public required bool CreateSitemapXml { get; init; }

    public required bool RemoveFiles { get; init; }
    public required (string[] folders, string[] files) RemoveFileList { get; init; }

    public required bool MinifyCssJs { get; init; }
    public required (string[] startsWith, string[] endsWith) MinifyExcludeList { get; init; }

    public required bool ZipFiles { get; init; }
    public required (string[] startsWith, string[] endsWith) ZipExcludeList { get; init; }


    public Config() { }

    [SetsRequiredMembers]
    public Config(string json) {
        JsonNode root = JsonNode.Parse(json) ?? throw new Exception($"json is not in a valid format:\n{json}");
        
        WorkingDirectory = root.GetString("working directory");
        if (!Directory.Exists(WorkingDirectory))
            throw new InvalidDataException($"working directory does not exist:\n{Path.Combine(Directory.GetCurrentDirectory(), WorkingDirectory)}");
        WorkingDirectoryWithTrailingSlash = $"{WorkingDirectory}{Path.DirectorySeparatorChar}";
        
        string relativePageFolderPath = root.Get("generate html pages").GetString("page folder");
        PageFolderPath = $"{WorkingDirectory}{Path.DirectorySeparatorChar}{relativePageFolderPath}";
        PageFolderPathWithTrailingSlash = $"{WorkingDirectory}{Path.DirectorySeparatorChar}{relativePageFolderPath}{Path.DirectorySeparatorChar}";

        SiteUrl = root.GetString("site url");

        GenerateHtmlPage = root.Get("generate files").Get("html page").GetBool("enabled");
        GenerateFiles = root.Get("generate files").Get("other files").AsStringArray();

        CreateRobotsTxt = root.GetBool("create robots.txt");

        CreateSitemapXml = root.GetBool("create sitemap.xml");

        RemoveFiles = root.Get("remove files").GetBool("enabled");
        RemoveFileList = (root.Get("remove files").Get("folder list").AsStringArray(), root.Get("remove files").Get("file list").AsStringArray());

        MinifyCssJs = root.Get("minify css/js").GetBool("enabled");
        MinifyExcludeList = (root.Get("minify css/js").Get("exclude list startsWith").AsStringArray(), root.Get("minify css/js").Get("exclude list endsWith").AsStringArray());

        ZipFiles = root.Get("zip files").GetBool("enabled");
        ZipExcludeList = (root.Get("zip files").Get("exclude list startsWith").AsStringArray(), root.Get("zip files").Get("exclude list endsWith").AsStringArray());
    }
}

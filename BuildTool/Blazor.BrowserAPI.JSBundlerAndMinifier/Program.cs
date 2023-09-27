using NUglify;
using NUglify.JavaScript;
using System.Text;

namespace Blazor.BrowserAPI.JSBundlerAndMinifier;

public static class Program {
    private const string OUTPUT_Path = "wwwroot/BrowserAPI.js";

    public static async Task Main(string[] args) {
        string inputPath = args.Length switch {
            >= 1 => args[0],
            _ => "."
        };

        List<string> jsFiles = new();
        {
            string[] directories = Directory.GetDirectories(inputPath);
            foreach (string path in directories) {
                string directory = path.Replace("\\", "/");
                if (directory.EndsWith($"/bin") || directory.EndsWith($"/obj") || directory.EndsWith($"/wwwroot"))
                    continue;

                string[] files = Directory.GetFiles(directory, "*.js", SearchOption.AllDirectories);
                foreach (string file in files)
                    jsFiles.Add(file);
            }
        }

        string bundleJS;
        {
            StringBuilder builder = new(1024 * jsFiles.Count);

            foreach (string file in jsFiles)
                builder.Append(File.ReadAllText(file));

            bundleJS = builder.ToString();
        }

        string minifiedJS;
        {
            UglifyResult minifyResult = Uglify.Js(bundleJS, new CodeSettings());
            if (minifyResult.HasErrors)
                throw new Exception("Js Minification error");

            minifiedJS = minifyResult.Code;
        }

        string outputPath = Path.Combine(inputPath, OUTPUT_Path);
        await File.WriteAllTextAsync(outputPath, minifiedJS);
    }
}

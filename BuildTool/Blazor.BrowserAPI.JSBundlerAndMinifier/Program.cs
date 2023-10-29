using NUglify;
using NUglify.JavaScript;
using System.Text;

namespace Blazor.BrowserAPI.JSBundlerAndMinifier;

public static class Program {
    public static void Main(string[] args) {
        string inputPath = args.Length switch {
            >= 1 => args[0],
            _ => "."
        };
        const string outputPath = "wwwroot/BrowserAPI.js";

        List<string> jsFilePaths = new();
        {
            string[] directories = Directory.GetDirectories(inputPath);
            foreach (string path in directories) {
                string directory = path.Replace("\\", "/");
                if (directory.EndsWith($"/bin") || directory.EndsWith($"/obj") || directory.EndsWith($"/wwwroot"))
                    continue;

                string[] filePaths = Directory.GetFiles(directory, "*.js", SearchOption.AllDirectories);
                foreach (string filePath in filePaths)
                    jsFilePaths.Add(filePath);
            }
        }

        string bundleJS;
        {
            StringBuilder builder = new(1024 * jsFilePaths.Count);

            foreach (string filePath in jsFilePaths)
                foreach (string line in File.ReadLines(filePath))
                    if (!line.StartsWith("import"))
                        builder.Append(line).Append('\n');

            bundleJS = builder.ToString();
        }

        string minifiedJS;
        {
            UglifyResult minifyResult = Uglify.Js(bundleJS, new CodeSettings());
            if (minifyResult.HasErrors)
                throw new Exception("Js Minification error");

            minifiedJS = minifyResult.Code;
        }

        string absoluteOutputPath = Path.Combine(inputPath, outputPath);
        File.WriteAllText(absoluteOutputPath, minifiedJS);
    }
}

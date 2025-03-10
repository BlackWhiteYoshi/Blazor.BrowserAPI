using CliWrap;
using CliWrap.Buffered;
using NUglify;
using NUglify.JavaScript;
using System.Text;

namespace Blazor.BrowserAPI.JSBundlerAndMinifier;

public static class Program {
    public static void Main(string[] args) {
        string workingDirectory = args.Length switch {
            >= 1 => args[0],
            _ => "."
        };
        string outputPath = Path.Combine(workingDirectory, "wwwroot/BrowserAPI.js");

        string bundleJS;
        try {
            Console.WriteLine("creating temp.ts ...");
            {
                File.Delete("./temp.ts");
                using FileStream tempTsStream = new("./temp.ts", FileMode.OpenOrCreate, FileAccess.Write);
                using StreamWriter tempTsWriter = new(tempTsStream, Encoding.UTF8);

                foreach (string filePath in Directory.GetFiles(workingDirectory, "*.ts", SearchOption.AllDirectories)) {
                    foreach (string line in File.ReadLines(filePath))
                        if (!line.StartsWith("import")) {
                            tempTsWriter.Write(line);
                            tempTsWriter.Write('\n');
                        }
                    tempTsWriter.Write('\n');
                }
            }
            Console.WriteLine("Done creating temp.ts\n");

            Console.WriteLine("executing 'tsc temp.ts --target ES2022 --module ES6' and read in resulting temp.js");
            {
                // tsc temp.ts --target ES2022 --module ES6
                CommandResult result = Cli.Wrap("tsc")
                    .WithWorkingDirectory(".")
                    .WithArguments("temp.ts --target ES2022 --module ES6")
                    .WithStandardOutputPipe(PipeTarget.ToDelegate(Console.WriteLine))
                    .ExecuteBufferedAsync().GetAwaiter().GetResult();
                if (result.ExitCode != 0)
                    throw new Exception("'tsc temp.ts --target ES2022 --module ES6' failed");

                bundleJS = File.ReadAllText("./temp.js");
            }
            Console.WriteLine("Done getting temp.js\n");
        }
        finally {
            File.Delete("temp.js");
            File.Delete("temp.ts");
        }            


        string minifiedJS;
        Console.WriteLine("Minifying ...");
        {
            UglifyResult minifyResult = Uglify.Js(bundleJS, new CodeSettings());
            if (minifyResult.HasErrors)
                throw new Exception("Js Minification error");

            minifiedJS = minifyResult.Code;
        }
        Console.WriteLine("Done minifying\n");


        File.WriteAllText(outputPath, minifiedJS);
    }
}

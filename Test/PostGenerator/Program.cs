namespace BrowserAPI.Test.PostGenerator;

public static class Program {
    public static int Main() {
        string json = File.ReadAllText("config.json");
        Config config = new(json);


        List<string> errorList = Generator.Generate(config);


        if (errorList.Count > 0) {
            Console.WriteLine("completed with one or more errors\n");
            foreach (string error in errorList)
                Console.WriteLine($"  {error}");

            return 1;
        }

        Console.WriteLine("completed successfully");

        return 0;
    }
}

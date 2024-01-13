namespace BrowserAPI.Test.PostGenerator;

public static class Program {
    public static async Task<int> Main(string[] args) {
        string json = await File.ReadAllTextAsync("config.json");
        Config config = new(json);


        List<string> errorList = await Generator.Generate(config);


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

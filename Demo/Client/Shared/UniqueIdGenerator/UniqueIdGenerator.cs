namespace BrowserAPI.Demo.Client;

public sealed class UniqueIdGenerator {
    private int id = 0;

    public int GetUniqueId() => id++;
}

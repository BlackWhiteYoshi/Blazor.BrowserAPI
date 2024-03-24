# Clipboard

The Clipboard interface implements the Clipboard API, providing—if the user grants permission—both read and write access to the contents of the system clipboard.


<br><br />
## Example

```csharp
public sealed partial class ExampleComponent : ComponentBase {
    [Inject]
    public required IClipboard Clipboard { private get; init; }

    private async Task Example() {
        await Clipboard.Write("example content");
        string clipboardContent = await Clipboard.Read(); // returns "example content"
    }
}
```


<br><br />
## Members

### IClipboard

#### Methods

| **Name** | **Parameters**                                               | **ReturnType**          | **Description**                                                                                                                                                                                        |
| -------- | ------------------------------------------------------------ | ----------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| Write    | string text, [CancellationToken cancellationToken = default] | ValueTask               | navigator.clipboard.writeText(text); The Clipboard interface's writeText() property writes the specified text string to the system clipboard. Text may be read back using either read() or readText(). |
| Read     | [CancellationToken cancellationToken = default]              | ValueTask&lt;string&gt; | navigator.clipboard.readText(); The Clipboard interface's readText() method returns a Promise which resolves with a copy of the textual contents of the system clipboard.                              |

**Note**: *IClipboardInProcess* does not exist, because methods *Copy* and *Paste* are itself asynchronous operations.

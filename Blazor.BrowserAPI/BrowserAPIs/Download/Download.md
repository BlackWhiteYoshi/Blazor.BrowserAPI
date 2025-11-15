# Download

Save data as a file download on the filesystem. For file upload use the *InputFile* component.


<br><br />
## Example

```csharp
public sealed partial class ExampleComponent : ComponentBase {
    [Inject]
    public required IDownload Download { private get; init; }

    private async Task Example() {
        await Download.DownloadAsFile("example.txt", "example content");
    }
}
```


<br><br />
## Members

### IDownload

#### Methods

| **Name**       | **Parameters**                                                                                      | **ReturnType** | **Description**                                                                                |
| -------------- | --------------------------------------------------------------------------------------------------- | ---------------| ---------------------------------------------------------------------------------------------- |
| DownloadAsFile | string fileName, string fileContent, [CancellationToken cancellationToken = default]                | ValueTask      | Triggers a download by adding an &lt;a&gt;-element to the document and simulate a click on it. |
| DownloadAsFile | string fileName, byte[] fileContent, [CancellationToken cancellationToken = default]                | ValueTask      | see Method *DownloadAsFile(string, string, CancellationToken)*                                 |
| DownloadAsFile | string fileName, DotNetStreamReference fileContent, [CancellationToken cancellationToken = default] | ValueTask      | see Method *DownloadAsFile(string, string, CancellationToken)*                                 |

**Note**: *IDownloadInProcess* does not exist, because method *DownloadAsFile* is itself an asynchronous operation.

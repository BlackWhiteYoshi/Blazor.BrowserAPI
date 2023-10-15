# Download

Save data as a file download on the filesystem. For file upload use the *InputFile* component.


<br><br />
## Example

TODO


<br><br />
## Members

### IDownload

#### Methods

| **Name**       | **Parameters**                                                                                      | **ReturnType** | **Dexcription**                                                                                |
| -------------- | --------------------------------------------------------------------------------------------------- | ---------------| ---------------------------------------------------------------------------------------------- |
| DownloadAsFile | string fileName, string fileContent, [CancellationToken cancellationToken = default]                | ValueTask      | Triggers a download by adding an &lt;a&gt;-element to the document and simulate a click on it. |
| DownloadAsFile | string fileName, byte[] fileContent, [CancellationToken cancellationToken = default]                | ValueTask      | Triggers a download by adding an &lt;a&gt;-element to the document and simulate a click on it. |
| DownloadAsFile | string fileName, DotNetStreamReference fileContent, [CancellationToken cancellationToken = default] | ValueTask      | Triggers a download by adding an &lt;a&gt;-element to the document and simulate a click on it. |

**Note**: *IDownloadInProcess* does not exist, because method *DownloadAsFile* is itself an asynchronous operation.

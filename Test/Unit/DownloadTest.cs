using BrowserAPI.Test.Client;
using Xunit;
using IDownloadData = Microsoft.Playwright.IDownload;

namespace BrowserAPI.UnitTest;

public sealed class DownloadTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    [Fact]
    public async Task Download() {
        Task<IDownloadData> downloadTask = Page.WaitForDownloadAsync();
        await Page.GetByTestId(DownloadGroup.BUTTON_DOWNLOAD_AS_FILE).ClickAsync();
        IDownloadData download = await downloadTask;

        Stream downloadData = await download.CreateReadStreamAsync() ?? throw new Exception("download data is null");
        using StreamReader streamReader = new(downloadData);
        string downloadContent = await streamReader.ReadToEndAsync();

        Assert.Equal(DownloadGroup.TEST_FILENAME, download.SuggestedFilename);
        Assert.Equal(DownloadGroup.TEST_FILECONTENT, downloadContent);
    }
}

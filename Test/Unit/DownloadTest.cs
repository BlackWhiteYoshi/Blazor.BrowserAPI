using BrowserAPI.Test.Client;
using Xunit;
using IDownloadData = Microsoft.Playwright.IDownload;

namespace BrowserAPI.UnitTest;

public sealed class DownloadTest : PlayWrightTest {
    public DownloadTest(PlayWrightFixture playWrightFixture) : base(playWrightFixture) { }


    [Fact]
    public async Task Download() {
        Task<IDownloadData> downloadTask = Page.WaitForDownloadAsync();
        await Page.GetByTestId(DownloadGroup.DATA_TESTID).ClickAsync();
        IDownloadData download = await downloadTask;
        
        Stream downloadData = await download.CreateReadStreamAsync() ?? throw new Exception("download data is null");
        using StreamReader streamReader = new(downloadData);
        string downloadContent = await streamReader.ReadToEndAsync();

        Assert.Equal(DownloadGroup.FILENAME, download.SuggestedFilename);
        Assert.Equal(DownloadGroup.FILECONTENT, downloadContent);
    }
}

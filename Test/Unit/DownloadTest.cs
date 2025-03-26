﻿using BrowserAPI.Test.Client;

namespace BrowserAPI.UnitTest;

[ClassDataSource<PlayWrightFixture>(Shared = SharedType.PerAssembly)]
public sealed class DownloadTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    [Test]
    [Retry(3)]
    public async Task Download() {
        Task<Microsoft.Playwright.IDownload> downloadTask = Page.WaitForDownloadAsync();
        await Page.GetByTestId(DownloadGroup.BUTTON_DOWNLOAD_AS_FILE).ClickAsync();
        Microsoft.Playwright.IDownload download = await downloadTask;

        Stream downloadData = await download.CreateReadStreamAsync() ?? throw new Exception("download data is null");
        using StreamReader streamReader = new(downloadData);
        string downloadContent = await streamReader.ReadToEndAsync();

        await Assert.That(download.SuggestedFilename).IsEqualTo(DownloadGroup.TEST_FILENAME);
        await Assert.That(downloadContent).IsEqualTo(DownloadGroup.TEST_FILECONTENT);
    }
}

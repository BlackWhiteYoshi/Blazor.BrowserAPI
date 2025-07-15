using BrowserAPI.Test.Client;

namespace BrowserAPI.UnitTest;

[ClassDataSource<PlayWrightFixture>(Shared = SharedType.PerAssembly)]
public sealed class PermissionsInProcessTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    [Test]
    public async Task Query() {
        await ExecuteTest(PermissionsInProcessGroup.BUTTON_QUERY);

        string? result = await Page.GetByTestId(PermissionsInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }


    [Test]
    public async Task GetName() {
        await ExecuteTest(PermissionsInProcessGroup.BUTTON_GET_NAME);

        string? result = await Page.GetByTestId(PermissionsInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(PermissionsInProcessGroup.TEST_PERMISSION_NAME);
    }

    [Test]
    public async Task GetState() {
        await ExecuteTest(PermissionsInProcessGroup.BUTTON_GET_STATE);

        string? result = await Page.GetByTestId(PermissionsInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("prompt");
    }


    [Test]
    public async Task RegisterOnChange() {
        await ExecuteTest(PermissionsInProcessGroup.BUTTON_REGISTER_ON_CHANGE);
        await BrowserContext.GrantPermissionsAsync([PermissionsInProcessGroup.TEST_PERMISSION_NAME]);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(PermissionsInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(PermissionsInProcessGroup.TEST_ON_CHANGE_EVENT);
    }
}

using BrowserAPI.Test.Client;

namespace BrowserAPI.UnitTest;

[ClassDataSource<PlayWrightFixture>(Shared = SharedType.PerAssembly)]
public sealed class PermissionsTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    [Test]
    public async Task Query() {
        await ExecuteTest(PermissionsGroup.BUTTON_QUERY);

        string? result = await Page.GetByTestId(PermissionsGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }


    [Test]
    public async Task GetName_Property() {
        await ExecuteTest(PermissionsGroup.BUTTON_GET_NAME_PROPERTY);

        string? result = await Page.GetByTestId(PermissionsGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(PermissionsGroup.TEST_PERMISSION_NAME);
    }

    [Test]
    public async Task GetName_Method() {
        await ExecuteTest(PermissionsGroup.BUTTON_GET_NAME_METHOD);

        string? result = await Page.GetByTestId(PermissionsGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(PermissionsGroup.TEST_PERMISSION_NAME);
    }

    [Test]
    public async Task GetState_Property() {
        await ExecuteTest(PermissionsGroup.BUTTON_GET_STATE_PROPERTY);

        string? result = await Page.GetByTestId(PermissionsGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("prompt");
    }

    [Test]
    public async Task GetState_Method() {
        await ExecuteTest(PermissionsGroup.BUTTON_GET_STATE_METHOD);

        string? result = await Page.GetByTestId(PermissionsGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("prompt");
    }


    [Test]
    public async Task RegisterOnChange() {
        await ExecuteTest(PermissionsGroup.BUTTON_REGISTER_ON_CHANGE);
        await BrowserContext.GrantPermissionsAsync([PermissionsGroup.TEST_PERMISSION_NAME]);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(PermissionsGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(PermissionsGroup.TEST_ON_CHANGE_EVENT);
    }
}

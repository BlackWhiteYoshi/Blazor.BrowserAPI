namespace BrowserAPI;

/// <summary>
/// Represents installed related apps.<br />
/// It is the ReturnType of <see cref="INavigator.GetInstalledRelatedApps"/>/<see cref="INavigatorInProcess.GetInstalledRelatedApps"/>
/// </summary>
/// <param name="Id">Represents the ID used to represent the application on the specified platform. The exact form of the string will vary by platform.</param>
/// <param name="Platform">
/// Represents the platform (ecosystem or operating system) the related app is associated with. This can be:<br />
/// - "chrome_web_store": A Google Chrome Web Store app.<br />
/// - "play": A Google Play Store app.<br />
/// - "chromeos_play": A ChromeOS Play app.<br />
/// - "webapp": A Progressive Web App.<br />
/// - "windows": A Windows Store app.<br />
/// - "f-droid": An F-Droid app.<br />
/// - "amazon": An Amazon App Store app.
/// </param>
/// <param name="Url">Represents the URL associated with the app. This is usually where you can read information about it and install it.</param>
/// <param name="Version">Represents the related app's version.</param>
public readonly record struct InstalledRelatedApps(string? Id, string Platform, string? Url, string? Version);

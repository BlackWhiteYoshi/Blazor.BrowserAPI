using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BrowserAPI.Demo.Client;

public sealed partial class Permissions : ComponentBase {
    [Inject]
    public required IPermissions PPermissions { private get; init; }


    private string backgroundSyncPermission = string.Empty;
    private async Task GetBackgroundSyncPermission() {
        try {
            await using IPermissionStatus permissionStatus = await PPermissions.Query("background-sync");
            backgroundSyncPermission = await permissionStatus.State;
        }
        catch (JSException) {
            backgroundSyncPermission = "not available";
        }
    }

    private string clipboardReadPermission = string.Empty;
    private async Task GetClipboardReadPermission() {
        try {
            await using IPermissionStatus permissionStatus = await PPermissions.Query("clipboard-read");
            clipboardReadPermission = await permissionStatus.State;
        }
        catch (JSException) {
            clipboardReadPermission = "not available";
        }
    }

    private string clipboardWritePermission = string.Empty;
    private async Task GetClipboardWritePermission() {
        try {
            await using IPermissionStatus permissionStatus = await PPermissions.Query("clipboard-write");
            clipboardWritePermission = await permissionStatus.State;
        }
        catch (JSException) {
            clipboardWritePermission = "not available";
        }
    }

    private string computePressurePermission = string.Empty;
    private async Task GetComputePressurePermission() {
        try {
            await using IPermissionStatus permissionStatus = await PPermissions.Query("compute-pressure");
            computePressurePermission = await permissionStatus.State;
        }
        catch (JSException) {
            computePressurePermission = "not available";
        }
    }

    private string geolocationPermission = string.Empty;
    private async Task GetGeolocationPermission() {
        try {
            await using IPermissionStatus permissionStatus = await PPermissions.Query("geolocation");
            geolocationPermission = await permissionStatus.State;
        }
        catch (JSException) {
            geolocationPermission = "not available";
        }
    }

    private string localFontsPermission = string.Empty;
    private async Task GetLocalFontsPermission() {
        try {
            await using IPermissionStatus permissionStatus = await PPermissions.Query("local-fonts");
            localFontsPermission = await permissionStatus.State;
        }
        catch (JSException) {
            localFontsPermission = "not available";
        }
    }

    private string cameraPermission = string.Empty;
    private async Task GetCameraPermission() {
        try {
            await using IPermissionStatus permissionStatus = await PPermissions.Query("camera");
            cameraPermission = await permissionStatus.State;
        }
        catch (JSException) {
            cameraPermission = "not available";
        }
    }

    private string microphonePermission = string.Empty;
    private async Task GetMicrophonePermission() {
        try {
            await using IPermissionStatus permissionStatus = await PPermissions.Query("microphone");
            microphonePermission = await permissionStatus.State;
        }
        catch (JSException) {
            microphonePermission = "not available";
        }
    }

    private string notificationsPermission = string.Empty;
    private async Task GetNotificationsPermission() {
        try {
            await using IPermissionStatus permissionStatus = await PPermissions.Query("notifications");
            notificationsPermission = await permissionStatus.State;
        }
        catch (JSException) {
            notificationsPermission = "not available";
        }
    }

    private string paymentHandlerPermission = string.Empty;
    private async Task GetPaymentHandlerPermission() {
        try {
            await using IPermissionStatus permissionStatus = await PPermissions.Query("payment-handler");
            paymentHandlerPermission = await permissionStatus.State;
        }
        catch (JSException) {
            paymentHandlerPermission = "not available";
        }
    }

    private string pushPermission = string.Empty;
    private async Task GetPushPermission() {
        try {
            await using IPermissionStatus permissionStatus = await PPermissions.Query("push");
            pushPermission = await permissionStatus.State;
        }
        catch (JSException) {
            pushPermission = "not available";
        }
    }

    private string screenWakeLockPermission = string.Empty;
    private async Task GetScreenWakeLockPermission() {
        try {
            await using IPermissionStatus permissionStatus = await PPermissions.Query("screen-wake-lock");
            screenWakeLockPermission = await permissionStatus.State;
        }
        catch (JSException) {
            screenWakeLockPermission = "not available";
        }
    }

    private string accelerometerPermission = string.Empty;
    private async Task GetAccelerometerPermission() {
        try {
            await using IPermissionStatus permissionStatus = await PPermissions.Query("accelerometer");
            accelerometerPermission = await permissionStatus.State;
        }
        catch (JSException) {
            accelerometerPermission = "not available";
        }
    }

    private string gyroscopePermission = string.Empty;
    private async Task GetGyroscopePermission() {
        try {
            await using IPermissionStatus permissionStatus = await PPermissions.Query("gyroscope");
            gyroscopePermission = await permissionStatus.State;
        }
        catch (JSException) {
            gyroscopePermission = "not available";
        }
    }

    private string magnetometerPermission = string.Empty;
    private async Task GetMagnetometerPermission() {
        try {
            await using IPermissionStatus permissionStatus = await PPermissions.Query("magnetometer");
            magnetometerPermission = await permissionStatus.State;
        }
        catch (JSException) {
            magnetometerPermission = "not available";
        }
    }

    private string ambientLightSensorPermission = string.Empty;
    private async Task GetAmbientLightSensorPermission() {
        try {
            await using IPermissionStatus permissionStatus = await PPermissions.Query("ambient-light-sensor");
            ambientLightSensorPermission = await permissionStatus.State;
        }
        catch (JSException) {
            ambientLightSensorPermission = "not available";
        }
    }

    private string storageAccessPermission = string.Empty;
    private async Task GetStorageAccessPermission() {
        try {
            await using IPermissionStatus permissionStatus = await PPermissions.Query("storage-access");
            storageAccessPermission = await permissionStatus.State;
        }
        catch (JSException) {
            storageAccessPermission = "not available";
        }
    }

    private string topLevelStorageAccessPermission = string.Empty;
    private async Task GetTopLevelStorageAccessPermission() {
        try {
            await using IPermissionStatus permissionStatus = await PPermissions.Query("top-level-storage-access");
            topLevelStorageAccessPermission = await permissionStatus.State;
        }
        catch (JSException) {
            topLevelStorageAccessPermission = "not available";
        }
    }

    private string persistentStoragePermission = string.Empty;
    private async Task GetPersistentStoragePermission() {
        try {
            await using IPermissionStatus permissionStatus = await PPermissions.Query("persistent-storage");
            persistentStoragePermission = await permissionStatus.State;
        }
        catch (JSException) {
            persistentStoragePermission = "not available";
        }
    }

    private string bluetoothPermission = string.Empty;
    private async Task GetBluetoothPermission() {
        try {
            await using IPermissionStatus permissionStatus = await PPermissions.Query("bluetooth");
            bluetoothPermission = await permissionStatus.State;
        }
        catch (JSException) {
            bluetoothPermission = "not available";
        }
    }

    private string midiPermission = string.Empty;
    private async Task GetMidiPermission() {
        try {
            await using IPermissionStatus permissionStatus = await PPermissions.Query("midi");
            midiPermission = await permissionStatus.State;
        }
        catch (JSException) {
            midiPermission = "not available";
        }
    }

    private string windowManagementPermission = string.Empty;
    private async Task GetWindowManagementPermission() {
        try {
            await using IPermissionStatus permissionStatus = await PPermissions.Query("window-management");
            windowManagementPermission = await permissionStatus.State;
        }
        catch (JSException) {
            windowManagementPermission = "not available";
        }
    }
}

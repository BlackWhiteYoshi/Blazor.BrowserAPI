import { ClipboardAPI } from "./BrowserAPIs/Clipboard/Clipboard.ts";
export { ClipboardAPI };

import { ConsoleAPI } from "./BrowserAPIs/Console/Console.ts";
export { ConsoleAPI };

import { CookieStorageAPI } from "./BrowserAPIs/CookieStorage/CookieStorage.ts";
export { CookieStorageAPI };

import { DocumentAPI } from "./BrowserAPIs/Document/Document.ts";
export { DocumentAPI }

import { DownloadAPI } from "./BrowserAPIs/Download/Download.ts";
export { DownloadAPI };

import { FileSystemAPI } from "./BrowserAPIs/FileSystem/FileSystem.ts";
export { FileSystemAPI };

import { GamepadInterfaceAPI } from "./BrowserAPIs/GamepadAPI/GamepadAPI.ts";
export { GamepadInterfaceAPI };

import { GeolocationAPI } from "./BrowserAPIs/Geolocation/Geolocation.ts";
export { GeolocationAPI };

import { HistoryAPI } from "./BrowserAPIs/History/History.ts";
export { HistoryAPI };

import { HTMLDialogElementAPI } from "./BrowserAPIs/HTMLDialogElement/HTMLDialogElement.ts";
export { HTMLDialogElementAPI };

import { HTMLElementAPI } from "./BrowserAPIs/HTMLElement/HTMLElement.ts";
export { HTMLElementAPI };

import { HTMLMediaElementAPI } from "./BrowserAPIs/HTMLMediaElement/HTMLMediaElement.ts";
export { HTMLMediaElementAPI };

import { LanguageAPI } from "./BrowserAPIs/Language/Language.ts"; // Obsolete
export { LanguageAPI }; // Obsolete

import { LocalStorageAPI } from "./BrowserAPIs/LocalStorage/LocalStorage.ts";
export { LocalStorageAPI };

import { MediaDevicesAPI } from "./BrowserAPIs/MediaDevices/MediaDevices.ts";
export { MediaDevicesAPI };

import { NavigatorAPI } from "./BrowserAPIs/Navigator/Navigator.ts";
export { NavigatorAPI };

import { NetworkInformationAPI } from "./BrowserAPIs/NetworkInformation/NetworkInformation.ts";
export { NetworkInformationAPI };

import { PermissionsAPI } from "./BrowserAPIs/Permissions/Permissions.ts";
export { PermissionsAPI };

// SensorAPI
import { SensorAPI } from "./BrowserAPIs/SensorAPI/Sensor/Sensor.ts";
import { AbsoluteOrientationSensorAPI } from "./BrowserAPIs/SensorAPI/Sensor/AbsoluteOrientationSensor/AbsoluteOrientationSensor.ts";
import { AccelerometerAPI } from "./BrowserAPIs/SensorAPI/Sensor/Accelerometer/Accelerometer.ts";
import { AmbientLightSensorAPI } from "./BrowserAPIs/SensorAPI/Sensor/AmbientLightSensor/AmbientLightSensor.ts";
import { GravitySensorAPI } from "./BrowserAPIs/SensorAPI/Sensor/GravitySensor/GravitySensor.ts";
import { GyroscopeAPI } from "./BrowserAPIs/SensorAPI/Sensor/Gyroscope/Gyroscope.ts";
import { LinearAccelerationSensorAPI } from "./BrowserAPIs/SensorAPI/Sensor/LinearAccelerationSensor/LinearAccelerationSensor.ts";
import { MagnetometerAPI } from "./BrowserAPIs/SensorAPI/Sensor/Magnetometer/Magnetometer.ts";
import { RelativeOrientationSensorAPI } from "./BrowserAPIs/SensorAPI/Sensor/RelativeOrientationSensor/RelativeOrientationSensor.ts";
import { UncalibratedMagnetometerAPI } from "./BrowserAPIs/SensorAPI/Sensor/UncalibratedMagnetometer/UncalibratedMagnetometer.ts";
export { SensorAPI, AbsoluteOrientationSensorAPI, AccelerometerAPI, AmbientLightSensorAPI, GravitySensorAPI, GyroscopeAPI, LinearAccelerationSensorAPI, MagnetometerAPI, RelativeOrientationSensorAPI, UncalibratedMagnetometerAPI };

import { ServiceWorkerContainerAPI } from "./BrowserAPIs/ServiceWorker/ServiceWorkerContainer/ServiceWorkerContainer.ts";
export { ServiceWorkerContainerAPI };

import { SessionStorageAPI } from "./BrowserAPIs/SessionStorage/SessionStorage.ts";
export { SessionStorageAPI };

import { WindowAPI } from "./BrowserAPIs/Window/Window.ts";
export { WindowAPI };

import { WindowManagementAPI } from "./BrowserAPIs/WindowManagement/WindowManagement.ts";
import { ScreenAPI } from "./BrowserAPIs/WindowManagement/Screen/Screen.ts";
export { WindowManagementAPI, ScreenAPI };


import { BlazorInvoke } from "./Extensions/blazorExtensions.ts";
BlazorInvoke.init();

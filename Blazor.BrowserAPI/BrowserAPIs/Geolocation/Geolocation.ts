import { BlazorInvoke } from "../../Extensions/blazorExtensions";

type GeolocationCoordinateObject = {
    latitude: number,
    longitude: number,
    altitude: number | null,
    accuracy: number,
    altitudeAccuracy: number | null,
    heading: number | null,
    speed: number | null,
    timestamp: number
};

export class GeolocationAPI {
    public static getCurrentPosition(callbackGeolocation: DotNet.DotNetObject, maximumAge: number, timeout: number, enableHighAccuracy: boolean): void {
        navigator.geolocation.getCurrentPosition(
            (geolocationPosition) => BlazorInvoke.method(callbackGeolocation, "Success", GeolocationAPI.toGeoCoordsObject(geolocationPosition.coords, geolocationPosition.timestamp)),
            (geolocationPositionError) => BlazorInvoke.method(callbackGeolocation, "Error", geolocationPositionError.code, geolocationPositionError.message),
            {
                maximumAge: maximumAge >= 0 ? maximumAge : Infinity,
                timeout: timeout >= 0 ? timeout : undefined,
                enableHighAccuracy
            }
        );
    }

    public static getCurrentPositionAsync(maximumAge: number, timeout: number, enableHighAccuracy: boolean): Promise<GeolocationCoordinateObject> {
        return new Promise((resolve, reject) => {
            navigator.geolocation.getCurrentPosition(
                (geolocationPosition) => resolve(GeolocationAPI.toGeoCoordsObject(geolocationPosition.coords, geolocationPosition.timestamp)),
                (geolocationPositionError) => reject({ code: geolocationPositionError.code, message: geolocationPositionError.message }),
                {
                    maximumAge: maximumAge >= 0 ? maximumAge : Infinity,
                    timeout: timeout >= 0 ? timeout : undefined,
                    enableHighAccuracy
                }
            );
        });
    }

    /** @returns watchId */
    public static watchPosition(callbackGeolocation: DotNet.DotNetObject, maximumAge: number, timeout: number, enableHighAccuracy: boolean): number {
        return navigator.geolocation.watchPosition(
            (geolocationPosition) => BlazorInvoke.method(callbackGeolocation, "Success", GeolocationAPI.toGeoCoordsObject(geolocationPosition.coords, geolocationPosition.timestamp)),
            (geolocationPositionError) => BlazorInvoke.method(callbackGeolocation, "Error", geolocationPositionError.code, geolocationPositionError.message),
            {
                maximumAge: maximumAge >= 0 ? maximumAge : Infinity,
                timeout: timeout >= 0 ? timeout : undefined,
                enableHighAccuracy
            }
        );
    }

    public static clearWatch(watchId: number): void {
        navigator.geolocation.clearWatch(watchId)
    }



    private static toGeoCoordsObject(geolocationCoordinates: GeolocationCoordinates, timestamp: number): GeolocationCoordinateObject {
        return {
            latitude: geolocationCoordinates.latitude,
            longitude: geolocationCoordinates.longitude,
            altitude: geolocationCoordinates.altitude,
            accuracy: geolocationCoordinates.accuracy,
            altitudeAccuracy: geolocationCoordinates.altitudeAccuracy,
            heading: geolocationCoordinates.heading,
            speed: geolocationCoordinates.speed,
            timestamp: timestamp
        };
    }
}

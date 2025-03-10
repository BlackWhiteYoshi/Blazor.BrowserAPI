import { DotNet } from "../../blazor";

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
    static getCurrentPosition(callbackGeolocation: DotNet.DotNetObject, maximumAge: number, timeout: number, enableHighAccuracy: boolean) {
        navigator.geolocation.getCurrentPosition(
            (geolocationPosition) => callbackGeolocation.invokeMethodAsync("Success", GeolocationAPI.#toGeoCoordsObject(geolocationPosition.coords, geolocationPosition.timestamp)),
            (geolocationPositionError) => callbackGeolocation.invokeMethodAsync("Error", geolocationPositionError.code, geolocationPositionError.message),
            {
                maximumAge: maximumAge >= 0 ? maximumAge : Infinity,
                timeout: timeout >= 0 ? timeout : undefined,
                enableHighAccuracy
            }
        );
    }

    static getCurrentPositionAsync(maximumAge: number, timeout: number, enableHighAccuracy: boolean): Promise<GeolocationCoordinateObject> {
        return new Promise((resolve, reject) => {
            navigator.geolocation.getCurrentPosition(
                (geolocationPosition) => resolve(GeolocationAPI.#toGeoCoordsObject(geolocationPosition.coords, geolocationPosition.timestamp)),
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
    static watchPosition(callbackGeolocation: DotNet.DotNetObject, maximumAge: number, timeout: number, enableHighAccuracy: boolean): number {
        return navigator.geolocation.watchPosition(
            (geolocationPosition) => callbackGeolocation.invokeMethodAsync("Success", GeolocationAPI.#toGeoCoordsObject(geolocationPosition.coords, geolocationPosition.timestamp)),
            (geolocationPositionError) => callbackGeolocation.invokeMethodAsync("Error", geolocationPositionError.code, geolocationPositionError.message),
            {
                maximumAge: maximumAge >= 0 ? maximumAge : Infinity,
                timeout: timeout >= 0 ? timeout : undefined,
                enableHighAccuracy
            }
        );
    }

    static clearWatch(watchId: number) {
        navigator.geolocation.clearWatch(watchId)
    }



    static #toGeoCoordsObject(geolocationCoordinates: GeolocationCoordinates, timestamp: number): GeolocationCoordinateObject {
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

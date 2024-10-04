export class GeolocationAPI {
    /**
     * @param {import("../../blazor").DotNet.DotNetObject} callbackGeolocation
     * @param {number} maximumAge;
     * @param {number} timeout;
     * @param {boolean} enableHighAccuracy
     */
    static getCurrentPosition(callbackGeolocation, maximumAge, timeout, enableHighAccuracy) {
        navigator.geolocation.getCurrentPosition(
            (geolocationPosition) => callbackGeolocation.invokeMethodAsync("Success", this.#toGeoCoordsObject(geolocationPosition.coords), geolocationPosition.timestamp),
            (geolocationPositionError) => callbackGeolocation.invokeMethodAsync("Error", geolocationPositionError.code, geolocationPositionError.message),
            {
                maximumAge: maximumAge >= 0 ? maximumAge : Infinity,
                timeout: timeout >= 0 ? timeout : undefined,
                enableHighAccuracy
            }
        );
    }

    /**
     * @param {import("../../blazor").DotNet.DotNetObject} callbackGeolocation
     * @param {number} maximumAge;
     * @param {number} timeout;
     * @param {boolean} enableHighAccuracy
     * @returns {number} watchId
     */
    static watchPosition(callbackGeolocation, maximumAge, timeout, enableHighAccuracy) {
        return navigator.geolocation.watchPosition(
            (geolocationPosition) => callbackGeolocation.invokeMethodAsync("Success", this.#toGeoCoordsObject(geolocationPosition.coords), geolocationPosition.timestamp),
            (geolocationPositionError) => callbackGeolocation.invokeMethodAsync("Error", geolocationPositionError.code, geolocationPositionError.message),
            {
                maximumAge: maximumAge >= 0 ? maximumAge : Infinity,
                timeout: timeout >= 0 ? timeout : undefined,
                enableHighAccuracy
            }
        );
    }

    /**
     * @param {number} watchId
     */
    static clearWatch(watchId) {
        navigator.geolocation.clearWatch(watchId)
    }



    /**
     * @param {GeolocationCoordinates} geolocationCoordinates
     * @returns { {latitude: number, longitude: number, altitude: number | null, accuracy: number, altitudeAccuracy: number | null, heading: number | null, speed: number | null} }
     */
    static #toGeoCoordsObject(geolocationCoordinates) {
        return {
            latitude: geolocationCoordinates.latitude,
            longitude: geolocationCoordinates.longitude,
            altitude: geolocationCoordinates.altitude,
            accuracy: geolocationCoordinates.accuracy,
            altitudeAccuracy: geolocationCoordinates.altitudeAccuracy,
            heading: geolocationCoordinates.heading,
            speed: geolocationCoordinates.speed
        };
    }
}

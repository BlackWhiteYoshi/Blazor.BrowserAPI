import { PermissionStatusAPI } from "./PermissionStatus/PermissionStatus";

export class PermissionsAPI {
    static async query(name: string, userVisibleOnly: boolean, sysex: boolean): Promise<PermissionStatusAPI> {
        const permissionStatus = await navigator.permissions.query(<PermissionDescriptor>{ name, userVisibleOnly, sysex });
        return new PermissionStatusAPI(permissionStatus);
    }
}

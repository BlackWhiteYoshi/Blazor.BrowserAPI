export class ConsoleAPI {
    public static assert(condition: boolean, data: any[]): void {
        console.assert(condition, data);
    }

    public static clear(): void {
        console.clear();
    }


    public static count(label?: string): void {
        console.count(label);
    }

    public static countReset(label?: string): void {
        console.countReset(label);
    }


    public static debug(data: any[]): void {
        console.debug(data);
    }


    public static dir(item: any): void {
        console.dir(item);
    }

    public static dirxml(item: any): void {
        console.dirxml(item);
    }


    public static error(data: any[]): void {
        console.error(data);
    }


    public static group(label?: string): void {
        console.group(label);
    }

    public static groupCollapsed(label?: string): void {
        console.groupCollapsed(label);
    }

    public static groupEnd(): void {
        console.groupEnd();
    }


    public static info(data: any[]): void {
        console.info(data);
    }

    public static log(data: any[]): void {
        console.log(data);
    }

    public static table(data: any, columns?: string[]): void {
        console.table(data, columns);
    }


    public static time(label?: string): void {
        console.time(label);
    }

    public static timeEnd(label?: string): void {
        console.timeEnd(label);
    }

    public static timeLog(label?: string, data?: any[]): void {
        if (data === undefined)
            console.timeLog(label);
        else
            console.timeLog(label, data);
    }


    public static trace(objects: any[]): void {
        console.trace(objects);
    }

    public static warn(data: any[]): void {
        console.warn(data);
    }
}

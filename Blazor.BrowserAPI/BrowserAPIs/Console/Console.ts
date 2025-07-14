export class ConsoleAPI {
    static assert(condition: boolean, data: any[]): void {
        console.assert(condition, data);
    }

    static clear(): void {
        console.clear();
    }


    static count(label?: string): void {
        console.count(label);
    }

    static countReset(label?: string): void {
        console.countReset(label);
    }


    static debug(data: any[]): void {
        console.debug(data);
    }


    static dir(item: any): void {
        console.dir(item);
    }

    static dirxml(item: any): void {
        console.dirxml(item);
    }


    static error(data: any[]): void {
        console.error(data);
    }


    static group(label?: string): void {
        console.group(label);
    }

    static groupCollapsed(label?: string): void {
        console.groupCollapsed(label);
    }

    static groupEnd(): void {
        console.groupEnd();
    }


    static info(data: any[]): void {
        console.info(data);
    }

    static log(data: any[]): void {
        console.log(data);
    }

    static table(data: any, columns?: string[]): void {
        console.table(data, columns);
    }


    static time(label?: string): void {
        console.time(label);
    }

    static timeEnd(label?: string): void {
        console.timeEnd(label);
    }

    static timeLog(label?: string, data?: any[]): void {
        if (data === undefined)
            console.timeLog(label);
        else
            console.timeLog(label, data);
    }


    static trace(objects: any[]): void {
        console.trace(objects);
    }

    static warn(data: any[]): void {
        console.warn(data);
    }
}

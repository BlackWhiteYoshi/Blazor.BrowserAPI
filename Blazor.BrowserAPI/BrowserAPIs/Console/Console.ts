export class ConsoleAPI {
    static assert(condition: boolean, data: any[]) {
        console.assert(condition, data);
    }

    static clear() {
        console.clear();
    }


    static count(label?: string) {
        console.count(label);
    }

    static countReset(label?: string) {
        console.countReset(label);
    }


    static debug(data: any[]) {
        console.debug(data);
    }


    static dir(item: any) {
        console.dir(item);
    }

    static dirxml(item: any) {
        console.dirxml(item);
    }


    static error(data: any[]) {
        console.error(data);
    }


    static group(label?: string) {
        console.group(label);
    }

    static groupCollapsed(label?: string) {
        console.groupCollapsed(label);
    }

    static groupEnd() {
        console.groupEnd();
    }


    static info(data: any[]) {
        console.info(data);
    }

    static log(data: any[]) {
        console.log(data);
    }

    static table(data: any, columns?: string[]) {
        console.table(data, columns);
    }


    static time(label?: string) {
        console.time(label);
    }

    static timeEnd(label?: string) {
        console.timeEnd(label);
    }

    static timeLog(label?: string, data?: any[]) {
        if (data === undefined)
            console.timeLog(label);
        else
            console.timeLog(label, data);
    }


    static trace(objects: any[]) {
        console.trace(objects);
    }

    static warn(data: any[]) {
        console.warn(data);
    }
}

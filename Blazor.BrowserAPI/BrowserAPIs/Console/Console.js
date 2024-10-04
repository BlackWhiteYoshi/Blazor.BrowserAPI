export class ConsoleAPI {
    /**
     * @param {boolean} condition
     * @param {any[]} data
     */
    static assert(condition, data) {
        console.assert(condition, data);
    }

    /**
     */
    static clear() {
        console.clear();
    }


    /**
     * @param {string} [label]
     */
    static count(label) {
        console.count(label);
    }

    /**
     * @param {string} [label]
     */
    static countReset(label) {
        console.countReset(label);
    }


    /**
     * @param {any[]} data
     */
    static debug(data) {
        console.debug(data);
    }


    /**
     * @param {any} item
     */
    static dir(item) {
        console.dir(item);
    }

    /**
     * @param {any} item
     */
    static dirxml(item) {
        console.dirxml(item);
    }


    /**
     * @param {any[]} data
     */
    static error(data) {
        console.error(data);
    }


    /**
     * @param {string} [label]
     */
    static group(label) {
        console.group(label);
    }

    /**
     * @param {string} [label]
     */
    static groupCollapsed(label) {
        console.groupCollapsed(label);
    }

    /**
     */
    static groupEnd() {
        console.groupEnd();
    }


    /**
     * @param {any[]} data
     */
    static info(data) {
        console.info(data);
    }

    /**
     * @param {any[]} data
     */
    static log(data) {
        console.log(data);
    }

    /**
     * @param {any} data
     * @param {string[]} [columns]
     */
    static table(data, columns) {
        console.table(data, columns);
    }


    /**
     * @param {string} [label]
     */
    static time(label) {
        console.time(label);
    }

    /**
     * @param {string} [label]
     */
    static timeEnd(label) {
        console.timeEnd(label);
    }

    /**
     * @param {string} [label]
     * @param {any[]} [data]
     */
    static timeLog(label, data) {
        if (data === undefined)
            console.timeLog(label);
        else
            console.timeLog(label, data);
    }


    /**
     * @param {any[]} objects
     */
    static trace(objects) {
        console.trace(objects);
    }

    /**
     * @param {any[]} data
     */
    static warn(data) {
        console.warn(data);
    }
}

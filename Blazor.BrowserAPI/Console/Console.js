/**
 * @param {boolean} condition
 * @param {any[]} data
 */
export function consoleAssert(condition, data) {
    console.assert(condition, data);
}

/**
 */
export function consoleClear() {
    console.clear();
}


/**
 * @param {string} [label]
 */
export function consoleCount(label) {
    console.count(label);
}

/**
 * @param {string} [label]
 */
export function consoleCountReset(label) {
    console.countReset(label);
}


/**
 * @param {any[]} data
 */
export function consoleDebug(data) {
    console.debug(data);
}


/**
 * @param {any} item
 */
export function consoleDir(item) {
    console.dir(item);
}

/**
 * @param {any} item
 */
export function consoleDirxml(item) {
    console.dirxml(item);
}


/**
 * @param {any[]} data
 */
export function consoleError(data) {
    console.error(data);
}


/**
 * @param {string} [label]
 */
export function consoleGroup(label) {
    console.group(label);
}

/**
 * @param {string} [label]
 */
export function consoleGroupCollapsed(label) {
    console.groupCollapsed(label);
}

/**
 */
export function consoleGroupEnd() {
    console.groupEnd();
}


/**
 * @param {any[]} data
 */
export function consoleInfo(data) {
    console.info(data);
}

/**
 * @param {any[]} data
 */
export function consoleLog(data) {
    console.log(data);
}

/**
 * @param {any} data
 * @param {string[]} [columns]
 */
export function consoleTable(data, columns) {
    console.table(data, columns);
}


/**
 * @param {string} [label]
 */
export function consoleTime(label) {
    console.time(label);
}

/**
 * @param {string} [label]
 */
export function consoleTimeEnd(label) {
    console.timeEnd(label);
}

/**
 * @param {string} [label]
 * @param {any[]} [data]
 */
export function consoleTimeLog(label, data) {
    if (data === undefined)
        console.timeLog(label);
    else
        console.timeLog(label, data);
}


/**
 * @param {any[]} objects
 */
export function consoleTrace(objects) {
    console.trace(objects);
}

/**
 * @param {any[]} data
 */
export function consoleWarn(data) {
    console.warn(data);
}

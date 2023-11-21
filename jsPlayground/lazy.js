export function $one(selector) {
    return document.querySelector(selector);
}

/**
 * This is a "JSDoc". It's just a standard comment, but
 * code editors treat it special and use it to help add
 * type "hints" to:
 * 
 * parameters: @param {datatype} name description
 * return types: @returns {datatype} description
 * variables: @type {datatype}
 * 
 * https://jsdoc.app/
 * 
 * But it is STILL not strongly typed. Just a "well
 * I ASSUME the type should be this".
 */

/**
 * Returns a list of elements that are identified using
 * a single CSS selector.
 * 
 * @param {string} selector
 *      The CSS selector to find
 * @returns {NodeListOf<Element>}
 */
export function $all(selector) {
    return document.querySelectorAll(selector);
}

/** Converts a text into a HTML element.
 * @param {string} innerHTML The text that'll be converted.
 * @returns The converted HTML element.
 */
export function ConvertToHTMLElement(innerHTML) {
    const TEMPORARY_DIV = document.createElement("div");
    TEMPORARY_DIV.innerHTML = innerHTML;
    return TEMPORARY_DIV.children[0];
}

/** Creates a new element and added into a parent element.
* @param {String} type The type of the element that'll be created.
* @param {HTMLElement} parent The parent element that contains the element.
* @param {Number} tabIndex The index of which the element can be tabbed onto.
* @param {String | Array<String>} classList The class name of the element, or the class list of it.
* @param {String} id The identifier of the element.
* @returns The element after being created.
*/
export function CreateElement(type, parent, tabIndex = -1, classList = [], id = null) {
    let element = document.createElement(type);

    parent.append(element);

    if (tabIndex >= 0) { element.tabIndex = tabIndex; }

    if (typeof (classList) == "string") { element.className = classList; }
    else { classList.forEach(className => element.classList.add(className)); }

    if (id != null) { element.id = id; }

    return element;
}
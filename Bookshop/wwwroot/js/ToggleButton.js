import { ConvertToHTMLElement } from "/js/main.global.js";

const TOGGLE_BUTTON_ELEMENT = ConvertToHTMLElement(`
    <div class="toggle-button-wrapper">
        <label></label>
        <button class="toggle-button" type="button">
            <input type="checkbox" />
            <div></div>
        </button>
    </div>
`);

/**
 * @param {HTMLElement} toggleButton 
 * @param {(e: MouseEvent) => void} onClick 
 */
function SetUpToggleButtonEvents(toggleButton, onClick) {
    const
        BUTTON_ELEMENT = toggleButton.querySelector("button"),
        CHECKBOX_ELEMENT = toggleButton.querySelector("input");

    BUTTON_ELEMENT.addEventListener("click", e => {
        CHECKBOX_ELEMENT.checked = !CHECKBOX_ELEMENT.checked;
        onClick?.(e);
    });
}

/** 
 * @param {string} text
 * @param {string | Array<string>} className 
 * @param {string} id 
 * @param {(e: MouseEvent) => void} onClick 
 */
export default function ToggleButton(text, className, id, onClick) {
    const TOGGLE_BUTTON_ELEMENT_COPY = TOGGLE_BUTTON_ELEMENT.cloneNode(true);

    const
        BUTTON_ELEMENT = TOGGLE_BUTTON_ELEMENT_COPY.querySelector("button"),
        LABEL_ELEMENT = TOGGLE_BUTTON_ELEMENT_COPY.querySelector("label");

    LABEL_ELEMENT.textContent = text;

    if (typeof (className) == "string") {
        BUTTON_ELEMENT.className += " " + className ?? "";
    } else {
        BUTTON_ELEMENT.classList.add(...className ?? []);
    }

    LABEL_ELEMENT.htmlFor = BUTTON_ELEMENT.id = id ?? "";

    SetUpToggleButtonEvents(TOGGLE_BUTTON_ELEMENT_COPY, onClick);

    return TOGGLE_BUTTON_ELEMENT_COPY;
}
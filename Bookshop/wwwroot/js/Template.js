SetUp();

function SetUp() {
    SetUpHeader();
    SetUpToggleButtons();
}

function SetUpHeader() {
    const
        NAVIGATION_BAR_BUTTON = document.querySelector("#navigation-bar-button"),
        HEADER_ELEMENT = document.querySelector("header");

    NAVIGATION_BAR_BUTTON.addEventListener("click", _ =>
        HEADER_ELEMENT.classList.toggle("navigation-bar-active"));
}

function SetUpToggleButtons() {
    const TOGGLE_BUTTONS = Array.from(document.querySelectorAll(".toggle-button"));
    TOGGLE_BUTTONS.forEach(toggleButton => {
        const CHECKBOX_ELEMENT = toggleButton.querySelector("input[type=checkbox]");

        toggleButton.addEventListener("click", e =>
            CHECKBOX_ELEMENT.checked = !CHECKBOX_ELEMENT.checked);
    });
}
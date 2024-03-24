import { CreateElement } from "/js/main.global.js";
import ToggleButton from "/js/ToggleButton.js";

const FORM = document.querySelector("form");

SetUpShop();

function SetUpGenreOptions() {
    const SELECT_ELEMENT = FORM.querySelector("select");

    GENRES.forEach(genre => {
        const OPTION = CreateElement("option", SELECT_ELEMENT);
        OPTION.textContent = OPTION.value = genre;
    });
}
function validatePhoneInput(e) {
    e.currentTarget.value = "+" + e.currentTarget.value.replace(/[^0-9]/g, "");
}
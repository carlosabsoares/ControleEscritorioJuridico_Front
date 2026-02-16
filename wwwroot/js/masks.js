function maskCep(element) {
    if (!element) return;

    let value = element.value.replace(/\D/g, '');

    if (value.length > 8)
        value = value.substring(0, 8);

    if (value.length > 5)
        value = value.replace(/^(\d{5})(\d)/, '$1-$2');

    element.value = value;
}

window.maskCep = maskCep; // 🔥 GARANTE GLOBAL

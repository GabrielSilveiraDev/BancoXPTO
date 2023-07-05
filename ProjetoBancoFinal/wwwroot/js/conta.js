const select = document.getElementById("tipoChavePix");

const divChaveTexto = document.getElementById("divChavePix");

select.addEventListener("change", () => {

    if (select.options[select.selectedIndex].value == 3 || select.options[select.selectedIndex].value == 0)
        divChaveTexto.style.display = "none";
    else
        divChaveTexto.style.display = "block";
})
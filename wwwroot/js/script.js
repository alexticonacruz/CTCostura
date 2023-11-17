function toggleActivacion(elemento) {
    // Toggle de una clase llamada "activo"
    elemento.classList.toggle("activo");
}

function activarDetalle(elemento) {
    let fotoPadre = elemento.parentNode;
    fotoPadre.classList.toggle("activo");
    elemento.classList.toggle("activo");
}
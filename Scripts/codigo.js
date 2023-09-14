/*
let barraLateral = document.querySelector(".barraLateral");

let btnAbrirMenu = document.querySelector(".btnAbrirMenu");

btnAbrirMenu.addEventListener("click", ()=>{
    barraLateral.classList.toggle("traslacion");
})
*/

let comboBox = [];
comboBox = document.querySelectorAll(".mensaje__combobox-contenedor");

for (let i = 0; i < comboBox.length; i++) {
    let elemento = comboBox[i];
    elemento.addEventListener("click", function () {
        let opciones = elemento.nextElementSibling;

        if (!elemento.classList.contains("mensaje__combobox-disabled")) {
            if (opciones.style.display == "block") {
                opciones.style.display = "none";
                setTimeout(() => {
                    opciones.style.opacity = "0";
                }, 100);
            }

            else {
                opciones.style.display = "block";
                setTimeout(() => {
                    opciones.style.opacity = "1";
                }, 100);
            }
        }
    })
}

// ! Cerrar el comboBox cuando se haga click fuera de él

document.addEventListener("mousedown", (event) => {
    for (let i = 0; i < comboBox.length; i++) {

        if (!comboBox[i].contains(event.target) && !comboBox[i].nextElementSibling.contains(event.target)) {
            let opciones = comboBox[i].nextElementSibling;
            opciones.style.display = "none";
            setTimeout(() => {
                opciones.style.opacity = "0";
            }, 100);
        }
    }
});

// ! Escribir la opcion en el comboBox
let opciones = [];
opciones = document.querySelectorAll(".mensaje__combobox-opcion");

for (let i = 0; i < opciones.length; i++) {
    let opcion = opciones[i];
    opcion.addEventListener("click", function () {

        let texto = opcion.innerHTML;
        let input = opcion.parentNode.previousElementSibling.querySelector(".mensaje__combobox-input");
        let contenedor = opcion.parentNode;

        input.value = texto;

        contenedor.style.display = "none";
        setTimeout(() => {
            contenedor.style.opacity = "0";
        }, 100);
    })
}


// ! cerrar la ventana

let btnCerrar = [];
btnCerrar = document.querySelectorAll(".mensaje__cerrar");

for (let i = 0; i < btnCerrar.length; i++) {
    let boton = btnCerrar[i];
    boton.addEventListener("click", function () {

        let ventana = boton.parentNode.parentNode.parentNode;

        ventana.style.opacity = "0";
        ventana.style.transition = "0.3s";

        setTimeout(() => {
            ventana.style.display = "none";
        }, 100);

    })
}


// ! 

let ventanaNuevo = document.querySelector(".mensaje-nuevo")

function abrirVentanaNuevo() {

    ventanaNuevo.style.display = "flex";

    setTimeout(() => {
        ventanaNuevo.style.opacity = "1";
    }, 100);
}


// ! 

let ventanaVerTarea = document.querySelector(".mensaje-verTarea")

function abrirVentanaVerTarea() {

    ventanaVerTarea.style.display = "flex";

    setTimeout(() => {
        ventanaVerTarea.style.opacity = "1";
    }, 100);
}
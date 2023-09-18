

// ! ABRIR EL COMBOBOX

let comboBox = [];
comboBox = document.querySelectorAll(".mensaje__combobox-contenedor");

let opciones = [];
opciones = document.querySelectorAll(".mensaje__combobox-opcion");



function abrirLosComboBox() {
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
}

abrirLosComboBox();



// ! Cerrar el comboBox cuando se haga click fuera de él

function cerrarLosComboBox() {
    comboBox = document.querySelectorAll(".mensaje__combobox-contenedor");

    document.addEventListener("mousedown", (event) => {
        for (let i = 0; i < comboBox.length; i++) {

            try {
                if (!comboBox[i].contains(event.target) && !comboBox[i].nextElementSibling.contains(event.target)) {
                    let opciones = comboBox[i].nextElementSibling;
                    opciones.style.display = "none";
                    setTimeout(() => {
                        opciones.style.opacity = "0";
                    }, 100);
                }
            } catch (error) {
                // 
            }
        }
    });
}

cerrarLosComboBox();



// ! Escribir la opcion en el comboBox

function escribirLosComboBox() {
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
}

escribirLosComboBox();



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


// ! ABRIR VENTANA NUEVO

let ventanaNuevo = document.querySelector(".mensaje-nuevo")

function abrirVentanaNuevo() {

    ventanaNuevo.style.display = "flex";

    setTimeout(() => {
        ventanaNuevo.style.opacity = "1";
    }, 100);
}


// ! ABRIR VENTANA VER

let ventanaVer = document.querySelector(".mensaje-ver")

function abrirVentanaVer() {

    ventanaVer.style.display = "flex";

    setTimeout(() => {
        ventanaVer.style.opacity = "1";
    }, 100);
}



// ! ABRIR VENTANA DE EDITAR 

let ventanaEditar = document.querySelector(".mensaje-editar")

function abrirVentanaEditar() {

    ventanaEditar.style.display = "flex";

    setTimeout(() => {
        ventanaEditar.style.opacity = "1";
    }, 100);
}



// ! ABRIR VENTANA DE ELIMINAR 

let ventanaEliminar = document.querySelector(".mensaje-eliminar")

function abrirVentanaEliminar() {

    ventanaEliminar.style.display = "flex";

    setTimeout(() => {
        ventanaEliminar.style.opacity = "1";
    }, 100);
}





// ! BUSCADOR

let buscador = [];
buscador = document.querySelectorAll(".buscador");

function añadirLosBuscadores() {
    buscador = document.querySelectorAll(".buscador");

    for (i = 0; i < buscador.length; i++) {
        let input = buscador[i];
        input.addEventListener("keyup", (e) => {
            let lista = input.parentNode.nextElementSibling;
            //let encontrado = false;
            let texto = input.value.toUpperCase();

            for (i = 0; i < lista.children.length; i++) {
                if (lista.children[i].innerHTML.toUpperCase().includes(texto)) {
                    lista.children[i].style.display = "inline-block";
                    //encontrado = true;
                } else {
                    lista.children[i].style.display = "none";
                }
            }

            /*
            if(!encontrado) {
                lista.children[lista.children.length-1].style.display = "flex";
            } else {
                lista.children[lista.children.length-1].style.display = "none";
            }
            */
        });
    }
}

añadirLosBuscadores();


// ! ELIMINAR DESARROLLADOR

function eliminarCampo(boton) {
    let multicampos = boton.parentNode.parentNode;

    if (multicampos.childElementCount > 1) {
        let campo = boton.parentNode;

        multicampos.removeChild(campo);
    }
}

// ! AGREGAR DESARROLLADOR

function añadirCampo(boton) {
    let multicampos = boton.previousElementSibling;

    let name = multicampos.querySelector(".mensaje__combobox-input").getAttribute("name");

    let campo = `
        <div class="multicampos__campo">
            <div class="mensaje__combobox">
                <div class="mensaje__input mensaje__combobox-contenedor" >
                    <input type="text" class="mensaje__combobox-input buscador" placeholder="Escribe ..." name="${name}">
                </div>
            </div>
            <div class="multicampos__icono" onclick="eliminarCampo(this)">
                <i class="fa-solid fa-trash-can"></i>
            </div>
        </div>
    `;

    multicampos.insertAdjacentHTML('beforeend', campo);

}


// ! AGREGAR DESARROLLADOR Y BUSCADOR

function añadirCampoYBuscador(boton) {
    let multicampos = boton.previousElementSibling;

    let opciones = multicampos.querySelector(".mensaje__combobox-opciones");

    let name = multicampos.querySelector(".mensaje__combobox-input").getAttribute("name");

    let campo = `
        <div class="multicampos__campo">
            <div class="mensaje__combobox">
                <div class="mensaje__input mensaje__combobox-contenedor" >
                    <input type="text" class="mensaje__combobox-input buscador" placeholder="-- Selecciona --" name="${name}">
                </div>
                <div class="mensaje__combobox-opciones">
                    ${opciones.innerHTML}
                </div>
            </div>
            <div class="multicampos__icono" onclick="eliminarCampo(this)">
                <i class="fa-solid fa-trash-can"></i>
            </div>
        </div>
    `;

    for (i = 0; i < opciones.children.length; i++) {
        opciones.children[i].style.display = "inline-block";
    }

    console.log(opciones)

    multicampos.insertAdjacentHTML('beforeend', campo);

    abrirLosComboBox();
    cerrarLosComboBox();
    añadirLosBuscadores();
    escribirLosComboBox();
    añadirLosBuscadores();

}




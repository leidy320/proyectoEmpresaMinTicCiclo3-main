function actualizar_form(){

    let select = document.querySelector("#selectFiltro").selectedIndex;
    let input = document.querySelector("#inputFiltro");
    let button = document.querySelector("#botonFiltro");

    if(select === 0){

        input.disabled = true;
        input.value = "";
    } else {

        input.disabled = false;
    }
}

function onLoad(){

    actualizar_form();
}
//URL de la API
const API_URL = "http://localhost:5014/Api/Torneo";


//Si la URL contiene un id de torneo, lo traigo
document.addEventListener("DOMContentLoaded", async () => {
    const urlParams = new URLSearchParams(window.location.search);
    var torneoId = urlParams.get('id');
    console.log(torneoId);

    if (torneoId) {

        htmlModoEditar();
        try{
            const response = await fetch(`${API_URL}/Torneo/${torneoId}`);
            if (!response.ok) {
                throw new Error('Error en la BD' + response.statusText);
            }

            const torneo = await response.json();

            cargarTorneoEnFormulario(torneo);
        }
        catch (error) {
            console.error("Error en operación fetch: ", error);
            alert("Hubo un problema al cargar el torneo. Inténtalo más tarde.");
        }

    }else{
        torneoId = 0;
    }

    const form = document.getElementById("altaTorneoForm");

    form.addEventListener("submit", async(event) => {
        event.preventDefault();

        const name = document.getElementById("nombreTorneo").value;
        const fechaInicio = document.getElementById("fechaInicio").value;
        const fechaFin = document.getElementById("fechaFin").value;

        let isValid = true;

        if (name === "") {
            alert("Es obligatorio ingresar nombre");
            isValid = false;
        }

        const today = new Date();
        const beginDate = new Date(fechaInicio);
        const endDate = new Date(fechaFin);

        if (torneoId === 0 && (fechaInicio === "" || beginDate <= today)) {
            alert("El torneo debe empezar en el futuro.");
            isValid = false;
        }

        if (torneoId === 0 && (fechaFin === "" || beginDate >= endDate)) {
            alert("La fecha de fin debe ser posterior a la fecha de inicio.");
            isValid = false;
        }

        if (!isValid) return;


        try {
            const response = await fetch('http://localhost:5014/Api/Torneo/Crear', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({
                    idTorneo: torneoId,
                    nombre: document.getElementById('nombreTorneo').value,
                    fechaInicio: document.getElementById('fechaInicio').value,
                    fechaFin: document.getElementById('fechaFin').value
                })
            });
            

            if (response.ok) {
                alert("Operación exitosa!");
                form.reset();
               fetchTorneos();
               
            } else {
                alert("Error, intente nuevamente en un momento.");
            }
        } catch (error) {
            console.error("Error:", error);
            alert("Ocurrió un error al intentar guardar el torneo");
        }
        
    });
});

function htmlModoEditar() {
    document.getElementById("tituloForm").textContent = "Editar Torneo";
    document.getElementById("btnCancelar").classList.toggle("d-none", false);
}

function cargarTorneoEnFormulario(torneo) {
    document.getElementById("nombreTorneo").value = torneo.nombre;
    document.getElementById("fechaInicio").value = torneo.fechaInicio.substring(0, 10);
    document.getElementById("fechaFin").value = torneo.fechaFin.substring(0, 10);
}


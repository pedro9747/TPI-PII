function borrarTorneo(boton) {
    // Obtiene el id_torneo desde el atributo data-id del botón
    const idTorneo = boton.getAttribute("data-id");
    console.log("ID del torneo a borrar:", idTorneo); // Depuración

    // Muestra una alerta de confirmación
    const confirmacion = confirm("¿Estás seguro de que deseas borrar este torneo?");
    if (!confirmacion) {
        return; // Si el usuario cancela, no hace nada
    }

    // Llama a la API para borrar el torneo con el id correspondiente
    fetch(`http://localhost:5014/Api/Torneo/Eliminar/${idTorneo}`, {
        method: "DELETE",
    })
    .then(response => {
        if (response.ok) {
            alert("Torneo borrado con éxito");
            // Opcional: Elimina la fila de la tabla si la respuesta es exitosa
            boton.closest("tr").remove();
        } else {
            alert("Hubo un error al intentar borrar el torneo");
        }
    })
    .catch(error => console.error("Error:", error));
}

// Asumiendo que el botón tiene un id 'botonEditar'
document.getElementById('botonBorrr').addEventListener('click', function() {
    borrarTorneo(this);
});

document.addEventListener("DOMContentLoaded", function() {
    const posicionesTableBody = document.getElementById("posicionesTableBody");


    function fetchPosiciones() {
        fetch("http://localhost:5014/Api/Torneo/Posiciones", {
            method: 'GET',
            headers: {
                'Accept': '*/*'
            }
        })
        .then(response => {
            if (!response.ok) {
                throw new Error('Error en la red: ' + response.statusText);
            }
            return response.json();
        })
        .then(data => {
            // Limpiar el contenido existente
            posicionesTableBody.innerHTML = '';


            // Verificar si hay resultados
            if (data.length === 0) {
                posicionesTableBody.innerHTML = '<tr><td colspan="7" class="text-center">No se encontraron resultados.</td></tr>';
                return;
            }


            // Llenar la tabla con los datos de las posiciones
            data.forEach(posicion => {
                const row = document.createElement("tr");
                row.innerHTML = `
                    <th scope="row">${posicion.equipo}</th>
                    <td>${posicion.partidosJugados}</td>
                    <td>${posicion.partidosGanados}</td>
                    <td>${posicion.partidosEmpatados}</td>
                    <td>${posicion.partidosPerdidos}</td>
                    <td>${posicion.diferenciaGoles}</td>
                    <td>${posicion.puntos}</td>
                `;
                posicionesTableBody.appendChild(row);
            });
        })
        .catch(error => {
            console.error('Error al obtener posiciones:', error);
            posicionesTableBody.innerHTML = '<tr><td colspan="7" class="text-center">Error al cargar posiciones.</td></tr>';
        });
    }


    // Llamar a la función para obtener y mostrar las posiciones
    fetchPosiciones();
});



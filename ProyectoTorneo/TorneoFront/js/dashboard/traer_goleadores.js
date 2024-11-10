document.addEventListener("DOMContentLoaded", function () {
    fetchGoleadores();
});

function fetchGoleadores() {
    fetch('http://localhost:5014/Api/Torneo/Goleadores')
        .then(response => response.json())
        .then(data => {
            const goleadoresTableBody = document.getElementById("goleadoresTableBody");
            goleadoresTableBody.innerHTML = ""; // Limpia la tabla antes de agregar nuevos datos

            data.forEach(goleador => {
                const row = document.createElement("tr");

                row.innerHTML = `
                    <td>${goleador.jugador}</td>
                    <td>${goleador.equipo}</td>
                    <td>${goleador.golesMarcados}</td>
                `;

                goleadoresTableBody.appendChild(row);
            });
        })
        .catch(error => console.error("Error al obtener los goleadores:", error));
}

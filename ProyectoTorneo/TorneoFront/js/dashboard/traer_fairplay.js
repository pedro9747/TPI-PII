document.addEventListener("DOMContentLoaded", function () {
    fetchFairPlay();
});

function fetchFairPlay() {
    fetch('http://localhost:5014/Api/Torneo/GetFairPlay')
        .then(response => response.json())
        .then(data => {
            const fairplayTableBody = document.getElementById("fairplayTableBody");
            fairplayTableBody.innerHTML = ""; // Limpia la tabla antes de agregar nuevos datos

            data.forEach(fairplay => {
                const row = document.createElement("tr");

                row.innerHTML = `
                    <td>${fairplay.nombreEquipo}</td>
                    <td>${fairplay.totalTarjetasAmarillas}</td>
                    <td>${fairplay.totalTarjetasRojas}</td>
                    <td>${fairplay.totalTarjetas}</td>
                    <td>${fairplay.puntaje}</td>
                `;

                fairplayTableBody.appendChild(row);
            });
        })
        .catch(error => console.error("Error al obtener los datos de Fair Play:", error));
}

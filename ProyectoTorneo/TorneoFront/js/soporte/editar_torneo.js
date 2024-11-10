// const urlParams = new URLSearchParams(window.location.search);
// const tournamentId = urlParams.get('id');
// console.log('Tournament ID:', tournamentId);


// async function cargarDatosTorneo(id) {
//     try {
//         const response = await fetch(`http://localhost:5014/Api/Torneo/Torneo/${id}`);
//         if (!response.ok) {
//             throw new Error('Error en la BD: ' + response.statusText);
//         }
//         const torneo = await response.json();
//         console.log(torneo);

//         // Llenar los campos del formulario con los datos del torneo
//         document.getElementById('nombreTorneo').value = torneo.nombre;
//         document.getElementById('desde').value = torneo.fechaInicio.substring(0, 10);
//         document.getElementById('hasta').value = torneo.fechaFin.substring(0, 10);
//     } catch (error) {
//         console.error('Error en operación fetch: ', error);
//         alert("Hubo un problema al cargar los datos del torneo. Inténtalo más tarde.");
//     }
// }

// // Al cargar el documento, cargamos los datos del torneo
// document.addEventListener('DOMContentLoaded', () => {
//     if (tournamentId) {
//         cargarDatosTorneo(tournamentId);
//     }

//     // Asignar la función al botón Aceptar
//     document.getElementById('altaTorneoForm').addEventListener('submit', function(event) {
//         event.preventDefault(); // Prevenir el envío del formulario
//         actualizarTorneo(); // Llama a la función de actualización
//     });
// });

// // Función para actualizar el torneo
// async function actualizarTorneo() {
//     const id = tournamentId; // ID del torneo a editar
//     const nombre = document.getElementById('nombreTorneo').value;
//     const fechaInicio = document.getElementById('fechaInicio').value;
//     const fechaFin = document.getElementById('fechaFin').value;

//     console.log({
//         IdTorneo: id,
//         nombre: nombre,
//         fechaInicio: fechaInicio,
//         fechaFin: fechaFin
//     });

//     try {
//         const response = await fetch(`http://localhost:5014/Api/Torneo/Editar`, {
//             method: 'PUT',
//             headers: {
//                 'Content-Type': 'application/json'
//             },
//             body: JSON.stringify({
//                 IdTorneo: id,
//                 nombre: nombre,
//                 fechaInicio: fechaInicio,
//                 fechaFin: fechaFin
//             })
//         });

//         if (!response.ok) {
//             throw new Error('Error en la BD: ' + response.statusText);
//         }

//         console.log('Torneo actualizado:', { id, nombre, fechaInicio, fechaFin });

//         alert('Torneo actualizado con éxito');
//         window.location.href = 'index.html'; // Redirige después de actualizar
//     } catch (error) {
//         console.error('Error en operación fetch: ', error);
//         alert("Hubo un problema al actualizar el torneo. Inténtalo más tarde.");
//     }
// }


   
// async function actualizarTorneo(idTorneo) {
//     console.log('ID del torneo:', idTorneo); // Verifica el ID
//     if (!idTorneo) {
//         console.error("El ID del torneo no es válido.");
//         return;
//     }
//     try {
//         const response = await fetch(`http://localhost:5014/Api/Torneo/Torneo/${idTorneo}`);
//         if (!response.ok) {
//             throw new Error('Error al obtener el torneo: ' + response.statusText);
//         }
//         const torneo = await response.json();

//         // Llenar el formulario con los datos del torneo
//         document.getElementById('nombreTorneo').value = torneo.nombre;
//         document.getElementById('fechaInicio').value = torneo.fechaInicio.substring(0, 10);
//         document.getElementById('fechaFin').value = torneo.fechaFin.substring(0, 10);

//         document.getElementById('btnEnviar').className = 'btn btn-primary disabled';
//         document.getElementById('btnGuardar').className = 'btn btn-primary';

//         // Cambiar el botón de enviar para que actualice el torneo
//         const form = document.getElementById('updateTorneoForm');

//         form.onsubmit = async function(event) {
//             event.preventDefault();

//             const updatedTorneo = {
//                 idTorneo: idTorneo, // Asegúrate de que el objeto incluya el ID
//                 nombre: document.getElementById('nombreTorneo').value,
//                 fechaInicio: document.getElementById('fechaInicio').value,
//                 fechaFin: document.getElementById('fechaFin').value,
//             };

//             const putResponse = await fetch('http://localhost:5014/Api/Torneo/Editar', {
//                 method: 'PUT',
//                 headers: {
//                     'Content-Type': 'application/json'
//                 },
//                 body: JSON.stringify(updatedTorneo)
//             });

//             if (!putResponse.ok) {
//                 throw new Error('Error al actualizar el torneo: ' + putResponse.statusText);
//             }

//             alert('Torneo actualizado con éxito');
//             window.location.href = 'index.html'; // Redirige después de actualizar
//         };

       

//     } catch (error) {
//         console.error('Error en operación fetch: ', error);
//         alert("Hubo un problema al cargar los datos del torneo. Inténtalo más tarde.");
//     }
// }

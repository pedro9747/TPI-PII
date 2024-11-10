// ! funcion pr traer un jugador by id y mndarlo al formulario
async function editarJugador(jugadorId) {
    console.log('Editar jugador con id:', jugadorId);
    document.getElementById('jugadorForm').style.opacity = 1;
    document.querySelectorAll(' #nombreJugador, #apellidoJugador, #dniJugador, #flexRadioDefault1, #flexRadioDefault2, #fechaNacimientoJugador, #posicionJugador, #rolJugador').forEach(element => {
        element.disabled = false;
    });

    const token = localStorage.getItem("jwtToken");
    try {
        const response = await fetch(`http://localhost:5014/Api/Jugador/Jugador/${jugadorId}`, {
            method: 'GET',
            headers: {
                "Authorization": `Bearer ${token}`,
                    }
        });
        
        if (!response.ok) {
            throw new Error('No autorizado o token expirado');
        }
        const jugador = await response.json();
        console.log('Jugador:', jugador);
        cargarJugadorEnFormulario(jugador); 
    } catch (error) {
        console.error('Error al cargar los datos del jugador:', error);
    }
}

// ! funcion para remplazar al jugador editado en l tbla pra no mandrlo en el json dos veces

function actualizarJugadorEnTabla(jugador) {
    const rows = document.querySelectorAll('#jugadoresTableBody tr');  // Esto obtiene las filas de la tabla
    Array.from(rows).some(row => {
        const cells = row.querySelectorAll('td');
        const idJugador = parseInt(cells[0].textContent.trim(), 10);  // Convertir a número
       
        if ( idJugador === parseInt(jugador.id, 10)) {
          
            const celdas = row.querySelectorAll('td');
            celdas[1].textContent = jugador.nombre;
            celdas[2].textContent = jugador.apellido;
            celdas[3].textContent = jugador.dni;
            celdas[4].textContent = jugador.fichaMedica ? 'Sí' : 'No';
            celdas[5].textContent = jugador.fechaNacimiento.substring(0, 10);
            switch (jugador.idPosicion) {
                case 1:
                    celdas[6].textContent = 'Arquero';
                    break;
                case 2:
                    celdas[6].textContent = 'Defensa';
                    break;
                case 3:
                    celdas[6].textContent = 'Centrocampista';
                    break;
                case 4:
                    celdas[6].textContent = 'Delantero';
                    break;
                default:
                    celdas[6].textContent = '-';
                    break;
            }
            celdas[7].textContent = jugador.rol; 
            switch (jugador.rol) {
                case 1:
                    celdas[7].textContent = 'Capitán';
                    break;
                case 2:
                    celdas[7].textContent = 'Subcapitán';
                    break;
                case 3:
                    celdas[7].textContent = 'Delegado';
                    break;
                default:
                    celdas[7].textContent = '-';
                    break;
            }
            
            
        }
        
    });
}


// Función que puedes usar para agregar un jugador si no está en la tabla
function agregarJugadorATabla(jugador) {
    const nuevaFila = `<tr>
        <td style="display: none;">${jugador.idJugador}</td>
        <td>${jugador.nombre || ''}</td>
        <td>${jugador.apellido || ''}</td>
        <td>${jugador.dni || 123 }</td>
        <td>${jugador.fichaMedica ? 'Sí' : 'No'}</td>
        <td>${jugador.fechaNacimiento}</td>
        <td>${(() => {
            switch (jugador.idPosicion) {
                case 1:
                    return 'Arquero';
                case 2:
                    return 'Defensa';
                case 3:
                    return 'Centrocampista';
                case 4:
                    return 'Delantero';
                default:
                    return '-';
            }
        })()}</td>
        <td>${(() => {
            switch (jugador.rol) {
                case 1:
                    return 'Capitán';
                case 2:
                    return 'Subcapitán';
                case 3:
                    return 'Delegado';
                default:
                    return '-';
            }
        })()}</td>
        <td><div class="btn-group btn-group-sm" role="group" aria-label="Basic mixed styles example">
            <button type="button" class="btn btn-primary" onclick="editarJugador(${jugador.idJugador})">
                <i class="bi bi-pencil"></i>
            </button>
            <button type="button" class="btn btn-danger" onclick="removePlayer(this)">
                <i class="bi bi-trash"></i>
            </button></div>
        </td>
    </tr>`;
    document.getElementById('jugadoresTableBody').insertAdjacentHTML('beforeend', nuevaFila);
}







// ! Cargar los datos del jugador en el formulario
function cargarJugadorEnFormulario(jugador) {
    document.getElementById('idJugador').value = jugador.idJugador;
    document.getElementById('nombreJugador').value = jugador.nombre;
    document.getElementById('apellidoJugador').value = jugador.apellido;
    document.getElementById('fechaNacimientoJugador').value = jugador.fechaNacimiento.substring(0, 10);
    switch (jugador.idPosicion) {
        case 1:
            document.getElementById('posicionJugador').value = 1;
            break;
        case 2:
            document.getElementById('posicionJugador').value = 2;
            break;
        case 3:
            document.getElementById('posicionJugador').value = 3;
            break;
        case 4:
            document.getElementById('posicionJugador').value = 4;
            break;
    }
    document.getElementById('dniJugador').value = jugador.dni;
    document.getElementById('flexRadioDefault1').checked = jugador.fichaMedica == true;
    document.getElementById('flexRadioDefault2').checked = jugador.fichaMedica == false;
    
    switch (jugador.rol) {
        case 1:
            document.getElementById('rolJugador').value = 1;
            break;
        case 2:
            document.getElementById('rolJugador').value = 2;
            break;
        case 3:
            document.getElementById('rolJugador').value = 3;
            break;
        default:
            document.getElementById('rolJugador').value = '-';
            break;
    }

}

// ! prepara la pagina de edicion de jugador
function modificacionesEditarHtml(){

    // ? CAMBIAR EN EL HTML SI ESTOY EDITANDO?
    document.getElementById('tituloCargarEditar').textContent = 'Editar equipo';
    document.getElementById('verEquiposVolver').textContent = 'Volver a equipos';
    document.getElementById('JugadoresTituloForm').textContent = 'Nuevo Jugador';
    document.getElementById('guardarEquipoBtn').textContent = 'Editar Equipo';

    document.getElementById('idJugador').style.opacity = 0.5;
}
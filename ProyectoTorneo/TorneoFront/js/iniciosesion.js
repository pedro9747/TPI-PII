



async function login() {
  const username = document.getElementById("username").value;
  const password = document.getElementById("password").value;

  try {
    const response = await fetch("http://localhost:5014/api/Auth/login", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({ NombreUsuario: username, Contraseña: password }),
    });

    if (response.ok) {
      const data = await response.json();
      
      const token = data.token;

      if (token) {
        localStorage.setItem("jwtToken", token);
        alert("Inicio de sesión exitoso");

        actualizarEstadoBoton();
      } else {
        console.error("El token no está presente en la respuesta");
      }
    } else {
      alert("Credenciales incorrectas");
    }
  } catch (error) {
    console.error("Error en la solicitud:", error);
  }
}

function logout() {
  localStorage.removeItem("jwtToken");
  alert("Sesión cerrada");
  actualizarEstadoBoton();
}

function actualizarEstadoBoton() {
  const token = localStorage.getItem("jwtToken");
  const boton = document.getElementById("miBoton");
  const dropdown = new bootstrap.Dropdown(boton);
  dropdown.hide();

  if (token) {
    boton.textContent = "Cerrar sesión";
    boton.onclick = logout;
  } else {
    boton.textContent = "Iniciar sesión";
  }
}


async function registrar(event) {
  // event.preventDefault(); // Evita el comportamiento por defecto del formulario

  const username = document.getElementById("usernameRegister").value;
  const password = document.getElementById("passwordRegister").value;
  const role = document.getElementById("role").value;

  try {
    const response = await fetch("http://localhost:5014/api/Auth/register", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({ nombreUsuario: username, contraseña: password, rolId: role }),
    });

    if (response.ok) {
      const data = await response.json();
      
      if (data) {
        // Cerrar el modal correctamente
        const modalElement = document.getElementById("registroModal");
        const modal = bootstrap.Modal.getInstance(modalElement) || new bootstrap.Modal(modalElement);
        modal.hide();

        // Resetear el formulario y mostrar mensaje de éxito
        // document.getElementById("formRegistro").reset();
        alert(data.message); // Muestra el mensaje de éxito devuelto por el backend
      } else {
        console.error("No se pudo completar el registro");
      }
    } else {
      const errorText = await response.text();
      alert("Error en el registro: " + errorText); // Muestra el mensaje de error devuelto por el backend
    }
  } catch (error) {
    console.error("Error en la solicitud:", error);
    alert("Ocurrió un error en la conexión. Por favor, revisa tu conexión y vuelve a intentarlo.");
  }
}

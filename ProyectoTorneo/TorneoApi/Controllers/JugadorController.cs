using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TorneoBack.Service.Contracts;

namespace TorneoApi.Controllers
{
    //[Authorize] c le digo que este controlador requiere utorizcion, lo dejo inhabilitado para que no les de error

    [ApiController]
    [Route("Api/[controller]")]
    public class JugadorController : Controller
    {
        private readonly ITorneoService _servicio;

        public JugadorController(ITorneoService servicio)
        {
            _servicio = servicio;
        }

        [HttpGet("Jugador/{id}")]
        public IActionResult GetJugadorById(int id)
        {
            try
            {
                var jugador = _servicio.GetJugadorById(id);
                if (jugador == null)
                {
                    return NotFound($"El jugador con ID '{id}' no fue encontrado.");
                }

                return Ok(jugador);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }



    }
}

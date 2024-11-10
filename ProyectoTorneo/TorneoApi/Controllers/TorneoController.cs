using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TorneoApi.Models;
using TorneoBack.Service;
using TorneoBack.Service.Contracts;

namespace TorneoApi.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class TorneoController : Controller
    {
        private readonly ITorneoService _servicio;

        public TorneoController(ITorneoService servicio)
        {
            _servicio = servicio;
        }

        
        [HttpPost("Crear")]
        public IActionResult CreateTorneo([FromBody] Torneo torneo)
        {
            try
            {
                if (torneo.FechaInicio > torneo.FechaFin)
                {
                    return BadRequest("La fecha de inicio no puede ser posterior a la fecha de finalización.");
                }

                bool torneoCreado = _servicio.AddTorneo(torneo);

                if (!torneoCreado)
                {
                    return BadRequest($"No se pudo crear el torneo '{torneo.Nombre}'. Verifique los datos e intente nuevamente.");
                }

                return Ok(new { mensaje = "Torneo creado exitosamente.", torneo });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
        [HttpGet("Posiciones")]
        public IActionResult GetPosiciones()
        {
            try
            {
                var torneos = _servicio.GetAllPosiciones();
                if (torneos.Count == 0)
                {
                    return NotFound("No se encontraron resultados.");
                }

                return Ok(torneos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("Goleadores")]
        public IActionResult GetGoleadores()
        {
            try
            {
                var goleadores = _servicio.GetAllGoleadores();
                if (goleadores.Count == 0)
                {
                    return NotFound("No se encontraron resultados.");
                }

                return Ok(goleadores);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("GetFairPlay")]
        public IActionResult GetFairPlay()
        {
            try
            {
                var equipos = _servicio.GetAllFairPlay();
                if (equipos.Count == 0)
                {
                    return NotFound("No se encontraron resultados.");
                }

                return Ok(equipos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("Torneos")]

        public IActionResult GetTorneos()
        {
            try
            {
                var torneos = _servicio.GetAllTorneos();
                if (torneos.Count == 0)
                {
                    return NotFound("No se encontraron torneos.");
                }

                return Ok(torneos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpDelete("Eliminar/{id}")]
        public IActionResult DeleteTorneo(int id){
            try
            {
                var existTorneo = _servicio.getTorneoById(id);
                if (existTorneo == null)
                {
                    return NotFound($"El torneo con ID '{id}' no fue encontrado.");
                }

                bool torneoEliminado = _servicio.DeleteTorneo(id);

                if (!torneoEliminado)
                {
                    return BadRequest($"No se pudo eliminar el torneo con ID '{id}'. Verifique los datos e intente nuevamente.");
                }

                return Ok(new { mensaje = "Torneo eliminado exitosamente.", torneo = existTorneo });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("Torneo/{id}")]
        public IActionResult GetTorneoById(int id)
        {
            try
            {
                var torneo = _servicio.getTorneoById(id);
                if (torneo == null)
                {
                    return NotFound($"El torneo con ID '{id}' no fue encontrado.");
                }

                return Ok(torneo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }


        [HttpPut("Editar")]
        public IActionResult UpdateTorneo([FromBody]Torneo torneo)
        {
           try
           {
               if (torneo.FechaInicio > torneo.FechaFin)
               {
                   return BadRequest("La fecha de inicio no puede ser posterior a la fecha de finalización.");
               }

               bool torneoActualizado = _servicio.UpdateTorneo(torneo);

               if (!torneoActualizado)
               {
                   return BadRequest($"No se pudo actualizar el torneo '{torneo.Nombre}'. Verifique los datos e intente nuevamente.");
               }

               return Ok(new { mensaje = "Torneo actualizado exitosamente.", torneo });
           }
           catch (Exception ex)
           {
               return StatusCode(500, $"Error interno del servidor: {ex.Message}");
           }
        }



    }
}

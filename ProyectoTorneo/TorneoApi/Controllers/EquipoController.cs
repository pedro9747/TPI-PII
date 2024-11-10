using Microsoft.AspNetCore.Mvc;
using TorneoApi.Models;
using TorneoBack.DTOs;
using TorneoBack.Service.Contracts;

namespace TorneoApi.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class EquipoController : Controller
    {
        private readonly ITorneoService _servicio;

        public EquipoController(ITorneoService servicio)
        {
            _servicio = servicio;
        }


        [HttpGet("Equipos")]
        public IActionResult GetEquipos()
        {
            try
            {
                var equipos = _servicio.GetAllEquipos();
                if (equipos.Count == 0)
                {
                    return NotFound("No se encontraron equipos.");
                }

                return Ok(equipos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("Equipo/{id}")]
        public IActionResult GetEquipoById(int id)
        {
            try
            {
                var equipo = _servicio.GetEquipoById(id);
                if (equipo == null)
                {
                    return NotFound($"El equipo con ID '{id}' no fue encontrado.");
                }

                return Ok(equipo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }


        [HttpPost("CrearTransaction")]
        public IActionResult AddEquipo([FromBody] EquipoDto equipoDto)
        {
            try
            {
                
                if (equipoDto.FechaFundacion > DateTime.Now)
                {
                    return BadRequest(new { mensaje = "La fecha de fundación no puede ser posterior a la fecha de hoy." });
                }

                bool eqCreado = _servicio.SaveEquipo(equipoDto);

                if (!eqCreado)
                {
                    return BadRequest($"No se pudo crear el equipo '{equipoDto.Nombre}'. Verifique los datos e intente nuevamente.");
                }

                return Ok(new { mensaje = "Equipo creado exitosamente.", equipo = equipoDto });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpDelete("Eliminar/{id}")]
        public IActionResult DeleteEquipo(int id)
        {
            try
            {
                var existEquip = _servicio.GetEquipoById(id);
                if (existEquip == null)
                {
                    return NotFound($"El equipo con ID '{id}' no fue encontrado.");
                }

                bool equipoEliminado = _servicio.DeleteEquipo(id);

                if (!equipoEliminado)
                {
                    return BadRequest($"No se pudo eliminar el equipo con ID '{id}'. Verifique los datos e intente nuevamente.");
                }

                return Ok(new { mensaje = "Equipo eliminado exitosamente.", Equipo = existEquip });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

    }
}

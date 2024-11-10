using TorneoApi.Models;

namespace TorneoApi.Controllers
{
    public class EquipoConJugadoresDto
    {
        public Equipo Equipo { get; set; }
        public List<Jugador> Jugadores { get; set; }
    }
}
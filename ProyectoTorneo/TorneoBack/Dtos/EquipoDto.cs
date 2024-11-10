using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorneoBack.DTOs
{
    public class EquipoDto
    {
        public int IdEquipo { get; set; }
        public string Nombre { get; set; }
        public DateTime? FechaFundacion { get; set; }
        public List<JugadorDto> Jugadores { get; set; }
        public bool Borrado { get; set; }
    }
}

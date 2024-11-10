using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorneoBack.DTOs
{
    public class JugadorDto
    {
        public int IdJugador { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int? Dni { get; set; } = 1;
        public bool? FichaMedica { get; set; } = true;
        public DateTime? FechaNacimiento { get; set; }
        public int? IdEquipo { get; set; }
        public int? IdPosicion { get; set; } = 1;
        public int? Rol { get; set; } = 1;
        public bool? Borrado { get; set; } = false;
    }
}

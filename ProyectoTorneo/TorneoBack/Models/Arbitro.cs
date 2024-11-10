using System;
using System.Collections.Generic;

namespace TorneoApi.Models;

public partial class Arbitro
{
    public int IdArbitro { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public int? Dni { get; set; }

    public int? IdCiudad { get; set; }

    public virtual ICollection<ContactosArbitro> ContactosArbitros { get; set; } = new List<ContactosArbitro>();

    public virtual Ciudade? IdCiudadNavigation { get; set; }

    public virtual ICollection<Partido> Partidos { get; set; } = new List<Partido>();
}

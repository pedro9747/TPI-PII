using System;
using System.Collections.Generic;

namespace TorneoApi.Models;

public partial class TiposContacto
{
    public int IdTipoContacto { get; set; }

    public string? TipoContacto { get; set; }

    public virtual ICollection<ContactosArbitro> ContactosArbitros { get; set; } = new List<ContactosArbitro>();

    public virtual ICollection<ContactosDirectore> ContactosDirectores { get; set; } = new List<ContactosDirectore>();

    public virtual ICollection<ContactosJugadore> ContactosJugadores { get; set; } = new List<ContactosJugadore>();
}

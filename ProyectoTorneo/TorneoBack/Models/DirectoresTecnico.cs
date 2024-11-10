using System;
using System.Collections.Generic;

namespace TorneoApi.Models;

public partial class DirectoresTecnico
{
    public int IdDirector { get; set; }

    public int? Dni { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    public int? IdCiudad { get; set; }

    public int? IdEquipo { get; set; }

    public virtual ICollection<ContactosDirectore> ContactosDirectores { get; set; } = new List<ContactosDirectore>();

    public virtual Ciudade? IdCiudadNavigation { get; set; }

    public virtual Equipo? IdEquipoNavigation { get; set; }
}

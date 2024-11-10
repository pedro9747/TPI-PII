using System;
using System.Collections.Generic;

namespace TorneoApi.Models;

public partial class Ciudade
{
    public int IdCiudad { get; set; }

    public int? IdProvincia { get; set; }

    public string? Ciudad { get; set; }

    public virtual ICollection<Arbitro> Arbitros { get; set; } = new List<Arbitro>();

    public virtual ICollection<DirectoresTecnico> DirectoresTecnicos { get; set; } = new List<DirectoresTecnico>();

    public virtual ICollection<Equipo> Equipos { get; set; } = new List<Equipo>();

    public virtual Provincia? IdProvinciaNavigation { get; set; }

    public virtual ICollection<Jugador> Jugadores { get; set; } = new List<Jugador>();
}

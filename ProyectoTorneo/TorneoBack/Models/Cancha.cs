using System;
using System.Collections.Generic;

namespace TorneoApi.Models;

public partial class Cancha
{
    public int IdCancha { get; set; }

    public DateTime? FechaUltMant { get; set; }

    public virtual ICollection<Partido> Partidos { get; set; } = new List<Partido>();
}

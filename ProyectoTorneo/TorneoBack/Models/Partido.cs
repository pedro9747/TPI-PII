using System;
using System.Collections.Generic;

namespace TorneoApi.Models;

public partial class Partido
{
    public int IdPartido { get; set; }

    public int? Equipo1 { get; set; }

    public int? Equipo2 { get; set; }

    public DateTime? Fecha { get; set; }

    public int? IdCancha { get; set; }

    public int? IdTorneo { get; set; }

    public int? IdArbitro { get; set; }

    public virtual Equipo? Equipo1Navigation { get; set; }

    public virtual Equipo? Equipo2Navigation { get; set; }

    public virtual ICollection<Evaluacione> Evaluaciones { get; set; } = new List<Evaluacione>();

    public virtual ICollection<Evento> Eventos { get; set; } = new List<Evento>();

    public virtual Arbitro? IdArbitroNavigation { get; set; }

    public virtual Cancha? IdCanchaNavigation { get; set; }

    public virtual Torneo? IdTorneoNavigation { get; set; }
}

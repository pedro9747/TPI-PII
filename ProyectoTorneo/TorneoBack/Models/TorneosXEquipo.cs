using System;
using System.Collections.Generic;

namespace TorneoApi.Models;

public partial class TorneosXEquipo
{
    public int IdTorneoXEquipo { get; set; }

    public int? IdTorneo { get; set; }

    public int? IdEquipo { get; set; }

    public virtual Equipo? IdEquipoNavigation { get; set; }

    public virtual Torneo? IdTorneoNavigation { get; set; }
}

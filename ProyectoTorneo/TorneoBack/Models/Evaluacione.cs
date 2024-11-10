using System;
using System.Collections.Generic;

namespace TorneoApi.Models;

public partial class Evaluacione
{
    public int IdEvaluacion { get; set; }

    public int IdJugador { get; set; }

    public int IdPartido { get; set; }

    public virtual ICollection<DetallesEvaluacion> DetallesEvaluacions { get; set; } = new List<DetallesEvaluacion>();

    public virtual Jugador IdJugadorNavigation { get; set; } = null!;

    public virtual Partido IdPartidoNavigation { get; set; } = null!;
}

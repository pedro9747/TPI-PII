using System;
using System.Collections.Generic;

namespace TorneoApi.Models;

public partial class Evento
{
    public int IdEvento { get; set; }

    public int? TipoEvento { get; set; }

    public int? IdPartido { get; set; }

    public int? IdJugador { get; set; }

    public short? Minuto { get; set; }

    public virtual Jugador? IdJugadorNavigation { get; set; }

    public virtual Partido? IdPartidoNavigation { get; set; }

    public virtual TiposEvento? TipoEventoNavigation { get; set; }
}

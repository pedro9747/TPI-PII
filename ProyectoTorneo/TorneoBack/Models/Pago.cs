using System;
using System.Collections.Generic;

namespace TorneoApi.Models;

public partial class Pago
{
    public int IdPago { get; set; }

    public DateOnly? Fecha { get; set; }

    public int IdFormaPago { get; set; }

    public int? IdJugador { get; set; }

    public int? IdTorneo { get; set; }

    public virtual ICollection<DetallesPago> DetallesPagos { get; set; } = new List<DetallesPago>();

    public virtual FormasPago IdFormaPagoNavigation { get; set; } = null!;

    public virtual Jugador? IdJugadorNavigation { get; set; }

    public virtual Torneo? IdTorneoNavigation { get; set; }
}

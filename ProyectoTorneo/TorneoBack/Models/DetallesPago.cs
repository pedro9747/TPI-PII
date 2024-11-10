using System;
using System.Collections.Generic;

namespace TorneoApi.Models;

public partial class DetallesPago
{
    public int IdDetalle { get; set; }

    public int IdPago { get; set; }

    public decimal? Monto { get; set; }

    public int? Cantidad { get; set; }

    public int IdServicio { get; set; }

    public virtual Pago IdPagoNavigation { get; set; } = null!;

    public virtual Servicio IdServicioNavigation { get; set; } = null!;
}

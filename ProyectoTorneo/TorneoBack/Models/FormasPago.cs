using System;
using System.Collections.Generic;

namespace TorneoApi.Models;

public partial class FormasPago
{
    public int IdFormaPago { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();
}

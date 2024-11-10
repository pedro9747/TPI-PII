using System;
using System.Collections.Generic;

namespace TorneoApi.Models;

public partial class Servicio
{
    public int IdServicio { get; set; }

    public string? Descripcion { get; set; }

    public int? Precio { get; set; }

    public virtual ICollection<DetallesPago> DetallesPagos { get; set; } = new List<DetallesPago>();
}

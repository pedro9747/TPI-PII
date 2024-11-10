using System;
using System.Collections.Generic;

namespace TorneoApi.Models;

public partial class TiposEvaluacion
{
    public int IdTipoEvaluacion { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<DetallesEvaluacion> DetallesEvaluacions { get; set; } = new List<DetallesEvaluacion>();
}

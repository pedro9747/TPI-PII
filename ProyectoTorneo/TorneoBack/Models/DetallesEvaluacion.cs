using System;
using System.Collections.Generic;

namespace TorneoApi.Models;

public partial class DetallesEvaluacion
{
    public int IdDetalleEvaluacion { get; set; }

    public int? IdTipoEvaluacion { get; set; }

    public int? IdEvaluacion { get; set; }

    public short? Evaluacion { get; set; }

    public virtual Evaluacione? IdEvaluacionNavigation { get; set; }

    public virtual TiposEvaluacion? IdTipoEvaluacionNavigation { get; set; }
}

using System;
using System.Collections.Generic;

namespace TorneoApi.Models;

public partial class TiposEvento
{
    public int IdTipoEvento { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Evento> Eventos { get; set; } = new List<Evento>();
}

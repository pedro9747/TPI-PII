using System;
using System.Collections.Generic;

namespace TorneoApi.Models;

public partial class Paise
{
    public int IdPais { get; set; }

    public string? Pais { get; set; }

    public virtual ICollection<Provincia> Provincia { get; set; } = new List<Provincia>();
}

using System;
using System.Collections.Generic;

namespace TorneoApi.Models;

public partial class Provincia
{
    public int IdProvincia { get; set; }

    public int? IdPais { get; set; }

    public string? Provincia1 { get; set; }

    public virtual ICollection<Ciudade> Ciudades { get; set; } = new List<Ciudade>();

    public virtual Paise? IdPaisNavigation { get; set; }
}

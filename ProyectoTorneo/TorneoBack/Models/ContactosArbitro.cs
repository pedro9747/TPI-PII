using System;
using System.Collections.Generic;

namespace TorneoApi.Models;

public partial class ContactosArbitro
{
    public int IdContacto { get; set; }

    public int IdArbitro { get; set; }

    public int IdTipoContacto { get; set; }

    public string Contacto { get; set; } = null!;

    public virtual Arbitro IdArbitroNavigation { get; set; } = null!;

    public virtual TiposContacto IdTipoContactoNavigation { get; set; } = null!;
}

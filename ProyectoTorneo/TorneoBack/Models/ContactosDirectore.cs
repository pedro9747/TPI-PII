using System;
using System.Collections.Generic;

namespace TorneoApi.Models;

public partial class ContactosDirectore
{
    public int IdContacto { get; set; }

    public int IdDirector { get; set; }

    public int IdTipoContacto { get; set; }

    public string Contacto { get; set; } = null!;

    public virtual DirectoresTecnico IdDirectorNavigation { get; set; } = null!;

    public virtual TiposContacto IdTipoContactoNavigation { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace TorneoApi.Models;

public partial class ContactosJugadore
{
    public int IdContacto { get; set; }

    public int IdJugador { get; set; }

    public int IdTipoContacto { get; set; }

    public string Contacto { get; set; } = null!;

    public virtual Jugador IdJugadorNavigation { get; set; } = null!;

    public virtual TiposContacto IdTipoContactoNavigation { get; set; } = null!;
}

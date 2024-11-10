using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TorneoApi.Models;

public partial class Jugador
{
    public int IdJugador { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public int? Dni { get; set; }

    public bool? FichaMedica { get; set; }

    public int? IdEquipo { get; set; }

    public int? IdObraSocial { get; set; } = 1; //combo

    public int? IdCiudad { get; set; } = 1; //combo

    public DateTime? FechaNacimiento { get; set; }

    public int? IdPosicion { get; set; } = 1; //combo

    public int? Rol { get; set; } = 1; //combo
    public bool? Borrado { get; set; } = false;

    [JsonIgnore]
    public virtual ICollection<ContactosJugadore>? ContactosJugadores { get; set; } = null;
    [JsonIgnore]
    public virtual ICollection<Evaluacione>? Evaluaciones { get; set; } = null;
    [JsonIgnore]
    public virtual ICollection<Evento>? Eventos { get; set; } = null;
    [JsonIgnore]
    public virtual Ciudade? IdCiudadNavigation { get; set; } = null;
    [JsonIgnore]
    public virtual Equipo? IdEquipoNavigation { get; set; } = null;
    [JsonIgnore]
    public virtual ObrasSociale? IdObraSocialNavigation { get; set; } = null;
    [JsonIgnore]
    public virtual PosicionesJuego? IdPosicionNavigation { get; set; } = null;
    [JsonIgnore]
    public virtual ICollection<Pago> Pagos { get; set; } =null;
    [JsonIgnore]
    public virtual TiposRole? RolNavigation { get; set; } = null;
}

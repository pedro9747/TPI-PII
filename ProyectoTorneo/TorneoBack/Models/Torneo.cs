using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TorneoApi.Models;

public partial class Torneo
{
    public int IdTorneo { get; set; }

    public string? Nombre { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; }

    public bool? Borrado { get; set; } = false;
    [JsonIgnore]
    public virtual ICollection<Pago>? Pagos { get; set; } = null;
    [JsonIgnore]
    public virtual ICollection<Partido>? Partidos { get; set; } = null;
    [JsonIgnore]
    public virtual ICollection<TorneosXEquipo>? TorneosXEquipos { get; set; } = null;
    }

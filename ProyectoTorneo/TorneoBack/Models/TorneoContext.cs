using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TorneoApi.Models;

public partial class TorneoContext : DbContext
{
    public TorneoContext()
    {
    }

    public TorneoContext(DbContextOptions<TorneoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Usuario> Usuarios { get; set; }
    public virtual DbSet<Arbitro> Arbitros { get; set; }

    public virtual DbSet<Cancha> Canchas { get; set; }

    public virtual DbSet<Ciudade> Ciudades { get; set; }

    public virtual DbSet<ContactosArbitro> ContactosArbitros { get; set; }

    public virtual DbSet<ContactosDirectore> ContactosDirectores { get; set; }

    public virtual DbSet<ContactosJugadore> ContactosJugadores { get; set; }

    public virtual DbSet<DetallesEvaluacion> DetallesEvaluacions { get; set; }

    public virtual DbSet<DetallesPago> DetallesPagos { get; set; }

    public virtual DbSet<DirectoresTecnico> DirectoresTecnicos { get; set; }

    public virtual DbSet<Equipo> Equipos { get; set; }

    public virtual DbSet<Evaluacione> Evaluaciones { get; set; }

    public virtual DbSet<Evento> Eventos { get; set; }

    public virtual DbSet<FormasPago> FormasPagos { get; set; }
    public virtual DbSet<Goleadore> Goleadores { get; set; }
    //public virtual DbSet<VGoleador> Goleadores { get; set; }

    public virtual DbSet<Jugador> Jugadores { get; set; }

    public virtual DbSet<ObrasSociale> ObrasSociales { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<Paise> Paises { get; set; }

    public virtual DbSet<Partido> Partidos { get; set; }

    public virtual DbSet<PosicionesJuego> PosicionesJuegos { get; set; }

    public virtual DbSet<Provincia> Provincias { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    public virtual DbSet<Tarjeta> Tarjetas { get; set; }

    public virtual DbSet<TiposContacto> TiposContactos { get; set; }

    public virtual DbSet<TiposEvaluacion> TiposEvaluacions { get; set; }

    public virtual DbSet<TiposEvento> TiposEventos { get; set; }

    public virtual DbSet<TiposRole> TiposRoles { get; set; }

    public virtual DbSet<Torneo> Torneos { get; set; }

    public virtual DbSet<TorneosXEquipo> TorneosXEquipos { get; set; }

    public virtual DbSet<VEvaluacionesArbitro> VEvaluacionesArbitros { get; set; }

    public virtual DbSet<VEvaluacionesCancha> VEvaluacionesCanchas { get; set; }

    public virtual DbSet<VFairPlay> VFairPlays { get; set; }

    public virtual DbSet<VGolesRecibido> VGolesRecibidos { get; set; }

    public virtual DbSet<VRendimientoJugadore> VRendimientoJugadors { get; set; }

    public virtual DbSet<VRendimientoJugadore> VRendimientoJugadores { get; set; }

    public virtual DbSet<VResultadoPartido> VResultadoPartidos { get; set; }

    public virtual DbSet<VTablaPosicione> VTablaPosiciones { get; set; }

    public virtual DbSet<VVerificacionArbitro> VVerificacionArbitros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-E045RR5\\SQLEXPRESS;Initial Catalog=TORNEO;Integrated Security=True;Trust Server Certificate=True");
    //      => optionsBuilder.UseSqlServer("Data Source=DESKTOP-SIC4FR5\\SQLEXPRESS; Initial Catalog=torneo; Integrated Security=True;Trust Server Certificate=True");

    //Data Source=DESKTOP-SIC4FR5\\SQLEXPRESS; Initial Catalog=torneo; Integrated Security=True;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Arbitro>(entity =>
        {
            entity.HasKey(e => e.IdArbitro).HasName("PK__Arbitros__335ACBC6ED8E7230");

            entity.HasIndex(e => e.Dni, "UQ__Arbitros__D87608A7830EA560").IsUnique();

            entity.Property(e => e.IdArbitro).HasColumnName("id_arbitro");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Dni).HasColumnName("dni");
            entity.Property(e => e.IdCiudad).HasColumnName("id_ciudad");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdCiudadNavigation).WithMany(p => p.Arbitros)
                .HasForeignKey(d => d.IdCiudad)
                .HasConstraintName("fk_arbitros_ciudades");
        });

        modelBuilder.Entity<Cancha>(entity =>
        {
            entity.HasKey(e => e.IdCancha).HasName("PK__Canchas__06795280A13DB363");

            entity.Property(e => e.IdCancha).HasColumnName("id_cancha");
            entity.Property(e => e.FechaUltMant)
                .HasColumnType("datetime")
                .HasColumnName("fecha_ult_mant");
        });

        modelBuilder.Entity<Ciudade>(entity =>
        {
            entity.HasKey(e => e.IdCiudad).HasName("PK__Ciudades__B7DC4CD5F97494DF");

            entity.Property(e => e.IdCiudad).HasColumnName("id_ciudad");
            entity.Property(e => e.Ciudad)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ciudad");
            entity.Property(e => e.IdProvincia).HasColumnName("id_provincia");

            entity.HasOne(d => d.IdProvinciaNavigation).WithMany(p => p.Ciudades)
                .HasForeignKey(d => d.IdProvincia)
                .HasConstraintName("fk_ciudades_provincias");
        });

        modelBuilder.Entity<ContactosArbitro>(entity =>
        {
            entity.HasKey(e => e.IdContacto).HasName("pk_contactos_arbitros");

            entity.ToTable("Contactos_Arbitros");

            entity.Property(e => e.IdContacto).HasColumnName("id_contacto");
            entity.Property(e => e.Contacto)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("contacto");
            entity.Property(e => e.IdArbitro).HasColumnName("id_arbitro");
            entity.Property(e => e.IdTipoContacto).HasColumnName("id_tipo_contacto");

            entity.HasOne(d => d.IdArbitroNavigation).WithMany(p => p.ContactosArbitros)
                .HasForeignKey(d => d.IdArbitro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_cont_arbitros_arbitros");

            entity.HasOne(d => d.IdTipoContactoNavigation).WithMany(p => p.ContactosArbitros)
                .HasForeignKey(d => d.IdTipoContacto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_cont_arbitros_tipos");
        });

        modelBuilder.Entity<ContactosDirectore>(entity =>
        {
            entity.HasKey(e => e.IdContacto).HasName("pk_contactos_directores");

            entity.ToTable("Contactos_Directores");

            entity.Property(e => e.IdContacto).HasColumnName("id_contacto");
            entity.Property(e => e.Contacto)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("contacto");
            entity.Property(e => e.IdDirector).HasColumnName("id_director");
            entity.Property(e => e.IdTipoContacto).HasColumnName("id_tipo_contacto");

            entity.HasOne(d => d.IdDirectorNavigation).WithMany(p => p.ContactosDirectores)
                .HasForeignKey(d => d.IdDirector)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_cont_directores_directores");

            entity.HasOne(d => d.IdTipoContactoNavigation).WithMany(p => p.ContactosDirectores)
                .HasForeignKey(d => d.IdTipoContacto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_cont_directores_tipos");
        });

        modelBuilder.Entity<ContactosJugadore>(entity =>
        {
            entity.HasKey(e => e.IdContacto).HasName("pk_cont_jugadores");

            entity.ToTable("Contactos_Jugadores");

            entity.Property(e => e.IdContacto).HasColumnName("id_contacto");
            entity.Property(e => e.Contacto)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("contacto");
            entity.Property(e => e.IdJugador).HasColumnName("id_jugador");
            entity.Property(e => e.IdTipoContacto).HasColumnName("id_tipo_contacto");

            entity.HasOne(d => d.IdJugadorNavigation).WithMany(p => p.ContactosJugadores)
                .HasForeignKey(d => d.IdJugador)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_cont_jugadores_jugadores");

            entity.HasOne(d => d.IdTipoContactoNavigation).WithMany(p => p.ContactosJugadores)
                .HasForeignKey(d => d.IdTipoContacto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_cont_jugadores_tipos");
        });

        modelBuilder.Entity<DetallesEvaluacion>(entity =>
        {
            entity.HasKey(e => e.IdDetalleEvaluacion).HasName("PK__Detalles__A487FB6CFE8D95F1");

            entity.ToTable("Detalles_Evaluacion");

            entity.Property(e => e.IdDetalleEvaluacion).HasColumnName("ID_DETALLE_EVALUACION");
            entity.Property(e => e.Evaluacion).HasColumnName("EVALUACION");
            entity.Property(e => e.IdEvaluacion).HasColumnName("ID_EVALUACION");
            entity.Property(e => e.IdTipoEvaluacion).HasColumnName("ID_TIPO_EVALUACION");

            entity.HasOne(d => d.IdEvaluacionNavigation).WithMany(p => p.DetallesEvaluacions)
                .HasForeignKey(d => d.IdEvaluacion)
                .HasConstraintName("FK_DETALLES_EVALUACION_EVALUACIONES");

            entity.HasOne(d => d.IdTipoEvaluacionNavigation).WithMany(p => p.DetallesEvaluacions)
                .HasForeignKey(d => d.IdTipoEvaluacion)
                .HasConstraintName("FK_DETALLES_EVALUACION_TIPOS_EVALUACION");
        });

        modelBuilder.Entity<DetallesPago>(entity =>
        {
            entity.HasKey(e => e.IdDetalle).HasName("PK_DETALLES_PAGOS");

            entity.ToTable("Detalles_Pagos");

            entity.Property(e => e.IdDetalle).HasColumnName("ID_DETALLE");
            entity.Property(e => e.Cantidad).HasColumnName("CANTIDAD");
            entity.Property(e => e.IdPago).HasColumnName("ID_PAGO");
            entity.Property(e => e.IdServicio).HasColumnName("ID_SERVICIO");
            entity.Property(e => e.Monto)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("MONTO");

            entity.HasOne(d => d.IdPagoNavigation).WithMany(p => p.DetallesPagos)
                .HasForeignKey(d => d.IdPago)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DETALLES_PAGOS_PAGOS");

            entity.HasOne(d => d.IdServicioNavigation).WithMany(p => p.DetallesPagos)
                .HasForeignKey(d => d.IdServicio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DETALLES_PAGOS_SERVICIOS");
        });

        modelBuilder.Entity<DirectoresTecnico>(entity =>
        {
            entity.HasKey(e => e.IdDirector).HasName("PK__Director__6B65E2A23CA42821");

            entity.ToTable("Directores_Tecnicos");

            entity.HasIndex(e => e.Dni, "UQ__Director__D87608A785BE218C").IsUnique();

            entity.Property(e => e.IdDirector).HasColumnName("id_director");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Dni).HasColumnName("dni");
            entity.Property(e => e.FechaNacimiento).HasColumnName("fecha_nacimiento");
            entity.Property(e => e.IdCiudad).HasColumnName("id_ciudad");
            entity.Property(e => e.IdEquipo).HasColumnName("id_equipo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdCiudadNavigation).WithMany(p => p.DirectoresTecnicos)
                .HasForeignKey(d => d.IdCiudad)
                .HasConstraintName("fk_directores_tecnicos_ciudades");

            entity.HasOne(d => d.IdEquipoNavigation).WithMany(p => p.DirectoresTecnicos)
                .HasForeignKey(d => d.IdEquipo)
                .HasConstraintName("fk_directores_tecnicos_equipos");
        });

        modelBuilder.Entity<Equipo>(entity =>
        {
            entity.HasKey(e => e.IdEquipo).HasName("PK__Equipos__EE01F88A5B67E80D");

            entity.HasIndex(e => e.Nombre, "UQ__Equipos__72AFBCC6152FFAFF").IsUnique();

            entity.Property(e => e.IdEquipo).HasColumnName("id_equipo");
            entity.Property(e => e.Borrado).HasColumnName("borrado");
            entity.Property(e => e.FechaFundacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_fundacion");
            entity.Property(e => e.IdCiudad).HasColumnName("id_ciudad");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdCiudadNavigation).WithMany(p => p.Equipos)
                .HasForeignKey(d => d.IdCiudad)
                .HasConstraintName("fk_equipos_ciudades");
        });

        modelBuilder.Entity<Evaluacione>(entity =>
        {
            entity.HasKey(e => e.IdEvaluacion).HasName("PK__Evaluaci__CE9B8DDCF7C527BF");

            entity.Property(e => e.IdEvaluacion).HasColumnName("ID_EVALUACION");
            entity.Property(e => e.IdJugador).HasColumnName("ID_JUGADOR");
            entity.Property(e => e.IdPartido).HasColumnName("ID_PARTIDO");

            entity.HasOne(d => d.IdJugadorNavigation).WithMany(p => p.Evaluaciones)
                .HasForeignKey(d => d.IdJugador)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EVALUACIONES_JUGADORES");

            entity.HasOne(d => d.IdPartidoNavigation).WithMany(p => p.Evaluaciones)
                .HasForeignKey(d => d.IdPartido)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EVALUACIONES_PARTIDOS");
        });

        modelBuilder.Entity<Evento>(entity =>
        {
            entity.HasKey(e => e.IdEvento).HasName("PK__Eventos__AF150CA505A5AA6B");

            entity.Property(e => e.IdEvento).HasColumnName("id_evento");
            entity.Property(e => e.IdJugador).HasColumnName("id_jugador");
            entity.Property(e => e.IdPartido).HasColumnName("id_partido");
            entity.Property(e => e.Minuto).HasColumnName("minuto");
            entity.Property(e => e.TipoEvento).HasColumnName("tipo_evento");

            entity.HasOne(d => d.IdJugadorNavigation).WithMany(p => p.Eventos)
                .HasForeignKey(d => d.IdJugador)
                .HasConstraintName("fk_eventos_jugadores");

            entity.HasOne(d => d.IdPartidoNavigation).WithMany(p => p.Eventos)
                .HasForeignKey(d => d.IdPartido)
                .HasConstraintName("fk_eventos_partidos");

            entity.HasOne(d => d.TipoEventoNavigation).WithMany(p => p.Eventos)
                .HasForeignKey(d => d.TipoEvento)
                .HasConstraintName("fk_eventos_tipos_eventos");
        });

        modelBuilder.Entity<FormasPago>(entity =>
        {
            entity.HasKey(e => e.IdFormaPago).HasName("PK__Formas_P__DA9B39EE6DA221FB");

            entity.ToTable("Formas_Pago");

            entity.HasIndex(e => e.Descripcion, "UQ__Formas_P__298336B60A26425A").IsUnique();

            entity.Property(e => e.IdFormaPago).HasColumnName("id_forma_pago");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcion");
        });

        //V_Goleadores decia antes
        modelBuilder.Entity<Goleadore>(entity =>
        {
            entity
                .HasNoKey()
                //.ToView("V_Goleadores");
                .ToView("Goleadores");

            entity.Property(e => e.Equipo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.GolesMarcados).HasColumnName("Goles_marcados");
            entity.Property(e => e.IdJugador).HasColumnName("Id Jugador");
            entity.Property(e => e.Jugador)
                .HasMaxLength(102)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Jugador>(entity =>
        {
            entity.HasKey(e => e.IdJugador).HasName("PK__Jugadore__75BB83E2548DE810");

            entity.HasIndex(e => e.Dni, "UQ__Jugadore__D87608A774C95E03").IsUnique();

            entity.Property(e => e.IdJugador).HasColumnName("id_jugador");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Borrado).HasColumnName("borrado");
            entity.Property(e => e.Dni).HasColumnName("dni");
            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("datetime")
                .HasColumnName("fecha_nacimiento");
            entity.Property(e => e.FichaMedica).HasColumnName("ficha_medica");
            entity.Property(e => e.IdCiudad).HasColumnName("id_ciudad");
            entity.Property(e => e.IdEquipo).HasColumnName("id_equipo");
            entity.Property(e => e.IdObraSocial).HasColumnName("id_obra_social");
            entity.Property(e => e.IdPosicion).HasColumnName("id_posicion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Rol).HasColumnName("rol");

            entity.HasOne(d => d.IdCiudadNavigation).WithMany(p => p.Jugadores)
                .HasForeignKey(d => d.IdCiudad)
                .HasConstraintName("fk_jugadores_ciudades");

            entity.HasOne(d => d.IdEquipoNavigation).WithMany(p => p.Jugadores)
                .HasForeignKey(d => d.IdEquipo)
                .HasConstraintName("fk_jugadores_equipos");

            entity.HasOne(d => d.IdObraSocialNavigation).WithMany(p => p.Jugadores)
                .HasForeignKey(d => d.IdObraSocial)
                .HasConstraintName("fk_jugadores_obras_sociales");

            entity.HasOne(d => d.IdPosicionNavigation).WithMany(p => p.Jugadores)
                .HasForeignKey(d => d.IdPosicion)
                .HasConstraintName("fk_jugadores_posiciones_juego");

            entity.HasOne(d => d.RolNavigation).WithMany(p => p.Jugadores)
                .HasForeignKey(d => d.Rol)
                .HasConstraintName("fk_jugadores_roles");
        });

        modelBuilder.Entity<ObrasSociale>(entity =>
        {
            entity.HasKey(e => e.IdObraSocial).HasName("PK__Obras_So__89039DF6545B6D15");

            entity.ToTable("Obras_Sociales");

            entity.Property(e => e.IdObraSocial).HasColumnName("id_obra_social");
            entity.Property(e => e.Altura).HasColumnName("altura");
            entity.Property(e => e.Calle)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("calle");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.IdPago).HasName("PK__Pagos__0941B074A7B29D0F");

            entity.Property(e => e.IdPago).HasColumnName("id_pago");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.IdFormaPago).HasColumnName("id_forma_pago");
            entity.Property(e => e.IdJugador).HasColumnName("id_jugador");
            entity.Property(e => e.IdTorneo).HasColumnName("id_torneo");

            entity.HasOne(d => d.IdFormaPagoNavigation).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.IdFormaPago)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_pagos_formas_pagos");

            entity.HasOne(d => d.IdJugadorNavigation).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.IdJugador)
                .HasConstraintName("fk_pagos_jugadores");

            entity.HasOne(d => d.IdTorneoNavigation).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.IdTorneo)
                .HasConstraintName("fk_pagos_torneos");
        });

        modelBuilder.Entity<Paise>(entity =>
        {
            entity.HasKey(e => e.IdPais).HasName("PK__Paises__0941A3A75B510BE7");

            entity.HasIndex(e => e.Pais, "UQ__Paises__833F4FBF969639C3").IsUnique();

            entity.Property(e => e.IdPais).HasColumnName("id_pais");
            entity.Property(e => e.Pais)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("pais");
        });

        modelBuilder.Entity<Partido>(entity =>
        {
            entity.HasKey(e => e.IdPartido).HasName("PK__Partidos__42D83E442143EACA");

            entity.Property(e => e.IdPartido).HasColumnName("id_partido");
            entity.Property(e => e.Equipo1).HasColumnName("equipo_1");
            entity.Property(e => e.Equipo2).HasColumnName("equipo_2");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.IdArbitro).HasColumnName("id_arbitro");
            entity.Property(e => e.IdCancha).HasColumnName("id_cancha");
            entity.Property(e => e.IdTorneo).HasColumnName("id_torneo");

            entity.HasOne(d => d.Equipo1Navigation).WithMany(p => p.PartidoEquipo1Navigations)
                .HasForeignKey(d => d.Equipo1)
                .HasConstraintName("fk_partidos_equipos1");

            entity.HasOne(d => d.Equipo2Navigation).WithMany(p => p.PartidoEquipo2Navigations)
                .HasForeignKey(d => d.Equipo2)
                .HasConstraintName("fk_partidos_equipos2");

            entity.HasOne(d => d.IdArbitroNavigation).WithMany(p => p.Partidos)
                .HasForeignKey(d => d.IdArbitro)
                .HasConstraintName("fk_partidos_arbitros");

            entity.HasOne(d => d.IdCanchaNavigation).WithMany(p => p.Partidos)
                .HasForeignKey(d => d.IdCancha)
                .HasConstraintName("fk_partidos_canchas");

            entity.HasOne(d => d.IdTorneoNavigation).WithMany(p => p.Partidos)
                .HasForeignKey(d => d.IdTorneo)
                .HasConstraintName("fk_partidos_torneos");
        });

        modelBuilder.Entity<PosicionesJuego>(entity =>
        {
            entity.HasKey(e => e.IdPosicion).HasName("PK__Posicion__2234F81051AB945A");

            entity.ToTable("Posiciones_Juego");

            entity.HasIndex(e => e.Posicion, "UQ__Posicion__979AB1B8F5C7CECC").IsUnique();

            entity.Property(e => e.IdPosicion).HasColumnName("id_posicion");
            entity.Property(e => e.Posicion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("posicion");
        });

        modelBuilder.Entity<Provincia>(entity =>
        {
            entity.HasKey(e => e.IdProvincia).HasName("PK__Provinci__66C18BFD4C750F45");

            entity.Property(e => e.IdProvincia).HasColumnName("id_provincia");
            entity.Property(e => e.IdPais).HasColumnName("id_pais");
            entity.Property(e => e.Provincia1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("provincia");

            entity.HasOne(d => d.IdPaisNavigation).WithMany(p => p.Provincia)
                .HasForeignKey(d => d.IdPais)
                .HasConstraintName("fk_provincias_paises");
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.IdServicio).HasName("PK_SERVICIOS");

            entity.Property(e => e.IdServicio).HasColumnName("ID_SERVICIO");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.Precio).HasColumnName("PRECIO");
        });

        modelBuilder.Entity<Tarjeta>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Tarjetas");

            entity.Property(e => e.Equipo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IdJugador).HasColumnName("Id_Jugador");
            entity.Property(e => e.Jugador)
                .HasMaxLength(102)
                .IsUnicode(false);
            entity.Property(e => e.TarjetasAmarillas).HasColumnName("Tarjetas_amarillas");
            entity.Property(e => e.TarjetasRojas).HasColumnName("Tarjetas_rojas");
        });

        modelBuilder.Entity<TiposContacto>(entity =>
        {
            entity.HasKey(e => e.IdTipoContacto).HasName("PK__Tipos_Co__CA854C0DE4973249");

            entity.ToTable("Tipos_Contactos");

            entity.HasIndex(e => e.TipoContacto, "UQ__Tipos_Co__6D5BDA29B9891EF9").IsUnique();

            entity.Property(e => e.IdTipoContacto).HasColumnName("id_tipo_contacto");
            entity.Property(e => e.TipoContacto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("tipo_contacto");
        });

        modelBuilder.Entity<TiposEvaluacion>(entity =>
        {
            entity.HasKey(e => e.IdTipoEvaluacion).HasName("PK__Tipos_Ev__D252E185D2160D05");

            entity.ToTable("Tipos_Evaluacion");

            entity.Property(e => e.IdTipoEvaluacion).HasColumnName("id_tipo_evaluacion");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<TiposEvento>(entity =>
        {
            entity.HasKey(e => e.IdTipoEvento).HasName("PK__Tipos_Ev__E3566D7989A9BEA5");

            entity.ToTable("Tipos_Eventos");

            entity.HasIndex(e => e.Descripcion, "UQ__Tipos_Ev__298336B6B222CF70").IsUnique();

            entity.Property(e => e.IdTipoEvento).HasColumnName("id_tipo_evento");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<TiposRole>(entity =>
        {
            entity.HasKey(e => e.IdTipoRol).HasName("PK__Tipos_Ro__9FB5400D86C1FDDC");

            entity.ToTable("Tipos_Roles");

            entity.Property(e => e.IdTipoRol).HasColumnName("ID_TIPO_ROL");
            entity.Property(e => e.Descripción)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCIÓN");
        });

        modelBuilder.Entity<Torneo>(entity =>
        {
            entity.HasKey(e => e.IdTorneo).HasName("PK__Torneos__DBB62AF83629C44B");

            entity.Property(e => e.IdTorneo).HasColumnName("id_torneo");
            entity.Property(e => e.FechaFin)
                .HasColumnType("datetime")
                .HasColumnName("fecha_fin");
            entity.Property(e => e.FechaInicio)
                .HasColumnType("datetime")
                .HasColumnName("fecha_inicio");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<TorneosXEquipo>(entity =>
        {
            entity.HasKey(e => e.IdTorneoXEquipo).HasName("PK__Torneos___9FF2FDAAB7ACD4FB");

            entity.ToTable("Torneos_X_Equipos");

            entity.Property(e => e.IdTorneoXEquipo).HasColumnName("id_torneo_x_equipo");
            entity.Property(e => e.IdEquipo).HasColumnName("id_equipo");
            entity.Property(e => e.IdTorneo).HasColumnName("id_torneo");

            entity.HasOne(d => d.IdEquipoNavigation).WithMany(p => p.TorneosXEquipos)
                .HasForeignKey(d => d.IdEquipo)
                .HasConstraintName("fk_torneos_equipos");

            entity.HasOne(d => d.IdTorneoNavigation).WithMany(p => p.TorneosXEquipos)
                .HasForeignKey(d => d.IdTorneo)
                .HasConstraintName("fk_equipos_torneos");
        });

        modelBuilder.Entity<VEvaluacionesArbitro>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_Evaluaciones_Arbitro");

            entity.Property(e => e.Arbitro)
                .HasMaxLength(102)
                .IsUnicode(false);
            entity.Property(e => e.IdArbitro).HasColumnName("id_arbitro");
            entity.Property(e => e.PuntajePromedio).HasColumnName("puntaje_promedio");
        });

        modelBuilder.Entity<VEvaluacionesCancha>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_Evaluaciones_Canchas");

            entity.Property(e => e.PuntajePromedio).HasColumnName("puntaje_promedio");
        });

        modelBuilder.Entity<VFairPlay>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_Fair_Play");

            entity.Property(e => e.IdEquipo).HasColumnName("id_equipo");
            entity.Property(e => e.NombreEquipo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_equipo");
            entity.Property(e => e.Puntaje).HasColumnName("PUNTAJE");
            entity.Property(e => e.TotalTarjetas).HasColumnName("total_tarjetas");
            entity.Property(e => e.TotalTarjetasAmarillas).HasColumnName("total_tarjetas_amarillas");
            entity.Property(e => e.TotalTarjetasRojas).HasColumnName("total_tarjetas_rojas");
        });

        modelBuilder.Entity<VGolesRecibido>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_Goles_Recibidos");

            entity.Property(e => e.Equipo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.GolesRecibidosComoLocal).HasColumnName("Goles_Recibidos_Como_Local");
            entity.Property(e => e.GolesRecibidosComoVisitante).HasColumnName("Goles_Recibidos_Como_Visitante");
            entity.Property(e => e.IdEquipo).HasColumnName("id_equipo");
            entity.Property(e => e.TotalGolesRecibidos).HasColumnName("Total_Goles_Recibidos");
        });

        modelBuilder.Entity<VRendimientoJugadore>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_Rendimiento_Jugador");

            entity.Property(e => e.Asistencias).HasColumnName("asistencias");
            entity.Property(e => e.Equipo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EQUIPO");
            entity.Property(e => e.Goles).HasColumnName("goles");
            entity.Property(e => e.IdJugador).HasColumnName("id_jugador");
            entity.Property(e => e.Jugador)
                .HasMaxLength(102)
                .IsUnicode(false);
            entity.Property(e => e.PartidosJugados).HasColumnName("partidos_jugados");
            entity.Property(e => e.TarjetasAmarillas).HasColumnName("tarjetas_amarillas");
            entity.Property(e => e.TarjetasRojas).HasColumnName("tarjetas_rojas");
        });

        modelBuilder.Entity<VRendimientoJugadore>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_Rendimiento_Jugadores");

            entity.Property(e => e.Equipo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName(" Equipo ");
            entity.Property(e => e.Goles).HasColumnName(" Goles ");
            entity.Property(e => e.IdJugador).HasColumnName("id_jugador");
            entity.Property(e => e.Jugador)
                .HasMaxLength(102)
                .IsUnicode(false)
                .HasColumnName(" Jugador ");
            entity.Property(e => e.PartidosJugados).HasColumnName(" Partidos_jugados ");
            entity.Property(e => e.TarjetasAmarillas).HasColumnName(" Tarjetas_amarillas");
            entity.Property(e => e.TarjetasRojas).HasColumnName(" Tarjetas_rojas");
        });

        modelBuilder.Entity<VResultadoPartido>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_Resultado_Partidos");

            entity.Property(e => e.Equipo1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Equipo_1");
            entity.Property(e => e.Equipo2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Equipo_2");
            entity.Property(e => e.GolesEquipo1).HasColumnName("goles_equipo_1");
            entity.Property(e => e.GolesEquipo2).HasColumnName("goles_equipo_2");
            entity.Property(e => e.IdPartido).HasColumnName("id_partido");
            entity.Property(e => e.Resultado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("resultado");
        });

        modelBuilder.Entity<VTablaPosicione>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_Tabla_Posiciones");

            entity.Property(e => e.DiferenciaGoles).HasColumnName("Diferencia_Goles");
            entity.Property(e => e.Equipo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PartidosEmpatados).HasColumnName("Partidos_Empatados");
            entity.Property(e => e.PartidosGanados).HasColumnName("Partidos_Ganados");
            entity.Property(e => e.PartidosJugados).HasColumnName("Partidos_Jugados");
            entity.Property(e => e.PartidosPerdidos).HasColumnName("Partidos_Perdidos");
        });

        modelBuilder.Entity<VVerificacionArbitro>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_VerificacionArbitros");

            entity.Property(e => e.Arbitro)
                .HasMaxLength(101)
                .IsUnicode(false);
            entity.Property(e => e.CantidadDeVecesQueElÁrbitroEstuvoConEsteEquipo).HasColumnName("Cantidad de veces que el árbitro estuvo con este equipo");
            entity.Property(e => e.CiudadDelArbitro)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Ciudad del arbitro");
            entity.Property(e => e.CiudadDelEquipo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Ciudad del equipo");
            entity.Property(e => e.Equipo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IdDelArbitro).HasColumnName("Id del arbitro");
            entity.Property(e => e.IdDelEquipo).HasColumnName("Id del equipo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using Microsoft.EntityFrameworkCore;
using System.Net;
using TorneoApi.Controllers;
using TorneoApi.Models;
using TorneoBack.DTOs;
using TorneoBack.Repository.Contracts;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TorneoBack.Repository
{
    public class EquiposRepository : IEquiposRepository
    {
        private readonly TorneoContext _context;
        public EquiposRepository(TorneoContext context)
        {
            _context = context;
        }
        
       
        public bool Delete(int id)
        {
            if (_context.Equipos.Any(t => t.IdEquipo == id))
            {
                var equipo = _context.Equipos.Find(id);
                equipo.Borrado = true;
                return _context.SaveChanges() > 0;
            }
            return false;
        }

        public List<Equipo> GetAll()
        {
            return _context.Equipos.Where(t => t.Borrado != true).ToList();
        }

        public EquipoDto GetById(int id)
        {
            var equipo = _context.Equipos.First(e=>e.IdEquipo == id);
            List<Jugador> juadores = _context.Jugadores.Where(j => j.IdEquipo == id).ToList();
            List<JugadorDto> jugadoresDto = new List<JugadorDto>();

            foreach (Jugador j in juadores)
            {
                var jugadorDto = new JugadorDto
                {
                    IdJugador = j.IdJugador,
                    Nombre = j.Nombre,
                    Apellido = j.Apellido,
                    Dni = j.Dni,
                    FichaMedica = j.FichaMedica,
                    FechaNacimiento = j.FechaNacimiento,
                    IdEquipo = id,
                    IdPosicion = j.IdPosicion,
                    Rol = j.Rol,
                    Borrado = j.Borrado
                };
                jugadoresDto.Add(jugadorDto);

            }

            var equipoDto = new EquipoDto
            {
                IdEquipo = equipo.IdEquipo,
                Nombre = equipo.Nombre,
                FechaFundacion = equipo.FechaFundacion,
                Jugadores = jugadoresDto
            };

            
            return equipoDto ;
        }

        public bool Save(EquipoDto equipoDto)
        {
            if (equipoDto == null)
                return false;

            using var transaction = _context.Database.BeginTransaction();
            try
            {
                Equipo equipo;

                if (equipoDto.IdEquipo == 0)
                {
                    equipo = new Equipo
                    {
                        Nombre = equipoDto.Nombre,
                        FechaFundacion = equipoDto.FechaFundacion
                    };
                    _context.Equipos.Add(equipo);
                    _context.SaveChanges();
                }
                else
                {
                    equipo = _context.Equipos.Find(equipoDto.IdEquipo);
                    if (equipo == null)
                        throw new Exception("Equipo no encontrado.");

                    if (!string.IsNullOrWhiteSpace(equipoDto.Nombre))
                        equipo.Nombre = equipoDto.Nombre;

                    if (equipoDto.FechaFundacion != DateTime.MinValue)
                        equipo.FechaFundacion = equipoDto.FechaFundacion;

                    _context.SaveChanges();
                }

               
                // Filtrar jugadores duplicados en equipoDto basados en Dni
                equipoDto.Jugadores = equipoDto.Jugadores
                    .GroupBy(j => j.Dni)
                    .Select(g => g.First())
                    .ToList();

                foreach (var jugadorDTO in equipoDto.Jugadores)
                {
                    if (jugadorDTO.IdJugador == 0)
                    {
                        jugadorDTO.Rol = jugadorDTO.Rol == 0 ? null : jugadorDTO.Rol;
                        jugadorDTO.IdPosicion = jugadorDTO.IdPosicion == 0 ? null : jugadorDTO.IdPosicion;

                        // Verificar que el DNI no esté en otro jugador
                        if (_context.Jugadores.Any(j => j.Dni == jugadorDTO.Dni))
                        {
                            throw new Exception($"Ya existe un jugador con el DNI {jugadorDTO.Dni}.");
                        }

                        var nuevoJugador = new Jugador
                        {
                            Nombre = jugadorDTO.Nombre,
                            Apellido = jugadorDTO.Apellido,
                            Dni = jugadorDTO.Dni,
                            FichaMedica = jugadorDTO.FichaMedica,
                            FechaNacimiento = jugadorDTO.FechaNacimiento,
                            IdEquipo = equipo.IdEquipo,
                            IdPosicion = jugadorDTO.IdPosicion,
                            Rol = jugadorDTO.Rol
                        };
                        _context.Jugadores.Add(nuevoJugador);
                    }
                    else
                    {
                        var jugador = _context.Jugadores.Find(jugadorDTO.IdJugador);
                        if (jugador == null)
                            throw new Exception("Jugador no encontrado.");

                        // Verificar que el DNI no pertenezca a otro jugador
                        if (_context.Jugadores.Any(j => j.Dni == jugadorDTO.Dni && j.IdJugador != jugadorDTO.IdJugador))
                        {
                            throw new Exception($"Ya existe un jugador con el DNI {jugadorDTO.Dni}.");
                        }
                        if (!string.IsNullOrWhiteSpace(jugadorDTO.Nombre))
                            jugador.Nombre = jugadorDTO.Nombre;
                        if (!string.IsNullOrWhiteSpace(jugadorDTO.Apellido))
                            jugador.Apellido = jugadorDTO.Apellido;
                        if (jugadorDTO.Dni != 0)
                            jugador.Dni = jugadorDTO.Dni;
                        jugador.FichaMedica = jugadorDTO.FichaMedica;
                        jugador.FechaNacimiento = jugadorDTO.FechaNacimiento;
                        jugador.IdPosicion = jugadorDTO.IdPosicion == 0 ? null : jugadorDTO.IdPosicion;
                        jugador.Rol = jugadorDTO.Rol == 0 ? null : jugadorDTO.Rol;
                    }
                }

                _context.SaveChanges();
                transaction.Commit();
                return true;
            }
            catch (DbUpdateException dbEx)
            {
                transaction.Rollback();
                Console.WriteLine($"Error de actualización de base de datos: {dbEx.InnerException?.Message ?? dbEx.Message}");
                return false;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }



    }
}

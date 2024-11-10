using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TorneoApi.Models;
using TorneoBack.Repository.Contracts;

namespace TorneoBack.Repository
{
    
    public class TorneoRepository : ITorneoRepository
    {
        private readonly TorneoContext _context;
        public TorneoRepository(TorneoContext context)
        {
            _context = context;
        }
        public bool Add(Torneo torneo)
        {
            if (torneo != null)
            {
                if (torneo.IdTorneo == 0)
                {
                    _context.Torneos.Add(torneo);
                    return _context.SaveChanges() > 0;
                }
                else
                {
                    var torneoActualizado = _context.Torneos.Find(torneo.IdTorneo);
                        torneoActualizado.Nombre = torneo.Nombre;
                        torneoActualizado.FechaInicio = torneo.FechaInicio;
                        torneoActualizado.FechaFin = torneo.FechaFin;
                        torneoActualizado.Borrado = torneo.Borrado;

                        _context.Entry(torneoActualizado).State = EntityState.Modified;

                        return _context.SaveChanges() > 0;
                
                }
            }
            else
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            if(_context.Torneos.Any(t => t.IdTorneo == id))
            {
                var torneo = _context.Torneos.Find(id);
                torneo.Borrado = true;
                return _context.SaveChanges() > 0;
            }
            return false;
        }
        public List<VTablaPosicione> GetAllPosiciones()
        {
            return _context.VTablaPosiciones.Where(t => t.PartidosJugados > 0)
                .OrderByDescending(t => t.Puntos).ToList();
        }

        public List<Torneo> GetAll()
        {
            return _context.Torneos.Where(t => t.Borrado != true).ToList();
        }

        public Torneo GetById(int id)
        {
            return _context.Torneos.Find(id);
        }

        public bool Update(Torneo torneo)
        {
            var torneoActualizado = _context.Torneos.Find(torneo.IdTorneo);
            if (torneoActualizado != null)
            {
                
                torneoActualizado.Nombre = torneo.Nombre;
                torneoActualizado.FechaInicio = torneo.FechaInicio;
                torneoActualizado.FechaFin = torneo.FechaFin;
                torneoActualizado.Borrado = torneo.Borrado;

                _context.Entry(torneoActualizado).State = EntityState.Modified;

                return _context.SaveChanges() > 0;
            }
            return false;
        }
        public List<Goleadore> GetAllGoleadores()
        {
            return _context.Goleadores.OrderByDescending(g => g.GolesMarcados).ToList();
        }

        public List<VFairPlay> GetAllFairPlay()
        {
            return _context.VFairPlays.OrderByDescending(f => f.Puntaje).ToList();
        }
    }
}

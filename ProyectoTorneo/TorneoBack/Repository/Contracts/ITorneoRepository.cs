using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TorneoApi.Models;

namespace TorneoBack.Repository.Contracts
{
    public interface ITorneoRepository
    {
        bool Add(Torneo torneo);
        bool Update(Torneo torneo);
        bool Delete(int id);
        List<Torneo> GetAll();
        Torneo GetById(int id);
        List<VTablaPosicione> GetAllPosiciones();
        List<Goleadore> GetAllGoleadores();
        List<VFairPlay> GetAllFairPlay();
    }
}

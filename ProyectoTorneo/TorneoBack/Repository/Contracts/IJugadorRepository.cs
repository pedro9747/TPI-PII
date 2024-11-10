using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TorneoApi.Models;
using TorneoBack.DTOs;

namespace TorneoBack.Repository.Contracts
{
    public interface IJugadorRepository
    {
        
        public JugadorDto GetById(int id);
        
    }
}

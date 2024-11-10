using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorneoBack.Service.Contracts
{
    public interface IAuthService
    {
        string Authenticate(string username, string password);
    }

}

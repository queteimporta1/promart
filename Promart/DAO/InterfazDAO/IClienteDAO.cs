using Promart.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Promart.DAO.InterfazDAO
{
    public interface IClienteDAO
    {
        Cliente Create(Cliente cliente);
        List<Cliente> List();
        Cliente Update(Cliente cliente);
        int Delete(int Id);
    }
}

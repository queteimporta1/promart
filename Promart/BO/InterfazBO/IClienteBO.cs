using Promart.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Promart.BO.InterfazBO
{
    public interface IClienteBO
    {
        Cliente Create(Cliente cliente);
        List<Cliente> List();
        Cliente Update(Cliente cliente);
        int Delete(int Id);
    }
}

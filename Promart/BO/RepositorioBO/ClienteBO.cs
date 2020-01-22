using Promart.BE;
using Promart.BO.InterfazBO;
using Promart.DAO.InterfazDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Promart.BO.RepositorioBO
{
    public class ClienteBO : IClienteBO
    {
        public readonly IClienteDAO _Cliente;
        public ClienteBO(IClienteDAO cliente)
        {
            _Cliente = cliente;
        }
        public Cliente Create(Cliente cliente)
        {
            return _Cliente.Create(cliente);
        }

        public int Delete(int Id)
        {
            return _Cliente.Delete(Id);
        }

        public List<Cliente> List()
        {
            return _Cliente.List();
        }

        public Cliente Update(Cliente cliente)
        {
            return _Cliente.Update(cliente);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Promart.BE
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public int NumeroPedido { get; set; }
        public string Direccion { get; set; }
    }
}

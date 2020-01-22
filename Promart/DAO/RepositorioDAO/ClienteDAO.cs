using Dapper;
using Microsoft.Extensions.Configuration;
using Promart.BE;
using Promart.DAO.InterfazDAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Promart.DAO.RepositorioDAO
{
    public class ClienteDAO : IClienteDAO
    {
        public readonly IConfiguration _config;

        public ClienteDAO(IConfiguration configuration)
        {
            _config = configuration;
        }
        public IDbConnection Con
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("Cn"));
            }
        }

        public Cliente Create(Cliente cliente)
        {

            Cliente client = new Cliente();
            IDbConnection Cn = Con;
            Cn.Open();
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                dypa.Add("@NombreCliente", cliente.NombreCliente);
                dypa.Add("@NumeroPedido", cliente.NumeroPedido);
                dypa.Add("@Direccion", cliente.Direccion);
                client = Cn.QueryFirst<Cliente>("SP_I_CLIENTE", dypa, commandType: CommandType.StoredProcedure);

            }
            catch (Exception e)
            {
                client = null;

            }
            finally
            {
                Cn.Close();
            }


            return client;


        }

        public int Delete(int Id)
        {
            int rpta = 1;
            IDbConnection Cn = Con;
            Cn.Open();
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                dypa.Add("@IdCliente", Id);
                Cn.Execute("SP_D_CLIENTE", dypa, commandType: CommandType.StoredProcedure);

            }
            catch (Exception e)
            {
                rpta = 0;

            }
            finally
            {
                Cn.Close();
            }


            return rpta;
        }

        public List<Cliente> List()
        {
            List<Cliente> lis = new List<Cliente>();
            IDbConnection Cn = Con;
            Cn.Open();
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                lis = Cn.Query<Cliente>("SP_L_CLIENTE", dypa, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception e)
            {
                lis = null;

            }
            finally
            {
                Cn.Close();
            }


            return lis;
        }

        public Cliente Update(Cliente cliente)
        {
            Cliente client = new Cliente();
            IDbConnection Cn = Con;
            Cn.Open();
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                dypa.Add("@IdCliente", cliente.IdCliente);
                dypa.Add("@NombreCliente", cliente.NombreCliente);
                dypa.Add("@NumeroPedido", cliente.NumeroPedido);
                dypa.Add("@Direccion", cliente.Direccion);
                client = Cn.QueryFirst<Cliente>("SP_U_CLIENTE", dypa, commandType: CommandType.StoredProcedure);

            }
            catch (Exception e)
            {
                client = null;

            }
            finally
            {
                Cn.Close();
            }


            return client;
        }
    }
}

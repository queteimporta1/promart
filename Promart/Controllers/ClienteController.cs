using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Promart.BE;
using Promart.BO.InterfazBO;

namespace Promart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("Politica")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteBO _clienteBO;

        public ClienteController(IClienteBO clienteBO)
        {
            _clienteBO = clienteBO;
        }
        // GET: api/Cliente
        [HttpGet]
        public IEnumerable<Cliente> Get()
        {
            return _clienteBO.List(); ;
        }

        // GET: api/Cliente/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            Cliente  clie= _clienteBO.List().Where(x => x.IdCliente == id).FirstOrDefault();
           
            return Ok(clie);
        }

        // POST: api/Cliente
        [HttpPost]
        public IActionResult Post([FromBody] Cliente cliente)
        {
            return Ok(_clienteBO.Create(cliente));
        }

        // PUT: api/Cliente/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Cliente cliente)
        {
            cliente.IdCliente = id;
            return Ok(_clienteBO.Update(cliente));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_clienteBO.Delete(id));
        }
    }
}

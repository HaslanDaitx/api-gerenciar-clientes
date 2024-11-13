using Microsoft.AspNetCore.Mvc;
using GerenciadorClientes.Models;
using System.Collections.Generic;

namespace GerenciadorClientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private static List<Cliente> clientes = new List<Cliente>();
        private static int nextId = 1;

        
        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> GetClientes()
        {
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public ActionResult<Cliente> GetCliente(int id)
        {
            var cliente = clientes.Find(c => c.Id == id);
            if (cliente == null)
                return NotFound();

            return Ok(cliente);
        }

        
        [HttpPost]
        public ActionResult<Cliente> CreateCliente(Cliente cliente)
        {
            cliente.Id = nextId++;
            clientes.Add(cliente);
            return CreatedAtAction(nameof(GetCliente), new { id = cliente.Id }, cliente);
        }

        
        [HttpPut("{id}")]
        public ActionResult UpdateCliente(int id, Cliente clienteAtualizado)
        {
            var cliente = clientes.Find(c => c.Id == id);
            if (cliente == null)
                return NotFound();

            cliente.Nome = clienteAtualizado.Nome;
            cliente.Email = clienteAtualizado.Email;
            cliente.Telefone = clienteAtualizado.Telefone;

            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public ActionResult DeleteCliente(int id)
        {
            var cliente = clientes.Find(c => c.Id == id);
            if (cliente == null)
                return NotFound();

            clientes.Remove(cliente);
            return NoContent();
        }
    }
}
using Estudos.Data;
using Estudos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estudos.Service
{
    public class ClienteService
    {
        private readonly EstudosContext _context;

        public ClienteService(EstudosContext context)
        {
            _context = context;
            CadastrarClientes();
        }

        private void CadastrarClientes()
        {
            if (_context.Cliente.Any()) return;
            _context.Cliente.Add(new Cliente { Nome = "JBC", Email = "jbc@jbc.com.br", Ativo = true });
            _context.Cliente.Add(new Cliente { Nome = "Microsoft", Email = "microsoft@microsoft.com.br", Ativo = true });
            _context.Cliente.Add(new Cliente { Nome = "IBM", Email = "ibm@ibm.com.br", Ativo = true });
            _context.Cliente.Add(new Cliente { Nome = "Oracle", Email = "oracle@oracle.com.br", Ativo = true });
            _context.Cliente.Add(new Cliente { Nome = "Semar", Email = "oracle@oracle.com.br", Ativo = false });
            _context.SaveChanges();
        }

        public Cliente Cadastrar(Cliente cliente)
        {
            cliente.Ativo = true;
            _context.Cliente.Add(cliente);
            _context.SaveChanges();
            return cliente;
        }

        public Cliente ObterCliente(long id)
        {
            var cliente = _context.Cliente.Find(id);

            if (cliente == null)
                return null;

            return cliente;
        }

        public Cliente ObterClienteAtivo(long id)
        {
            var cliente = _context.Cliente.Where(c => c.Ativo == true && c.Id == id).FirstOrDefault();

            if (cliente == null)
                return null;

            return cliente;
        }

        public IEnumerable<Cliente> ObterAtivos()
        {
            var clientes = _context.Cliente.Where(c => c.Ativo == true).ToList();

            if (clientes == null)
                return null;

            return clientes;
        }

        public Cliente Atualizar(long id, Cliente cliente)
        {
            var result = ObterClienteAtivo(id);

            if (result == null)
                return null;

            result.Nome = cliente.Nome;
            result.Email = cliente.Email;

            _context.Cliente.Update(cliente);
            _context.SaveChanges();

            return ObterCliente(id);
        }

        public bool Inativar(long id)
        {
            var cliente = ObterClienteAtivo(id);

            if (cliente == null)
                return false;

            cliente.Ativo = false;

            _context.Cliente.Update(cliente);
            var excluiu = _context.SaveChanges();

            return excluiu > 0 ? true : false;          
        }
    }
}

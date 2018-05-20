using Estudos.Data;
using Estudos.Models;
using Estudos.ViewModel;
using System.Collections.Generic;
using System.Linq;

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
            _context.Cliente.Add(new Cliente("JBC", "jbc@jbc.com.br"));
            _context.Cliente.Add(new Cliente("Microsoft", "microsoft@microsoft.com.br"));
            _context.Cliente.Add(new Cliente("IBM", "ibm@ibm.com.br"));
            _context.Cliente.Add(new Cliente("Oracle", "oracle@oracle.com.br"));
            _context.Cliente.Add(new Cliente("Semar", "semair@gmail.com"));
            _context.SaveChanges();
        }

        public Cliente Cadastrar(ClienteViewModel clienteVm)
        {
            var cliente = new Cliente(clienteVm.Nome, clienteVm.Email);
            var x = new Cliente();

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

        public Cliente Atualizar(long id, ClienteViewModel clienteVm)
        {
            var cliente = ObterClienteAtivo(id);

            if (cliente == null)
                return null;

            cliente.Atualizar(clienteVm.Nome, clienteVm.Email);

            _context.Cliente.Update(cliente);
            _context.SaveChanges();

            return ObterCliente(id);
        }

        public bool Inativar(long id)
        {
            var cliente = ObterClienteAtivo(id);

            if (cliente == null)
                return false;

            cliente.Inativar();

            _context.Cliente.Update(cliente);
            var excluiu = _context.SaveChanges();

            return excluiu > 0 ? true : false;
        }
    }
}

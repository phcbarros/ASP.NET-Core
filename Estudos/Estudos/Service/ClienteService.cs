using Estudos.Data;
using Estudos.Data.Repository;
using Estudos.Models;
using Estudos.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace Estudos.Service
{
    public class ClienteService
    {
        private readonly EstudosContext _context;
        private readonly ClienteRepository _repository;

        public ClienteService(EstudosContext context, ClienteRepository repository)
        {
            _context = context;
            _repository = repository;
            CadastrarClientes();
        }

        private void CadastrarClientes()
        {
            if (_repository.ObterAtivos().Any()) return;

            _repository.Cadastrar(new Cliente("JBC", "jbc@jbc.com.br"));
            _repository.Cadastrar(new Cliente("Microsoft", "microsoft@microsoft.com.br"));
            _repository.Cadastrar(new Cliente("IBM", "ibm@ibm.com.br"));
            _repository.Cadastrar(new Cliente("Oracle", "oracle@oracle.com.br"));
            _repository.Cadastrar(new Cliente("Semar", "semair@gmail.com"));
        }

        public Cliente Cadastrar(ClienteViewModel clienteVm)
        {
            var cliente = new Cliente(clienteVm.Nome, clienteVm.Email);

            return _repository.Cadastrar(cliente);
        }

        public Cliente ObterCliente(long id)
        {
            var cliente = _repository.ObterCliente(id);

            if (cliente == null)
                return null;

            return cliente;
        }

        public Cliente ObterClienteAtivo(long id)
        {
            var cliente = _repository.ObterClienteAtivo(id);

            if (cliente == null)
                return null;

            return cliente;
        }

        public IEnumerable<Cliente> ObterAtivos()
        {
            var clientes = _repository.ObterAtivos();

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

            var atualizou =_repository.Atualizar(cliente);

            return atualizou ? ObterClienteAtivo(id) : null;
        }

        public bool Inativar(long id)
        {
            var cliente = ObterClienteAtivo(id);

            if (cliente == null)
                return false;

            cliente.Inativar();

            return _repository.Inativar(cliente);
        }
    }
}

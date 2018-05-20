using Estudos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estudos.Data.Repository
{
    public class ClienteRepository
    {
        private readonly EstudosContext _context;

        public ClienteRepository(EstudosContext context)
        {
            _context = context;
        }

        public Cliente Cadastrar(Cliente cliente)
        {
            _context.Cliente.Add(cliente);
            var cadastrou = _context.SaveChanges();

            return cadastrou > 0 ? cliente : null;
        }

        public Cliente ObterCliente(long id)
        {
            return _context.Cliente.Find(id);
        }

        public Cliente ObterClienteAtivo(long id)
        {
            return _context.Cliente.Where(c => c.Ativo == true && c.Id == id).FirstOrDefault();
        }

        public IEnumerable<Cliente> ObterAtivos()
        {
            return _context.Cliente.Where(c => c.Ativo == true).ToList();
        }

        public bool Atualizar(Cliente cliente)
        {
            _context.Cliente.Update(cliente);
            var atualizou = _context.SaveChanges();

            return atualizou > 0 ? true : false;
        }

        public bool Inativar(Cliente cliente)
        {
            _context.Cliente.Update(cliente);
            var excluiu = _context.SaveChanges();

            return excluiu > 0 ? true : false;
        }
    }
}

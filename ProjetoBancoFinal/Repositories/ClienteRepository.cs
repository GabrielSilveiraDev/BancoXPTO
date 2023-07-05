using Microsoft.EntityFrameworkCore;
using ProjetoBancoFinal.Areas.Identity.Data;
using ProjetoBancoFinal.Models;

namespace ProjetoBancoFinal.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private BancoXPTOContext _context;

        public ClienteRepository(BancoXPTOContext context)
        {
            _context = context;
        }
        public void Atualizar(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
        }

        public Cliente BuscarPorConta(Conta conta)
        {
            return _context.Clientes.Where(c => c.Conta == conta).Include(c => c.Conta.ChavesPix).FirstOrDefault();
        }

        public Cliente BuscarPorId(string id)
        {
            return _context.Clientes.Where(c => c.Id == id).Include(c => c.Conta.ChavesPix).FirstOrDefault();
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }

        
    }
}

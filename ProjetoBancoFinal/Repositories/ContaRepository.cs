using ProjetoBancoFinal.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;
using ProjetoBancoFinal.Models;
using System.Linq.Expressions;

namespace ProjetoBancoFinal.Repositories
{
    public class ContaRepository : IContaRepository
    {
        private BancoXPTOContext _context;

        public ContaRepository(BancoXPTOContext context)
        {
            _context = context;
        }

        public void Atualizar(Conta conta)
        {
            _context.Contas.Update(conta);
        }

        public Conta BuscarPorId(int id)
        {
            return _context.Contas.Where(c => c.ContaId == id).FirstOrDefault();
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }


    }
}

using Microsoft.EntityFrameworkCore;
using ProjetoBancoFinal.Areas.Identity.Data;
using ProjetoBancoFinal.Models;
using System.Linq.Expressions;

namespace ProjetoBancoFinal.Repositories
{
    public class ChavePixRepository : IChavePixRepository
    {
        private BancoXPTOContext _context;

        public ChavePixRepository(BancoXPTOContext context)
        {
            _context = context;
        }

        public int BuscarContaId(int id)
        {
            ChavePix chavePix = _context.ChavesPix.Find(id);
            return chavePix.ContaId;

        }

        public IList<ChavePix> BuscarPor(Expression<Func<ChavePix, bool>> filtro)
        {
            return _context.ChavesPix.Where(filtro).ToList();
        }


        public void Cadastrar(ChavePix chavePix)
        {
            _context.ChavesPix.Add(chavePix);
        }

        public void Remover(int id)
        {
            ChavePix chavePix = _context.ChavesPix.Find(id);
            _context.ChavesPix.Remove(chavePix);
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}

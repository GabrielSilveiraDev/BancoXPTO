using ProjetoBancoFinal.Models;
using System.Linq.Expressions;

namespace ProjetoBancoFinal.Repositories
{
    public interface IChavePixRepository
    {
        IList<ChavePix> BuscarPor(Expression<Func<ChavePix, bool>> filtro);

        int BuscarContaId(int id);
        void Cadastrar(ChavePix chavePix );

        void Remover(int id);

        void Salvar();
    }
}

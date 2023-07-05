using ProjetoBancoFinal.Models;
using System.Linq.Expressions;

namespace ProjetoBancoFinal.Repositories
{
    public interface IContaRepository
    {
        Conta BuscarPorId(int id);
        void Atualizar(Conta conta);

        void Salvar();
    }
}

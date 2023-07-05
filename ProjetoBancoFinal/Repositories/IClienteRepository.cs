using ProjetoBancoFinal.Areas.Identity.Data;
using ProjetoBancoFinal.Models;

namespace ProjetoBancoFinal.Repositories
{
    public interface IClienteRepository
    {
        void Atualizar(Cliente cliente);

        Cliente BuscarPorId(string id);

        Cliente BuscarPorConta(Conta conta);

        void Salvar();
    }
}

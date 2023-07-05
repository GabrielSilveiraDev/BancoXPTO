using ProjetoBancoFinal.Areas.Identity.Data;
using ProjetoBancoFinal.Models;

namespace ProjetoBancoFinal.ViewModels
{
    public class ClienteChavePixViewModel
    {
        public Cliente? Cliente { get; set; }

        public decimal Valor { get; set; }

        public TipoChavePix TipoChave { get; set; }

        public string? Chave { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ProjetoBancoFinal.Models
{
    public class ChavePix
    {
        public int ChavePixId { get; set; }

        public string Chave { get; set; }

        public TipoChavePix Tipo { get; set; }

        //RN04 
        public Conta Conta { get; set; }

        public int ContaId { get; set; }

    }

    public enum TipoChavePix
    {
        [Display(Name = "CPF")] Cpf,
        [Display(Name = "E-mail")] Email,
        Telefone,
        [Display(Name = "Aleatório")] Aleatorio
    }
}

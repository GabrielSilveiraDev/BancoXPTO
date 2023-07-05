using System.ComponentModel.DataAnnotations;

namespace ProjetoBancoFinal.Models
{
    public abstract class Conta
    {
        public int ContaId { get; set; }

        public string? Numero { get; set; }

        public decimal Saldo { get; set; }

        public TipoConta Tipo { get; set; }

        public abstract void Transferir(decimal quantia);

        public abstract void Depositar(decimal quantia);

        //RN03
        public ICollection<ChavePix> ChavesPix { get; set; }

    }

    public enum TipoConta
    {
        Corrente, Poupanca
    }
}
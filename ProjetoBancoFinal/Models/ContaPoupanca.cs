namespace ProjetoBancoFinal.Models
{
    public class ContaPoupanca : Conta
    {
        public decimal TaxaRendimento { get; set; }

        public decimal AcrescentarRendimento(decimal quantia)
        {
            TaxaRendimento += quantia;
            return TaxaRendimento;
        }

        public override void Transferir(decimal quantia)
        {
            Saldo -= quantia;
        }

        public override void Depositar(decimal quantia)
        {
            Saldo += quantia;
        }
    }
}

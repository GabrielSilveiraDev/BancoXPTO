namespace ProjetoBancoFinal.Models
{
    public class ContaCorrente : Conta
    {
        public decimal TaxaManutencao { get; set; }
        
        public decimal DescontarTaxa(decimal quantia)
        {
            quantia = TaxaManutencao;
            Saldo -= quantia;
            return (Saldo);
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

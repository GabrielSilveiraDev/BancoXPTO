using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ProjetoBancoFinal.Models;

namespace ProjetoBancoFinal.Areas.Identity.Data;

// Add profile data for application users by adding properties to the Cliente class
public class Cliente : IdentityUser
{

    [Display(Name = "CPF")]
    public string Cpf { get; set; }

    public string Nome { get; set; }

    [Display(Name = "Data de Nascimento"), DataType(DataType.Date)]
    public DateTime DataNascimento { get; set; }

    public TipoCliente Tipo { get; set; }

    //1:1
    public Conta Conta { get; set; }

    public int ContaId { get; set; }

    public void ValidarTipo()
    {
        if (Conta.Saldo < 5000)
        {
            Tipo = TipoCliente.Comum;
        }
        else if (Conta.Saldo < 15000)
        {
            Tipo = TipoCliente.Super;
        }
        else
        {
            Tipo = TipoCliente.Premium;
        }
    }
}

public enum TipoCliente
{
    Comum, Super, Premium
}



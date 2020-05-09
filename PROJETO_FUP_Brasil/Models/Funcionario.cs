using ForeignKey_Email;
using Remake_FUP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PROJETO_FUP_Brasil.Models
{
    public class Funcionario
    {
        public int FuncionarioId { get; set; }
        public string NomeFuncionario { get; set; }
        public decimal SalarioFuncionario { get; set; }


        [InverseProperty("Funcionario")]
        public virtual Email Email { get; set; }

        [InverseProperty("Funcionario")]
        public Telefone Telefone { get; set; }

        [InverseProperty("Funcionario")]
        public virtual Financeiro Financeiro { get; set; }
    }
}

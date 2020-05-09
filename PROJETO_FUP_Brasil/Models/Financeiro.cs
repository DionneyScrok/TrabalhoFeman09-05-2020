using Remake_FUP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PROJETO_FUP_Brasil.Models
{
    public class Financeiro
    {
        public int FinanceiroId { get; set; }

        [InverseProperty("Financeiro")]
        public int AlunoID { get; set; }
        public Aluno Aluno { get; set; }

        [InverseProperty("Financeiro")]
        public int FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }
    }
}

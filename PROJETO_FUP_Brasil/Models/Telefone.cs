using PROJETO_FUP_Brasil.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Remake_FUP.Models
{
    public class Telefone
    {
        [Key]
        public int Id_Telefone { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Phone(ErrorMessage = "Telefone inválido")]
        public string _Telefone { get; set; }

        public int AlunoId { get; set; }
        [ForeignKey(nameof(AlunoId))]
        [InverseProperty("Telefone")]
        public Aluno Aluno { get; set; }


        public int FuncionarioID { get; set; }
        [ForeignKey(nameof(AlunoId))]
        [InverseProperty("Telefone")]
        public Funcionario Funcionario { get; set; }

    }
}

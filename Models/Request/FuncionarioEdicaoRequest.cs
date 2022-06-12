using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Services.Models.Request
{
    public class FuncionarioEdicaoRequest
    {
        [Required(ErrorMessage = "Por favor, informe o id do funcionário.")]
        public int IdFuncionario { get; set; }

        [Required(ErrorMessage = "Por favor, informe o nome do funcionário.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe o salário do funcionário.")]
        public decimal Salario { get; set; }

        [Required(ErrorMessage = "Por favor, informe a data de admissão do funcionário.")]
        public DateTime DataAdmissao { get; set; }
    }
}
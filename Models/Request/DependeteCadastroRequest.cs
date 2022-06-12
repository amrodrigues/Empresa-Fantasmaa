using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Services.Models.Request
{
    public class DependenteCadastroRequest
    {
        [Required(ErrorMessage = "Por favor, informe o nome do dependente.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe a data de nascimento de dependente.")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Por favor, informe o funcionário.")]
        public int IdFuncionario { get; set; }
    }
}
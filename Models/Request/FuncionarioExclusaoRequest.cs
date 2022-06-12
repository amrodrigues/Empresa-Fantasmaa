using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Services.Models.Request
{
    public class FuncionarioExclusaoRequest
    {
        [Required(ErrorMessage ="Por favor. informe o id do funcionário.")]
        public int IdFuncionario { get; set; }
    }
}
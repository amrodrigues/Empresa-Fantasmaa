using Projeto.Services.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.Services.Models.Response
{
    public class DependenteConsultaResponse
    {
        public int IdDependente { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }

        public int IdFuncionario { get; set; }

        public FuncionarioConsultaResponse Funcionario { get; set; }
    }
}
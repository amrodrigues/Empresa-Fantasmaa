using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entities;

namespace Projeto.Business.Contracts
{
    public interface IFuncionarioBusiness : IBaseBusiness<Funcionario>
    {
        List<Funcionario> ConsultaPorNome(string nome);
        List<Funcionario> ConsultarTodos();
    }
}

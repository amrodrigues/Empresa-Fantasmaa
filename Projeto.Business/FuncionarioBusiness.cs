using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entities;
using Projeto.Business.Contracts;
using Projeto.Repository.Contracts;

namespace Projeto.Business
{
   public class FuncionarioBusiness : BaseBusiness<Funcionario> , IFuncionarioBusiness
    {
        private IFuncionarioRepository repository;

        public FuncionarioBusiness(IFuncionarioRepository repository) : base(repository)
        {
            this.repository = repository;
        }
        public List<Funcionario> ConsultaPorNome(string nome)
        {
            return repository.FindByNome(nome);
        }

        public List<Funcionario> ConsultarTodos()
        {
            return repository.FindAll();
        }
    }
}

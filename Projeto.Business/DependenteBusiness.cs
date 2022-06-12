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
    public class DependenteBusiness : BaseBusiness<Dependente> , IDependenteBusiness
    {
        private IDependenteRepository repository;

        public DependenteBusiness(IDependenteRepository repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}

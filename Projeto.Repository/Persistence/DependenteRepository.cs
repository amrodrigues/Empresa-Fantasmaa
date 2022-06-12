using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Repository.Context;
using Projeto.Repository.Contracts;
using Projeto.Entities;
using System.Data.Entity;

namespace Projeto.Repository.Persistence
{
    public class DependenteRepository : BaseRepository<Dependente> , IDependenteRepository
    {
        public override List <Dependente> FindAll()
        {
            using (DataContext ctx = new DataContext())
            {
                return ctx.Dependente
                    .Include(d => d.Funcionario)
                    .ToList();
            }
        }

        public override Dependente FindById(int id)
        {
            using (DataContext ctx = new DataContext())
            {
                return ctx.Dependente
                    .Include(d => d.Funcionario)
                    .FirstOrDefault(d => d.IdDependente == id);
            }
        }
    }
}

using Projeto.Entities;
using Projeto.Repository.Context;
using Projeto.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Repository.Persistence
{
  public class FuncionarioRepository : BaseRepository<Funcionario> , IFuncionarioRepository 
    {
        public List<Funcionario> FindByNome(string nome)
        {
            using (DataContext ctx = new DataContext())
            {
                return ctx.Funcionario
                    .Where(f => f.Nome.Contains(nome))
                    .OrderBy(f => f.Nome)
                    .ToList();
            }
        }
    }
}

using Projeto.Entities;
using Projeto.Repository.Mappings;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Repository.Context
{
    // 1-- herdar DbContext
    public class DataContext :DbContext
    {
       //2 -- Consutrutor que envie para a superclasse (DbContext)
        //o caminho da connectionstring do banco de dados ..
        public DataContext() : base(ConfigurationManager.ConnectionStrings["aula"].ConnectionString)
        {

        }

        //3- Sobrescrever o método onModelCreating..
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // incluir cada classe de mapeamento ..
            modelBuilder.Configurations.Add(new DependenteMap());
            modelBuilder.Configurations.Add(new FuncionarioMap());
        }

        // 4-- Declarar uma propriedade DbSet para cada entidade
        public DbSet<Dependente> Dependente { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
    }
}

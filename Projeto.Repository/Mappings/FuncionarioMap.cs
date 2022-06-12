using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Projeto.Repository.Mappings
{
    public class FuncionarioMap : EntityTypeConfiguration<Funcionario>
    {
        public FuncionarioMap()
        {
            ToTable("Funcionario");

            HasKey(f => f.IdFuncionario);

            Property(f => f.IdFuncionario)
                .HasColumnName("IdFuncionario")
                .IsRequired();

            Property(f => f.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(50)
                .IsRequired();

            Property(f => f.Salario)
                .HasColumnName("Salario")
                .HasPrecision(18, 2)
                .IsRequired();

            Property(f => f.DataAdmissao)
                .HasColumnName("DataAdmissao")
                .IsRequired();
        }
    }
}

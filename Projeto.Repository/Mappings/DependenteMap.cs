using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Projeto.Repository.Mappings
{
    public class DependenteMap : EntityTypeConfiguration<Dependente>
    {
        public DependenteMap()
        {
            ToTable("Dependente");

            HasKey(d => d.IdDependente);

            Property(d => d.IdDependente)
                .HasColumnName("IdDependente")
                .IsRequired();

            Property(d => d.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(50)
                .IsRequired();

            Property(d => d.DataNascimento)
                .HasColumnName("DataNascimento")
                .IsRequired();

            HasRequired(d => d.Funcionario)
                .WithMany(f => f.Dependentes)
                .HasForeignKey(d => d.IdFuncionario);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entities
{
    public class Dependente
    {
        public int IdDependente { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public int IdFuncionario { get; set; } //chave estrangeira

        //Associação (TER-1)
        public Funcionario Funcionario { get; set; }

        public Dependente()
        {

        }

        public Dependente(int idDependente, string nome, DateTime dataNascimento)
        {
            IdDependente = idDependente;
            Nome = nome;
            DataNascimento = dataNascimento;
        }

        public override string ToString()
        {
            return $"Id: {IdDependente}, Nome: {Nome}, Data de Nascimento: {DataNascimento}";
        }
    }
}

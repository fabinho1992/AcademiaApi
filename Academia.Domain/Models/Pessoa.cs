using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Domain.Models
{
    public abstract class Pessoa
    {
        protected Pessoa(int id, string nome, string cpf,
            DateTime dataNascimento, DateTime dataCadastro, string endereco, int telefone)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            DataCadastro = dataCadastro;
            Endereco = endereco;
            Telefone = telefone;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public string Endereco { get; private set; }
        public int Telefone { get; private set; }
    }
}

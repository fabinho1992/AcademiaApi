using Academia.Domain.Models.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Domain.Models
{
    public sealed class Aluno : Pessoa
    {
        public Aluno(int id, string nome, string cpf,
            DateTime dataNascimento, DateTime dataCadastro, string endereco, int telefone) :
            base(id, nome, cpf, dataNascimento, dataCadastro, endereco, telefone)
        {
        }

        public Plano Plano { get; set; }
        public double Altura { get; set; }
        public double Peso { get; set; }

    }
}

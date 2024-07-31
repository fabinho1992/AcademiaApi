using Academia.Domain.Models.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Domain.Models
{
    public sealed class Professor : Pessoa
    {
        public Professor(int id, string nome, string cpf,
            DateTime dataNascimento, DateTime dataCadastro, string endereco, int telefone) :
            base(id, nome, cpf, dataNascimento, dataCadastro, endereco, telefone)
        {
        }

        public string? Experiencia { get; set; }
        public Status Status { get; set; }
    }
}

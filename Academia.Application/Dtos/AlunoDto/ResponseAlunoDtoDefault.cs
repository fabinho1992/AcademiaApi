using Academia.Domain.Models.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Application.Dtos.AlunoDto
{
    public class ResponseAlunoDtoDefault
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public Plano Plano { get; set; }
        public double Altura { get; set; }
        public double Peso { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Application.Dtos.PessoaDto
{
    public abstract class RequestPessoa
    {

        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public string Endereco { get; set; }
        [Required]
        //[Range(9, 11, ErrorMessage = "Digite um telefone válido, com ou sem o prefixo.")]
        public string Telefone { get; set; }
        
    }
}

using Academia.Domain.Models.Enuns;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Application.Dtos.AlunoDto
{
    public class PutAlunoDto
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe o Nome do aluno.")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Informe o Cpf do aluno.")]
        [MaxLength(11, ErrorMessage = "Cpf tem que ter no máximo 11 caracteres.")]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "Informe um email válido.")]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; }
        [DataType(DataType.Date)]
        [Required]
        public DateTime DataNascimento { get; set; }
        [DataType(DataType.Date)]
        [Required]
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        [Required]
        [MaxLength(150)]
        public string Endereco { get; set; }
        [Required]
        //[Range(9, 11, ErrorMessage = "Digite um telefone válido, com ou sem o prefixo.")]
        public int Telefone { get; set; }
        [Required]
        public Plano Plano { get; set; }
        [Required]
        [Range(1, 3)]
        public double Altura { get; set; }
        [Required]
        [Range(40, 300, ErrorMessage = "Peso deve ser entre 40 e 300 kilos.")]
        public double Peso { get; set; }
    }
}

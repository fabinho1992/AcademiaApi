using Academia.Application.Dtos.PessoaDto;
using Academia.Domain.Models.Enuns;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Application.Dtos.AlunoDto
{
    public class PutAlunoDto : RequestAlunoDto
    {
        [Required]
        public int Id { get; set; }
        //[Required]
        //public Plano Plano { get; set; }
        //[Required]
        //[Range(1, 3)]
        //public double Altura { get; set; }
        //[Required]
        //[Range(40, 300, ErrorMessage = "Peso deve ser entre 40 e 300 kilos.")]
        //public double Peso { get; set; }
    }
}

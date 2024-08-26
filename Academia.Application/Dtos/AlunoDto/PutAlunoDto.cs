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
        
    }
}

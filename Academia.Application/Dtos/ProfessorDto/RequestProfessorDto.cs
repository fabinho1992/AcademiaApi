using Academia.Application.Dtos.PessoaDto;
using Academia.Domain.Models.Enuns;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Application.Dtos.ProfessorDto
{
    public class RequestProfessorDto : RequestPessoa
    {
        [Required]
        [MaxLength(200)]
        public string? Experiencia { get; set; }
        [Required]
        public Status Status { get; set; }
    }
}

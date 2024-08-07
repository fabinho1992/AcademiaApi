using Academia.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Application.Dtos.ExameFisicoDto
{
    public class RequestExameFisicoDto
    {
        
        [Required]
        [DataType(DataType.Date)]
        public DateTime DataExame { get; set; }
        [Required]
        public int AlunoId { get; set; }
        [Required]
        public int ProfessorId { get; set; }

        
    }
}

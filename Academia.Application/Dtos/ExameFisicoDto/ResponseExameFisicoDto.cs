using Academia.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Application.Dtos.ExameFisicoDto
{
    public class ResponseExameFisicoDto
    {
        public int Id { get; set; }
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double Imc { get; set; }
        public DateTime DataExame { get; set; }
        public string? Aluno { get; set; }
        public string? Professor { get; set; }

    }
}

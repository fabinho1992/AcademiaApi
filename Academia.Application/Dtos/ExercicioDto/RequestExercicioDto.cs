using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Application.Dtos.ExercicioDto
{
    public class RequestExercicioDto
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }
        [Required]
        public int Serie { get; set; }
        [Required]
        public int Repeticao { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Musculo deve ter no máximo 100 caracteres.")]
        public string Musculo { get; set; }
    }
}

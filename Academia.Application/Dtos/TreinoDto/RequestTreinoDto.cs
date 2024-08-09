using Academia.Application.Dtos.ExercicioDto;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Application.Dtos.TreinoDto
{
    public class RequestTreinoDto
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Nome deve ter no máximo 100 caracteres.")]
        public string? Nome { get; set; }
        [Required]
        [MaxLength(180)]
        public string? Descricao { get; set; }
        [Required]
        public int AlunoId { get; set; }
        public ICollection<ExercicioReferenciaDto> Exercicios { get; set; } = new Collection<ExercicioReferenciaDto>();
    }
}

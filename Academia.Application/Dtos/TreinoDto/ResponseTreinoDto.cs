using Academia.Application.Dtos.AlunoDto;
using Academia.Application.Dtos.ExercicioDto;
using Academia.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Application.Dtos.TreinoDto
{
    public class ResponseTreinoDto
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public string Aluno { get; set; }
        public ICollection<ResponseExercicioDto> Exercicios { get; set; } = new Collection<ResponseExercicioDto>();
    }
}

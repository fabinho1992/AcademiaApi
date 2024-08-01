using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Domain.Models
{
    public class TreinoExercicio
    {
        public int TreinoId { get; set; }
        public Treino Treino { get; set; }

        public int ExercicioId { get; set; }
        public Exercicio Exercicio { get; set; }
    }
}

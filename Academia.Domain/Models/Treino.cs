using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Domain.Models
{
    public sealed class Treino
    {
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public ICollection<Exercicio>? Exercicios { get; set; }
    }
}

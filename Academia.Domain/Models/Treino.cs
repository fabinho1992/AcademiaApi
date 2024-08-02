using System.Collections.ObjectModel;

namespace Academia.Domain.Models
{
    public sealed class Treino
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }
        public ICollection<Exercicio> Exercicios { get; set; } = new Collection<Exercicio>();
    }
}

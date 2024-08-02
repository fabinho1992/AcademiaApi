using System.Collections.ObjectModel;

namespace Academia.Domain.Models
{
    public sealed class Exercicio
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Serie { get; set; }
        public int Repeticao { get; set; }
        public string Musculo { get; set; }
        public ICollection<Treino> Treinos { get; set; } = new Collection<Treino>();
    }
}

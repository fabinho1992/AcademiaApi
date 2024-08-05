using Academia.Domain.Models.Enuns;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace Academia.Domain.Models
{
    public sealed class Aluno : Pessoa
    {

        public Plano Plano { get; set; }
        public double Altura { get; set; }
        public double Peso { get; set; }
        [JsonIgnore]
        public ICollection<ExameFisico> ExamesFisicos { get; set; } = new Collection<ExameFisico>();
        [JsonIgnore]
        public ICollection<Treino> Treinos { get; set; } = new Collection<Treino>();

    }
}

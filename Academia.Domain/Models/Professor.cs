using Academia.Domain.Models.Enuns;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace Academia.Domain.Models
{
    public sealed class Professor : Pessoa
    {

        public string? Experiencia { get; set; }
        public Status Status { get; set; }
        public ICollection<ExameFisico> ExamesFisicos { get; set; } = new Collection<ExameFisico>();
    }
}

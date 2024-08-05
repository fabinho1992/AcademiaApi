using Academia.Domain.Models.Enuns;
using System.Collections.ObjectModel;

namespace Academia.Domain.Models
{
    public sealed class Professor : Pessoa
    {

        public string? Experiencia { get; set; }
        public Status Status { get; set; }
        public ICollection<ExameFisico> ExamesFisicos { get; set; } = new Collection<ExameFisico>();
    }
}

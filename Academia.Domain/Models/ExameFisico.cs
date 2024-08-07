using System.Text.Json.Serialization;

namespace Academia.Domain.Models
{
    public sealed class ExameFisico
    {
        public int Id { get; set; }
        public double Imc { get; set; }
        public DateTime DataExame { get; set; }
        public int AlunoId { get; set; }
        public Aluno? Aluno { get; set; }
        public int ProfessorId { get; set; }
        public Professor? Professor { get; set; }

        
    }
}

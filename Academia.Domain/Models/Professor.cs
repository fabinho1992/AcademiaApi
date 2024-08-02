using Academia.Domain.Models.Enuns;
using System.Collections.ObjectModel;

namespace Academia.Domain.Models
{
    public sealed class Professor : Pessoa
    {
        public Professor(int id, string nome, string cpf,
            DateTime dataNascimento, DateTime dataCadastro, string endereco, int telefone) :
            base(id, nome, cpf, dataNascimento, dataCadastro, endereco, telefone)
        {
        }

        public string? Experiencia { get; set; }
        public Status Status { get; set; }
        public ICollection<ExameFisico> ExamesFisicos { get; set; } = new Collection<ExameFisico>();
    }
}

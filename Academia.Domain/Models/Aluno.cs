using Academia.Domain.Models.Enuns;
using System.Collections.ObjectModel;

namespace Academia.Domain.Models
{
    public sealed class Aluno : Pessoa
    {
        public Aluno(int id, string nome, string cpf,
            DateTime dataNascimento, DateTime dataCadastro, string endereco, int telefone) :
            base(id, nome, cpf, dataNascimento, dataCadastro, endereco, telefone)
        {
        }

        public Plano Plano { get; set; }
        public double Altura { get; set; }
        public double Peso { get; set; }
        public ICollection<ExameFisico> ExamesFisicos { get; set; } = new Collection<ExameFisico>();
        public ICollection<Treino> Treinos { get; set; } = new Collection<Treino>();

    }
}

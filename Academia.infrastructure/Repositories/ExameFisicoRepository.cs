using Academia.Domain.Interfaces;
using Academia.Domain.Models;
using Academia.infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Academia.infrastructure.Repositories
{
    public class ExameFisicoRepository : IExameFisicoService
    {
        private readonly AppDbContext _context;

        public ExameFisicoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ExameFisico>> GetAll()
        {
            var exames = await _context.ExamesFisicos.Include(x => x.Aluno)
                .Include(x => x.Professor).AsTracking().ToListAsync();
            return exames;
        }

        public async Task<ExameFisico> GetById(int id)
        {
            var exame = await _context.ExamesFisicos.FirstOrDefaultAsync(x => x.Id == id);
            return exame;
        }

        public async Task<IEnumerable<ExameFisico>> GetCpf(string cpf)
        {
            return await _context.ExamesFisicos.Where(a => a.Aluno.Cpf.Equals(cpf)).Include(x => x.Aluno).Include(x => x.Professor).ToListAsync();
        }

        public async Task<ExameFisico> Post(ExameFisico entity)
        {
            var aluno = await _context.Alunos.FindAsync(entity.AlunoId);
            
            var exameNovo = new ExameFisico()
            {
                DataExame = entity.DataExame,
                ProfessorId = entity.ProfessorId,
                AlunoId = entity.AlunoId,
                Imc = aluno.Peso / (aluno.Altura * aluno.Altura)
            };            
            await _context.ExamesFisicos.AddAsync(exameNovo);
            return entity;
        }

        public void Delete (ExameFisico exameFisico)
        {
            _context.ExamesFisicos.Remove(exameFisico);
        }
    }
}

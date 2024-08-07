using Academia.Application.Dtos.ExameFisicoDto;
using Academia.Domain.Interfaces;
using Academia.Domain.Models;
using Academia.infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                .Include(x => x.Professor).ToListAsync();
            return exames;
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
    }
}

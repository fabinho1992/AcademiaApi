using Academia.Application.Dtos.AlunoDto;
using Academia.Domain.Interfaces;
using Academia.Domain.Models;
using Academia.infrastructure.Context;
using Academia.infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.infrastructure.Repositories
{
    public class AlunoRepository : RepositoryBase<Aluno>, IAlunoService
    {
        public AlunoRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Aluno> GetIdExames(int id)
        {
            var aluno = await _context.Alunos.Include(e => e.ExamesFisicos)
                .ThenInclude(p => p.Professor).FirstOrDefaultAsync(a => a.Id == id);
            return aluno; 
        }

        public async Task<IEnumerable<Aluno>> GetPaginado(AlunosPaginado alunosPaginado)
        {
            var alunos = await _context.Alunos
                .OrderBy(a => a.Id)
                .Skip((alunosPaginado.PageNumber - 1) * alunosPaginado.PageSize)
                .Take(alunosPaginado.PageSize).ToListAsync();

            return alunos;
        }
    }
}

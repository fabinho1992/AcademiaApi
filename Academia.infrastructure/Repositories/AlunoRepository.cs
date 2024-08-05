using Academia.Domain.Interfaces;
using Academia.Domain.Models;
using Academia.infrastructure.Context;
using Academia.infrastructure.Repositories.Base;
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
    }
}

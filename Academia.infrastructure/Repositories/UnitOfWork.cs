using Academia.Domain.Interfaces;
using Academia.infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.infrastructure.Repositories
{
    public class UnitOfWork : IUnitofWork
    {
        private IAlunoService? _alunoService;
        
        public AppDbContext _appDbContext;

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IAlunoService AlunoService
        {
            get
            {
                return _alunoService = _alunoService ?? new AlunoRepository(_appDbContext);
            }
        }

        public async Task Commit()
        {
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Dispose()
        {
            await _appDbContext.DisposeAsync();
        }
    }
}

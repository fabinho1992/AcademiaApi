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
        private IProfessorService? _professorService;
        private IExameFisicoService? _exameFisicoService;
        private IExercicioService? _exercicioService;
        private ITreinoService? _treinoService;
        
        
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

        public IProfessorService ProfessorService
        {
            get
            {
                return _professorService = _professorService ?? new ProfessorRepository(_appDbContext);
            }
        }

        public IExameFisicoService ExameFisicoService
        {
            get
            {
                return _exameFisicoService = _exameFisicoService ?? new ExameFisicoRepository(_appDbContext);
            }
        }

        public IExercicioService ExercicioService
        {
            get
            {
                return _exercicioService = _exercicioService ?? new ExercicioRepository(_appDbContext);
            }
        }

        public ITreinoService TreinoService
        {
            get
            {
                return _treinoService = _treinoService ?? new TreinoRepository(_appDbContext);  
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

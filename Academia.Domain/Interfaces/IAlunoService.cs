using Academia.Application.Dtos.AlunoDto;
using Academia.Domain.Interfaces.Generic;
using Academia.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Domain.Interfaces
{
    public interface IAlunoService : IGeneric<Aluno>
    {
        Task<IEnumerable<Aluno>> GetPaginado(AlunosPaginado alunosPaginado);
    }
}

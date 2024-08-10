using Academia.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Domain.Interfaces
{
    public interface ITreinoService
    {
        Task<Treino> Post(Treino treino);
        Task<IEnumerable<Treino>> GetAll();
        Task<Treino> GetId(int id);
        Task Delete(Treino treino);
    }
}

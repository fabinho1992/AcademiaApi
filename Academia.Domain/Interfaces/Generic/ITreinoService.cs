using Academia.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Domain.Interfaces.Generic
{
    public interface ITreinoService
    {
        Task<Treino> Post(Treino treino);
        Task<Treino> GetId(int id);
    }
}

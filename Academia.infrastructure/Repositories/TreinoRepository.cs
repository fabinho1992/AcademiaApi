using Academia.Domain.Interfaces.Generic;
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
    public class TreinoRepository : ITreinoService
    {
        private readonly AppDbContext _context;

        public TreinoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Treino> GetId(int id)
        {
            var treino = await _context.Treinos.Include(x => x.Aluno)
                .Include(x => x.Exercicios).FirstOrDefaultAsync(t => t.Id == id);
            return treino;
        }

        public async Task<Treino> Post(Treino treino)
        {
            await InsertMedicoEspecilidades(treino);
            await _context.Treinos.AddAsync(treino);
            return treino;
        }

        private async Task InsertMedicoEspecilidades(Treino treino)
        {
            var especialidadesConsultadas = new List<Exercicio>();
            foreach (var especialidade in treino.Exercicios)
            {
                var exercicioConsultado = await _context.Exercicios.FindAsync(especialidade.Id);
                especialidadesConsultadas.Add(exercicioConsultado);
            }
            treino.Exercicios = especialidadesConsultadas;


        }
    }
}

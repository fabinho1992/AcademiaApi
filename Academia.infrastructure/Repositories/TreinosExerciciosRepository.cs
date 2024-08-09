using Academia.Domain.Interfaces;
using Academia.Domain.Models;
using Academia.infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.infrastructure.Repositories
{
    public class TreinosExerciciosRepository 
    {
        private readonly AppDbContext _context;

        public TreinosExerciciosRepository(AppDbContext context)
        {
            _context = context;
        }

        
    }
}

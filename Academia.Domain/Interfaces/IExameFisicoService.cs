using Academia.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Domain.Interfaces
{
    public interface IExameFisicoService
    {
        Task<ExameFisico> Post(ExameFisico exameFisico);
        Task<IEnumerable<ExameFisico>> GetAll();
        Task<IEnumerable<ExameFisico>> GetCpf(string cpf);
        Task<ExameFisico> GetById(int id);
        void Delete(ExameFisico exameFisico);
        
    }
}

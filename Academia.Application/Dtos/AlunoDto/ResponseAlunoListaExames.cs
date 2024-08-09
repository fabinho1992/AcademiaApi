using Academia.Application.Dtos.ExameFisicoDto;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Application.Dtos.AlunoDto
{
    public class ResponseAlunoListaExames
    {
        public string Nome { get; set; }
        public ICollection<ResponseExameFisicoDto> Exames { get; set; } = new Collection<ResponseExameFisicoDto>();
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Application.Dtos.ProfessorDto
{
    public class PutProfessorDto : RequestProfessorDto
    {
        [Required]
        public int Id { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.infrastructure.Identity.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Cpf obrigatório!!")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Password obrigatório!!")]
        public string? Password { get; set; }
    }
}

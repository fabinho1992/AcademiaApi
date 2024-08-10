using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.infrastructure.Identity.Models
{
    public class RegisterUser
    {
        [Required(ErrorMessage = "UserName obrigatório!!")]
        public string? UserName { get; set; }
        [Required]
        [MaxLength(11, ErrorMessage = "Cpf deve ter no máximo 11 caracteres")]
        public string Cpf { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Email obrigatório!!")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Password obrigatório!!")]
        public string? Password { get; set; }

    }
}

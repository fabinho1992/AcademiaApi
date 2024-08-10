using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.infrastructure.Identity.Models
{
    public class AppUser : IdentityUser
    {
        public string Cpf { get; set; }
    }
}

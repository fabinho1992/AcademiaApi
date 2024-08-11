using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.infrastructure.Identity.Models
{
    public class ResponseIdentityLogin : ResponseIdentityCreate
    {
        public string? Token { get; set; }
        public DateTime Expired { get; set; }
    }
}

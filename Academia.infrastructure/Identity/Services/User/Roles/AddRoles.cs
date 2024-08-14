using Academia.infrastructure.Identity.Models;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.infrastructure.Identity.Services.User.Roles
{
    public class AddRoles
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public AddRoles(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<ResponseRoles> AdicionarRoles(string userEmail, string roleName)
        {
            var user = await _userManager.FindByEmailAsync(userEmail);

            if (user is not null)
            {
                var roleAdd = await _userManager.AddToRoleAsync(user, roleName);

                if (roleAdd.Succeeded)
                {
                    return new ResponseRoles { Status = "200", Message = $"user {user.Email} added to role {roleName} successfully" };
                }
                else
                {
                    return new ResponseRoles { Status = "400", Message = "error adding user to role.." };
                }
            }
            return new ResponseRoles { Status = "404", Message = $"User {userEmail} not found.." };
        }
    }
}

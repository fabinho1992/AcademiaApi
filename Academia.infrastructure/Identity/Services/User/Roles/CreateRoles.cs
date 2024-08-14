using Academia.infrastructure.Context;
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
    public class CreateRoles
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public CreateRoles(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<ResponseRoles> CreateRole(string roleName)
        {
            var roleExiste = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExiste)
            {
                var role = await _roleManager.CreateAsync(new IdentityRole(roleName));

                if (role.Succeeded)
                {
                    return new ResponseRoles { Message = $"Role - {roleName} created successfully!", Status = "200" };
                }
                else
                {
                    return new ResponseRoles { Status = "400", Message = "Error creating role.." };
                }
            }

            return new ResponseRoles { Status = "409", Message = "role already exists" };
        }
    }

 
    }


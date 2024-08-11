using Academia.infrastructure.Identity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.infrastructure.Identity.Services.User
{
    public class CreateUser
    {
        private readonly UserManager<AppUser> _userManager;

        public CreateUser(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ResponseIdentityCreate> CreateUserAsync(RegisterUser registerUser)
        {
            var usuarioExiste = await _userManager.FindByNameAsync(registerUser.UserName!);//consulto se o nome passado exite no banco

            if (usuarioExiste != null)
            {
                return new ResponseIdentityCreate { Status = "Erro", Message = "User already exists!" };// se existir passo esse erro
            }
            AppUser user = new()
            {
                UserName = registerUser.UserName,
                Email = registerUser.Email,
                Cpf = registerUser.Cpf,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var resultado = await _userManager.CreateAsync(user, registerUser.Password!);//crio o usuario

            if (!resultado.Succeeded)
            {
                return new ResponseIdentityCreate { Message = "Erro", Status = "Error creating user" };
            }

            return new ResponseIdentityCreate { Status = "Ok", Message = "User created successfully" };
        }
    }
}

using Academia.infrastructure.Identity.Models;
using Academia.infrastructure.Identity.Services.Token;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Academia.infrastructure.Identity.Services.User
{
    public class LoginUser
    {
        private ITokenService _tokenService;
        private UserManager<AppUser> _userManager;
        private IConfiguration _configuration;

        public LoginUser(ITokenService tokenService, UserManager<AppUser> userManager, IConfiguration configuration)
        {
            _tokenService = tokenService;
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<ResponseIdentityLogin> LoginAsync(Login login)
        {
            var usuario = await _userManager.FindByEmailAsync(login.Email!);

            if (usuario is not null && await _userManager.CheckPasswordAsync(usuario, login.Password!))
            {
                //aqui armazeno os perfis do usuario
                var usuarioRoles = await _userManager.GetRolesAsync(usuario);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usuario.UserName!),
                    new Claim(ClaimTypes.Email, usuario.Email!),
                    new Claim("id", usuario.UserName!),
                    new Claim("cpf", usuario.Cpf),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                foreach (var usuarioRole in usuarioRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, usuarioRole));
                }

                var token = _tokenService.GenerationAcessToken(authClaims, _configuration);//gero o token

                await _userManager.UpdateAsync(usuario);//atualizo o banco de dados com o usuario

                return new ResponseIdentityLogin
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expired = token.ValidTo,
                    Status = "Sucess 200",
                    Message = "Token Generated Successfully"
                };
            }
            return new ResponseIdentityLogin
            {
                Status = "Bad Request 400",
                Message = "error generating token"
            };

        }


    }
}


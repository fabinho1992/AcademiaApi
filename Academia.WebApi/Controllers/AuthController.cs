using Academia.infrastructure.Identity.Models;
using Academia.infrastructure.Identity.Services.Token;
using Academia.infrastructure.Identity.Services.User;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Academia.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly CreateUser _createUser;
        private readonly LoginUser _loginUser;

        public AuthController(CreateUser createUser, LoginUser loginUser)
        {
            _createUser = createUser;
            _loginUser = loginUser;
        }

        /// <summary>
        /// Registra o Usuario
        /// </summary>
        /// <param name="registerUser"></param>
        /// <returns>Status Code 200, Usuario criado</returns>
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUser registerUser)
        {
            #region Direto na controller
            //var usuarioExiste = await _userManager.FindByNameAsync(registerUser.UserName!);//consulto se o nome passado exite no banco

            //if (usuarioExiste != null)
            //{
            //    return StatusCode(StatusCodes.Status500InternalServerError,
            //        new ResponseIdentityCreate { Status = "Erro", Message = "User already exists!" });// se existir passo esse erro
            //}
            //AppUser user = new()
            //{
            //    UserName = registerUser.UserName,
            //    Email = registerUser.Email,
            //    Cpf = registerUser.Cpf,
            //    SecurityStamp = Guid.NewGuid().ToString()
            //};

            //var resultado = await _userManager.CreateAsync(user, registerUser.Password!);//crio o usuario

            //if (!resultado.Succeeded)
            //{
            //    return StatusCode(StatusCodes.Status500InternalServerError,
            //        new ResponseIdentityCreate { Status = "Erro!", Message = "User creation failed" });
            //}

            //return Ok(new ResponseIdentityCreate { Status = "Ok", Message = "User created successfully" });
            #endregion
            
            var usuario = await _createUser.CreateUserAsync(registerUser);
            return Ok(usuario);
        }

        /// <summary>
        /// Verifica credências do usuario
        /// </summary>
        /// <param name="loginDto">Objeto Login</param>
        /// <returns>Status Code 200 e Token de acesso do usuario</returns>
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] Login loginDto)
        {
            var login = await _loginUser.LoginAsync(loginDto);
            return Ok(login);
           
            
            #region Direto na controller
            //var usuario = await _userManager.FindByEmailAsync(loginDto.Email!);

            //if (usuario is not null && await _userManager.CheckPasswordAsync(usuario, loginDto.Password!))
            //{
            //    //aqui armazeno os perfis do usuario
            //    var usuarioRoles = await _userManager.GetRolesAsync(usuario);

            //    var authClaims = new List<Claim>
            //    {
            //        new Claim(ClaimTypes.Name, usuario.UserName!),
            //        new Claim(ClaimTypes.Email, usuario.Email!),
            //        new Claim("id", usuario.UserName!),
            //        new Claim("cpf", usuario.Cpf),
            //        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            //    };

            //    foreach (var usuarioRole in usuarioRoles)
            //    {
            //        authClaims.Add(new Claim(ClaimTypes.Role, usuarioRole));
            //    }

            //    var token = _tokenService.GenerationAcessToken(authClaims, _configuration);//gero o token

            //    await _userManager.UpdateAsync(usuario);//atualizo o banco de dados com o usuario

            //    return Ok(new
            //    {
            //        Token = new JwtSecurityTokenHandler().WriteToken(token),
            //        Expired = token.ValidTo
            //    });
            //}
            //return Unauthorized();
            #endregion
            
        }
    }
}

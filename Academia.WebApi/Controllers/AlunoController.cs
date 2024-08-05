using Academia.Domain.Interfaces;
using Academia.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Academia.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {

        private readonly IUnitofWork _context;
        

        public AlunoController(IUnitofWork context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Aluno aluno)
        {
            var alunoNovo =  new Aluno
            {
                Nome = aluno.Nome,
                Cpf = aluno.Cpf,
                Endereco = aluno.Endereco,
                Altura = aluno.Altura,
                DataCadastro = aluno.DataCadastro,
                DataNascimento = aluno.DataNascimento,
                Peso = aluno.Peso,
                Plano = aluno.Plano,
                Telefone = aluno.Telefone,
                Email = aluno.Email

            };

            await _context.AlunoService.Create(alunoNovo);
            await _context.Commit();

            return Ok(alunoNovo);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var alunos = await _context.AlunoService.GetAll();
            return Ok(alunos);
        }
    }
}

using Academia.Application.Dtos.AlunoDto;
using Academia.Application.Services;
using Academia.Domain.Interfaces;
using Academia.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace Academia.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {

        private readonly IUnitofWork _context;
        private readonly IMapper _mapper;


        public AlunoController(IUnitofWork context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Endpoint exclusivo para Admin
        /// </summary>
        /// <param name="alunoDto"></param>
        /// <returns>Status Code 201 e um email de confirmação de cadastro</returns>
        //[Authorize(Policy = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Post(RequestAlunoDto alunoDto)
        {
            if (alunoDto is null)
            {
                return BadRequest("Insira os dados corretos.");
            }
            var alunoNovo = _mapper.Map<Aluno>(alunoDto);
            await _context.AlunoService.Create(alunoNovo);
            EmailService.SendConfirmationEmail(alunoNovo.Email, alunoNovo.Nome);
            
            await _context.Commit();


            return new CreatedAtRouteResult("GetAluno", new { id = alunoNovo.Id }, alunoNovo);
        }

        [Authorize(Policy = "User")]
        [Authorize(Policy = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var alunos = await _context.AlunoService.GetAll();
            if(alunos is null)
            {
                return BadRequest("Nenhum aluno encontrado.");
            }

            var alunosDto = _mapper.Map<IEnumerable<ResponseAlunoDtoDefault>>(alunos);
            return Ok(alunosDto);
        }

        [Authorize(Policy = "User")]
        [Authorize(Policy = "Admin")]
        [HttpGet("{id}", Name = "GetAluno")]
        public async Task<IActionResult> GetById(int? id)
        {
            var aluno = await _context.AlunoService.Get(a => a.Id == id);
            if(id is null || id < 0)
            {
                return BadRequest("Id inválido!");
            }
            if (aluno is null)
            {
                return NotFound($"Aluno com o Id = {id} não existe!");
            }

            var alunoResponse = _mapper.Map<ResponseAlunoDtoDefault>(aluno);
            return Ok(alunoResponse);
        }

        [Authorize(Policy = "User")]
        [Authorize(Policy = "Admin")]
        [HttpGet("AlunosPaginados")]
        public async Task<IActionResult> GetAllPaginado([FromQuery]AlunosPaginado alunosPaginado)
        {
            var alunos = await _context.AlunoService.GetPaginado(alunosPaginado);
            if(alunos is null)
            {
                return NotFound("Alunos não encontrados!");
            }
            var alunosDto = _mapper.Map<IEnumerable<ResponseAlunoDtoDefault>>(alunos);
            return Ok(alunosDto);

        }

        [Authorize(Policy = "User")]
        [Authorize(Policy = "Admin")]
        [HttpGet("AlunosListaExames")]
        public async Task<IActionResult> GetAlunosExames(int id)
        {
            var aluno = await _context.AlunoService.GetIdExames(id);
            if (id < 0)
            {
                return BadRequest("Id inválido!");
            }
            if (aluno is null)
            {
                return NotFound($"Aluno com o Id = {id} não existe!");
            }
            var alunoDto = _mapper.Map<ResponseAlunoListaExames>(aluno);
            return Ok(alunoDto);
        }

        /// <summary>
        /// Endpoint exclusivo para Admin
        /// </summary>
        /// <param name="id"></param>
        /// <param name="alunoDto"></param>
        /// <returns></returns>
        [Authorize(Policy = "Admin")]
        [HttpPut]
        public async Task<IActionResult> Update(int id, PutAlunoDto alunoDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != alunoDto.Id)
            {
                return BadRequest("Id incorreto!");
            }
            var aluno = _mapper.Map<Aluno>(alunoDto);
            await _context.AlunoService.Update(aluno);
            return Ok(aluno);
        }

        /// <summary>
        /// Endpoint exclusivo para Admin
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Policy = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var aluno = await _context.AlunoService.Get(x => x.Id == id);
            if (aluno is null)
            {
                return BadRequest("Id de aluno não existe!");
            }
            await _context.AlunoService.Delete(aluno);
            await _context.Commit();
            return Ok("Dados do aluno deletado!");
        }
    }
}

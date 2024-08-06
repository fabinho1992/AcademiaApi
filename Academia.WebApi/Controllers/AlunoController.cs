using Academia.Application.Dtos.AlunoDto;
using Academia.Domain.Interfaces;
using Academia.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Academia.WebApi.Controllers
{
    [Route("api/[controller]")]
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

        [HttpPost]
        public async Task<IActionResult> Post(RequestAlunoDto alunoDto)
        {
            var alunoNovo = _mapper.Map<Aluno>(alunoDto);
            await _context.AlunoService.Create(alunoNovo);
            await _context.Commit();

            return Ok(alunoNovo);
        }

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
    }
}

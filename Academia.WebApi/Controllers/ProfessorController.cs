using Academia.Application.Dtos.AlunoDto;
using Academia.Application.Dtos.ProfessorDto;
using Academia.Domain.Interfaces;
using Academia.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Academia.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IUnitofWork _context;
        private readonly IMapper _mapper;

        public ProfessorController(IUnitofWork context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post(RequestProfessorDto professorDto)
        {
            if (professorDto is null)
            {
                return BadRequest("Insira os dados corretos. ");
            }
            var professor = _mapper.Map<Professor>(professorDto);
            await _context.ProfessorService.Create(professor);
            await _context.Commit();
            return new CreatedAtRouteResult("GetById", new { id = professor.Id }, professor);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var professores = await  _context.ProfessorService.GetAll();
            if (professores is null )
            {
                return BadRequest("Nenhum cadastro encontrado!");
            }
            var profDto = _mapper.Map<IEnumerable<ResponseProfessorDefault>>(professores);
            return Ok(profDto);
        }

        [HttpGet("{id}", Name = "GetById")]
        public async Task<IActionResult> GetById(int? id)
        {
            
            if (id is null || id < 0)
            {
                return BadRequest("Id inválido!");
            }
            var prof = await _context.ProfessorService.Get(a => a.Id == id);
            if (prof is null)
            {
                return NotFound($"Professor com o Id = {id} não existe!");
            }

            var profResponse = _mapper.Map<ResponseProfessorDefault>(prof);
            return Ok(profResponse);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, PutProfessorDto profDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != profDto.Id)
            {
                return BadRequest("Id incorreto!");
            }
            var profAtualizado = _mapper.Map<Professor>(profDto);
            await _context.ProfessorService.Update(profAtualizado);
            return Ok(profAtualizado);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var prof = await _context.ProfessorService.Get(x => x.Id == id);
            if (prof is null)
            {
                return BadRequest("Id de aluno não existe!");
            }
            await _context.ProfessorService.Delete(prof);
            await _context.Commit();
            return Ok("Dados do professor deletado!");
        }
    }
}

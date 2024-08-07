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
            return Ok();
        }
    }
}

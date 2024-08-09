using Academia.Application.Dtos.ExercicioDto;
using Academia.Domain.Interfaces;
using Academia.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Academia.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ExercicioController : ControllerBase
    {
        private readonly IUnitofWork _context;
        private readonly IMapper _mapper;

        public ExercicioController(IUnitofWork context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post(RequestExercicioDto exercicioDto)
        {
            if (exercicioDto is null)
            {
                return BadRequest("Isira dados validos.");
            }
            var exercicio = _mapper.Map<Exercicio>(exercicioDto);
            await _context.ExercicioService.Create(exercicio);
            await _context.Commit();
            return new CreatedAtRouteResult("GetId", new { id = exercicio.Id }, exercicio);

        }

        [HttpGet("{id}", Name = "GetId")]
        public async Task<IActionResult> GetById(int? id)
        {
            var exercicio = await _context.ExercicioService.Get(a => a.Id == id);
            if (id is null || id < 0)
            {
                return BadRequest("Id inválido!");
            }
            if (exercicio is null)
            {
                return NotFound($"Exercicio com o Id = {id} não existe!");
            }

            var exercicioDto = _mapper.Map<ResponseExercicioDto>(exercicio);
            return Ok(exercicioDto);
        }
    }
}

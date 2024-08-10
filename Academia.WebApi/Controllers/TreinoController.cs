using Academia.Application.Dtos.TreinoDto;
using Academia.Domain.Interfaces;
using Academia.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Academia.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TreinoController : ControllerBase
    {
        private readonly IUnitofWork _context;
        private readonly IMapper _mapper;

        public TreinoController(IUnitofWork context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post(RequestTreinoDto treinoDto)
        {
            if (treinoDto is null)
            {
                return BadRequest("Insira os dados corretos.");
            }
            var treino = _mapper.Map<Treino>(treinoDto);
            await _context.TreinoService.Post(treino);
            await _context.Commit();
            return new CreatedAtRouteResult("GetId", new { id = treino.Id }, 
                _mapper.Map<ResponseTreinoDto>(treino));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var treinos = await _context.TreinoService.GetAll();
            if (treinos is null)
            {
                return NotFound("Nehnum Exercicio encontrado!");
            }
            var treinosDto = _mapper.Map<IEnumerable<ResponseTreinoListaDto>>(treinos);
            return Ok(treinosDto);
        }

        [HttpGet("GetId")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id < 0)
            {
                return BadRequest("Id Inválido!");
            }
            var treino = await _context.TreinoService.GetId(id);
            if (treino is null)
            {
                return NotFound($"Treino com o Id = {id} não existe!");
            }
            var treinoDto = _mapper.Map<ResponseTreinoDto>(treino);
            return Ok(treinoDto);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var treino = await _context.TreinoService.GetId(id);
            if (treino is null)
            {
                return NotFound($"Treino com Id {id} não encontrado!");
            }
            await _context.TreinoService.Delete(treino);
            await _context.Commit();
            return Ok();
        }
    }
}

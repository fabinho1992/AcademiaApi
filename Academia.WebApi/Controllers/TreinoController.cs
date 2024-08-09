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
            var treino = _mapper.Map<Treino>(treinoDto);
            await _context.TreinoService.Post(treino);
            await _context.Commit();
            return new CreatedAtRouteResult("GetId", new { id = treino.Id }, 
                _mapper.Map<ResponseTreinoDto>(treino));
        }

        [HttpGet("GetId")]
        public async Task<IActionResult> GetById(int id)
        {
            var treino = await _context.TreinoService.GetId(id);
            var treinoDto = _mapper.Map<ResponseTreinoDto>(treino);
            return Ok(treinoDto);
        }
    }
}

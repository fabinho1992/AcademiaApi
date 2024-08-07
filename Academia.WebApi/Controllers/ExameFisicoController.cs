using Academia.Application.Dtos.ExameFisicoDto;
using Academia.Domain.Interfaces;
using Academia.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Academia.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ExameFisicoController : ControllerBase
    {
        private readonly IUnitofWork _context;
        private readonly IMapper _mapper;

        public ExameFisicoController(IUnitofWork context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post(RequestExameFisicoDto exameFisico)
        {
            if (exameFisico is null)
            {
                return BadRequest();
            }
            var exameNovo = _mapper.Map<ExameFisico>(exameFisico);
            await _context.ExameFisicoService.Post(exameNovo);
            await _context.Commit();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var exames = await _context.ExameFisicoService.GetAll();
            if (exames is null)
            {
                return BadRequest("Exames não encontrados!");
            }
            var examesDto = _mapper.Map<IEnumerable<ResponseExameFisicoDto>>(exames);
            return Ok(examesDto);
        }
    }
}

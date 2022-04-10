using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FilmesAPI.DTO.Sessao;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController: ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public SessaoController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaSessao(CreateSessaoDto dto)
        {
            Sessao sessao = _mapper.Map<Sessao>(dto);
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaSessaoesPorId), new {Id = sessao.Id}, sessao);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaSessaoesPorId(int id)
        {
            Sessao sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);
            if (sessao != null)
            {
                ReadSessaoDTO sessaoDto = _mapper.Map<ReadSessaoDTO>(sessao);

                return Ok(sessaoDto);
            }
            return NotFound();
        }
    }
}

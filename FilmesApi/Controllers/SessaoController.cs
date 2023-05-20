using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos.SessaoDTOs;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CinemaAPI.Controllers
{
    [ApiController]
    [Route("sessao")]
    public class SessaoController : ControllerBase
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;

        public SessaoController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AdicionaSessao(CreateSessaoDTO dto)
        {
            var sessao = _mapper.Map<Sessao>(dto);
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaSessoesPorId), new { filmeId = sessao.FilmeId, cinemaId = sessao.CinemaId }, dto);
        }

        [HttpGet]
        public IEnumerable<ReadSessaoDTO> RecuperaSessoes()
        {
            return _mapper.Map<List<ReadSessaoDTO>>(_context.Sessoes.ToList());
        }

        [HttpGet("{filmeId}/{cinemaId}")]
        public IActionResult RecuperaSessoesPorId([FromRoute] int filmeId, [FromRoute] int cinemaId)
        {
            var sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.FilmeId == filmeId && sessao.CinemaId == cinemaId);
            if (sessao != null)
            {
                ReadSessaoDTO sessaoDto = _mapper.Map<ReadSessaoDTO>(sessao);

                return Ok(sessaoDto);
            }
            return NotFound("Sessão não encontrada.");
        }

        [HttpDelete("{cinemaId}/{filmeId}")]
        public IActionResult DeletaSessao([FromRoute] int cinemaId, [FromRoute] int filmeId)
        {
            var sessao = _context.Sessoes
                .FirstOrDefault(e => e.CinemaId == cinemaId && e.FilmeId == filmeId);
            if (sessao == null) return NotFound("Sessão não encontrada.");
            _context.Remove(sessao);
            _context.SaveChanges();
            return Ok("Sessão deletada com sucesso.");
        }
    }
}
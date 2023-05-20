using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos.CinemaDTOs;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CinemaAPI.Controllers
{
    [ApiController]
    [Route("cinema")]
    public class CinemaController : ControllerBase
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;

        public CinemaController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AdicionaCinema(
            [FromBody] CreateCinemaDTO cinemaDto)
        {
            var cinema = _mapper.Map<Cinema>(cinemaDto);
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaCinemaPorId), new { d = cinema.Id },
                cinemaDto);
        }

        [HttpGet]
        public List<ReadCinemaDTO> RecuperaCinemas()
        {
            return _mapper.Map<List<ReadCinemaDTO>>(_context.Cinemas.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaCinemaPorId([FromRoute] int id)
        {
            var cinema = _context.Cinemas
                .FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null) return NotFound("Cinema não encontrado.");
            var cinemaDto = _mapper.Map<ReadCinemaDTO>(cinema);
            return Ok(cinemaDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCinema([FromRoute] int id,
            [FromBody] UpdateCinemaDTO cinemaDto)
        {
            var cinema = _context.Cinemas.FirstOrDefault(
                cinema => cinema.Id == id);
            if (cinema == null) return NotFound("Cinema não encontrado.");
            _mapper.Map(cinemaDto, cinema);
            _context.SaveChanges();
            return Ok("Cinema alterado com sucesso.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaCinema([FromRoute] int id)
        {
            var cinema = _context.Cinemas.FirstOrDefault(
                cinema => cinema.Id == id);
            if (cinema == null) return NotFound("Cinema não encontrado.");
            _context.Remove(cinema);
            _context.SaveChanges();
            return Ok("Cinema deletado com sucesso.");
        }
    }
}
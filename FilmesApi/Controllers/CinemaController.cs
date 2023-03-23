using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using FilmesApi.Models;
using FilmesApi.Data;
using FilmesApi.Data.Dtos.CinemaDTOs;

namespace CinemasApi.Controllers
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

        /// <summary>
        /// Adiciona um cinema ao banco de dados
        /// </summary>
        /// <param name="cinemaDto">Objeto com os campos necessários para criação de um cinema</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Caso inserção seja feita com sucesso</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AdicionaCinema(
            [FromBody] CreateCinemaDTO cinemaDto)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaCinemaPorId),
                new { id = cinema.Id },
                cinema);
        }
        //sumary
        [HttpGet]
        public List<ReadCinemaDTO> RecuperaCinemas()
        {
            return _mapper.Map<List<ReadCinemaDTO>>(_context.Cinemas.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaCinemaPorId(int id)
        {
            var cinema = _context.Cinemas
                .FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null) return NotFound();
            var cinemaDto = _mapper.Map<ReadCinemaDTO>(cinema);
            return Ok(cinemaDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCinema(int id,
            [FromBody] UpdateCinemaDTO cinemaDto)
        {
            var cinema = _context.Cinemas.FirstOrDefault(
                cinema => cinema.Id == id);
            if (cinema == null) return NotFound();
            _mapper.Map(cinemaDto, cinema);
            _context.SaveChanges();
            return Ok("Cinema alterado com sucesso.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaCinema(int id)
        {
            var cinema = _context.Cinemas.FirstOrDefault(
                cinema => cinema.Id == id);
            if (cinema == null) return NotFound();
            _context.Remove(cinema);
            int changes = _context.SaveChanges();
            return Ok("Cinema deletado com sucesso.");
        }
    }
}

using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos.FilmeDTOs;
using FilmesApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[ApiController]
[Route("filmes")]
public class FilmeController : ControllerBase
{

    private ApplicationDbContext _context;
    private IMapper _mapper;

    public FilmeController(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdicionaFilme(
        [FromBody] CreateFilmeDto filmeDto)
    {
        Filme filme = _mapper.Map<Filme>(filmeDto);
        _context.Filmes.Add(filme);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaFilmePorId),
            new { id = filme.Id },
            filmeDto);
    }

    [HttpGet]
    public IEnumerable<ReadFilmeDto> RecuperaFilmes()
    {
        return _mapper.Map<List<ReadFilmeDto>>(_context.Filmes.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaFilmePorId([FromRoute] int id)
    {
        var filme = _context.Filmes
            .FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound("Filme não encontrado.");
        var filmeDto = _mapper.Map<ReadFilmeDto>(filme);
        return Ok(filmeDto);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaFilme([FromRoute] int id,
        [FromBody] UpdateFilmeDto filmeDto)
    {
        var filme = _context.Filmes.FirstOrDefault(
            filme => filme.Id == id);
        if (filme == null) return NotFound("Filme não encontrado.");
        _mapper.Map(filmeDto, filme);
        _context.SaveChanges();
        return Ok("Filme editado com sucesso");
    }


    [HttpDelete("{id}")]
    public IActionResult DeletaFilme([FromRoute] int id)
    {
        var filme = _context.Filmes.FirstOrDefault(
            filme => filme.Id == id);
        if (filme == null) return NotFound("Filme não encontrado.");
        _context.Remove(filme);
        _context.SaveChanges();
        return Ok("Filme deletado com sucesso");
    }
}
        
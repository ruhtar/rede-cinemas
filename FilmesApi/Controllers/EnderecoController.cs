using AutoMapper;
using FilmesApi.Data.Dtos.EnderecoDTOs;
using FilmesApi.Data;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("endereco")]
    public class EnderecoController : ControllerBase
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;

        public EnderecoController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AdicionaEndereco(
            [FromBody] CreateEnderecoDTO enderecoDto)
        {
            var endereco = _mapper.Map<Endereco>(enderecoDto);
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaEnderecoPorId),
                new { id = endereco.Id },
                enderecoDto);
        }

        [HttpGet]
        public IEnumerable<ReadEnderecoDTO> RecuperaEnderecos([FromQuery] int skip = 0,
            [FromQuery] int take = 50)
        {
            return _mapper.Map<List<ReadEnderecoDTO>>(_context.Enderecos.Skip(skip).Take(take));
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaEnderecoPorId([FromRoute] int id)
        {
            var endereco = _context.Enderecos
                .FirstOrDefault(endereco => endereco.Id == id);
            if (endereco == null) return NotFound("Endereço não encontrado.");
            var enderecoDto = _mapper.Map<ReadEnderecoDTO>(endereco);
            return Ok(enderecoDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaEndereco([FromRoute] int id,
            [FromBody] UpdateEnderecoDTO enderecoDto)
        {
            var endereco = _context.Enderecos.FirstOrDefault(
                endereco => endereco.Id == id);
            if (endereco == null) return NotFound("Endereço não encontrado.");
            _mapper.Map(enderecoDto, endereco);
            _context.SaveChanges();
            return Ok("Endereço alterado com sucesso.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaEndereco([FromRoute] int id)
        {
            var endereco = _context.Enderecos.FirstOrDefault(
                endereco => endereco.Id == id);
            if (endereco == null) return NotFound("Endereço não encontrado.");
            _context.Remove(endereco);
            _context.SaveChanges();
            return Ok("Endereço deletado com sucesso.");
        }
    }
}
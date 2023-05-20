using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Infra.Dtos.FuncionarioDTOs;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CinemaAPI.Controllers
{
    [ApiController]
    [Route("funcionario")]
    public class FuncionarioController : ControllerBase
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;

        public FuncionarioController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AdicionaFuncionario(
            [FromBody] CreateFuncionarioDTO funcionarioDto)
        {
            Funcionario funcionario = _mapper.Map<Funcionario>(funcionarioDto);
            _context.Funcionarios.Add(funcionario);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaFuncionarioPorId),
                new { id = funcionario.Id },
                funcionarioDto);
        }

        [HttpGet]
        public IEnumerable<ReadFuncionarioDTO> RecuperaFuncionarios([FromQuery] int skip = 0,
            [FromQuery] int take = 50)
        {
            return _mapper.Map<List<ReadFuncionarioDTO>>(_context.Funcionarios.Skip(skip).Take(take));
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFuncionarioPorId([FromRoute] int id)
        {
            var funcionario = _context.Funcionarios
                .FirstOrDefault(funcionario => funcionario.Id == id);
            if (funcionario == null) return NotFound("Funcionário não encontrado.");
            var funcionarioDto = _mapper.Map<ReadFuncionarioDTO>(funcionario);
            return Ok(funcionarioDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaFuncionario([FromRoute] int id,
            [FromBody] UpdateFuncionarioDTO funcionarioDto)
        {
            var funcionario = _context.Funcionarios.FirstOrDefault(
                funcionario => funcionario.Id == id);
            if (funcionario == null) return NotFound("Funcionário não encontrado.");
            _mapper.Map(funcionarioDto, funcionario);
            _context.SaveChanges();
            return Ok("Funcionário alterado com sucesso.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaFuncionario([FromRoute] int id)
        {
            var funcionario = _context.Funcionarios.FirstOrDefault(
                funcionario => funcionario.Id == id);
            if (funcionario == null) return NotFound("Funcionário não encontrado.");
            _context.Remove(funcionario);
            _context.SaveChanges();
            return Ok("Funcionário deletado com sucesso.");
        }
    }
}

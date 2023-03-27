using AutoMapper;
using CinemaAPI.Data.DTOs.UsuarioDTOs;
using CinemaAPI.Models;
using FilmesApi.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CinemaAPI.Controllers
{
    [ApiController]
    [Route("usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UsuarioController(UserManager<IdentityUser> userManager, ApplicationDbContext context, IMapper mapper)
        {
            _userManager = userManager;
            _context = context;
            _mapper = mapper;
        }
        [Route("cadastrar")]
        [HttpPost]
        public IActionResult CadastrarUsuario([FromBody] CreateUsuarioDTO usuarioDTO) {
            //var userRegistered = _userManager.FindByEmailAsync(usuarioDTO.Password);
            //if (userRegistered != null) return Conflict("Usuário já registrado."); //Status code: 409
            var usuarioModel = _mapper.Map<Usuario>(usuarioDTO);
            var usuarioIdentity = _mapper.Map<IdentityUser>(usuarioModel);
            var resultadoIdentity = _userManager.CreateAsync(usuarioIdentity, usuarioDTO.Password);
            if (resultadoIdentity.Result.Succeeded) return Ok("Usuário cadastrado com sucesso.");
            return StatusCode(500);
        }
    }
}

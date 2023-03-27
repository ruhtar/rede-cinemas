using AutoMapper;
using CinemaAPI.Data.DTOs.UsuarioDTOs;
using CinemaAPI.Models;

namespace CinemaAPI.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile() { 
            CreateMap<Usuario, CreateUsuarioDTO>();
        }
    }
}

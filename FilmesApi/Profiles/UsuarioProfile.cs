using AutoMapper;
using CinemaAPI.Data.DTOs.UsuarioDTOs;
using CinemaAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace CinemaAPI.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile() { 
            CreateMap<CreateUsuarioDTO, Usuario>();
            CreateMap<Usuario, IdentityUser>();
        }
    }
}

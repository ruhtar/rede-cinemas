using AutoMapper;
using FilmesApi.Infra.Dtos.FuncionarioDTOs;
using FilmesApi.Migrations;
using FilmesApi.Models;

namespace FilmesApi.Profiles
{
    public class FuncionarioProfile : Profile
    {
        public FuncionarioProfile()
        {
            CreateMap<CreateFuncionarioDTO, Funcionario>();
            CreateMap<Funcionario, ReadFuncionarioDTO>();
            CreateMap<UpdateFuncionarioDTO, Funcionario>();
        }
    }
}

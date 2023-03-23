using FilmesApi.Data.Dtos.EnderecoDTOs;
using FilmesApi.Data.Dtos.SessaoDTOs;
using FilmesApi.Infra.Dtos.FuncionarioDTOs;
using FilmesApi.Models;
using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos.CinemaDTOs
{
    public class ReadCinemaDTO
    {
        public int Id { get; set; }

        public string Nome { get; set; }
        public ReadEnderecoDTO Endereco { get; set; }
        public ICollection<ReadFuncionarioDTO> Funcionarios { get; set; }
        public ICollection<ReadSessaoDTO> Sessoes { get; set; }
    }
}

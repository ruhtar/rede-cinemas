using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Infra.Dtos.FuncionarioDTOs
{
    public class CreateFuncionarioDTO
    {
        [Required(ErrorMessage = "O nome do funcionário é obrigatório")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "A idade do funcionário é obrigatória")]
        [Range(18, 65, ErrorMessage = "O funcionário deve ter 18 e 65 anos")]
        public int Idade { get; set; }


        [Required(ErrorMessage = "O Id do cinema é obrigatório")]
        public int CinemaId { get; set; }
    }
}

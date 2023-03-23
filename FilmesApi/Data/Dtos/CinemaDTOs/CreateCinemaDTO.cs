using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos.CinemaDTOs
{
    public class CreateCinemaDTO
    {
        [Required(ErrorMessage = "O campo de nome precisa ser preenchido.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Id do endereco é obrigatório.")]
        public int EnderecoId { get; set; }
    }
}

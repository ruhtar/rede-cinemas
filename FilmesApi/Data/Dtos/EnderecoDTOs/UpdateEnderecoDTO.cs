using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos.EnderecoDTOs
{
    public class UpdateEnderecoDTO
    {
        [Required(ErrorMessage = "A rua é obrigatória")]
        public string Rua { get; set; }
        [Required(ErrorMessage = "O número do endereço é obrigatório")]
        [Range(1, 10000, ErrorMessage = "O número do endereço deve estar entre 1 e 10.000")]
        public int Numero { get; set; }
    }
}

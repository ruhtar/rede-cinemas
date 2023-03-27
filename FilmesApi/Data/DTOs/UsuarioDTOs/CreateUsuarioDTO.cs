using System.ComponentModel.DataAnnotations;

namespace CinemaAPI.Data.DTOs.UsuarioDTOs
{
    public class CreateUsuarioDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string RePassword { get; set; }

    }
}

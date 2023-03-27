using System.ComponentModel.DataAnnotations;

namespace CinemaAPI.Data.DTOs.UsuarioDTOs
{
    public class CreateUsuarioDTO
    {
        [Required(ErrorMessage = "O campo username é obrigatório.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "O campo email é obrigatório.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo senha é obrigatório.")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Sua senha precisa ter no mínimo 6 caracteres.")]
        [MaxLength(16, ErrorMessage = "Sua senha precisa ter no máximo 16 caracteres.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "O campo de confirmação de senha é obrigatório.")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "As senhas precisam ser iguais.")]
        [MaxLength(16, ErrorMessage = "Sua senha precisa ter no máximo 16 caracteres.")]
        [MinLength(6, ErrorMessage = "Sua senha precisa ter no mínimo 6 caracteres.")]
        public string RePassword { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Models
{
    public class Cinema
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string Nome { get; set; }
        public int EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }

        public int SessaoId { get; set; }
        public virtual ICollection<Sessao> Sessoes { get; set; }

        public int FuncionarioId { get; set; }
        public virtual ICollection<Funcionario> Funcionarios { get; set; }
    }
}

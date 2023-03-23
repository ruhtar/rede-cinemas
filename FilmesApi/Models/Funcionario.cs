
using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }

        public int CinemaId { get; set; }
        public virtual Cinema Cinema { get; set; }
    }
}

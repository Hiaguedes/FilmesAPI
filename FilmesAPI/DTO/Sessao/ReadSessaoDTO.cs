using FilmesAPI.Models;

namespace FilmesAPI.DTO.Sessao
{
    public class ReadSessaoDTO
    {
        public Cinema Cinema { get; set; }
        public Filme Filme { get; set; }
        public int Id { get; set; }
    }
}

using FilmesAPI.Models;

namespace FilmesAPI.DTO.Gerente
{
    public class ReadGerenteDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public object Cinema {get; set;}
    }
}

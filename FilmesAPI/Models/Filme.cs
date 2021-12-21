using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace FilmesAPI.Models;

public class Filme
{
    [Required(ErrorMessage = "O campo título é obrigatório")]
    public string Titulo { get; set; }
    [Required(ErrorMessage = "O campo diretor é obrigatório")]
    public string Diretor { get; set; }
    [StringLength(40, ErrorMessage = "O gênero não deve passar de 40 caracteres")]
    public string Genero { get; set; }
    [Range(1,450, ErrorMessage = "A duração deve ficar entre 1 minuto e 450 minutos")]
    public double Duracao { get; set; }
}
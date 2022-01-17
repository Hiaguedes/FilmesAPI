using Microsoft.AspNetCore.Mvc;
using FilmesAPI.Models;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController
{
    private static List<Filme> filmes = new();

    private static int ControllerId = 0;
    
    [HttpPost]
    public ObjectResult AdicionaFilme([FromBody] Filme filme)
    {
        filme.Id = ControllerId++;
        filmes.Add(filme);
        Console.WriteLine(filme.Titulo); 
        return new ObjectResult( filme) { StatusCode =  StatusCodes.Status201Created };
    }

    [HttpGet]
    public IEnumerable<Filme> ListaFilmes()
    {
        return filmes;
    }

    [HttpGet("{id}")]
    public ObjectResult BuscaFilmePorId(int id)
    {
        Filme filmeBuscado = filmes.FirstOrDefault(film => film.Id == id);

        if (filmeBuscado != null)
        {
            return new OkObjectResult(filmeBuscado);
        }

        return new NotFoundObjectResult(null);

    }
    
}
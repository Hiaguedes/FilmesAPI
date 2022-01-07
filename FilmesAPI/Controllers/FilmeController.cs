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
    public void AdicionaFilme([FromBody] Filme filme)
    {
        filme.Id = ControllerId++;
        filmes.Add(filme);
        Console.WriteLine(filme.Titulo); 
    }

    [HttpGet]
    public IEnumerable<Filme> ListaFilmes()
    {
        return filmes;
    }

    [HttpGet("{id}")]
    public IActionResult BuscaFilmePorId(int id)
    {
        Filme filmeBuscado = filmes.FirstOrDefault(film => film.Id == id);

        if (filmeBuscado != null)
        {
            return Ok(filmeBuscado);
        }

        return NotFound();

    }
    
}
using Microsoft.AspNetCore.Mvc;
using FilmesAPI.Models;
using FilmesAPI.Data;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private FilmesContext _context;

    public FilmeController(FilmesContext context)
    {
        _context = context;
    }
    
    [HttpPost]
    public ObjectResult AdicionaFilme([FromBody] Filme filme)
    {

        _context.Filme.Add(filme);
        _context.SaveChanges();

        return new ObjectResult(_context.Filme) { StatusCode =  StatusCodes.Status201Created };
    }

    [HttpGet]
    public ObjectResult ListaFilmes()
    {
        return new ObjectResult(_context.Filme) { StatusCode = StatusCodes.Status200OK };
    }

    [HttpGet("{id}")]
    public ObjectResult BuscaFilmePorId(int id)
    {
        Filme filmeBuscado = _context.Filme.FirstOrDefault(film => film.Id == id);

        if (filmeBuscado != null)
        {
            return new OkObjectResult(filmeBuscado);
        }

        return new NotFoundObjectResult(null);

    }

    [HttpPut("{id}")]
    public ObjectResult AtualizaFilme(int id, [FromBody] Filme filme)
    {
        var filmeParaEditar = _context.Filme.FirstOrDefault(film => film.Id == id);

        if(filmeParaEditar == null)
        {
            return new NotFoundObjectResult(null);
        }

        filmeParaEditar.Titulo = filme.Titulo;
        filmeParaEditar.Duracao = filme.Duracao;
        filmeParaEditar.Genero = filme.Genero;
        filmeParaEditar.Diretor = filme.Diretor;

        _context.SaveChanges();

        return new ObjectResult(null) { StatusCode = StatusCodes.Status204NoContent };
    }

    [HttpDelete("{id}")]
    public ObjectResult DeletarFilme(int id)
    {
        var filmeParaDeletar = _context.Filme.FirstOrDefault(film => film.Id == id);

        if (filmeParaDeletar == null)
        {
            return new NotFoundObjectResult(null);
        }

        _context.Remove(filmeParaDeletar);
        _context.SaveChanges();

        return new ObjectResult(null) { StatusCode = StatusCodes.Status204NoContent };
    }
    
}
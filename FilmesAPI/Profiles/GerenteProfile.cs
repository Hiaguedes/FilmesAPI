using AutoMapper;
using FilmesAPI.DTO.Gerente;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles
{
    public class GerenteProfile : Profile
    {
        public GerenteProfile()
        {
            CreateMap<CreateGerenteDTO, Gerente>();
            CreateMap<Gerente, ReadGerenteDTO>()
                .ForMember(gerente => gerente.Cinema, opts => opts
                .MapFrom(gerente => gerente.Cinemas.Select(
                        c => new { c.Id, c.Nome, c.Endereco, c.EnderecoId }
                    )));
        }
    }
}

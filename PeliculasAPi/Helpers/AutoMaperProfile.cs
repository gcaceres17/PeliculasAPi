using AutoMapper;
using PeliculasAPi.DTOs;
using PeliculasAPi.Entidades;

namespace PeliculasAPi.Helpers
{
    public class AutoMaperProfile : Profile
    {
        public AutoMaperProfile()
        {
            CreateMap<Genero, GeneroDto>().ReverseMap();
            CreateMap<GeneroCreacionDTo, Genero>();

            CreateMap<Actor, ActorDTo>().ReverseMap();
            CreateMap<ActorCreacionDto, Actor>();

        }
    }
}

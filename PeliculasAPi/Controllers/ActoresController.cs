using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeliculasAPi.DTOs;
using PeliculasAPi.Entidades;

namespace PeliculasAPi.Controllers
{
    [Route("api/actores")]
    [ApiController]
    public class ActoresController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ActoresController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ActorDTo>>> Get()
        {
            var entidades = await context.Actores.ToListAsync();
            var dtos = mapper.Map<List<ActorDTo>>(entidades);

            return dtos;
        }

        [HttpGet("{id}", Name = "ObtenerActor")]
        public async Task<ActionResult<ActorDTo>> GetById(int id)
        {
            var entidad = await context.Actores.FirstOrDefaultAsync(x => x.Id == id);

            if (entidad == null)
            {
                return NotFound();
            }

            return mapper.Map<ActorDTo>(entidad);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ActorCreacionDto actorCreacionDto)
        {
            var entidad = mapper.Map<Actor>(actorCreacionDto);
            context.Add(entidad);
            await context.SaveChangesAsync();
            var actorDTo = mapper.Map<ActorDTo>(entidad);

            return new CreatedAtRouteResult("ObtenerActor", new { id = actorDTo.Id }, actorDTo);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ActorCreacionDto actorCreacionDto)
        {
            var entidad = mapper.Map<Actor>(actorCreacionDto);
            entidad.Id = id;
            context.Entry(entidad).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Actores.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NoContent();
            }

            context.Remove(new Actor() { Id = id });
            await context.SaveChangesAsync();
            return NoContent();
        }

    }
}

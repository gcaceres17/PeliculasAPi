using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeliculasAPi.DTOs;
using PeliculasAPi.Entidades;

namespace PeliculasAPi.Controllers
{
    [Route("api/generos")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public GenerosController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<GeneroDto>>> Get()
        {
            var entidades = await context.Generos.ToListAsync();
            var dtos = mapper.Map<List<GeneroDto>>(entidades);

            return dtos;
        }

        [HttpGet("{id:int}", Name = "ObtenerGenero")]
        public async Task<ActionResult<GeneroDto>> GetById(int id)
        {
            var entidad = await context.Generos.FirstOrDefaultAsync(x => x.id == id);

            if (entidad == null)
            {
                return NotFound();
            }

            return Ok(entidad);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] GeneroCreacionDTo generoCreacionDto)
        {
            var entidad = mapper.Map<Genero>(generoCreacionDto);
            context.Add(entidad);
            await context.SaveChangesAsync();
            var generoDto = mapper.Map<GeneroDto>(entidad);

            return new CreatedAtRouteResult("ObtenerGenero", new { id = generoDto.id }, generoDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put (int id, [FromBody] GeneroCreacionDTo generoCreacionDTo)
        {
            var entidad = mapper.Map<Genero>(generoCreacionDTo);
            entidad.id = id;
            context.Entry(entidad).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id ) 
        {
            var existe = await context.Generos.AnyAsync(x => x.id == id);
            if (!existe)
            {
                return NoContent();
            }

            context.Remove(new Genero() { id = id });
            await context.SaveChangesAsync();
            return NoContent();
        }

    }
}

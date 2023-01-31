using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAutores.Entidades;
using WebApiAutores.Servicios;
using WebApiAutoresDb;

namespace WebApiAutores.Controllers
{
    [ApiController]
    [Route("api/autores")]
    public class AutoresController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IServicio servicio;
        private readonly ServicioTransient servicioTransient;
        private readonly ServicioScoped servicioScoped;
        private readonly ServicioSingleton servicioSingleton;

        public AutoresController(ApplicationDbContext context, IServicio servicio, 
            ServicioTransient servicioTransient, ServicioScoped servicioScoped, ServicioSingleton servicioSingleton)
        {
            this.context = context;
            this.servicio = servicio;
            this.servicioTransient = servicioTransient;
            this.servicioScoped = servicioScoped;
            this.servicioSingleton = servicioSingleton;
        }

        [HttpGet("GUID")]
        public ActionResult ObtenerGuid()
        {
            return Ok(new
            {
                AutoresController_Transient = servicioTransient.Guid,
                ServicioA_Transient = servicio.ObtenerTransient(),
                AutoresController_Scoped = servicioScoped.Guid,
                ServicioA_Scoped = servicio.ObtenerScoped(),
                AutoresController_Singleton= servicioSingleton.Guid,
                ServicioA_Singleton = servicio.ObtenerSingleton()
            });
        }

        [HttpGet]
        public async Task<ActionResult<List<Autor>>> Get()
        {
            return await context.Autores.Include(x => x.Libros).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Autor autor)
        {
            // VALIDACION EN CONTROLADOR

            var existeAutorConElMismoNombre = await context.Autores.AnyAsync(x => x.Name == autor.Name);

            if (existeAutorConElMismoNombre)
            {
                return BadRequest($"Ya existe un autor con el nombre {autor.Name}");
            }

            context.Add(autor);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]// api/autores/1
        public async Task<ActionResult> Put(Autor autor, int id)
        {
            if (autor.Id != id)
            {
                return BadRequest("El id del autor no cincide con el id de la URL");
            }

            var existe = await context.Autores.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound();
            }

            context.Update(autor);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Autores.AnyAsync(x => x.Id == id);

            if (!existe) 
            {
                return NotFound();
            }

            context.Remove(new Autor() { Id = id });
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}

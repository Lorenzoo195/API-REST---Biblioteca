using Microsoft.AspNetCore.Mvc;
using Models;

namespace Controllers;

[ApiController]
[Route("api/[controller]")]
public class PrestamosController : ControllerBase
{
    private static readonly List<Prestamos> cuenta = new()
    {
        new Prestamos { Id = 1, NombreLector = "Jose", TituloLibro = "Rey Leon", FechaPrestamo = DateTime.Now.AddHours(-2), DuracionDias = 2, EsRenovable = true, EstadoPrestamo = Estado.Activo},
        new Prestamos { Id = 2, NombreLector = "Pepe", TituloLibro = "Cars", FechaPrestamo = DateTime.Now.AddHours(-1), DuracionDias = 2, EsRenovable = true, EstadoPrestamo = Estado.Devuelto},
        new Prestamos { Id = 3, NombreLector = "Mario", TituloLibro = "Toy Story", FechaPrestamo = DateTime.Now, DuracionDias = 2, EsRenovable = true, EstadoPrestamo = Estado.Activo}
    };

    [HttpGet]
    public ActionResult<IEnumerable<Prestamos>> GetAll()
    {
        return Ok(cuenta);
    }
    [HttpGet("{id:int}")]
    public ActionResult<Prestamos> GetById(int id)
    {
        var prest = cuenta.FirstOrDefault(x => x.Id == id);
            if(prest is null)
            {
                return NotFound();
            }
            return Ok(prest);
    }
    [HttpPost]
    public ActionResult<Prestamos> Create ([FromBody] Prestamos prest)
    {
        int nid = 0;
        if(cuenta.Count > 0)
        {
            nid = cuenta.Max(x =>x.Id) +1;
        }
        prest.Id = nid;
        prest.EstadoPrestamo = Estado.Activo;
        prest.FechaPrestamo = DateTime.Now;
        cuenta.Add(prest);
        return CreatedAtAction(nameof(GetById),new { id = prest.Id} ,prest);
    }
    [HttpPut("{id:int}")]
    public ActionResult Update([FromBody] Prestamos prest, int id)
    {
        var prestado = cuenta.FirstOrDefault(x => x.Id == id);
        if(prestado is null)
        {
            return NoContent();
        }
        prestado.NombreLector = prest.NombreLector;
        prestado.TituloLibro = prest.TituloLibro;
        prestado.FechaPrestamo = prest.FechaPrestamo;
        prestado.DuracionDias = prest.DuracionDias;
        prestado.EsRenovable = prest.EsRenovable;
        return NoContent();
    }
    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var prestado = cuenta.FirstOrDefault(x => x.Id == id);
        if(prestado is null)
        {
            return NotFound();
        }
        cuenta.Remove(prestado);
        return NoContent();
    }
    [HttpPut("{id:int}/devolver")]
    public ActionResult Devolver(int id)
    {
        var prestado = cuenta.FirstOrDefault(x => x.Id == id);
        if(prestado is null)
        {
            return NoContent();
        }
        if(prestado.EstadoPrestamo == Estado.Activo)
        {
            return Conflict();
        }
        prestado.EstadoPrestamo = Estado.Activo;
        return NoContent();
    }
    [HttpGet("recientes")]
    public ActionResult<IEnumerable<Prestamos>> GetRecientes([FromQuery] int cantidad = 5)
    {
        if (cantidad <= 0)
      {
         return BadRequest("La cantidad deve ser mayor que cero. ");
      }
      var resultado = cuenta
      .OrderByDescending(x => x.FechaPrestamo)
      .Take(cantidad)
      .ToList();

      return Ok(resultado);
    }
    [HttpGet("buscar")]
    public ActionResult<Prestamos> Buscar([FromQuery] string lector)
    {
        if (string.IsNullOrWhiteSpace(lector))
        {
            return Ok(new List<Prestamos>());
        }
        var resultado = cuenta
        .Where(x =>x.NombreLector.Contains(lector, StringComparison.OrdinalIgnoreCase))
        .ToList();
        return Ok(resultado);
    }
}
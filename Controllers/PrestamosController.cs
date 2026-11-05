using Microsoft.AspNetCore.Mvc;
using Models;

namespace Controllers;

[ApiController]
[Route("api/[controller]")]
public class PrestamosController : ControllerBase
{
    private static readonly List<Prestamos> cuenta = new()
    {
        new Prestamos { Id = 1, NombreLector = "Jose", TituloLibro = "Rey Leon", FechaPrestamo = DateTime.Now, DuracionDias = 2, EsRenovable = true, EstadoPrestamo = Estado.Activo},
        new Prestamos { Id = 2, NombreLector = "Jose", TituloLibro = "Rey Leon", FechaPrestamo = DateTime.Now, DuracionDias = 2, EsRenovable = true, EstadoPrestamo = Estado.Devuelto},
        new Prestamos { Id = 3, NombreLector = "Jose", TituloLibro = "Rey Leon", FechaPrestamo = DateTime.Now, DuracionDias = 2, EsRenovable = true, EstadoPrestamo = Estado.Activo}
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

    
}
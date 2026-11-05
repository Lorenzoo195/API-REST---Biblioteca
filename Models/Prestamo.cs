namespace Models;

public class Prestamos
{
    public int Id {get; set;}
    public string NombreLector {get;set;}
    public string TituloLibro {get;set;}
    public DateTime FechaPrestamo {get;set;}
    public int DuracionDias {get;set;}
    public bool EsRenovable {get;set;}
    public Estado EstadoPrestamo {get;set;}
    public Prestamos() {}
    public Prestamos(int id, string nombrelector, string titulolibro, DateTime fechaprestamo, int duraciondias, bool esrenovable, Estado estadoprestamo)
    {
        Id = id;
        NombreLector = nombrelector;
        TituloLibro = titulolibro;
        FechaPrestamo = fechaprestamo;
        DuracionDias = duraciondias;
        EsRenovable = esrenovable;
        EstadoPrestamo = estadoprestamo;
    }
}
namespace Hotel.Datos.Entidades;

public class sedes
{
    public int id { get; set; }
    public string? nombre { get; set; }
    public string? ciudad { get; set; }
    public string? direccion { get; set; }
    public string? telefono { get; set; }
    public int estrellas { get; set; }
    public List<habitaciones> habitaciones { get; set; }
    public List<empleados> empleados { get; set; }
}

// Categorias de habitacion y su tarifa base.

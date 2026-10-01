namespace Hotel.Datos.Entidades;

public class proveedores
{
    public int id { get; set; }
    public string? nit { get; set; }
    public string? nombre { get; set; }
    public string? telefono { get; set; }
    public string? ciudad { get; set; }
    public List<productos> productos { get; set; }
}

// Ordenes de mantenimiento de habitaciones.

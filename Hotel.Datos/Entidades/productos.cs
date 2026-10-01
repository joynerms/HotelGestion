namespace Hotel.Datos.Entidades;

public class productos
{
    public int id { get; set; }
    public int proveedor { get; set; }
    public string? nombre { get; set; }
    public decimal precio { get; set; }
    public int stock { get; set; }
    public proveedores? _proveedor { get; set; }
    public List<consumos> consumos { get; set; }
}

// Consumos cargados a la habitacion.

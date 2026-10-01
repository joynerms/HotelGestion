namespace Hotel.Datos.Entidades;

public class tipos_habitacion
{
    public int id { get; set; }
    public string? nombre { get; set; }
    public int capacidad { get; set; }
    public decimal tarifa_base { get; set; }
    public string? descripcion { get; set; }
    public List<habitaciones> habitaciones { get; set; }
}

// Habitaciones fisicas de cada sede.

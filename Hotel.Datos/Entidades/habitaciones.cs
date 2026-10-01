namespace Hotel.Datos.Entidades;

public class habitaciones
{
    public int id { get; set; }
    public int sede { get; set; }
    public int tipo { get; set; }
    public string? numero { get; set; }
    public int piso { get; set; }
    public string? estado { get; set; }
    public sedes? _sede { get; set; }
    public tipos_habitacion? _tipo { get; set; }
    public List<detalles_reserva> detalles_reserva { get; set; }
    public List<mantenimientos> mantenimientos { get; set; }
}

// Huespedes registrados en el sistema.

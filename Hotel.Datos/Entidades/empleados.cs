namespace Hotel.Datos.Entidades;

public class empleados
{
    public int id { get; set; }
    public int sede { get; set; }
    public int cargo { get; set; }
    public string? documento { get; set; }
    public string? nombres { get; set; }
    public DateTime fecha_ingreso { get; set; }
    public sedes? _sede { get; set; }
    public cargos? _cargo { get; set; }
    public List<reservas> reservas { get; set; }
    public List<check_in> check_in { get; set; }
    public List<mantenimientos> mantenimientos { get; set; }
}

// Reservas realizadas por los clientes.

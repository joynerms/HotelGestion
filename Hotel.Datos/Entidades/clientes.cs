namespace Hotel.Datos.Entidades;

public class clientes
{
    public int id { get; set; }
    public string? documento { get; set; }
    public string? nombres { get; set; }
    public string? apellidos { get; set; }
    public string? correo { get; set; }
    public string? telefono { get; set; }
    public List<reservas> reservas { get; set; }
    public List<facturas> facturas { get; set; }
}

// Cargos u ocupaciones de los empleados.

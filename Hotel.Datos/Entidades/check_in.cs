namespace Hotel.Datos.Entidades;

public class check_in
{
    public int id { get; set; }
    public int reserva { get; set; }
    public int empleado { get; set; }
    public DateTime fecha_hora { get; set; }
    public string? observacion { get; set; }
    public reservas? _reserva { get; set; }
    public empleados? _empleado { get; set; }
    public List<check_out> check_out { get; set; }
}

// Registro de salida de los huespedes.

namespace Hotel.Datos.Entidades;

public class reservas
{
    public int id { get; set; }
    public int cliente { get; set; }
    public int empleado { get; set; }
    public DateTime fecha_reserva { get; set; }
    public DateTime fecha_entrada { get; set; }
    public DateTime fecha_salida { get; set; }
    public string? estado { get; set; }
    public clientes? _cliente { get; set; }
    public empleados? _empleado { get; set; }
    public List<detalles_reserva> detalles_reserva { get; set; }
    public List<check_in> check_in { get; set; }
    public List<facturas> facturas { get; set; }
    public List<servicios_solicitados> servicios_solicitados { get; set; }
    public List<consumos> consumos { get; set; }
}

// Habitaciones incluidas en cada reserva.

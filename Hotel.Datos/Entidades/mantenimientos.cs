namespace Hotel.Datos.Entidades;

public class mantenimientos
{
    public int id { get; set; }
    public int habitacion { get; set; }
    public int empleado { get; set; }
    public DateTime fecha { get; set; }
    public string? descripcion { get; set; }
    public decimal costo { get; set; }
    public habitaciones? _habitacion { get; set; }
    public empleados? _empleado { get; set; }
}

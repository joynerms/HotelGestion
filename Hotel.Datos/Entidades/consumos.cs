namespace Hotel.Datos.Entidades;

public class consumos
{
    public int id { get; set; }
    public int reserva { get; set; }
    public int producto { get; set; }
    public DateTime fecha { get; set; }
    public int cantidad { get; set; }
    public reservas? _reserva { get; set; }
    public productos? _producto { get; set; }
}

// Proveedores de productos e insumos.

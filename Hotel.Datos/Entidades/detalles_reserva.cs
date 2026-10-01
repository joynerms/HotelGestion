namespace Hotel.Datos.Entidades;

public class detalles_reserva
{
    public int id { get; set; }
    public int reserva { get; set; }
    public int habitacion { get; set; }
    public int noches { get; set; }
    public decimal tarifa_aplicada { get; set; }
    public reservas? _reserva { get; set; }
    public habitaciones? _habitacion { get; set; }
}

// Registro de ingreso de los huespedes.

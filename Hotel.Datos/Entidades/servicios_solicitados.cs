namespace Hotel.Datos.Entidades;

public class servicios_solicitados
{
    public int id { get; set; }
    public int reserva { get; set; }
    public int servicio { get; set; }
    public DateTime fecha { get; set; }
    public int cantidad { get; set; }
    public string? estado { get; set; }
    public reservas? _reserva { get; set; }
    public servicios? _servicio { get; set; }
}

// Productos de consumo disponibles (minibar, restaurante).

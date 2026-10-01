namespace Hotel.Datos.Entidades;

public class check_out
{
    public int id { get; set; }
    public int check_in { get; set; }
    public DateTime fecha_hora { get; set; }
    public string? estado_habitacion { get; set; }
    public decimal cargos_extra { get; set; }
    public check_in? _check_in { get; set; }
}

// Formas de pago aceptadas.

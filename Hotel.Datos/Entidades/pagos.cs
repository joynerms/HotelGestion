namespace Hotel.Datos.Entidades;

public class pagos
{
    public int id { get; set; }
    public int factura { get; set; }
    public int metodo { get; set; }
    public DateTime fecha { get; set; }
    public decimal valor { get; set; }
    public facturas? _factura { get; set; }
    public metodos_pago? _metodo { get; set; }
}

// Servicios adicionales ofrecidos por el hotel.

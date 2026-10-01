namespace Hotel.Datos.Entidades;

public class facturas
{
    public int id { get; set; }
    public int reserva { get; set; }
    public int cliente { get; set; }
    public DateTime fecha { get; set; }
    public decimal subtotal { get; set; }
    public decimal iva { get; set; }
    public decimal total { get; set; }
    public reservas? _reserva { get; set; }
    public clientes? _cliente { get; set; }
    public List<detalles_factura> detalles_factura { get; set; }
    public List<pagos> pagos { get; set; }
}

// Conceptos incluidos en cada factura.

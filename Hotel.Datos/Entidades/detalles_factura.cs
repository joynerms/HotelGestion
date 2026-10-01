namespace Hotel.Datos.Entidades;

public class detalles_factura
{
    public int id { get; set; }
    public int factura { get; set; }
    public string? concepto { get; set; }
    public int cantidad { get; set; }
    public decimal valor_unitario { get; set; }
    public facturas? _factura { get; set; }
}

// Pagos aplicados a las facturas.

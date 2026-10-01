namespace Hotel.Datos.Entidades;

public class metodos_pago
{
    public int id { get; set; }
    public string? nombre { get; set; }
    public decimal comision { get; set; }
    public bool activo { get; set; }
    public List<pagos> pagos { get; set; }
}

// Facturas emitidas a los clientes.

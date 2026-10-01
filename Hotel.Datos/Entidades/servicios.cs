namespace Hotel.Datos.Entidades;

public class servicios
{
    public int id { get; set; }
    public string? nombre { get; set; }
    public decimal precio { get; set; }
    public string? categoria { get; set; }
    public List<servicios_solicitados> servicios_solicitados { get; set; }
}

// Servicios pedidos por los huespedes.

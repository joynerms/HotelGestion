namespace Hotel.Datos.Entidades;

public class cargos
{
    public int id { get; set; }
    public string? nombre { get; set; }
    public decimal salario_base { get; set; }
    public string? area { get; set; }
    public List<empleados> empleados { get; set; }
}

// Personal que labora en el hotel.

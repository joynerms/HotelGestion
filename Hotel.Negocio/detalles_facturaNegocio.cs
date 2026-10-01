using Hotel.Datos;
using Hotel.Datos.Entidades;

namespace Hotel.Negocio;

// Reglas de negocio de la entidad detalles_factura.
public class detalles_facturaNegocio
{
    private readonly Repositorio<detalles_factura> repositorio;

    public detalles_facturaNegocio(IConexion conexion) { repositorio = new Repositorio<detalles_factura>(conexion); }

    public bool Validar(detalles_factura e)
    {
        if (e == null) return false;
        if (e.id <= 0) return false;
        if (e.factura <= 0) return false;
        if (string.IsNullOrWhiteSpace(e.concepto)) return false;
        if (e.cantidad <= 0) return false;
        if (e.valor_unitario < 0) return false;
        return true;
    }

    public List<detalles_factura> Listar() => repositorio.Listar();

    public bool Guardar(detalles_factura e)
    {
        if (!Validar(e)) return false;
        return repositorio.Insertar(e) > 0;
    }

    public bool Eliminar(int id) => id > 0 && repositorio.Eliminar(id) > 0;
}

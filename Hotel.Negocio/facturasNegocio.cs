using Hotel.Datos;
using Hotel.Datos.Entidades;

namespace Hotel.Negocio;

// Reglas de negocio de la entidad facturas.
public class facturasNegocio
{
    private readonly Repositorio<facturas> repositorio;

    public facturasNegocio(IConexion conexion) { repositorio = new Repositorio<facturas>(conexion); }

    public bool Validar(facturas e)
    {
        if (e == null) return false;
        if (e.id <= 0) return false;
        if (e.reserva <= 0) return false;
        if (e.cliente <= 0) return false;
        if (e.fecha == DateTime.MinValue) return false;
        if (e.subtotal < 0) return false;
        if (e.iva < 0) return false;
        if (e.total < 0) return false;
        if (e.total != e.subtotal + e.iva) return false;
        return true;
    }

    public List<facturas> Listar() => repositorio.Listar();

    public bool Guardar(facturas e)
    {
        if (!Validar(e)) return false;
        return repositorio.Insertar(e) > 0;
    }

    public bool Eliminar(int id) => id > 0 && repositorio.Eliminar(id) > 0;
}

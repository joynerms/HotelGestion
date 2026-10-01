using Hotel.Datos;
using Hotel.Datos.Entidades;

namespace Hotel.Negocio;

// Reglas de negocio de la entidad pagos.
public class pagosNegocio
{
    private readonly Repositorio<pagos> repositorio;

    public pagosNegocio(IConexion conexion) { repositorio = new Repositorio<pagos>(conexion); }

    public bool Validar(pagos e)
    {
        if (e == null) return false;
        if (e.id <= 0) return false;
        if (e.factura <= 0) return false;
        if (e.metodo <= 0) return false;
        if (e.fecha == DateTime.MinValue) return false;
        if (e.valor < 0) return false;
        return true;
    }

    public List<pagos> Listar() => repositorio.Listar();

    public bool Guardar(pagos e)
    {
        if (!Validar(e)) return false;
        return repositorio.Insertar(e) > 0;
    }

    public bool Eliminar(int id) => id > 0 && repositorio.Eliminar(id) > 0;
}

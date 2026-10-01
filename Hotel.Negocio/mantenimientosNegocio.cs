using Hotel.Datos;
using Hotel.Datos.Entidades;

namespace Hotel.Negocio;

// Reglas de negocio de la entidad mantenimientos.
public class mantenimientosNegocio
{
    private readonly Repositorio<mantenimientos> repositorio;

    public mantenimientosNegocio(IConexion conexion) { repositorio = new Repositorio<mantenimientos>(conexion); }

    public bool Validar(mantenimientos e)
    {
        if (e == null) return false;
        if (e.id <= 0) return false;
        if (e.habitacion <= 0) return false;
        if (e.empleado <= 0) return false;
        if (e.fecha == DateTime.MinValue) return false;
        if (string.IsNullOrWhiteSpace(e.descripcion)) return false;
        if (e.costo < 0) return false;
        return true;
    }

    public List<mantenimientos> Listar() => repositorio.Listar();

    public bool Guardar(mantenimientos e)
    {
        if (!Validar(e)) return false;
        return repositorio.Insertar(e) > 0;
    }

    public bool Eliminar(int id) => id > 0 && repositorio.Eliminar(id) > 0;
}

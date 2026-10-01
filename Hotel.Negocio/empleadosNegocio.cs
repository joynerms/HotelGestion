using Hotel.Datos;
using Hotel.Datos.Entidades;

namespace Hotel.Negocio;

// Reglas de negocio de la entidad empleados.
public class empleadosNegocio
{
    private readonly Repositorio<empleados> repositorio;

    public empleadosNegocio(IConexion conexion) { repositorio = new Repositorio<empleados>(conexion); }

    public bool Validar(empleados e)
    {
        if (e == null) return false;
        if (e.id <= 0) return false;
        if (e.sede <= 0) return false;
        if (e.cargo <= 0) return false;
        if (string.IsNullOrWhiteSpace(e.documento)) return false;
        if (string.IsNullOrWhiteSpace(e.nombres)) return false;
        if (e.fecha_ingreso == DateTime.MinValue) return false;
        return true;
    }

    public List<empleados> Listar() => repositorio.Listar();

    public bool Guardar(empleados e)
    {
        if (!Validar(e)) return false;
        return repositorio.Insertar(e) > 0;
    }

    public bool Eliminar(int id) => id > 0 && repositorio.Eliminar(id) > 0;
}

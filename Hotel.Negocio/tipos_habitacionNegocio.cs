using Hotel.Datos;
using Hotel.Datos.Entidades;

namespace Hotel.Negocio;

// Reglas de negocio de la entidad tipos_habitacion.
public class tipos_habitacionNegocio
{
    private readonly Repositorio<tipos_habitacion> repositorio;

    public tipos_habitacionNegocio(IConexion conexion) { repositorio = new Repositorio<tipos_habitacion>(conexion); }

    public bool Validar(tipos_habitacion e)
    {
        if (e == null) return false;
        if (e.id <= 0) return false;
        if (string.IsNullOrWhiteSpace(e.nombre)) return false;
        if (e.capacidad <= 0) return false;
        if (e.tarifa_base < 0) return false;
        if (string.IsNullOrWhiteSpace(e.descripcion)) return false;
        return true;
    }

    public List<tipos_habitacion> Listar() => repositorio.Listar();

    public bool Guardar(tipos_habitacion e)
    {
        if (!Validar(e)) return false;
        return repositorio.Insertar(e) > 0;
    }

    public bool Eliminar(int id) => id > 0 && repositorio.Eliminar(id) > 0;
}

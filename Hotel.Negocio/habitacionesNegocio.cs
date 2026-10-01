using Hotel.Datos;
using Hotel.Datos.Entidades;

namespace Hotel.Negocio;

// Reglas de negocio de la entidad habitaciones.
public class habitacionesNegocio
{
    private readonly Repositorio<habitaciones> repositorio;

    public habitacionesNegocio(IConexion conexion) { repositorio = new Repositorio<habitaciones>(conexion); }

    public bool Validar(habitaciones e)
    {
        if (e == null) return false;
        if (e.id <= 0) return false;
        if (e.sede <= 0) return false;
        if (e.tipo <= 0) return false;
        if (string.IsNullOrWhiteSpace(e.numero)) return false;
        if (e.piso < 0) return false;
        if (string.IsNullOrWhiteSpace(e.estado)) return false;
        return true;
    }

    public List<habitaciones> Listar() => repositorio.Listar();

    public bool Guardar(habitaciones e)
    {
        if (!Validar(e)) return false;
        return repositorio.Insertar(e) > 0;
    }

    public bool Eliminar(int id) => id > 0 && repositorio.Eliminar(id) > 0;
}

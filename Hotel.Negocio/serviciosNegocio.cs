using Hotel.Datos;
using Hotel.Datos.Entidades;

namespace Hotel.Negocio;

// Reglas de negocio de la entidad servicios.
public class serviciosNegocio
{
    private readonly Repositorio<servicios> repositorio;

    public serviciosNegocio(IConexion conexion) { repositorio = new Repositorio<servicios>(conexion); }

    public bool Validar(servicios e)
    {
        if (e == null) return false;
        if (e.id <= 0) return false;
        if (string.IsNullOrWhiteSpace(e.nombre)) return false;
        if (e.precio < 0) return false;
        if (string.IsNullOrWhiteSpace(e.categoria)) return false;
        return true;
    }

    public List<servicios> Listar() => repositorio.Listar();

    public bool Guardar(servicios e)
    {
        if (!Validar(e)) return false;
        return repositorio.Insertar(e) > 0;
    }

    public bool Eliminar(int id) => id > 0 && repositorio.Eliminar(id) > 0;
}

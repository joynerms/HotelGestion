using Hotel.Datos;
using Hotel.Datos.Entidades;

namespace Hotel.Negocio;

// Reglas de negocio de la entidad sedes.
public class sedesNegocio
{
    private readonly Repositorio<sedes> repositorio;

    public sedesNegocio(IConexion conexion) { repositorio = new Repositorio<sedes>(conexion); }

    public bool Validar(sedes e)
    {
        if (e == null) return false;
        if (e.id <= 0) return false;
        if (string.IsNullOrWhiteSpace(e.nombre)) return false;
        if (string.IsNullOrWhiteSpace(e.ciudad)) return false;
        if (string.IsNullOrWhiteSpace(e.direccion)) return false;
        if (string.IsNullOrWhiteSpace(e.telefono)) return false;
        if (e.estrellas <= 0) return false;
        if (e.estrellas > 5) return false;
        return true;
    }

    public List<sedes> Listar() => repositorio.Listar();

    public bool Guardar(sedes e)
    {
        if (!Validar(e)) return false;
        return repositorio.Insertar(e) > 0;
    }

    public bool Eliminar(int id) => id > 0 && repositorio.Eliminar(id) > 0;
}

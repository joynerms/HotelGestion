using Hotel.Datos;
using Hotel.Datos.Entidades;

namespace Hotel.Negocio;

// Reglas de negocio de la entidad proveedores.
public class proveedoresNegocio
{
    private readonly Repositorio<proveedores> repositorio;

    public proveedoresNegocio(IConexion conexion) { repositorio = new Repositorio<proveedores>(conexion); }

    public bool Validar(proveedores e)
    {
        if (e == null) return false;
        if (e.id <= 0) return false;
        if (string.IsNullOrWhiteSpace(e.nit)) return false;
        if (string.IsNullOrWhiteSpace(e.nombre)) return false;
        if (string.IsNullOrWhiteSpace(e.telefono)) return false;
        if (string.IsNullOrWhiteSpace(e.ciudad)) return false;
        return true;
    }

    public List<proveedores> Listar() => repositorio.Listar();

    public bool Guardar(proveedores e)
    {
        if (!Validar(e)) return false;
        return repositorio.Insertar(e) > 0;
    }

    public bool Eliminar(int id) => id > 0 && repositorio.Eliminar(id) > 0;
}

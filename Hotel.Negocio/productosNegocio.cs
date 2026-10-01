using Hotel.Datos;
using Hotel.Datos.Entidades;

namespace Hotel.Negocio;

// Reglas de negocio de la entidad productos.
public class productosNegocio
{
    private readonly Repositorio<productos> repositorio;

    public productosNegocio(IConexion conexion) { repositorio = new Repositorio<productos>(conexion); }

    public bool Validar(productos e)
    {
        if (e == null) return false;
        if (e.id <= 0) return false;
        if (e.proveedor <= 0) return false;
        if (string.IsNullOrWhiteSpace(e.nombre)) return false;
        if (e.precio < 0) return false;
        if (e.stock < 0) return false;
        return true;
    }

    public List<productos> Listar() => repositorio.Listar();

    public bool Guardar(productos e)
    {
        if (!Validar(e)) return false;
        return repositorio.Insertar(e) > 0;
    }

    public bool Eliminar(int id) => id > 0 && repositorio.Eliminar(id) > 0;
}

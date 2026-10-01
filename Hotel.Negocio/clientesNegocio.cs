using Hotel.Datos;
using Hotel.Datos.Entidades;

namespace Hotel.Negocio;

// Reglas de negocio de la entidad clientes.
public class clientesNegocio
{
    private readonly Repositorio<clientes> repositorio;

    public clientesNegocio(IConexion conexion) { repositorio = new Repositorio<clientes>(conexion); }

    public bool Validar(clientes e)
    {
        if (e == null) return false;
        if (e.id <= 0) return false;
        if (string.IsNullOrWhiteSpace(e.documento)) return false;
        if (string.IsNullOrWhiteSpace(e.nombres)) return false;
        if (string.IsNullOrWhiteSpace(e.apellidos)) return false;
        if (string.IsNullOrWhiteSpace(e.correo)) return false;
        if (string.IsNullOrWhiteSpace(e.telefono)) return false;
        return true;
    }

    public List<clientes> Listar() => repositorio.Listar();

    public bool Guardar(clientes e)
    {
        if (!Validar(e)) return false;
        return repositorio.Insertar(e) > 0;
    }

    public bool Eliminar(int id) => id > 0 && repositorio.Eliminar(id) > 0;
}

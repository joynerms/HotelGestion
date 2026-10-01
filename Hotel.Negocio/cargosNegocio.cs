using Hotel.Datos;
using Hotel.Datos.Entidades;

namespace Hotel.Negocio;

// Reglas de negocio de la entidad cargos.
public class cargosNegocio
{
    private readonly Repositorio<cargos> repositorio;

    public cargosNegocio(IConexion conexion) { repositorio = new Repositorio<cargos>(conexion); }

    public bool Validar(cargos e)
    {
        if (e == null) return false;
        if (e.id <= 0) return false;
        if (string.IsNullOrWhiteSpace(e.nombre)) return false;
        if (e.salario_base < 0) return false;
        if (string.IsNullOrWhiteSpace(e.area)) return false;
        return true;
    }

    public List<cargos> Listar() => repositorio.Listar();

    public bool Guardar(cargos e)
    {
        if (!Validar(e)) return false;
        return repositorio.Insertar(e) > 0;
    }

    public bool Eliminar(int id) => id > 0 && repositorio.Eliminar(id) > 0;
}

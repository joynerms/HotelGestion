using Hotel.Datos;
using Hotel.Datos.Entidades;

namespace Hotel.Negocio;

// Reglas de negocio de la entidad check_out.
public class check_outNegocio
{
    private readonly Repositorio<check_out> repositorio;

    public check_outNegocio(IConexion conexion) { repositorio = new Repositorio<check_out>(conexion); }

    public bool Validar(check_out e)
    {
        if (e == null) return false;
        if (e.id <= 0) return false;
        if (e.check_in <= 0) return false;
        if (e.fecha_hora == DateTime.MinValue) return false;
        if (string.IsNullOrWhiteSpace(e.estado_habitacion)) return false;
        if (e.cargos_extra < 0) return false;
        return true;
    }

    public List<check_out> Listar() => repositorio.Listar();

    public bool Guardar(check_out e)
    {
        if (!Validar(e)) return false;
        return repositorio.Insertar(e) > 0;
    }

    public bool Eliminar(int id) => id > 0 && repositorio.Eliminar(id) > 0;
}

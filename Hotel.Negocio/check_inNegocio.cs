using Hotel.Datos;
using Hotel.Datos.Entidades;

namespace Hotel.Negocio;

// Reglas de negocio de la entidad check_in.
public class check_inNegocio
{
    private readonly Repositorio<check_in> repositorio;

    public check_inNegocio(IConexion conexion) { repositorio = new Repositorio<check_in>(conexion); }

    public bool Validar(check_in e)
    {
        if (e == null) return false;
        if (e.id <= 0) return false;
        if (e.reserva <= 0) return false;
        if (e.empleado <= 0) return false;
        if (e.fecha_hora == DateTime.MinValue) return false;
        if (string.IsNullOrWhiteSpace(e.observacion)) return false;
        return true;
    }

    public List<check_in> Listar() => repositorio.Listar();

    public bool Guardar(check_in e)
    {
        if (!Validar(e)) return false;
        return repositorio.Insertar(e) > 0;
    }

    public bool Eliminar(int id) => id > 0 && repositorio.Eliminar(id) > 0;
}

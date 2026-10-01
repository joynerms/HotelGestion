using Hotel.Datos;
using Hotel.Datos.Entidades;

namespace Hotel.Negocio;

// Reglas de negocio de la entidad reservas.
public class reservasNegocio
{
    private readonly Repositorio<reservas> repositorio;

    public reservasNegocio(IConexion conexion) { repositorio = new Repositorio<reservas>(conexion); }

    public bool Validar(reservas e)
    {
        if (e == null) return false;
        if (e.id <= 0) return false;
        if (e.cliente <= 0) return false;
        if (e.empleado <= 0) return false;
        if (e.fecha_reserva == DateTime.MinValue) return false;
        if (e.fecha_entrada == DateTime.MinValue) return false;
        if (e.fecha_salida == DateTime.MinValue) return false;
        if (string.IsNullOrWhiteSpace(e.estado)) return false;
        if (e.fecha_salida <= e.fecha_entrada) return false;
        return true;
    }

    public List<reservas> Listar() => repositorio.Listar();

    public bool Guardar(reservas e)
    {
        if (!Validar(e)) return false;
        return repositorio.Insertar(e) > 0;
    }

    public bool Eliminar(int id) => id > 0 && repositorio.Eliminar(id) > 0;
}

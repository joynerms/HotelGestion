using Hotel.Datos;
using Hotel.Datos.Entidades;

namespace Hotel.Negocio;

// Reglas de negocio de la entidad detalles_reserva.
public class detalles_reservaNegocio
{
    private readonly Repositorio<detalles_reserva> repositorio;

    public detalles_reservaNegocio(IConexion conexion) { repositorio = new Repositorio<detalles_reserva>(conexion); }

    public bool Validar(detalles_reserva e)
    {
        if (e == null) return false;
        if (e.id <= 0) return false;
        if (e.reserva <= 0) return false;
        if (e.habitacion <= 0) return false;
        if (e.noches <= 0) return false;
        if (e.tarifa_aplicada < 0) return false;
        return true;
    }

    public List<detalles_reserva> Listar() => repositorio.Listar();

    public bool Guardar(detalles_reserva e)
    {
        if (!Validar(e)) return false;
        return repositorio.Insertar(e) > 0;
    }

    public bool Eliminar(int id) => id > 0 && repositorio.Eliminar(id) > 0;
}

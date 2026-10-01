using Hotel.Datos;
using Hotel.Datos.Entidades;

namespace Hotel.Negocio;

// Reglas de negocio de la entidad consumos.
public class consumosNegocio
{
    private readonly Repositorio<consumos> repositorio;

    public consumosNegocio(IConexion conexion) { repositorio = new Repositorio<consumos>(conexion); }

    public bool Validar(consumos e)
    {
        if (e == null) return false;
        if (e.id <= 0) return false;
        if (e.reserva <= 0) return false;
        if (e.producto <= 0) return false;
        if (e.fecha == DateTime.MinValue) return false;
        if (e.cantidad <= 0) return false;
        return true;
    }

    public List<consumos> Listar() => repositorio.Listar();

    public bool Guardar(consumos e)
    {
        if (!Validar(e)) return false;
        return repositorio.Insertar(e) > 0;
    }

    public bool Eliminar(int id) => id > 0 && repositorio.Eliminar(id) > 0;
}

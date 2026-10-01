using Hotel.Datos;
using Hotel.Datos.Entidades;

namespace Hotel.Negocio;

// Reglas de negocio de la entidad servicios_solicitados.
public class servicios_solicitadosNegocio
{
    private readonly Repositorio<servicios_solicitados> repositorio;

    public servicios_solicitadosNegocio(IConexion conexion) { repositorio = new Repositorio<servicios_solicitados>(conexion); }

    public bool Validar(servicios_solicitados e)
    {
        if (e == null) return false;
        if (e.id <= 0) return false;
        if (e.reserva <= 0) return false;
        if (e.servicio <= 0) return false;
        if (e.fecha == DateTime.MinValue) return false;
        if (e.cantidad <= 0) return false;
        if (string.IsNullOrWhiteSpace(e.estado)) return false;
        return true;
    }

    public List<servicios_solicitados> Listar() => repositorio.Listar();

    public bool Guardar(servicios_solicitados e)
    {
        if (!Validar(e)) return false;
        return repositorio.Insertar(e) > 0;
    }

    public bool Eliminar(int id) => id > 0 && repositorio.Eliminar(id) > 0;
}

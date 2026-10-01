using Hotel.Datos;
using Hotel.Datos.Entidades;

namespace Hotel.Negocio;

// Reglas de negocio de la entidad metodos_pago.
public class metodos_pagoNegocio
{
    private readonly Repositorio<metodos_pago> repositorio;

    public metodos_pagoNegocio(IConexion conexion) { repositorio = new Repositorio<metodos_pago>(conexion); }

    public bool Validar(metodos_pago e)
    {
        if (e == null) return false;
        if (e.id <= 0) return false;
        if (string.IsNullOrWhiteSpace(e.nombre)) return false;
        if (e.comision < 0) return false;
        return true;
    }

    public List<metodos_pago> Listar() => repositorio.Listar();

    public bool Guardar(metodos_pago e)
    {
        if (!Validar(e)) return false;
        return repositorio.Insertar(e) > 0;
    }

    public bool Eliminar(int id) => id > 0 && repositorio.Eliminar(id) > 0;
}

using Microsoft.Data.SqlClient;

namespace Hotel.Datos;

// Contrato para la conexion a la base de datos SQL Server.
public interface IConexion
{
    string string_conexion { get; set; }
    SqlConnection ObtenerConexion();
    bool ProbarConexion();
    List<Dictionary<string, object>> Consultar(string sql);
    int Ejecutar(string sql, Dictionary<string, object> parametros);
}

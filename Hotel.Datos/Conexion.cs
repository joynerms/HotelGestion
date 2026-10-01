using Microsoft.Data.SqlClient;

namespace Hotel.Datos;

// Implementacion de IConexion usando ADO.NET (SqlConnection / SqlCommand).
public class Conexion : IConexion
{
    // Cambiar "localhost" por "localhost\\SQLEXPRESS" si usan SQL Server Express.
    public string string_conexion { get; set; } =
        "Server=localhost;Database=HotelGestion;Trusted_Connection=True;TrustServerCertificate=True;";

    public Conexion() { }

    public Conexion(string cadena) { string_conexion = cadena; }

    public SqlConnection ObtenerConexion()
    {
        return new SqlConnection(string_conexion);
    }

    public bool ProbarConexion()
    {
        try
        {
            using var conexion = ObtenerConexion();
            conexion.Open();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public List<Dictionary<string, object>> Consultar(string sql)
    {
        var resultado = new List<Dictionary<string, object>>();
        using var conexion = ObtenerConexion();
        conexion.Open();
        using var comando = new SqlCommand(sql, conexion);
        using var lector = comando.ExecuteReader();
        while (lector.Read())
        {
            var fila = new Dictionary<string, object>();
            for (int i = 0; i < lector.FieldCount; i++)
                fila[lector.GetName(i)] = lector.GetValue(i);
            resultado.Add(fila);
        }
        return resultado;
    }

    public int Ejecutar(string sql, Dictionary<string, object> parametros)
    {
        using var conexion = ObtenerConexion();
        conexion.Open();
        using var comando = new SqlCommand(sql, conexion);
        foreach (var p in parametros)
            comando.Parameters.AddWithValue("@" + p.Key, p.Value ?? DBNull.Value);
        return comando.ExecuteNonQuery();
    }
}

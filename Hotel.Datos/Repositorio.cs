namespace Hotel.Datos;

// Repositorio generico: sirve para las 20 entidades.
// El nombre de la tabla es igual al nombre de la clase.
public class Repositorio<T> where T : new()
{
    private readonly IConexion conexion;
    private readonly string tabla = typeof(T).Name;

    public Repositorio(IConexion conexion) { this.conexion = conexion; }

    // Solo propiedades simples (int, string, decimal, DateTime, bool) = columnas.
    private static IEnumerable<System.Reflection.PropertyInfo> Columnas() =>
        typeof(T).GetProperties().Where(p => !p.Name.StartsWith("_") &&
            (p.PropertyType.IsPrimitive || p.PropertyType == typeof(string) ||
             p.PropertyType == typeof(decimal) || p.PropertyType == typeof(DateTime)));

    public List<T> Listar()
    {
        var lista = new List<T>();
        foreach (var fila in conexion.Consultar($"SELECT * FROM {tabla}"))
        {
            var obj = new T();
            foreach (var p in Columnas())
                if (fila.ContainsKey(p.Name) && fila[p.Name] != DBNull.Value)
                    p.SetValue(obj, Convert.ChangeType(fila[p.Name], p.PropertyType));
            lista.Add(obj);
        }
        return lista;
    }

    public int Insertar(T entidad)
    {
        var cols = Columnas().ToList();
        string sql = $"INSERT INTO {tabla} ({string.Join(", ", cols.Select(c => c.Name))}) " +
                     $"VALUES ({string.Join(", ", cols.Select(c => "@" + c.Name))})";
        return conexion.Ejecutar(sql, cols.ToDictionary(c => c.Name, c => c.GetValue(entidad)));
    }

    public int Eliminar(int id)
    {
        return conexion.Ejecutar($"DELETE FROM {tabla} WHERE id = @id",
            new Dictionary<string, object> { { "id", id } });
    }
}

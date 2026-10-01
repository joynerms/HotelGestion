// ============================================================
// Sistema de Gestion Hotelera - Capa de Presentacion
// Integrantes: Joyner Stiwar Molina Smith - Juan Manuel Ospina
// ============================================================
using Hotel.Datos;
using Hotel.Negocio;

IConexion conexion = new Conexion();

Console.WriteLine("=== SISTEMA DE GESTION HOTELERA ===");
if (!conexion.ProbarConexion())
{
    Console.WriteLine("No se pudo conectar a SQL Server.");
    Console.WriteLine("1) Ejecute lib/Script.sql  2) Revise la cadena en Hotel.Datos/Conexion.cs");
    return;
}

while (true)
{
    Console.WriteLine("\n--- Seleccione la tabla a listar ---");
    Console.WriteLine("(1, 2). sedes");
    Console.WriteLine("(2, 2). tipos_habitacion");
    Console.WriteLine("(3, 2). cargos");
    Console.WriteLine("(4, 2). clientes");
    Console.WriteLine("(5, 2). metodos_pago");
    Console.WriteLine("(6, 2). proveedores");
    Console.WriteLine("(7, 2). servicios");
    Console.WriteLine("(8, 2). productos");
    Console.WriteLine("(9, 2). habitaciones");
    Console.WriteLine("(10, 2). empleados");
    Console.WriteLine("(11, 2). reservas");
    Console.WriteLine("(12, 2). detalles_reserva");
    Console.WriteLine("(13, 2). check_in");
    Console.WriteLine("(14, 2). check_out");
    Console.WriteLine("(15, 2). facturas");
    Console.WriteLine("(16, 2). detalles_factura");
    Console.WriteLine("(17, 2). pagos");
    Console.WriteLine("(18, 2). servicios_solicitados");
    Console.WriteLine("(19, 2). consumos");
    Console.WriteLine("(20, 2). mantenimientos");
    Console.WriteLine(" 0. Salir");
    Console.Write("Opcion: ");
    string op = Console.ReadLine();
    if (op == "0" || op == null) break;
    switch (op)
    {
        case "1": Mostrar(new sedesNegocio(conexion).Listar(), "sedes"); break;
        case "2": Mostrar(new tipos_habitacionNegocio(conexion).Listar(), "tipos_habitacion"); break;
        case "3": Mostrar(new cargosNegocio(conexion).Listar(), "cargos"); break;
        case "4": Mostrar(new clientesNegocio(conexion).Listar(), "clientes"); break;
        case "5": Mostrar(new metodos_pagoNegocio(conexion).Listar(), "metodos_pago"); break;
        case "6": Mostrar(new proveedoresNegocio(conexion).Listar(), "proveedores"); break;
        case "7": Mostrar(new serviciosNegocio(conexion).Listar(), "servicios"); break;
        case "8": Mostrar(new productosNegocio(conexion).Listar(), "productos"); break;
        case "9": Mostrar(new habitacionesNegocio(conexion).Listar(), "habitaciones"); break;
        case "10": Mostrar(new empleadosNegocio(conexion).Listar(), "empleados"); break;
        case "11": Mostrar(new reservasNegocio(conexion).Listar(), "reservas"); break;
        case "12": Mostrar(new detalles_reservaNegocio(conexion).Listar(), "detalles_reserva"); break;
        case "13": Mostrar(new check_inNegocio(conexion).Listar(), "check_in"); break;
        case "14": Mostrar(new check_outNegocio(conexion).Listar(), "check_out"); break;
        case "15": Mostrar(new facturasNegocio(conexion).Listar(), "facturas"); break;
        case "16": Mostrar(new detalles_facturaNegocio(conexion).Listar(), "detalles_factura"); break;
        case "17": Mostrar(new pagosNegocio(conexion).Listar(), "pagos"); break;
        case "18": Mostrar(new servicios_solicitadosNegocio(conexion).Listar(), "servicios_solicitados"); break;
        case "19": Mostrar(new consumosNegocio(conexion).Listar(), "consumos"); break;
        case "20": Mostrar(new mantenimientosNegocio(conexion).Listar(), "mantenimientos"); break;
        default: Console.WriteLine("Opcion no valida"); break;
    }
}

static void Mostrar<T>(List<T> lista, string nombre)
{
    Console.WriteLine($"\n--- {nombre.ToUpper()} ({lista.Count} registros) ---");
    var props = typeof(T).GetProperties().Where(p => !p.Name.StartsWith("_") &&
        (p.PropertyType.IsPrimitive || p.PropertyType == typeof(string) ||
         p.PropertyType == typeof(decimal) || p.PropertyType == typeof(DateTime)));
    foreach (var item in lista)
        Console.WriteLine(string.Join(" | ", props.Select(p => $"{p.Name}: {p.GetValue(item)}")));
}

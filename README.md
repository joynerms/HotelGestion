# Sistema de Gestion Hotelera (HotelGestion)

Integrantes: Joyner Stiwar Molina Smith - Juan Manuel Ospina
Materia: Programacion de Software

## Estructura
- `HotelGestion.sln` - solucion
- `lib/Script.sql` - base de datos (20 tablas + 5 registros por tabla)
- `Hotel.Datos` - IConexion, Conexion, Repositorio y las 20 entidades
- `Hotel.Negocio` - reglas de negocio (20 clases)
- `Hotel.Presentacion` - aplicacion de consola (menu)
- `Hotel.Pruebas` - 20 pruebas unitarias (MSTest)

## Como ejecutar
1. Abrir `lib/Script.sql` en SQL Server Management Studio y ejecutarlo (F5).
2. Si usan SQL Express, cambiar `localhost` por `localhost\SQLEXPRESS` en `Hotel.Datos/Conexion.cs`.
3. `dotnet build`
4. `dotnet test` (20 pruebas)
5. `dotnet run --project Hotel.Presentacion`

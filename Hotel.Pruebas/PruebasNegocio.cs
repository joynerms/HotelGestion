using Hotel.Datos;
using Hotel.Datos.Entidades;
using Hotel.Negocio;

namespace Hotel.Pruebas;

// 20 pruebas unitarias: una por entidad (no necesitan base de datos).
[TestClass]
public class PruebasNegocio
{
    private readonly IConexion conexion = new Conexion();

    [TestMethod]
    public void Validar_sedes()
    {
        var negocio = new sedesNegocio(conexion);
        var valido = new sedes()
        {
            id = 1,
            nombre = "Hotel Andino Centro",
            ciudad = "Bogota",
            direccion = "Cra 7 # 45-12",
            telefono = "6012345678",
            estrellas = 4
        };
        Assert.IsTrue(negocio.Validar(valido), "Un registro correcto debe ser valido");

        valido.nombre = "";
        Assert.IsFalse(negocio.Validar(valido), "Un registro incompleto no debe ser valido");
    }

    [TestMethod]
    public void Validar_tipos_habitacion()
    {
        var negocio = new tipos_habitacionNegocio(conexion);
        var valido = new tipos_habitacion()
        {
            id = 1,
            nombre = "Sencilla",
            capacidad = 1,
            tarifa_base = 150000.0m,
            descripcion = "Una cama sencilla"
        };
        Assert.IsTrue(negocio.Validar(valido), "Un registro correcto debe ser valido");

        valido.nombre = "";
        Assert.IsFalse(negocio.Validar(valido), "Un registro incompleto no debe ser valido");
    }

    [TestMethod]
    public void Validar_cargos()
    {
        var negocio = new cargosNegocio(conexion);
        var valido = new cargos()
        {
            id = 1,
            nombre = "Recepcionista",
            salario_base = 1600000.0m,
            area = "Recepcion"
        };
        Assert.IsTrue(negocio.Validar(valido), "Un registro correcto debe ser valido");

        valido.nombre = "";
        Assert.IsFalse(negocio.Validar(valido), "Un registro incompleto no debe ser valido");
    }

    [TestMethod]
    public void Validar_clientes()
    {
        var negocio = new clientesNegocio(conexion);
        var valido = new clientes()
        {
            id = 1,
            documento = "1094567321",
            nombres = "Laura",
            apellidos = "Restrepo",
            correo = "laura.r@mail.com",
            telefono = "3101234567"
        };
        Assert.IsTrue(negocio.Validar(valido), "Un registro correcto debe ser valido");

        valido.documento = "";
        Assert.IsFalse(negocio.Validar(valido), "Un registro incompleto no debe ser valido");
    }

    [TestMethod]
    public void Validar_metodos_pago()
    {
        var negocio = new metodos_pagoNegocio(conexion);
        var valido = new metodos_pago()
        {
            id = 1,
            nombre = "Efectivo",
            comision = 0.0m,
            activo = true
        };
        Assert.IsTrue(negocio.Validar(valido), "Un registro correcto debe ser valido");

        valido.nombre = "";
        Assert.IsFalse(negocio.Validar(valido), "Un registro incompleto no debe ser valido");
    }

    [TestMethod]
    public void Validar_proveedores()
    {
        var negocio = new proveedoresNegocio(conexion);
        var valido = new proveedores()
        {
            id = 1,
            nit = "900123456-1",
            nombre = "Distribuidora El Sol",
            telefono = "6013334455",
            ciudad = "Bogota"
        };
        Assert.IsTrue(negocio.Validar(valido), "Un registro correcto debe ser valido");

        valido.nit = "";
        Assert.IsFalse(negocio.Validar(valido), "Un registro incompleto no debe ser valido");
    }

    [TestMethod]
    public void Validar_servicios()
    {
        var negocio = new serviciosNegocio(conexion);
        var valido = new servicios()
        {
            id = 1,
            nombre = "Lavanderia",
            precio = 40000.0m,
            categoria = "Housekeeping"
        };
        Assert.IsTrue(negocio.Validar(valido), "Un registro correcto debe ser valido");

        valido.nombre = "";
        Assert.IsFalse(negocio.Validar(valido), "Un registro incompleto no debe ser valido");
    }

    [TestMethod]
    public void Validar_productos()
    {
        var negocio = new productosNegocio(conexion);
        var valido = new productos()
        {
            id = 1,
            proveedor = 1,
            nombre = "Agua 600ml",
            precio = 5000.0m,
            stock = 240
        };
        Assert.IsTrue(negocio.Validar(valido), "Un registro correcto debe ser valido");

        valido.nombre = "";
        Assert.IsFalse(negocio.Validar(valido), "Un registro incompleto no debe ser valido");
    }

    [TestMethod]
    public void Validar_habitaciones()
    {
        var negocio = new habitacionesNegocio(conexion);
        var valido = new habitaciones()
        {
            id = 1,
            sede = 1,
            tipo = 1,
            numero = "101",
            piso = 1,
            estado = "Disponible"
        };
        Assert.IsTrue(negocio.Validar(valido), "Un registro correcto debe ser valido");

        valido.numero = "";
        Assert.IsFalse(negocio.Validar(valido), "Un registro incompleto no debe ser valido");
    }

    [TestMethod]
    public void Validar_empleados()
    {
        var negocio = new empleadosNegocio(conexion);
        var valido = new empleados()
        {
            id = 1,
            sede = 1,
            cargo = 1,
            documento = "1015667788",
            nombres = "Marcela Rios",
            fecha_ingreso = new DateTime(2023, 2, 1)
        };
        Assert.IsTrue(negocio.Validar(valido), "Un registro correcto debe ser valido");

        valido.documento = "";
        Assert.IsFalse(negocio.Validar(valido), "Un registro incompleto no debe ser valido");
    }

    [TestMethod]
    public void Validar_reservas()
    {
        var negocio = new reservasNegocio(conexion);
        var valido = new reservas()
        {
            id = 1,
            cliente = 1,
            empleado = 1,
            fecha_reserva = new DateTime(2026, 8, 1),
            fecha_entrada = new DateTime(2026, 8, 10),
            fecha_salida = new DateTime(2026, 8, 13),
            estado = "Cerrada"
        };
        Assert.IsTrue(negocio.Validar(valido), "Un registro correcto debe ser valido");

        valido.estado = "";
        Assert.IsFalse(negocio.Validar(valido), "Un registro incompleto no debe ser valido");
    }

    [TestMethod]
    public void Validar_detalles_reserva()
    {
        var negocio = new detalles_reservaNegocio(conexion);
        var valido = new detalles_reserva()
        {
            id = 1,
            reserva = 1,
            habitacion = 1,
            noches = 3,
            tarifa_aplicada = 150000.0m
        };
        Assert.IsTrue(negocio.Validar(valido), "Un registro correcto debe ser valido");

        valido.id = 0;
        Assert.IsFalse(negocio.Validar(valido), "Un registro incompleto no debe ser valido");
    }

    [TestMethod]
    public void Validar_check_in()
    {
        var negocio = new check_inNegocio(conexion);
        var valido = new check_in()
        {
            id = 1,
            reserva = 1,
            empleado = 1,
            fecha_hora = new DateTime(2026, 8, 10, 14, 5, 0),
            observacion = "Sin novedades"
        };
        Assert.IsTrue(negocio.Validar(valido), "Un registro correcto debe ser valido");

        valido.observacion = "";
        Assert.IsFalse(negocio.Validar(valido), "Un registro incompleto no debe ser valido");
    }

    [TestMethod]
    public void Validar_check_out()
    {
        var negocio = new check_outNegocio(conexion);
        var valido = new check_out()
        {
            id = 1,
            check_in = 1,
            fecha_hora = new DateTime(2026, 8, 13, 11, 0, 0),
            estado_habitacion = "Bueno",
            cargos_extra = 0.0m
        };
        Assert.IsTrue(negocio.Validar(valido), "Un registro correcto debe ser valido");

        valido.estado_habitacion = "";
        Assert.IsFalse(negocio.Validar(valido), "Un registro incompleto no debe ser valido");
    }

    [TestMethod]
    public void Validar_facturas()
    {
        var negocio = new facturasNegocio(conexion);
        var valido = new facturas()
        {
            id = 1,
            reserva = 1,
            cliente = 1,
            fecha = new DateTime(2026, 8, 13),
            subtotal = 450000.0m,
            iva = 85500.0m,
            total = 535500.0m
        };
        Assert.IsTrue(negocio.Validar(valido), "Un registro correcto debe ser valido");

        valido.id = 0;
        Assert.IsFalse(negocio.Validar(valido), "Un registro incompleto no debe ser valido");
    }

    [TestMethod]
    public void Validar_detalles_factura()
    {
        var negocio = new detalles_facturaNegocio(conexion);
        var valido = new detalles_factura()
        {
            id = 1,
            factura = 1,
            concepto = "Alojamiento sencilla",
            cantidad = 3,
            valor_unitario = 150000.0m
        };
        Assert.IsTrue(negocio.Validar(valido), "Un registro correcto debe ser valido");

        valido.concepto = "";
        Assert.IsFalse(negocio.Validar(valido), "Un registro incompleto no debe ser valido");
    }

    [TestMethod]
    public void Validar_pagos()
    {
        var negocio = new pagosNegocio(conexion);
        var valido = new pagos()
        {
            id = 1,
            factura = 1,
            metodo = 1,
            fecha = new DateTime(2026, 8, 13),
            valor = 535500.0m
        };
        Assert.IsTrue(negocio.Validar(valido), "Un registro correcto debe ser valido");

        valido.id = 0;
        Assert.IsFalse(negocio.Validar(valido), "Un registro incompleto no debe ser valido");
    }

    [TestMethod]
    public void Validar_servicios_solicitados()
    {
        var negocio = new servicios_solicitadosNegocio(conexion);
        var valido = new servicios_solicitados()
        {
            id = 1,
            reserva = 1,
            servicio = 1,
            fecha = new DateTime(2026, 8, 11),
            cantidad = 2,
            estado = "Prestado"
        };
        Assert.IsTrue(negocio.Validar(valido), "Un registro correcto debe ser valido");

        valido.estado = "";
        Assert.IsFalse(negocio.Validar(valido), "Un registro incompleto no debe ser valido");
    }

    [TestMethod]
    public void Validar_consumos()
    {
        var negocio = new consumosNegocio(conexion);
        var valido = new consumos()
        {
            id = 1,
            reserva = 1,
            producto = 1,
            fecha = new DateTime(2026, 8, 10, 20, 15, 0),
            cantidad = 2
        };
        Assert.IsTrue(negocio.Validar(valido), "Un registro correcto debe ser valido");

        valido.id = 0;
        Assert.IsFalse(negocio.Validar(valido), "Un registro incompleto no debe ser valido");
    }

    [TestMethod]
    public void Validar_mantenimientos()
    {
        var negocio = new mantenimientosNegocio(conexion);
        var valido = new mantenimientos()
        {
            id = 1,
            habitacion = 4,
            empleado = 4,
            fecha = new DateTime(2026, 8, 5),
            descripcion = "Cambio de aire acondicionado",
            costo = 850000.0m
        };
        Assert.IsTrue(negocio.Validar(valido), "Un registro correcto debe ser valido");

        valido.descripcion = "";
        Assert.IsFalse(negocio.Validar(valido), "Un registro incompleto no debe ser valido");
    }
}

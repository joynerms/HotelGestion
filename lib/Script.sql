-- Script.sql - Sistema de Gestion Hotelera
-- Integrantes: Joyner Stiwar Molina Smith - Juan Manuel Ospina

IF DB_ID('HotelGestion') IS NULL CREATE DATABASE HotelGestion;
GO
USE HotelGestion;
GO

IF OBJECT_ID('mantenimientos','U') IS NOT NULL DROP TABLE mantenimientos;
IF OBJECT_ID('consumos','U') IS NOT NULL DROP TABLE consumos;
IF OBJECT_ID('servicios_solicitados','U') IS NOT NULL DROP TABLE servicios_solicitados;
IF OBJECT_ID('pagos','U') IS NOT NULL DROP TABLE pagos;
IF OBJECT_ID('detalles_factura','U') IS NOT NULL DROP TABLE detalles_factura;
IF OBJECT_ID('facturas','U') IS NOT NULL DROP TABLE facturas;
IF OBJECT_ID('check_out','U') IS NOT NULL DROP TABLE check_out;
IF OBJECT_ID('check_in','U') IS NOT NULL DROP TABLE check_in;
IF OBJECT_ID('detalles_reserva','U') IS NOT NULL DROP TABLE detalles_reserva;
IF OBJECT_ID('reservas','U') IS NOT NULL DROP TABLE reservas;
IF OBJECT_ID('empleados','U') IS NOT NULL DROP TABLE empleados;
IF OBJECT_ID('habitaciones','U') IS NOT NULL DROP TABLE habitaciones;
IF OBJECT_ID('productos','U') IS NOT NULL DROP TABLE productos;
IF OBJECT_ID('servicios','U') IS NOT NULL DROP TABLE servicios;
IF OBJECT_ID('proveedores','U') IS NOT NULL DROP TABLE proveedores;
IF OBJECT_ID('metodos_pago','U') IS NOT NULL DROP TABLE metodos_pago;
IF OBJECT_ID('clientes','U') IS NOT NULL DROP TABLE clientes;
IF OBJECT_ID('cargos','U') IS NOT NULL DROP TABLE cargos;
IF OBJECT_ID('tipos_habitacion','U') IS NOT NULL DROP TABLE tipos_habitacion;
IF OBJECT_ID('sedes','U') IS NOT NULL DROP TABLE sedes;
GO

CREATE TABLE sedes (
    id INT NOT NULL PRIMARY KEY,
    nombre VARCHAR(150) NOT NULL,
    ciudad VARCHAR(150) NOT NULL,
    direccion VARCHAR(150) NOT NULL,
    telefono VARCHAR(150) NOT NULL,
    estrellas INT NOT NULL
);
GO

CREATE TABLE tipos_habitacion (
    id INT NOT NULL PRIMARY KEY,
    nombre VARCHAR(150) NOT NULL,
    capacidad INT NOT NULL,
    tarifa_base DECIMAL(12,2) NOT NULL,
    descripcion VARCHAR(150) NOT NULL
);
GO

CREATE TABLE cargos (
    id INT NOT NULL PRIMARY KEY,
    nombre VARCHAR(150) NOT NULL,
    salario_base DECIMAL(12,2) NOT NULL,
    area VARCHAR(150) NOT NULL
);
GO

CREATE TABLE clientes (
    id INT NOT NULL PRIMARY KEY,
    documento VARCHAR(150) NOT NULL,
    nombres VARCHAR(150) NOT NULL,
    apellidos VARCHAR(150) NOT NULL,
    correo VARCHAR(150) NOT NULL,
    telefono VARCHAR(150) NOT NULL
);
GO

CREATE TABLE metodos_pago (
    id INT NOT NULL PRIMARY KEY,
    nombre VARCHAR(150) NOT NULL,
    comision DECIMAL(12,2) NOT NULL,
    activo BIT NOT NULL
);
GO

CREATE TABLE proveedores (
    id INT NOT NULL PRIMARY KEY,
    nit VARCHAR(150) NOT NULL,
    nombre VARCHAR(150) NOT NULL,
    telefono VARCHAR(150) NOT NULL,
    ciudad VARCHAR(150) NOT NULL
);
GO

CREATE TABLE servicios (
    id INT NOT NULL PRIMARY KEY,
    nombre VARCHAR(150) NOT NULL,
    precio DECIMAL(12,2) NOT NULL,
    categoria VARCHAR(150) NOT NULL
);
GO

CREATE TABLE productos (
    id INT NOT NULL PRIMARY KEY,
    proveedor INT NOT NULL FOREIGN KEY REFERENCES proveedores(id),
    nombre VARCHAR(150) NOT NULL,
    precio DECIMAL(12,2) NOT NULL,
    stock INT NOT NULL
);
GO

CREATE TABLE habitaciones (
    id INT NOT NULL PRIMARY KEY,
    sede INT NOT NULL FOREIGN KEY REFERENCES sedes(id),
    tipo INT NOT NULL FOREIGN KEY REFERENCES tipos_habitacion(id),
    numero VARCHAR(150) NOT NULL,
    piso INT NOT NULL,
    estado VARCHAR(150) NOT NULL
);
GO

CREATE TABLE empleados (
    id INT NOT NULL PRIMARY KEY,
    sede INT NOT NULL FOREIGN KEY REFERENCES sedes(id),
    cargo INT NOT NULL FOREIGN KEY REFERENCES cargos(id),
    documento VARCHAR(150) NOT NULL,
    nombres VARCHAR(150) NOT NULL,
    fecha_ingreso DATETIME NOT NULL
);
GO

CREATE TABLE reservas (
    id INT NOT NULL PRIMARY KEY,
    cliente INT NOT NULL FOREIGN KEY REFERENCES clientes(id),
    empleado INT NOT NULL FOREIGN KEY REFERENCES empleados(id),
    fecha_reserva DATETIME NOT NULL,
    fecha_entrada DATETIME NOT NULL,
    fecha_salida DATETIME NOT NULL,
    estado VARCHAR(150) NOT NULL
);
GO

CREATE TABLE detalles_reserva (
    id INT NOT NULL PRIMARY KEY,
    reserva INT NOT NULL FOREIGN KEY REFERENCES reservas(id),
    habitacion INT NOT NULL FOREIGN KEY REFERENCES habitaciones(id),
    noches INT NOT NULL,
    tarifa_aplicada DECIMAL(12,2) NOT NULL
);
GO

CREATE TABLE check_in (
    id INT NOT NULL PRIMARY KEY,
    reserva INT NOT NULL FOREIGN KEY REFERENCES reservas(id),
    empleado INT NOT NULL FOREIGN KEY REFERENCES empleados(id),
    fecha_hora DATETIME NOT NULL,
    observacion VARCHAR(150) NOT NULL
);
GO

CREATE TABLE check_out (
    id INT NOT NULL PRIMARY KEY,
    check_in INT NOT NULL FOREIGN KEY REFERENCES check_in(id),
    fecha_hora DATETIME NOT NULL,
    estado_habitacion VARCHAR(150) NOT NULL,
    cargos_extra DECIMAL(12,2) NOT NULL
);
GO

CREATE TABLE facturas (
    id INT NOT NULL PRIMARY KEY,
    reserva INT NOT NULL FOREIGN KEY REFERENCES reservas(id),
    cliente INT NOT NULL FOREIGN KEY REFERENCES clientes(id),
    fecha DATETIME NOT NULL,
    subtotal DECIMAL(12,2) NOT NULL,
    iva DECIMAL(12,2) NOT NULL,
    total DECIMAL(12,2) NOT NULL
);
GO

CREATE TABLE detalles_factura (
    id INT NOT NULL PRIMARY KEY,
    factura INT NOT NULL FOREIGN KEY REFERENCES facturas(id),
    concepto VARCHAR(150) NOT NULL,
    cantidad INT NOT NULL,
    valor_unitario DECIMAL(12,2) NOT NULL
);
GO

CREATE TABLE pagos (
    id INT NOT NULL PRIMARY KEY,
    factura INT NOT NULL FOREIGN KEY REFERENCES facturas(id),
    metodo INT NOT NULL FOREIGN KEY REFERENCES metodos_pago(id),
    fecha DATETIME NOT NULL,
    valor DECIMAL(12,2) NOT NULL
);
GO

CREATE TABLE servicios_solicitados (
    id INT NOT NULL PRIMARY KEY,
    reserva INT NOT NULL FOREIGN KEY REFERENCES reservas(id),
    servicio INT NOT NULL FOREIGN KEY REFERENCES servicios(id),
    fecha DATETIME NOT NULL,
    cantidad INT NOT NULL,
    estado VARCHAR(150) NOT NULL
);
GO

CREATE TABLE consumos (
    id INT NOT NULL PRIMARY KEY,
    reserva INT NOT NULL FOREIGN KEY REFERENCES reservas(id),
    producto INT NOT NULL FOREIGN KEY REFERENCES productos(id),
    fecha DATETIME NOT NULL,
    cantidad INT NOT NULL
);
GO

CREATE TABLE mantenimientos (
    id INT NOT NULL PRIMARY KEY,
    habitacion INT NOT NULL FOREIGN KEY REFERENCES habitaciones(id),
    empleado INT NOT NULL FOREIGN KEY REFERENCES empleados(id),
    fecha DATETIME NOT NULL,
    descripcion VARCHAR(150) NOT NULL,
    costo DECIMAL(12,2) NOT NULL
);
GO

-- sedes
INSERT INTO sedes (id, nombre, ciudad, direccion, telefono, estrellas) VALUES (1, 'Hotel Andino Centro', 'Bogota', 'Cra 7 # 45-12', '6012345678', 4);
INSERT INTO sedes (id, nombre, ciudad, direccion, telefono, estrellas) VALUES (2, 'Hotel Andino Norte', 'Bogota', 'Cll 140 # 15-30', '6017654321', 5);
INSERT INTO sedes (id, nombre, ciudad, direccion, telefono, estrellas) VALUES (3, 'Hotel Andino Caribe', 'Cartagena', 'Av San Martin # 8-90', '6056789012', 5);
INSERT INTO sedes (id, nombre, ciudad, direccion, telefono, estrellas) VALUES (4, 'Hotel Andino Valle', 'Cali', 'Cll 5 # 60-20', '6023456789', 3);
INSERT INTO sedes (id, nombre, ciudad, direccion, telefono, estrellas) VALUES (5, 'Hotel Andino Cafe', 'Pereira', 'Cra 14 # 20-11', '6063344556', 4);
GO

-- tipos_habitacion
INSERT INTO tipos_habitacion (id, nombre, capacidad, tarifa_base, descripcion) VALUES (1, 'Sencilla', 1, 150000.0, 'Una cama sencilla');
INSERT INTO tipos_habitacion (id, nombre, capacidad, tarifa_base, descripcion) VALUES (2, 'Doble', 2, 220000.0, 'Dos camas sencillas');
INSERT INTO tipos_habitacion (id, nombre, capacidad, tarifa_base, descripcion) VALUES (3, 'Matrimonial', 2, 260000.0, 'Cama king');
INSERT INTO tipos_habitacion (id, nombre, capacidad, tarifa_base, descripcion) VALUES (4, 'Suite', 4, 450000.0, 'Sala, jacuzzi y balcon');
INSERT INTO tipos_habitacion (id, nombre, capacidad, tarifa_base, descripcion) VALUES (5, 'Familiar', 5, 520000.0, 'Dos habitaciones conectadas');
GO

-- cargos
INSERT INTO cargos (id, nombre, salario_base, area) VALUES (1, 'Recepcionista', 1600000.0, 'Recepcion');
INSERT INTO cargos (id, nombre, salario_base, area) VALUES (2, 'Camarera', 1400000.0, 'Housekeeping');
INSERT INTO cargos (id, nombre, salario_base, area) VALUES (3, 'Chef', 3200000.0, 'Alimentos');
INSERT INTO cargos (id, nombre, salario_base, area) VALUES (4, 'Mantenimiento', 1700000.0, 'Tecnica');
INSERT INTO cargos (id, nombre, salario_base, area) VALUES (5, 'Administrador', 4500000.0, 'Administracion');
GO

-- clientes
INSERT INTO clientes (id, documento, nombres, apellidos, correo, telefono) VALUES (1, '1094567321', 'Laura', 'Restrepo', 'laura.r@mail.com', '3101234567');
INSERT INTO clientes (id, documento, nombres, apellidos, correo, telefono) VALUES (2, '1023998745', 'Andres', 'Gomez', 'andres.g@mail.com', '3159876543');
INSERT INTO clientes (id, documento, nombres, apellidos, correo, telefono) VALUES (3, '79554123', 'Carlos', 'Mejia', 'c.mejia@mail.com', '3204567890');
INSERT INTO clientes (id, documento, nombres, apellidos, correo, telefono) VALUES (4, '52334871', 'Diana', 'Torres', 'diana.t@mail.com', '3012345678');
INSERT INTO clientes (id, documento, nombres, apellidos, correo, telefono) VALUES (5, '1088445566', 'Julian', 'Ospina', 'julian.o@mail.com', '3187654321');
GO

-- metodos_pago
INSERT INTO metodos_pago (id, nombre, comision, activo) VALUES (1, 'Efectivo', 0.0, 1);
INSERT INTO metodos_pago (id, nombre, comision, activo) VALUES (2, 'Tarjeta Credito', 2.5, 1);
INSERT INTO metodos_pago (id, nombre, comision, activo) VALUES (3, 'Tarjeta Debito', 1.2, 1);
INSERT INTO metodos_pago (id, nombre, comision, activo) VALUES (4, 'Transferencia', 0.5, 1);
INSERT INTO metodos_pago (id, nombre, comision, activo) VALUES (5, 'PSE', 1.0, 0);
GO

-- proveedores
INSERT INTO proveedores (id, nit, nombre, telefono, ciudad) VALUES (1, '900123456-1', 'Distribuidora El Sol', '6013334455', 'Bogota');
INSERT INTO proveedores (id, nit, nombre, telefono, ciudad) VALUES (2, '800998877-2', 'Vinos y Licores SAS', '6014445566', 'Bogota');
INSERT INTO proveedores (id, nit, nombre, telefono, ciudad) VALUES (3, '901556677-3', 'Snacks Andinos', '6045556677', 'Medellin');
INSERT INTO proveedores (id, nit, nombre, telefono, ciudad) VALUES (4, '830112233-4', 'Cafe de Origen', '6066667788', 'Pereira');
INSERT INTO proveedores (id, nit, nombre, telefono, ciudad) VALUES (5, '901778899-5', 'Insumos Hoteleros', '6057778899', 'Cartagena');
GO

-- servicios
INSERT INTO servicios (id, nombre, precio, categoria) VALUES (1, 'Lavanderia', 40000.0, 'Housekeeping');
INSERT INTO servicios (id, nombre, precio, categoria) VALUES (2, 'Spa relajante', 180000.0, 'Bienestar');
INSERT INTO servicios (id, nombre, precio, categoria) VALUES (3, 'Transporte aeropuerto', 90000.0, 'Transporte');
INSERT INTO servicios (id, nombre, precio, categoria) VALUES (4, 'Desayuno buffet', 35000.0, 'Alimentos');
INSERT INTO servicios (id, nombre, precio, categoria) VALUES (5, 'Alquiler salon', 600000.0, 'Eventos');
GO

-- productos
INSERT INTO productos (id, proveedor, nombre, precio, stock) VALUES (1, 1, 'Agua 600ml', 5000.0, 240);
INSERT INTO productos (id, proveedor, nombre, precio, stock) VALUES (2, 1, 'Gaseosa lata', 6000.0, 180);
INSERT INTO productos (id, proveedor, nombre, precio, stock) VALUES (3, 2, 'Vino tinto copa', 25000.0, 60);
INSERT INTO productos (id, proveedor, nombre, precio, stock) VALUES (4, 3, 'Snack mixto', 9000.0, 120);
INSERT INTO productos (id, proveedor, nombre, precio, stock) VALUES (5, 4, 'Cafe premium', 8000.0, 200);
GO

-- habitaciones
INSERT INTO habitaciones (id, sede, tipo, numero, piso, estado) VALUES (1, 1, 1, '101', 1, 'Disponible');
INSERT INTO habitaciones (id, sede, tipo, numero, piso, estado) VALUES (2, 1, 2, '102', 1, 'Ocupada');
INSERT INTO habitaciones (id, sede, tipo, numero, piso, estado) VALUES (3, 2, 4, '501', 5, 'Disponible');
INSERT INTO habitaciones (id, sede, tipo, numero, piso, estado) VALUES (4, 3, 3, '302', 3, 'Mantenimiento');
INSERT INTO habitaciones (id, sede, tipo, numero, piso, estado) VALUES (5, 4, 5, '205', 2, 'Ocupada');
GO

-- empleados
INSERT INTO empleados (id, sede, cargo, documento, nombres, fecha_ingreso) VALUES (1, 1, 1, '1015667788', 'Marcela Rios', '2023-02-01T00:00:00');
INSERT INTO empleados (id, sede, cargo, documento, nombres, fecha_ingreso) VALUES (2, 1, 2, '1002334455', 'Sandra Lopez', '2022-08-15T00:00:00');
INSERT INTO empleados (id, sede, cargo, documento, nombres, fecha_ingreso) VALUES (3, 2, 3, '80123456', 'Ivan Duarte', '2021-05-10T00:00:00');
INSERT INTO empleados (id, sede, cargo, documento, nombres, fecha_ingreso) VALUES (4, 3, 4, '73445566', 'Pedro Salas', '2024-01-20T00:00:00');
INSERT INTO empleados (id, sede, cargo, documento, nombres, fecha_ingreso) VALUES (5, 4, 5, '1093221100', 'Ana Beltran', '2020-11-03T00:00:00');
GO

-- reservas
INSERT INTO reservas (id, cliente, empleado, fecha_reserva, fecha_entrada, fecha_salida, estado) VALUES (1, 1, 1, '2026-08-01T00:00:00', '2026-08-10T00:00:00', '2026-08-13T00:00:00', 'Cerrada');
INSERT INTO reservas (id, cliente, empleado, fecha_reserva, fecha_entrada, fecha_salida, estado) VALUES (2, 2, 1, '2026-08-03T00:00:00', '2026-08-12T00:00:00', '2026-08-15T00:00:00', 'Confirmada');
INSERT INTO reservas (id, cliente, empleado, fecha_reserva, fecha_entrada, fecha_salida, estado) VALUES (3, 3, 3, '2026-08-05T00:00:00', '2026-08-20T00:00:00', '2026-08-22T00:00:00', 'Confirmada');
INSERT INTO reservas (id, cliente, empleado, fecha_reserva, fecha_entrada, fecha_salida, estado) VALUES (4, 4, 5, '2026-08-07T00:00:00', '2026-08-18T00:00:00', '2026-08-19T00:00:00', 'Cancelada');
INSERT INTO reservas (id, cliente, empleado, fecha_reserva, fecha_entrada, fecha_salida, estado) VALUES (5, 5, 1, '2026-08-09T00:00:00', '2026-08-25T00:00:00', '2026-08-30T00:00:00', 'Confirmada');
GO

-- detalles_reserva
INSERT INTO detalles_reserva (id, reserva, habitacion, noches, tarifa_aplicada) VALUES (1, 1, 1, 3, 150000.0);
INSERT INTO detalles_reserva (id, reserva, habitacion, noches, tarifa_aplicada) VALUES (2, 2, 2, 3, 220000.0);
INSERT INTO detalles_reserva (id, reserva, habitacion, noches, tarifa_aplicada) VALUES (3, 3, 3, 2, 450000.0);
INSERT INTO detalles_reserva (id, reserva, habitacion, noches, tarifa_aplicada) VALUES (4, 4, 4, 1, 260000.0);
INSERT INTO detalles_reserva (id, reserva, habitacion, noches, tarifa_aplicada) VALUES (5, 5, 5, 5, 520000.0);
GO

-- check_in
INSERT INTO check_in (id, reserva, empleado, fecha_hora, observacion) VALUES (1, 1, 1, '2026-08-10T14:05:00', 'Sin novedades');
INSERT INTO check_in (id, reserva, empleado, fecha_hora, observacion) VALUES (2, 2, 1, '2026-08-12T15:30:00', 'Solicita cuna');
INSERT INTO check_in (id, reserva, empleado, fecha_hora, observacion) VALUES (3, 3, 3, '2026-08-20T13:10:00', 'Llegada anticipada');
INSERT INTO check_in (id, reserva, empleado, fecha_hora, observacion) VALUES (4, 5, 1, '2026-08-25T16:45:00', 'Grupo familiar');
INSERT INTO check_in (id, reserva, empleado, fecha_hora, observacion) VALUES (5, 1, 5, '2026-08-10T18:00:00', 'Cambio de habitacion');
GO

-- check_out
INSERT INTO check_out (id, check_in, fecha_hora, estado_habitacion, cargos_extra) VALUES (1, 1, '2026-08-13T11:00:00', 'Bueno', 0.0);
INSERT INTO check_out (id, check_in, fecha_hora, estado_habitacion, cargos_extra) VALUES (2, 2, '2026-08-15T10:30:00', 'Bueno', 45000.0);
INSERT INTO check_out (id, check_in, fecha_hora, estado_habitacion, cargos_extra) VALUES (3, 3, '2026-08-22T12:00:00', 'Regular', 120000.0);
INSERT INTO check_out (id, check_in, fecha_hora, estado_habitacion, cargos_extra) VALUES (4, 4, '2026-08-30T09:40:00', 'Bueno', 0.0);
INSERT INTO check_out (id, check_in, fecha_hora, estado_habitacion, cargos_extra) VALUES (5, 5, '2026-08-13T11:20:00', 'Bueno', 30000.0);
GO

-- facturas
INSERT INTO facturas (id, reserva, cliente, fecha, subtotal, iva, total) VALUES (1, 1, 1, '2026-08-13T00:00:00', 450000.0, 85500.0, 535500.0);
INSERT INTO facturas (id, reserva, cliente, fecha, subtotal, iva, total) VALUES (2, 2, 2, '2026-08-15T00:00:00', 660000.0, 125400.0, 785400.0);
INSERT INTO facturas (id, reserva, cliente, fecha, subtotal, iva, total) VALUES (3, 3, 3, '2026-08-22T00:00:00', 900000.0, 171000.0, 1071000.0);
INSERT INTO facturas (id, reserva, cliente, fecha, subtotal, iva, total) VALUES (4, 5, 5, '2026-08-30T00:00:00', 2600000.0, 494000.0, 3094000.0);
INSERT INTO facturas (id, reserva, cliente, fecha, subtotal, iva, total) VALUES (5, 1, 1, '2026-08-13T00:00:00', 80000.0, 15200.0, 95200.0);
GO

-- detalles_factura
INSERT INTO detalles_factura (id, factura, concepto, cantidad, valor_unitario) VALUES (1, 1, 'Alojamiento sencilla', 3, 150000.0);
INSERT INTO detalles_factura (id, factura, concepto, cantidad, valor_unitario) VALUES (2, 2, 'Alojamiento doble', 3, 220000.0);
INSERT INTO detalles_factura (id, factura, concepto, cantidad, valor_unitario) VALUES (3, 3, 'Alojamiento suite', 2, 450000.0);
INSERT INTO detalles_factura (id, factura, concepto, cantidad, valor_unitario) VALUES (4, 4, 'Alojamiento familiar', 5, 520000.0);
INSERT INTO detalles_factura (id, factura, concepto, cantidad, valor_unitario) VALUES (5, 5, 'Servicio de lavanderia', 2, 40000.0);
GO

-- pagos
INSERT INTO pagos (id, factura, metodo, fecha, valor) VALUES (1, 1, 1, '2026-08-13T00:00:00', 535500.0);
INSERT INTO pagos (id, factura, metodo, fecha, valor) VALUES (2, 2, 2, '2026-08-15T00:00:00', 785400.0);
INSERT INTO pagos (id, factura, metodo, fecha, valor) VALUES (3, 3, 4, '2026-08-22T00:00:00', 1071000.0);
INSERT INTO pagos (id, factura, metodo, fecha, valor) VALUES (4, 4, 3, '2026-08-30T00:00:00', 3094000.0);
INSERT INTO pagos (id, factura, metodo, fecha, valor) VALUES (5, 5, 1, '2026-08-13T00:00:00', 95200.0);
GO

-- servicios_solicitados
INSERT INTO servicios_solicitados (id, reserva, servicio, fecha, cantidad, estado) VALUES (1, 1, 1, '2026-08-11T00:00:00', 2, 'Prestado');
INSERT INTO servicios_solicitados (id, reserva, servicio, fecha, cantidad, estado) VALUES (2, 2, 4, '2026-08-13T00:00:00', 3, 'Prestado');
INSERT INTO servicios_solicitados (id, reserva, servicio, fecha, cantidad, estado) VALUES (3, 3, 2, '2026-08-21T00:00:00', 1, 'Prestado');
INSERT INTO servicios_solicitados (id, reserva, servicio, fecha, cantidad, estado) VALUES (4, 5, 3, '2026-08-25T00:00:00', 1, 'Pendiente');
INSERT INTO servicios_solicitados (id, reserva, servicio, fecha, cantidad, estado) VALUES (5, 5, 5, '2026-08-27T00:00:00', 1, 'Pendiente');
GO

-- consumos
INSERT INTO consumos (id, reserva, producto, fecha, cantidad) VALUES (1, 1, 1, '2026-08-10T20:15:00', 2);
INSERT INTO consumos (id, reserva, producto, fecha, cantidad) VALUES (2, 2, 3, '2026-08-13T21:00:00', 1);
INSERT INTO consumos (id, reserva, producto, fecha, cantidad) VALUES (3, 3, 4, '2026-08-20T18:40:00', 3);
INSERT INTO consumos (id, reserva, producto, fecha, cantidad) VALUES (4, 5, 5, '2026-08-26T07:30:00', 2);
INSERT INTO consumos (id, reserva, producto, fecha, cantidad) VALUES (5, 5, 2, '2026-08-27T22:10:00', 4);
GO

-- mantenimientos
INSERT INTO mantenimientos (id, habitacion, empleado, fecha, descripcion, costo) VALUES (1, 4, 4, '2026-08-05T00:00:00', 'Cambio de aire acondicionado', 850000.0);
INSERT INTO mantenimientos (id, habitacion, empleado, fecha, descripcion, costo) VALUES (2, 1, 4, '2026-08-08T00:00:00', 'Reparacion de ducha', 120000.0);
INSERT INTO mantenimientos (id, habitacion, empleado, fecha, descripcion, costo) VALUES (3, 2, 4, '2026-08-14T00:00:00', 'Pintura de paredes', 300000.0);
INSERT INTO mantenimientos (id, habitacion, empleado, fecha, descripcion, costo) VALUES (4, 3, 4, '2026-08-18T00:00:00', 'Cambio de cerradura', 180000.0);
INSERT INTO mantenimientos (id, habitacion, empleado, fecha, descripcion, costo) VALUES (5, 5, 4, '2026-08-23T00:00:00', 'Revision electrica', 95000.0);
GO

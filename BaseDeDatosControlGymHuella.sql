-- Crear la base de datos
CREATE DATABASE control_gym_huella;
GO

-- Usar la base de datos recién creada
USE control_gym_huella;
GO

-- Crear tablas
CREATE TABLE socios (
    id_socio INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    dni_socio INT,
    nombre VARCHAR(30) NOT NULL,
    apellido VARCHAR(30) NOT NULL,
    telefono VARCHAR(15),
    fecha_nac DATETIME,
    domicilio VARCHAR(100),
    email VARCHAR(50)
);
GO

CREATE TABLE huellas_digitales (
    id_huella INT IDENTITY(1,1) PRIMARY KEY,
    id_socio INT NOT NULL,
    huella VARBINARY(MAX) NOT NULL,
    fecha_registro DATETIME DEFAULT GETDATE(),
    FOREIGN KEY(id_socio) REFERENCES socios(id_socio)
);
GO

CREATE TABLE empleados (
    dni_empleado INT NOT NULL PRIMARY KEY,
    nombre VARCHAR(30) NOT NULL,
    apellido VARCHAR(30) NOT NULL,
    telefono VARCHAR(15),
    fecha_nac DATETIME NOT NULL,
    domicilio VARCHAR(100) NOT NULL,
    email VARCHAR(50) UNIQUE,
    contraseña VARCHAR(100) NOT NULL,
    rol VARCHAR(20) NOT NULL
);
GO

CREATE TABLE clientes (
    dni_cliente INT PRIMARY KEY,
    nombre VARCHAR(50),
    apellido VARCHAR(30),
    telefono VARCHAR(15),
    domicilio VARCHAR(100),
    email VARCHAR(50)
);
GO

CREATE TABLE proveedores (
    cod_proveedor INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL,
    cuit VARCHAR(20),
    telefono VARCHAR(15) NOT NULL,
    direccion VARCHAR(100) NOT NULL,
    email VARCHAR(50) NOT NULL
);
GO

CREATE TABLE tipos_productos (
    cod_tipo_producto INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    nombre VARCHAR(50)
);
GO

CREATE TABLE productos (
    cod_producto BIGINT PRIMARY KEY NOT NULL IDENTITY(1,1),
    cod_proveedor INT NOT NULL,
    cod_tipo_producto INT NOT NULL,
    nombre VARCHAR(50),
    fecha_venc DATETIME,
    precio_costo DECIMAL NOT NULL,
    precio_venta DECIMAL NOT NULL,
    ganancia DECIMAL NOT NULL,
    stock INT NOT NULL,
    FOREIGN KEY(cod_proveedor) REFERENCES proveedores(cod_proveedor),
    FOREIGN KEY(cod_tipo_producto) REFERENCES tipos_productos(cod_tipo_producto)
);
GO

CREATE TABLE ventas (
    num_venta INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    dni_cliente INT NOT NULL,
    dni_empleado INT NOT NULL,
    fecha DATETIME NOT NULL,
    total DECIMAL NOT NULL,
    FOREIGN KEY(dni_cliente) REFERENCES clientes(dni_cliente),
    FOREIGN KEY(dni_empleado) REFERENCES empleados(dni_empleado)
);
GO

CREATE TABLE detalles_ventas (
    num_venta INT NOT NULL,
    cod_producto BIGINT NOT NULL,
    subtotal DECIMAL NOT NULL,
    cantidad INT NOT NULL,
    descuento DECIMAL,
    FOREIGN KEY(num_venta) REFERENCES ventas(num_venta),
    FOREIGN KEY(cod_producto) REFERENCES productos(cod_producto)
);
GO

CREATE TABLE tipos_membresias (
    cod_tipo_membresia INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL,
    precio DECIMAL NOT NULL,
    cantidad_dias INT NOT NULL
);
GO

CREATE TABLE membresias (
    cod_membresia INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    cod_tipo_membresia INT NOT NULL,
    id_socio INT NOT NULL,
    fecha_inicio DATETIME NOT NULL,
    fecha_fin DATETIME NOT NULL,
    FOREIGN KEY(cod_tipo_membresia) REFERENCES tipos_membresias(cod_tipo_membresia),
    FOREIGN KEY(id_socio) REFERENCES socios(id_socio)
);
GO

CREATE TABLE Licencias (
    IdLicencia INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    dni_empleado INT NOT NULL,
    FechaInicio DATETIME NOT NULL,
    FechaExpiracion DATETIME NOT NULL,
    Estado VARCHAR(50) NOT NULL,
    FOREIGN KEY(dni_empleado) REFERENCES empleados(dni_empleado)
);
GO

CREATE TABLE cuotas (
    cod_cuota INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    cod_membresia INT NOT NULL,
    fecha_pago DATETIME NOT NULL,
    FOREIGN KEY(cod_membresia) REFERENCES membresias(cod_membresia)
);
GO

CREATE TABLE asistencias (
    id_asistencia INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    id_socio INT NOT NULL,
    fecha_asistencia DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (id_socio) REFERENCES socios(id_socio)
);
GO

-- Crear tipo para detalles de ventas
CREATE TYPE detalles_ventas_type AS TABLE (
    cod_producto BIGINT,
    subtotal DECIMAL,
    cantidad INT,
    descuento DECIMAL
);
GO

-- Procedimientos almacenados
CREATE PROCEDURE spRealizarVenta
    @dni_cliente INT,
    @dni_empleado INT,
    @descuento DECIMAL,
    @detallesVenta DETALLES_VENTAS_TYPE READONLY,
    @total DECIMAL
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @num_venta INT;

    BEGIN TRY
        BEGIN TRANSACTION;
        INSERT INTO ventas (dni_cliente, dni_empleado, fecha, total)
        VALUES (@dni_cliente, @dni_empleado, GETDATE(), @total);
        SET @num_venta = SCOPE_IDENTITY();

        INSERT INTO detalles_ventas (num_venta, cod_producto, subtotal, cantidad, descuento)
        SELECT @num_venta, d.cod_producto, 
               (p.precio_venta - (p.precio_venta * d.descuento / 100)) * d.cantidad, 
               d.cantidad, d.descuento
        FROM @detallesVenta AS d
        INNER JOIN productos AS p ON d.cod_producto = p.cod_producto;

        COMMIT;
    END TRY
    BEGIN CATCH
        ROLLBACK;
        THROW;
    END CATCH;
END;
GO

CREATE PROCEDURE [dbo].[sp_GuardarSocioConHuella]
    @dni INT,
    @nombre NVARCHAR(100),
    @apellido NVARCHAR(100),
    @fechaNacimiento DATE,
    @telefono NVARCHAR(20),
    @domicilio NVARCHAR(255),
    @email NVARCHAR(100),
    @huella VARBINARY(MAX)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;
        INSERT INTO socios (dni_socio, nombre, apellido, fecha_nac, telefono, domicilio, email)
        VALUES (@dni, @nombre, @apellido, @fechaNacimiento, @telefono, @domicilio, @email);

        DECLARE @idSocio INT;
        SET @idSocio = SCOPE_IDENTITY();

        INSERT INTO huellas_digitales (id_socio, huella)
        VALUES (@idSocio, @huella);

        COMMIT;
    END TRY
    BEGIN CATCH
        ROLLBACK;
        THROW;
    END CATCH;
END;
GO

CREATE PROCEDURE EliminarSocio
    @id_socio INT
AS
BEGIN
    BEGIN TRY
        DELETE FROM cuotas WHERE cod_membresia IN (SELECT cod_membresia FROM membresias WHERE id_socio = @id_socio);
        DELETE FROM membresias WHERE id_socio = @id_socio;
        DELETE FROM huellas_digitales WHERE id_socio = @id_socio;
        DELETE FROM socios WHERE id_socio = @id_socio;
        PRINT 'Socio eliminado correctamente';
    END TRY
    BEGIN CATCH
        PRINT 'Error al eliminar socio: ' + ERROR_MESSAGE();
    END CATCH;
END;
GO

-- Datos iniciales
INSERT INTO empleados (dni_empleado, nombre, apellido, telefono, fecha_nac, domicilio, email, contraseña, rol)
VALUES (41144645, 'Nicolás', 'Contreras', '3813328410', GETDATE(), 'Las Talitas', 'asd@gmail.com', 'test', 'Administrador');
GO

INSERT INTO Licencias (dni_empleado, FechaInicio, FechaExpiracion, Estado)
VALUES (41144645, GETDATE(), '2026-01-01', 'Activa');
GO

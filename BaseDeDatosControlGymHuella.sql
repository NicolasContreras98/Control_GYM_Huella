-- ============================================
-- CREAR BASE DE DATOS
-- ============================================
CREATE DATABASE control_gym_huella;
GO

USE control_gym_huella;
GO


-- ============================================
-- TABLAS
-- ============================================

CREATE TABLE socios (
    id_socio INT IDENTITY(1,1) PRIMARY KEY,
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
    dni_empleado INT PRIMARY KEY,
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
    cod_proveedor INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL,
    cuit VARCHAR(20),
    telefono VARCHAR(15) NOT NULL,
    direccion VARCHAR(100) NOT NULL,
    email VARCHAR(50) NOT NULL
);
GO


CREATE TABLE tipos_productos (
    cod_tipo_producto INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(50)
);
GO


CREATE TABLE productos (
    cod_producto BIGINT IDENTITY(1,1) PRIMARY KEY,
    cod_proveedor INT NOT NULL,
    cod_tipo_producto INT NOT NULL,
    nombre VARCHAR(50),
    fecha_venc DATETIME,
    precio_costo DECIMAL(10,2) NOT NULL,
    precio_venta DECIMAL(10,2) NOT NULL,
    ganancia DECIMAL(10,2) NOT NULL,
    stock INT NOT NULL,
    FOREIGN KEY(cod_proveedor) REFERENCES proveedores(cod_proveedor),
    FOREIGN KEY(cod_tipo_producto) REFERENCES tipos_productos(cod_tipo_producto)
);
GO


CREATE TABLE ventas (
    num_venta INT IDENTITY(1,1) PRIMARY KEY,
    dni_cliente INT NOT NULL,
    dni_empleado INT NOT NULL,
    fecha DATETIME NOT NULL,
    total DECIMAL(10,2) NOT NULL,
    FOREIGN KEY(dni_cliente) REFERENCES clientes(dni_cliente),
    FOREIGN KEY(dni_empleado) REFERENCES empleados(dni_empleado)
);
GO


CREATE TABLE detalles_ventas (
    num_venta INT NOT NULL,
    cod_producto BIGINT NOT NULL,
    subtotal DECIMAL(10,2) NOT NULL,
    cantidad INT NOT NULL,
    descuento DECIMAL(10,2),
    FOREIGN KEY(num_venta) REFERENCES ventas(num_venta),
    FOREIGN KEY(cod_producto) REFERENCES productos(cod_producto)
);
GO


CREATE TABLE tipos_membresias (
    cod_tipo_membresia INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL,
    precio DECIMAL(10,2) NOT NULL,
    cantidad_dias INT NOT NULL
);
GO


CREATE TABLE membresias (
    cod_membresia INT IDENTITY(1,1) PRIMARY KEY,
    cod_tipo_membresia INT NOT NULL,
    id_socio INT NOT NULL,
    fecha_inicio DATETIME NOT NULL,
    fecha_fin DATETIME NOT NULL,
    estado VARCHAR(20) DEFAULT 'Activa',
    FOREIGN KEY(cod_tipo_membresia) REFERENCES tipos_membresias(cod_tipo_membresia),
    FOREIGN KEY(id_socio) REFERENCES socios(id_socio)
);
GO


CREATE TABLE Licencias (
    IdLicencia INT IDENTITY(1,1) PRIMARY KEY,
    dni_empleado INT NOT NULL,
    FechaInicio DATETIME NOT NULL,
    FechaExpiracion DATETIME NOT NULL,
    Estado VARCHAR(50) NOT NULL,
    FOREIGN KEY(dni_empleado) REFERENCES empleados(dni_empleado)
);
GO


CREATE TABLE cuotas (
    cod_cuota INT IDENTITY(1,1) PRIMARY KEY,
    cod_membresia INT NOT NULL,
    fecha_pago DATETIME NOT NULL,
    monto DECIMAL(10,2) NOT NULL,
    FOREIGN KEY(cod_membresia) REFERENCES membresias(cod_membresia)
);
GO


CREATE TABLE asistencias (
    id_asistencia INT IDENTITY(1,1) PRIMARY KEY,
    id_socio INT NOT NULL,
    fecha_asistencia DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (id_socio) REFERENCES socios(id_socio)
);
GO

-- ============================================
-- TIPO PARA DETALLES DE VENTA
-- ============================================

CREATE TYPE detalles_ventas_type AS TABLE (
    cod_producto BIGINT,
    subtotal DECIMAL(10,2),
    cantidad INT,
    descuento DECIMAL(10,2)
);
GO

-- ============================================
-- PROCEDIMIENTOS ALMACENADOS
-- ============================================
-- ============================================
-- PROCEDIMIENTO REALIZAR VENTA
-- ============================================

CREATE PROCEDURE sp_RealizarVenta
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
        SELECT 
            @num_venta,
            d.cod_producto,
            (p.precio_venta - (p.precio_venta * d.descuento / 100)) * d.cantidad,
            d.cantidad,
            d.descuento
        FROM @detallesVenta d
        INNER JOIN productos p ON d.cod_producto = p.cod_producto;

        COMMIT;

    END TRY
    BEGIN CATCH
        ROLLBACK;
        THROW;
    END CATCH
END
GO


-- ============================================
-- GUARDAR SOCIO CON HUELLA
-- ============================================

CREATE PROCEDURE sp_GuardarSocioConHuella
    @dni INT,
    @nombre NVARCHAR(100),
    @apellido NVARCHAR(100),
    @fechaNacimiento DATE,
    @telefono NVARCHAR(20),
    @domicilio NVARCHAR(255),
    @email NVARCHAR(100),
    @huella VARBINARY(MAX) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY

        BEGIN TRANSACTION;

        INSERT INTO socios
        (dni_socio, nombre, apellido, fecha_nac, telefono, domicilio, email)
        VALUES
        (@dni, @nombre, @apellido, @fechaNacimiento, @telefono, @domicilio, @email);

        DECLARE @idSocio INT;
        SET @idSocio = SCOPE_IDENTITY();

        -- Insertar huella solo si tiene datos reales
        IF @huella IS NOT NULL AND DATALENGTH(@huella) > 0
        BEGIN
            INSERT INTO huellas_digitales (id_socio, huella)
            VALUES (@idSocio, @huella);
        END

        COMMIT;

    END TRY
    BEGIN CATCH

        IF @@TRANCOUNT > 0
            ROLLBACK;

        THROW;

    END CATCH
END
GO


-- ============================================
-- ELIMINAR SOCIO
-- ============================================

CREATE PROCEDURE sp_EliminarSocio
    @id_socio INT
AS
BEGIN
    BEGIN TRY

        DELETE FROM cuotas
        WHERE cod_membresia IN
        (SELECT cod_membresia FROM membresias WHERE id_socio = @id_socio)

        DELETE FROM membresias WHERE id_socio = @id_socio
        DELETE FROM huellas_digitales WHERE id_socio = @id_socio
        DELETE FROM socios WHERE id_socio = @id_socio

    END TRY
    BEGIN CATCH
        PRINT ERROR_MESSAGE()
    END CATCH
END
GO


-- ============================================
-- REGISTRAR CUOTA
-- ============================================

CREATE PROCEDURE sp_RegistrarCuota
    @cod_membresia INT
AS
BEGIN

    DECLARE @monto DECIMAL(10,2)

    SELECT @monto = tm.precio
    FROM membresias m
    INNER JOIN tipos_membresias tm
        ON m.cod_tipo_membresia = tm.cod_tipo_membresia
    WHERE m.cod_membresia = @cod_membresia

    INSERT INTO cuotas (cod_membresia, fecha_pago, monto)
    VALUES (@cod_membresia, GETDATE(), @monto)

END
GO


-- ============================================
-- DATOS INICIALES
-- ============================================

INSERT INTO empleados
(dni_empleado, nombre, apellido, telefono, fecha_nac, domicilio, email, contraseña, rol)
VALUES
(41144645,'Nicolás','Contreras','3813328410',GETDATE(),'Las Talitas','asd@gmail.com','test','Administrador');
GO


INSERT INTO Licencias
(dni_empleado, FechaInicio, FechaExpiracion, Estado)
VALUES
(41144645, GETDATE(), '2050-01-01', 'Activa');
GO
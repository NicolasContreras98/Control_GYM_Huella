CREATE DATABASE control_gym_huella;
USE control_gym_huella;


-- Tabla Socios
CREATE TABLE socios (
    id_socio INT IDENTITY(1,1) NOT NULL PRIMARY KEY, -- Cambio nombre del id
	dni_socio INT, -- AGREGO DNI PARA QUE REALICE LA BÚSQUEDA DEL SOCIO(NO HARÁ LA VERIFICACION DE LOGIN MEDIANTE ESTE)
    nombre VARCHAR(30) NOT NULL,
    apellido VARCHAR(30) NOT NULL,
	-- AGREGO CAMPOS NUEVOS QUE ESTABAN EN EL ANTERIOR ESQUEMA Y EN LA VENTANA DE SOCIOS
	telefono VARCHAR(15),
	fecha_nac DATETIME,
	domicilio VARCHAR(100),
	email VARCHAR(50)
);

CREATE TABLE huellas_digitales (
    id_huella INT IDENTITY(1,1) PRIMARY KEY,
    id_socio INT NOT NULL,
    huella VARBINARY(MAX) NOT NULL,
    fecha_registro DATETIME DEFAULT GETDATE(),

	FOREIGN KEY(id_socio) REFERENCES socios(id_socio)
);

-- Tabla Empleados
CREATE TABLE empleados(
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

-- Tabla Clientes
CREATE TABLE clientes(
    dni_cliente INT PRIMARY KEY,
    nombre VARCHAR(50),
	apellido VARCHAR(30),
    telefono VARCHAR(15),
    domicilio VARCHAR(100),
    email VARCHAR(50)
);

-- Tabla Proveedores
CREATE TABLE proveedores(
    cod_proveedor INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL,
    cuit VARCHAR(20),
    telefono VARCHAR(15) NOT NULL,
    direccion VARCHAR(100) NOT NULL,
    email VARCHAR(50) NOT NULL
);

-- Tabla Tipos de Productos
CREATE TABLE tipos_productos(
    cod_tipo_producto INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    nombre VARCHAR(50)
);

-- Tabla Productos
CREATE TABLE productos(
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

-- Tabla Ventas
CREATE TABLE ventas(
    num_venta INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    dni_cliente INT NOT NULL,
    dni_empleado INT NOT NULL,
    fecha DATETIME NOT NULL,
    total DECIMAL NOT NULL,
    
    FOREIGN KEY(dni_cliente) REFERENCES clientes(dni_cliente),
    FOREIGN KEY(dni_empleado) REFERENCES empleados(dni_empleado)
);

-- Tabla Detalles Ventas
CREATE TABLE detalles_ventas(
    num_venta INT NOT NULL,
    cod_producto BIGINT NOT NULL,
    subtotal DECIMAL NOT NULL,
    cantidad INT NOT NULL,
    descuento DECIMAL,
    
    FOREIGN KEY(num_venta) REFERENCES ventas(num_venta),
    FOREIGN KEY(cod_producto) REFERENCES productos(cod_producto)
);

-- Tabla Tipos de Membresías
CREATE TABLE tipos_membresias(
    cod_tipo_membresia INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL,
    precio DECIMAL NOT NULL,
    cantidad_dias INT NOT NULL
);

-- Tabla Membresías
CREATE TABLE membresias(
    cod_membresia INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    cod_tipo_membresia INT NOT NULL,
    id_socio INT NOT NULL,
    fecha_inicio DATETIME NOT NULL,
    fecha_fin DATETIME NOT NULL,
    
    FOREIGN KEY(cod_tipo_membresia) REFERENCES tipos_membresias(cod_tipo_membresia),
    FOREIGN KEY(id_socio) REFERENCES socios(id_socio)
);

-- Tabla Licencias
CREATE TABLE Licencias (
    IdLicencia INT IDENTITY(1,1) NOT NULL PRIMARY KEY, -- Columna autoincremental para IdLicencia
    dni_empleado INT NOT NULL, -- Clave foránea referenciando a empleados
    FechaInicio DATETIME NOT NULL, -- Fecha de inicio de la licencia
    FechaExpiracion DATETIME NOT NULL, -- Fecha de expiración de la licencia
    Estado VARCHAR(50) NOT NULL, -- Estado de la licencia (por ejemplo, activa, expirada, etc.)
    
    FOREIGN KEY (dni_empleado) REFERENCES empleados(dni_empleado) -- Relación con la tabla empleados
);

-- Tabla Cuotas
CREATE TABLE cuotas (
    cod_cuota INT IDENTITY(1,1) NOT NULL PRIMARY KEY, -- Columna autoincremental para cod_cuota
    cod_membresia INT NOT NULL, -- Clave foránea referenciando a membresias
    fecha_pago DATETIME NOT NULL, -- Fecha de pago de la cuota
    
    FOREIGN KEY (cod_membresia) REFERENCES membresias(cod_membresia) -- Relación con la tabla membresias
);

-- Crear el tipo de datos para detalles de ventas
CREATE TYPE detalles_ventas_type AS TABLE
(
    cod_producto BIGINT,
    subtotal DECIMAL,
    cantidad INT,
    descuento DECIMAL
);

-- Procedimiento para realizar una venta
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
        
        DECLARE @stockSuficiente BIT = 1;
        
        SELECT @stockSuficiente = CASE
            WHEN p.stock >= d.cantidad THEN 1
            ELSE 0
        END
        FROM @detallesVenta AS d
        INNER JOIN productos AS p ON d.cod_producto = p.cod_producto;
        
        IF @stockSuficiente = 1
        BEGIN
            INSERT INTO detalles_ventas (num_venta, cod_producto, subtotal, cantidad, descuento)
            SELECT @num_venta, d.cod_producto, (p.precio_venta - (p.precio_venta * d.descuento / 100)) * d.cantidad, d.cantidad, d.descuento
            FROM @detallesVenta AS d
            INNER JOIN productos AS p ON d.cod_producto = p.cod_producto;
            
            UPDATE productos
            SET stock = stock - d.cantidad
            FROM @detallesVenta AS d
            WHERE productos.cod_producto = d.cod_producto;
        END
        ELSE
        BEGIN
            THROW 51000, 'No hay suficiente stock para completar la venta.', 0;
        END
        
        COMMIT;
    END TRY
    BEGIN CATCH
        ROLLBACK;
    END CATCH;
END;





USE [control_gym_huella]
GO

/** Object:  StoredProcedure [dbo].[sp_GuardarSocioConHuella]    Script Date: 07/11/2024 13:13:59 **/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
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
    -- Iniciar transacción para asegurar la consistencia de los datos
    BEGIN TRY
        BEGIN TRANSACTION;
        
        -- Insertar los datos del socio
        INSERT INTO socios (dni_socio, nombre, apellido, fecha_nac, telefono, domicilio, email)
        VALUES (@dni, @nombre, @apellido, @fechaNacimiento, @telefono, @domicilio, @email);
        
        -- Obtener el id del socio recién insertado
        DECLARE @idSocio INT;
        SET @idSocio = SCOPE_IDENTITY();

        -- Insertar la huella dactilar asociada al socio
        INSERT INTO huellas_digitales (id_socio, huella)
        VALUES (@idSocio, @huella);

        -- Confirmar la transacción
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- Si ocurre un error, revertir la transacción
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;

GO

CREATE PROCEDURE EliminarSocio
    @id_socio INT
AS
BEGIN
    BEGIN TRY
        -- 1. Eliminar cuotas asociadas a la membresía del socio
        DELETE FROM cuotas
        WHERE cod_membresia IN (SELECT cod_membresia FROM membresias WHERE id_socio = @id_socio);

        -- 2. Eliminar membresías asociadas al socio
        DELETE FROM membresias
        WHERE id_socio = @id_socio;

        -- 3. Eliminar huellas digitales asociadas al socio
        DELETE FROM huellas_digitales
        WHERE id_socio = @id_socio;

        -- 4. Finalmente, eliminar al socio
        DELETE FROM socios
        WHERE id_socio = @id_socio;

        PRINT 'Socio eliminado correctamente';
    END TRY
    BEGIN CATCH
        PRINT 'Error al eliminar socio: ' + ERROR_MESSAGE();
    END CATCH
END;



-- CONSULTAS

INSERT INTO [dbo].[empleados]
           ([dni_empleado]
           ,[nombre]
           ,[apellido]
           ,[telefono]
           ,[fecha_nac]
           ,[domicilio]
           ,[email]
           ,[contraseña]
           ,[rol])
     VALUES
           (44616531
           ,'Tomás'
           ,'Sosa'
           ,'3813284273'
           ,GETDATE()
           ,'Diagonal Sur 464'
           ,'tomas.facundo.sosa@gmail.com'
           ,'eugenia11'
           ,'Administrador')
GO

insert into Licencias values(44616531, GETDATE(), '2026-01-01', 'Activa')
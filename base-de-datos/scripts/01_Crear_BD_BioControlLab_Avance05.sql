/*
    BioControl Lab - Avance 05
    Base de datos con 15 tablas, PK y FK.
    La parte codeable actual conecta login, roles, cliente/admin e instrumentos.
    Los demás módulos quedan preparados para las interfaces de fachada.
*/

IF DB_ID('BioControlLab') IS NOT NULL
BEGIN
    ALTER DATABASE BioControlLab SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE BioControlLab;
END
GO

CREATE DATABASE BioControlLab;
GO

USE BioControlLab;
GO

-- 1. ROLES
CREATE TABLE Roles (
    idRol INT IDENTITY(1,1) PRIMARY KEY,
    nombreRol VARCHAR(30) NOT NULL UNIQUE,
    descripcion VARCHAR(150) NULL,
    activo BIT NOT NULL DEFAULT 1
);
GO

-- 2. CLIENTES
CREATE TABLE Clientes (
    idCliente INT IDENTITY(1,1) PRIMARY KEY,
    codigoCliente VARCHAR(20) NOT NULL UNIQUE,
    nombres VARCHAR(80) NOT NULL,
    apellidos VARCHAR(80) NOT NULL,
    cedula VARCHAR(25) NULL,
    telefono VARCHAR(25) NULL,
    correo VARCHAR(100) NULL,
    direccion VARCHAR(200) NULL,
    activo BIT NOT NULL DEFAULT 1
);
GO

-- 3. EMPLEADOS
CREATE TABLE Empleados (
    idEmpleado INT IDENTITY(1,1) PRIMARY KEY,
    codigoEmpleado VARCHAR(20) NOT NULL UNIQUE,
    nombres VARCHAR(80) NOT NULL,
    apellidos VARCHAR(80) NOT NULL,
    cargo VARCHAR(60) NOT NULL,
    telefono VARCHAR(25) NULL,
    correo VARCHAR(100) NULL,
    activo BIT NOT NULL DEFAULT 1
);
GO

-- 4. USUARIOS
CREATE TABLE Usuarios (
    idUsuario INT IDENTITY(1,1) PRIMARY KEY,
    idRol INT NOT NULL,
    idCliente INT NULL,
    idEmpleado INT NULL,
    usuario VARCHAR(50) NOT NULL UNIQUE,
    clave VARCHAR(50) NOT NULL,
    nombreCompleto VARCHAR(120) NOT NULL,
    activo BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_Usuarios_Roles FOREIGN KEY (idRol) REFERENCES Roles(idRol),
    CONSTRAINT FK_Usuarios_Clientes FOREIGN KEY (idCliente) REFERENCES Clientes(idCliente),
    CONSTRAINT FK_Usuarios_Empleados FOREIGN KEY (idEmpleado) REFERENCES Empleados(idEmpleado)
);
GO

-- 5. SERVICIOS
CREATE TABLE Servicios (
    idServicio INT IDENTITY(1,1) PRIMARY KEY,
    nombreServicio VARCHAR(100) NOT NULL,
    descripcion VARCHAR(200) NULL,
    precio DECIMAL(10,2) NOT NULL,
    activo BIT NOT NULL DEFAULT 1
);
GO

-- 6. CITAS
CREATE TABLE Citas (
    idCita INT IDENTITY(1,1) PRIMARY KEY,
    idCliente INT NOT NULL,
    idEmpleado INT NULL,
    idServicio INT NOT NULL,
    fechaCita DATE NOT NULL,
    horaCita TIME NOT NULL,
    estado VARCHAR(30) NOT NULL DEFAULT 'Programada',
    observacion VARCHAR(200) NULL,
    CONSTRAINT FK_Citas_Clientes FOREIGN KEY (idCliente) REFERENCES Clientes(idCliente),
    CONSTRAINT FK_Citas_Empleados FOREIGN KEY (idEmpleado) REFERENCES Empleados(idEmpleado),
    CONSTRAINT FK_Citas_Servicios FOREIGN KEY (idServicio) REFERENCES Servicios(idServicio)
);
GO

-- 7. TIPOS DE EXAMEN
CREATE TABLE TiposExamen (
    idTipoExamen INT IDENTITY(1,1) PRIMARY KEY,
    nombreExamen VARCHAR(100) NOT NULL,
    descripcion VARCHAR(200) NULL,
    precio DECIMAL(10,2) NOT NULL,
    activo BIT NOT NULL DEFAULT 1
);
GO

-- 8. EXAMENES
CREATE TABLE Examenes (
    idExamen INT IDENTITY(1,1) PRIMARY KEY,
    idCliente INT NOT NULL,
    idTipoExamen INT NOT NULL,
    idCita INT NULL,
    idEmpleado INT NULL,
    fechaSolicitud DATE NOT NULL,
    estado VARCHAR(30) NOT NULL DEFAULT 'Solicitado',
    observacion VARCHAR(200) NULL,
    CONSTRAINT FK_Examenes_Clientes FOREIGN KEY (idCliente) REFERENCES Clientes(idCliente),
    CONSTRAINT FK_Examenes_TiposExamen FOREIGN KEY (idTipoExamen) REFERENCES TiposExamen(idTipoExamen),
    CONSTRAINT FK_Examenes_Citas FOREIGN KEY (idCita) REFERENCES Citas(idCita),
    CONSTRAINT FK_Examenes_Empleados FOREIGN KEY (idEmpleado) REFERENCES Empleados(idEmpleado)
);
GO

-- 9. RESULTADOS DE EXAMENES
CREATE TABLE ResultadosExamenes (
    idResultado INT IDENTITY(1,1) PRIMARY KEY,
    idExamen INT NOT NULL,
    idEmpleado INT NULL,
    fechaResultado DATE NOT NULL,
    resultado VARCHAR(500) NOT NULL,
    observacion VARCHAR(250) NULL,
    estado VARCHAR(30) NOT NULL DEFAULT 'Finalizado',
    CONSTRAINT FK_Resultados_Examenes FOREIGN KEY (idExamen) REFERENCES Examenes(idExamen),
    CONSTRAINT FK_Resultados_Empleados FOREIGN KEY (idEmpleado) REFERENCES Empleados(idEmpleado)
);
GO

-- 10. RECETAS
CREATE TABLE Recetas (
    idReceta INT IDENTITY(1,1) PRIMARY KEY,
    idCliente INT NOT NULL,
    idEmpleado INT NULL,
    idResultado INT NULL,
    fechaReceta DATE NOT NULL,
    indicaciones VARCHAR(500) NOT NULL,
    CONSTRAINT FK_Recetas_Clientes FOREIGN KEY (idCliente) REFERENCES Clientes(idCliente),
    CONSTRAINT FK_Recetas_Empleados FOREIGN KEY (idEmpleado) REFERENCES Empleados(idEmpleado),
    CONSTRAINT FK_Recetas_Resultados FOREIGN KEY (idResultado) REFERENCES ResultadosExamenes(idResultado)
);
GO

-- 11. FACTURAS
CREATE TABLE Facturas (
    idFactura INT IDENTITY(1,1) PRIMARY KEY,
    idCliente INT NOT NULL,
    idUsuario INT NOT NULL,
    idCita INT NULL,
    fechaFactura DATE NOT NULL,
    subtotal DECIMAL(10,2) NOT NULL DEFAULT 0,
    impuesto DECIMAL(10,2) NOT NULL DEFAULT 0,
    total DECIMAL(10,2) NOT NULL DEFAULT 0,
    estado VARCHAR(30) NOT NULL DEFAULT 'Pendiente',
    CONSTRAINT FK_Facturas_Clientes FOREIGN KEY (idCliente) REFERENCES Clientes(idCliente),
    CONSTRAINT FK_Facturas_Usuarios FOREIGN KEY (idUsuario) REFERENCES Usuarios(idUsuario),
    CONSTRAINT FK_Facturas_Citas FOREIGN KEY (idCita) REFERENCES Citas(idCita)
);
GO

-- 12. DETALLE FACTURA
CREATE TABLE DetalleFactura (
    idDetalle INT IDENTITY(1,1) PRIMARY KEY,
    idFactura INT NOT NULL,
    idServicio INT NULL,
    idExamen INT NULL,
    descripcion VARCHAR(150) NOT NULL,
    cantidad INT NOT NULL DEFAULT 1,
    precioUnitario DECIMAL(10,2) NOT NULL,
    subtotal DECIMAL(10,2) NOT NULL,
    CONSTRAINT FK_Detalle_Facturas FOREIGN KEY (idFactura) REFERENCES Facturas(idFactura),
    CONSTRAINT FK_Detalle_Servicios FOREIGN KEY (idServicio) REFERENCES Servicios(idServicio),
    CONSTRAINT FK_Detalle_Examenes FOREIGN KEY (idExamen) REFERENCES Examenes(idExamen)
);
GO

-- 13. PROVEEDORES
CREATE TABLE Proveedores (
    idProveedor INT IDENTITY(1,1) PRIMARY KEY,
    nombreProveedor VARCHAR(120) NOT NULL,
    ruc VARCHAR(30) NULL,
    telefono VARCHAR(25) NULL,
    correo VARCHAR(100) NULL,
    direccion VARCHAR(200) NULL,
    activo BIT NOT NULL DEFAULT 1
);
GO

-- 14. INSTRUMENTOS
CREATE TABLE Instrumentos (
    idInstrumento INT IDENTITY(1,1) PRIMARY KEY,
    idProveedor INT NULL,
    idEmpleadoResponsable INT NULL,
    codigo VARCHAR(20) NOT NULL UNIQUE,
    nombre VARCHAR(100) NOT NULL,
    categoria VARCHAR(50) NULL,
    marca VARCHAR(50) NULL,
    modelo VARCHAR(50) NULL,
    estado VARCHAR(30) NOT NULL DEFAULT 'Disponible',
    fechaRevision DATE NOT NULL,
    observacion VARCHAR(200) NULL,
    activo BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_Instrumentos_Proveedores FOREIGN KEY (idProveedor) REFERENCES Proveedores(idProveedor),
    CONSTRAINT FK_Instrumentos_Empleados FOREIGN KEY (idEmpleadoResponsable) REFERENCES Empleados(idEmpleado)
);
GO

-- 15. MANTENIMIENTOS DE INSTRUMENTOS
CREATE TABLE MantenimientosInstrumentos (
    idMantenimiento INT IDENTITY(1,1) PRIMARY KEY,
    idInstrumento INT NOT NULL,
    idProveedor INT NULL,
    idEmpleado INT NULL,
    fechaMantenimiento DATE NOT NULL,
    tipoMantenimiento VARCHAR(80) NOT NULL,
    costo DECIMAL(10,2) NULL,
    resultado VARCHAR(200) NULL,
    proximaRevision DATE NULL,
    CONSTRAINT FK_Mantenimientos_Instrumentos FOREIGN KEY (idInstrumento) REFERENCES Instrumentos(idInstrumento),
    CONSTRAINT FK_Mantenimientos_Proveedores FOREIGN KEY (idProveedor) REFERENCES Proveedores(idProveedor),
    CONSTRAINT FK_Mantenimientos_Empleados FOREIGN KEY (idEmpleado) REFERENCES Empleados(idEmpleado)
);
GO

-- DATOS DE PRUEBA
INSERT INTO Roles(nombreRol, descripcion) VALUES
('ADMIN', 'Administrador del sistema'),
('CLIENTE', 'Cliente o paciente del laboratorio');
GO

INSERT INTO Clientes(codigoCliente, nombres, apellidos, cedula, telefono, correo, direccion) VALUES
('CLI-001', 'María José', 'López Pérez', '001-000000-0000A', '8888-1111', 'maria@email.com', 'Managua'),
('CLI-002', 'Carlos Antonio', 'Gómez Ruiz', '001-111111-0000B', '8888-2222', 'carlos@email.com', 'Managua');
GO

INSERT INTO Empleados(codigoEmpleado, nombres, apellidos, cargo, telefono, correo) VALUES
('EMP-001', 'Ana', 'Martínez', 'Administrador', '7777-1111', 'ana@biocontrol.com'),
('EMP-002', 'Luis', 'Herrera', 'Bioanalista', '7777-2222', 'luis@biocontrol.com');
GO

INSERT INTO Usuarios(idRol, idCliente, idEmpleado, usuario, clave, nombreCompleto) VALUES
(1, NULL, 1, 'admin', 'admin123', 'Administrador BioControl'),
(2, 1, NULL, 'cliente1', 'cliente123', 'María José López'),
(2, 2, NULL, 'cliente2', 'cliente123', 'Carlos Antonio Gómez');
GO

INSERT INTO Servicios(nombreServicio, descripcion, precio) VALUES
('Consulta general', 'Atención básica al cliente', 300.00),
('Toma de muestra', 'Proceso de toma de muestra', 150.00);
GO

INSERT INTO TiposExamen(nombreExamen, descripcion, precio) VALUES
('Biometría hemática', 'Examen básico de sangre', 450.00),
('Glucosa', 'Medición de glucosa', 180.00);
GO

INSERT INTO Proveedores(nombreProveedor, ruc, telefono, correo, direccion) VALUES
('Equipos Médicos Nicaragua', 'J031000000001', '2222-1111', 'ventas@equiposni.com', 'Managua'),
('Lab Supply Central', 'J031000000002', '2222-2222', 'contacto@labsupply.com', 'Managua');
GO

INSERT INTO Instrumentos(idProveedor, idEmpleadoResponsable, codigo, nombre, categoria, marca, modelo, estado, fechaRevision, observacion) VALUES
(1, 2, 'INS-001', 'Microscopio', 'Óptico', 'Olympus', 'CX23', 'Disponible', '2026-08-15', 'Equipo principal de observación'),
(2, 2, 'INS-002', 'Centrífuga', 'Laboratorio', 'Daiki', 'D100', 'En revisión', '2026-07-10', 'Revisar calibración');
GO

-- CONSULTAS RÁPIDAS DE PRUEBA
SELECT * FROM Roles;
SELECT * FROM Usuarios;
SELECT * FROM Instrumentos;
GO

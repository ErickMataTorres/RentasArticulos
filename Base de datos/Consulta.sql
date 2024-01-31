CREATE DATABASE RentasArticulosBD
USE RentasArticulosBD
--
CREATE TABLE Usuarios
(
	Id INT NOT NULL IDENTITY PRIMARY KEY,
	NombreCompleto VARCHAR(100) NOT NULL,
	Sexo VARCHAR(10) NOT NULL,
	FechaNacimiento DATE NOT NULL,
	FechaRegistro DATETIME DEFAULT(SYSDATETIME()),
	IdRol INT NOT NULL REFERENCES Roles(Id) ON UPDATE NO ACTION ON DELETE NO ACTION,
	Correo VARCHAR(100) NOT NULL UNIQUE,
	Contrasena VARCHAR(50) NOT NULL
)
--
CREATE TABLE Roles
(
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	Nombre VARCHAR(50) NOT NULL,
	Administrador CHAR(1) NOT NULL CHECK (Administrador = 'S' OR Administrador = 'N')
)
CREATE PROCEDURE spConsultarRoles
AS
BEGIN
	SELECT * FROM Roles
END
ALTER PROCEDURE spEjecutarAccionRol
@Id INT,
@Nombre VARCHAR(50),
@Administrador CHAR(1)
AS
BEGIN
	IF NOT EXISTS (SELECT Id FROM Roles WHERE Id=@Id)
	BEGIN
		INSERT INTO Roles (Nombre,Administrador) VALUES (@Nombre, @Administrador)
		SELECT '1' AS [Id], 'Se ha registrado correctamente' AS [Nombre];
	END
		ELSE
		BEGIN
			UPDATE Roles SET Nombre=@Nombre, Administrador=@Administrador WHERE Id=@Id
			SELECT '2' AS [Id], 'Se ha modificado correctamente' AS [Nombre];
		END
END
EXECUTE spEjecutarAccionRol 0, 'CAJERO', 'N'
--
CREATE TABLE Permisos
(
	IdRol INT NOT NULL REFERENCES Roles(Id) ON UPDATE NO ACTION ON DELETE NO ACTION,
	Opcion VARCHAR(10) NOT NULL,
	PRIMARY KEY(IdRol, Opcion)
)
--
CREATE TABLE EstadoArticulos
(
	Id INT NOT NULL IDENTITY PRIMARY KEY,
	Nombre VARCHAR(100) NOT NULL
)
--
CREATE TABLE Categorias
(
	Id INT NOT NULL IDENTITY PRIMARY KEY,
	Nombre VARCHAR(50) NOT NULL
)
--
CREATE TABLE Articulos
(
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	Nombre VARCHAR(100) NOT NULL,
	IdCategoria INT NOT NULL REFERENCES Categorias(Id) ON UPDATE NO ACTION ON DELETE NO ACTION,
	CostoArticulo NUMERIC(12,2) NOT NULL,
	FechaComprado DATETIME NOT NULL DEFAULT(SYSDATETIME()),
	PrecioPorHora NUMERIC(12,2) NOT NULL,
	PrecioPorHoraExtra NUMERIC(12,2) NOT NULL,
	FechaUltimaRentada DATETIME NOT NULL,
	IdEstado INT NOT NULL REFERENCES EstadoArticulos(Id) ON UPDATE NO ACTION ON DELETE NO ACTION
)
--
CREATE TABLE TipoDePagos
(
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	Nombre VARCHAR(50) NOT NULL,
	ComisionPorcentaje NUMERIC(12,2) NOT NULL
)
--
CREATE TABLE TemporalRentas
(
	Renglon INT NOT NULL PRIMARY KEY,
	IdArticulo INT NOT NULL REFERENCES Articulos(Id) ON UPDATE NO ACTION ON DELETE NO ACTION,
	PrecioPorHora NUMERIC(12,2) NOT NULL,
	TiempoRentaMinutos NUMERIC(12,2) NOT NULL,
	SubTotal NUMERIC(12,2) NOT NULL
)
--
CREATE TABLE Rentas
(
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	IdPago INT NOT NULL REFERENCES TipoDePagos(Id) ON UPDATE NO ACTION ON DELETE NO ACTION,
	Fecha DATETIME DEFAULT(SYSDATETIME()),
	ComisionPorcentaje NUMERIC(12,2) NOT NULL,
	Comision NUMERIC(12,2) NOT NULL,
	SubTotal NUMERIC(12,2) NOT NULL,
	Total NUMERIC(12,2) NOT NULL,
	DineroPago NUMERIC(12,2) NOT NULL,
	Cambio NUMERIC(12,2) NOT NULL
)
--
CREATE TABLE DetalleRentas
(
	IdRenta INT NOT NULL REFERENCES Rentas(Id) ON UPDATE NO ACTION ON DELETE NO ACTION,
	Renglon INT NOT NULL,
	IdArticulo INT NOT NULL REFERENCES Articulos(Id) ON UPDATE NO ACTION ON DELETE NO ACTION,
	PrecioPorHora NUMERIC(12,2) NOT NULL,
	PrecioPorHoraExtra NUMERIC(12,2) NOT NULL,
	TiempoExtra NUMERIC(12,2) NOT NULL DEFAULT(0.00),
	CargosPorExtra NUMERIC(12,2) NOT NULL DEFAULT(0.00),
	FechaRentaComenzada DATETIME NOT NULL,
	FechaRentaTerminada DATETIME NOT NULL,
	FechaRentaTerminadaExtra DATETIME NOT NULL DEFAULT(SYSDATETIME()),
	TiempoRentaMinutos NUMERIC(12,2) NOT NULL,
	SubTotal NUMERIC(12,2) NOT NULL
)
--
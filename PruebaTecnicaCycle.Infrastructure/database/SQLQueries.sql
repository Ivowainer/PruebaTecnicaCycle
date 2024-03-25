CREATE DATABASE PruebaTecnicaCycle;

USE PruebaTecnicaCycle;
CREATE SCHEMA Catalogo;

CREATE TABLE Catalogo.Productos (
    Id INT IDENTITY(1,1),
    Nombre VARCHAR(150),
    Precio NUMERIC(10,2),
    Categoria VARCHAR(150),
    Descripcion VARCHAR(500),
    Imagen VARCHAR(MAX),
    Estado BIT
);

CREATE PROCEDURE Catalogo.ListarProductos
AS
BEGIN 
	SELECT * FROM Catalogo.Productos;
END;

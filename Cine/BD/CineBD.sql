-----------------------------------------------------
-- 1. CREACIÓN DE LA BASE DE DATOS
-----------------------------------------------------
IF EXISTS (SELECT name FROM sys.databases WHERE name = N'CineDB')
BEGIN
    DROP DATABASE CineDB;
END;
GO

CREATE DATABASE CineDB;
GO

USE CineDB;
GO

-----------------------------------------------------
-- 2. CREACIÓN DE TABLAS
-----------------------------------------------------

-------------------
-- 2.1 PELICULA
-------------------
CREATE TABLE Pelicula (
    IDPelicula     INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Titulo         NVARCHAR(100) NOT NULL,
    Genero         NVARCHAR(50)  NOT NULL,
    Duracion       INT           NOT NULL,  -- En minutos
    Clasificacion  NVARCHAR(10)  NOT NULL
);
GO

-------------------
-- 2.2 SALA
-------------------
CREATE TABLE Sala (
    IDSala    INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Numero    INT          NOT NULL,
    Capacidad INT          NOT NULL,
    Tipo      NVARCHAR(50) NOT NULL  -- 2D, 3D, 4D, IMAX, etc.
);
GO

-------------------
-- 2.3 FUNCIÓN
-------------------
CREATE TABLE Funcion (
    IDFuncion   INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    IDPelicula  INT NOT NULL,
    IDSala      INT NOT NULL,
    Fecha       DATE NOT NULL,
    Hora        INT NOT NULL 
        CONSTRAINT CH_Funcion_Hora CHECK (Hora >= 1 AND Hora <= 24),
    CONSTRAINT FK_Funcion_Pelicula FOREIGN KEY (IDPelicula) REFERENCES Pelicula(IDPelicula),
    CONSTRAINT FK_Funcion_Sala FOREIGN KEY (IDSala) REFERENCES Sala(IDSala)
);
GO

-------------------
-- 2.4 BOLETO
-------------------
CREATE TABLE Boleto (
    IDBoleto   INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    IDFuncion  INT NOT NULL,
    Precio     DECIMAL(10,2) NOT NULL,
    Estado     NVARCHAR(50)  NOT NULL,  -- "Vendido", "Reservado", etc.
    CONSTRAINT FK_Boleto_Funcion FOREIGN KEY (IDFuncion) REFERENCES Funcion(IDFuncion)
);
GO

-----------------------------------------------------
-- 3. STORED PROCEDURES (CRUD)
-----------------------------------------------------

-----------------------------------------------------
-- 3.1 SP PARA TABLA: PELICULA
-----------------------------------------------------

-------------------
-- INSERT
-------------------
CREATE OR ALTER PROCEDURE sp_InsertPelicula
    @Titulo        NVARCHAR(100),
    @Genero        NVARCHAR(50),
    @Duracion      INT,
    @Clasificacion NVARCHAR(10)
AS
BEGIN
    INSERT INTO Pelicula (Titulo, Genero, Duracion, Clasificacion)
    VALUES (@Titulo, @Genero, @Duracion, @Clasificacion);

    SELECT SCOPE_IDENTITY() AS NuevoID;
END;
GO

-------------------
-- UPDATE
-------------------
CREATE OR ALTER PROCEDURE sp_UpdatePelicula
    @IDPelicula    INT,
    @Titulo        NVARCHAR(100),
    @Genero        NVARCHAR(50),
    @Duracion      INT,
    @Clasificacion NVARCHAR(10)
AS
BEGIN
    UPDATE Pelicula
    SET
        Titulo        = @Titulo,
        Genero        = @Genero,
        Duracion      = @Duracion,
        Clasificacion = @Clasificacion
    WHERE IDPelicula = @IDPelicula;
END;
GO

-------------------
-- DELETE
-------------------
CREATE OR ALTER PROCEDURE sp_DeletePelicula
    @IDPelicula INT
AS
BEGIN
    DELETE FROM Pelicula
    WHERE IDPelicula = @IDPelicula;
END;
GO

-------------------
-- GET ALL
-------------------
CREATE OR ALTER PROCEDURE sp_GetAllPeliculas
AS
BEGIN
    SELECT 
        IDPelicula,
        Titulo,
        Genero,
        Duracion,
        Clasificacion
    FROM Pelicula;
END;
GO

-------------------
-- GET BY ID
-------------------
CREATE OR ALTER PROCEDURE sp_GetPeliculaByID
    @IDPelicula INT
AS
BEGIN
    SELECT 
        IDPelicula,
        Titulo,
        Genero,
        Duracion,
        Clasificacion
    FROM Pelicula
    WHERE IDPelicula = @IDPelicula;
END;
GO

-----------------------------------------------------
-- 3.2 SP PARA TABLA: SALA
-----------------------------------------------------

-------------------
-- INSERT
-------------------
CREATE OR ALTER PROCEDURE sp_InsertSala
    @Numero    INT,
    @Capacidad INT,
    @Tipo      NVARCHAR(50)
AS
BEGIN
    INSERT INTO Sala (Numero, Capacidad, Tipo)
    VALUES (@Numero, @Capacidad, @Tipo);

    SELECT SCOPE_IDENTITY() AS NuevoID;
END;
GO

-------------------
-- UPDATE
-------------------
CREATE OR ALTER PROCEDURE sp_UpdateSala
    @IDSala    INT,
    @Numero    INT,
    @Capacidad INT,
    @Tipo      NVARCHAR(50)
AS
BEGIN
    UPDATE Sala
    SET
        Numero    = @Numero,
        Capacidad = @Capacidad,
        Tipo      = @Tipo
    WHERE IDSala = @IDSala;
END;
GO

-------------------
-- DELETE
-------------------
CREATE OR ALTER PROCEDURE sp_DeleteSala
    @IDSala INT
AS
BEGIN
    DELETE FROM Sala
    WHERE IDSala = @IDSala;
END;
GO

-------------------
-- GET ALL
-------------------
CREATE OR ALTER PROCEDURE sp_GetAllSalas
AS
BEGIN
    SELECT 
        IDSala,
        Numero,
        Capacidad,
        Tipo
    FROM Sala;
END;
GO

-------------------
-- GET BY ID
-------------------
CREATE OR ALTER PROCEDURE sp_GetSalaByID
    @IDSala INT
AS
BEGIN
    SELECT 
        IDSala,
        Numero,
        Capacidad,
        Tipo
    FROM Sala
    WHERE IDSala = @IDSala;
END;
GO

-----------------------------------------------------
-- 3.3 SP PARA TABLA: FUNCION
-----------------------------------------------------

-------------------
-- INSERT
-------------------
CREATE OR ALTER PROCEDURE sp_InsertFuncion
    @IDPelicula INT,
    @IDSala     INT,
    @Fecha      DATE,
    @Hora       INT
AS
BEGIN
    INSERT INTO Funcion (IDPelicula, IDSala, Fecha, Hora)
    VALUES (@IDPelicula, @IDSala, @Fecha, @Hora);

    SELECT SCOPE_IDENTITY() AS NuevoID;
END;
GO

-------------------
-- UPDATE
-------------------
CREATE OR ALTER PROCEDURE sp_UpdateFuncion
    @IDFuncion  INT,
    @IDPelicula INT,
    @IDSala     INT,
    @Fecha      DATE,
    @Hora       INT
AS
BEGIN
    UPDATE Funcion
    SET
        IDPelicula = @IDPelicula,
        IDSala     = @IDSala,
        Fecha      = @Fecha,
        Hora       = @Hora
    WHERE IDFuncion = @IDFuncion;
END;
GO

-------------------
-- DELETE
-------------------
CREATE OR ALTER PROCEDURE sp_DeleteFuncion
    @IDFuncion INT
AS
BEGIN
    DELETE FROM Funcion
    WHERE IDFuncion = @IDFuncion;
END;
GO

-------------------
-- GET ALL
-------------------
CREATE OR ALTER PROCEDURE sp_GetAllFunciones
AS
BEGIN
    SELECT
        f.IDFuncion,
        f.IDPelicula,
        p.Titulo AS Pelicula,
        f.IDSala,
        s.Numero AS Sala,
        f.Fecha,
        f.Hora
    FROM Funcion f
    INNER JOIN Pelicula p ON f.IDPelicula = p.IDPelicula
    INNER JOIN Sala s ON f.IDSala = s.IDSala;
END;
GO

-------------------
-- GET BY ID
-------------------
CREATE OR ALTER PROCEDURE sp_GetFuncionByID
    @IDFuncion INT
AS
BEGIN
    SELECT
        f.IDFuncion,
        f.IDPelicula,
        p.Titulo AS Pelicula,
        f.IDSala,
        s.Numero AS Sala,
        f.Fecha,
        f.Hora
    FROM Funcion f
    INNER JOIN Pelicula p ON f.IDPelicula = p.IDPelicula
    INNER JOIN Sala s ON f.IDSala = s.IDSala
    WHERE f.IDFuncion = @IDFuncion;
END;
GO

-----------------------------------------------------
-- 3.4 SP PARA TABLA: BOLETO
-----------------------------------------------------

-------------------
-- INSERT
-------------------
CREATE OR ALTER PROCEDURE sp_InsertBoleto
    @IDFuncion INT,
    @Precio    DECIMAL(10,2),
    @Estado    NVARCHAR(50)
AS
BEGIN
    INSERT INTO Boleto (IDFuncion, Precio, Estado)
    VALUES (@IDFuncion, @Precio, @Estado);

    SELECT SCOPE_IDENTITY() AS NuevoID;
END;
GO

-------------------
-- UPDATE
-------------------
CREATE OR ALTER PROCEDURE sp_UpdateBoleto
    @IDBoleto  INT,
    @IDFuncion INT,
    @Precio    DECIMAL(10,2),
    @Estado    NVARCHAR(50)
AS
BEGIN
    UPDATE Boleto
    SET
        IDFuncion = @IDFuncion,
        Precio    = @Precio,
        Estado    = @Estado
    WHERE IDBoleto = @IDBoleto;
END;
GO

-------------------
-- DELETE
-------------------
CREATE OR ALTER PROCEDURE sp_DeleteBoleto
    @IDBoleto INT
AS
BEGIN
    DELETE FROM Boleto
    WHERE IDBoleto = @IDBoleto;
END;
GO

-------------------
-- GET ALL
-------------------
CREATE OR ALTER PROCEDURE sp_GetAllBoletos
AS
BEGIN
    SELECT
        b.IDBoleto,
        b.IDFuncion,
        b.Precio,
        b.Estado,
        f.Fecha,
        f.Hora,
        p.Titulo AS Pelicula,
        s.Numero AS Sala
    FROM Boleto b
    INNER JOIN Funcion f  ON b.IDFuncion  = f.IDFuncion
    INNER JOIN Pelicula p ON f.IDPelicula = p.IDPelicula
    INNER JOIN Sala s     ON f.IDSala     = s.IDSala;
END;
GO

-------------------
-- GET BY ID
-------------------
CREATE OR ALTER PROCEDURE sp_GetBoletoByID
    @IDBoleto INT
AS
BEGIN
    SELECT
        b.IDBoleto,
        b.IDFuncion,
        b.Precio,
        b.Estado,
        f.Fecha,
        f.Hora,
        p.Titulo AS Pelicula,
        s.Numero AS Sala
    FROM Boleto b
    INNER JOIN Funcion f  ON b.IDFuncion  = f.IDFuncion
    INNER JOIN Pelicula p ON f.IDPelicula = p.IDPelicula
    INNER JOIN Sala s     ON f.IDSala     = s.IDSala
    WHERE b.IDBoleto = @IDBoleto;
END;
GO


-----------------------------------------------------
-- INSERTS EN TABLA: PELICULA
-----------------------------------------------------
INSERT INTO Pelicula (Titulo, Genero, Duracion, Clasificacion)
VALUES 
('Avatar: El Camino del Agua', 'Accion', 192, 'B'),
('Spider-Man: Lejos de Casa', 'Accion', 130, 'B'),
('El Padrino', 'Drama', 175, 'C'),
('Toy Story', 'Animacion', 81, 'A');

-----------------------------------------------------
-- INSERTS EN TABLA: SALA
-----------------------------------------------------
INSERT INTO Sala (Numero, Capacidad, Tipo)
VALUES 
(1, 200, '2D'),
(2, 150, '3D'),
(3, 100, 'IMAX'),
(4, 250, '4DX');

-----------------------------------------------------
-- INSERTS EN TABLA: FUNCION
-----------------------------------------------------
INSERT INTO Funcion (IDPelicula, IDSala, Fecha, Hora)
VALUES
(1, 1, '2025-02-10', 18),
(2, 2, '2025-02-10', 20),
(3, 3, '2025-02-11', 21),
(4, 4, '2025-02-12', 16);

-----------------------------------------------------
-- INSERTS EN TABLA: BOLETO
-----------------------------------------------------
INSERT INTO Boleto (IDFuncion, Precio, Estado)
VALUES
(1, 100.00, 'Vendido'),
(2, 120.00, 'Reservado'),
(3, 90.00, 'Disponible'),
(4, 150.00, 'Vendido');


GO
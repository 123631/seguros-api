CREATE DATABASE SegurosDB;
GO

USE SegurosDB;

CREATE TABLE Clientes (
    Id INT IDENTITY PRIMARY KEY,
    Nombre NVARCHAR(100),
    Identificacion NVARCHAR(50),
    Correo NVARCHAR(100)
);

CREATE TABLE Coberturas (
    Id INT IDENTITY PRIMARY KEY,
    Nombre NVARCHAR(100),
    MontoCobertura DECIMAL(10,2)
);

INSERT INTO Coberturas (Nombre, MontoCobertura) VALUES
('Robo', 500),
('Choque', 700),
('Responsabilidad Civil', 300);
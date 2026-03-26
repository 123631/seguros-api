CREATE DATABASE SegurosDB;
GO

USE SegurosDB;
GO

-- =========================
-- CLIENTES
-- =========================
CREATE TABLE Clientes (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(50) NOT NULL,
    Identificacion NVARCHAR(50) NOT NULL UNIQUE,
    Correo NVARCHAR(50) NOT NULL
);

-- =========================
-- VEHICULOS
-- =========================
CREATE TABLE Vehiculos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Placa NVARCHAR(20) NOT NULL UNIQUE,
    Marca NVARCHAR(20) NOT NULL,
    Modelo NVARCHAR(50) NOT NULL,
    Anio INT NOT NULL,
    ValorComercial DECIMAL(18,2) NOT NULL
);

-- =========================
-- COBERTURAS
-- =========================
CREATE TABLE Coberturas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    MontoCobertura DECIMAL(18,2) NOT NULL
);

-- =========================
-- POLIZAS
-- =========================
CREATE TABLE Polizas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    NumeroPoliza NVARCHAR(50) NOT NULL UNIQUE,
    ClienteId INT NOT NULL,
    VehiculoId INT NOT NULL,
    FechaEmision DATETIME NOT NULL DEFAULT GETDATE(),
    SumaAsegurada DECIMAL(18,2) NOT NULL,
    PrimaTotal DECIMAL(18,2) NOT NULL,

    CONSTRAINT FK_Poliza_Cliente FOREIGN KEY (ClienteId) REFERENCES Clientes(Id),
    CONSTRAINT FK_Poliza_Vehiculo FOREIGN KEY (VehiculoId) REFERENCES Vehiculos(Id)
);

-- =========================
-- RELACION POLIZA - COBERTURA (N:N)
-- =========================
CREATE TABLE PolizaCoberturas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    PolizaId INT NOT NULL,
    CoberturaId INT NOT NULL,

    CONSTRAINT FK_PC_Poliza FOREIGN KEY (PolizaId) REFERENCES Polizas(Id),
    CONSTRAINT FK_PC_Cobertura FOREIGN KEY (CoberturaId) REFERENCES Coberturas(Id)
);

-- =========================
-- DATOS DE PRUEBA
-- =========================
INSERT INTO Coberturas (Nombre, MontoCobertura) VALUES
('Robo', 5000),
('Choque', 7000),
('Responsabilidad Civil', 10000);
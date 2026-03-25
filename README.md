API REST desarrollada en .NET 6 para la emisión de pólizas de seguros de automóviles.

Tecnologías utilizadas
.NET 6
ASP.NET Core Web API
Entity Framework Core
SQL Server
Swagger

Arquitectura

El proyecto sigue una arquitectura en capas:

Controllers → Exposición de endpoints
Services → Lógica de negocio
Repositories → Acceso a datos
Data → DbContext
Models → Entidades
DTOs → Transferencia de datos

Crear base de datos
CREATE DATABASE SegurosDB;
Ejecutar script inicial
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


Editar el archivo appsettings.json:

"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=SegurosDB;Trusted_Connection=True;TrustServerCertificate=True"
}

Ejecución del proyecto
dotnet restore
dotnet ef database update
dotnet run

▶️ Ejecución del proyecto
dotnet restore
dotnet ef database update
dotnet run
📘 Swagger

Una vez ejecutado:

https://localhost:xxxx/swagger

🔗 Endpoints
📋 Catálogos
Obtener clientes
GET /api/clientes
Obtener coberturas
GET /api/coberturas

Emisión de póliza
POST /api/polizas/emitir
Body:
{
  "clienteId": 1,
  "vehiculo": {
    "placa": "ABC123",
    "marca": "Toyota",
    "modelo": "Corolla",
    "anio": 2022,
    "valorComercial": 15000
  },
  "coberturasIds": [1,2]
}
📄 Consultar póliza por ID
GET /api/polizas/{id}
📚 Listar todas las pólizas
GET /api/polizas
🧠 Lógica de negocio
La prima total se calcula como la suma de las coberturas seleccionadas.
El número de póliza se genera automáticamente.
Se valida que el cliente exista antes de emitir.
⚠️ Manejo de errores
400 Bad Request → Datos inválidos
404 Not Found → Recurso no encontrado
201 Created → Póliza creada correctamente
✨ Mejoras posibles
Validaciones con FluentValidation
AutoMapper
Middleware de manejo de errores
Autenticación JWT
Dockerización
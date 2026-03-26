SegurosApi - Sistema de Gestión de Pólizas

📌 Descripción

API desarrollada en C# con .NET para la gestión de centros de costo.

Permite crear, consultar, actualizar y eliminar registros, así como manejar relaciones contables asociadas.

El proyecto aplica una arquitectura desacoplada mediante el uso de Repositorios y Servicios.
# Características Principales

    Arquitectura por Capas: Separación clara entre Controladores, Servicios y Repositorios.

    Inyección de Dependencias: Gestión de servicios y repositorios mediante el contenedor nativo de .NET.

    Manejo Global de Excepciones: Middleware centralizado para respuestas HTTP semánticas (400, 404, 500).

    Persistencia de Datos: Entity Framework Core con SQL Server.

    Validaciones Semánticas: Respuestas estandarizadas para recursos no encontrados o peticiones inválidas.

# Tecnologías Utilizadas

    * Lenguaje: C#

    * Framework: ASP.NET Core Web API

    * ORM: Entity Framework Core

    * Base de Datos: SQL Server

# Estructura del Proyecto

    El proyecto sigue un patrón de diseño orientado a la mantenibilidad:

    * /Controllers: Define los puntos de entrada de la API y las respuestas HTTP.

    * /Services: Contiene la lógica de negocio (emisión de pólizas, cálculos de primas).

    * /Repositories: Maneja el acceso directo a la base de datos (Pólizas, Vehículos, Clientes).

    * /Middleware: Captura de errores global para evitar bloques try-catch repetitivos.

    * /DTOs: Objetos de transferencia de datos para las peticiones y respuestas.

# Configuración e Instalación
    Requisitos previos

    .NET SDK (versión 8 o superior)

    SQL Server Local o Remoto

    Pasos para ejecutar

    Clonar el repositorio:
    Bash

    git clone https://github.com/123631/SegurosApi.git
    cd SegurosApi

    Configurar la cadena de conexión:
    Actualiza el archivo appsettings.json con tus credenciales de SQL Server:
    JSON

    "ConnectionStrings": {
      "DefaultConnection": "Server=TU_SERVIDOR;Database=SegurosDb;Trusted_Connection=True;"
    }

    ⚠️ Personaliza estos valores según tu entorno

    Ejecutar migraciones (opcional si la BD ya existe):
    El schema de BD si se quiere crear está en el archivo Schema.sql
    Bash

    Instalar herramienta EF Core (si no la tienes)
 
    `dotnet tool install --global dotnet-ef`

    dotnet ef database update

    Iniciar la aplicación:
    Bash

    dotnet run

# Documentación e Interfaz (Swagger)

    Una vez en ejecución, la documentación interactiva está disponible en:
    https://localhost:7289/swagger/index.html

    Desde aquí se pueden probar todos los endpoints sin necesidad de herramientas externas.
# Endpoints y Ejemplos (JSON)
    Emitir Póliza (POST /api/polizas/emitir)

    Request:
    JSON

    {
    "clienteId": 1,
    "vehiculo": {
        "placa": "M123456",
        "marca": "Toyota",
        "modelo": "Hilux",
        "anio": 2024,
        "valorComercial": 35000.00
    },
    "coberturasIds": [1, 2]
    }

    Consultar Póliza por ID (GET /api/polizas/{id})

    Response (200 OK): Devuelve el objeto completo con relaciones.
    Response (404 Not Found):
    JSON

    {
    "status": 404,
    "message": "La póliza no fue encontrada"
    }
# Colección de Postman

    Se ha incluido el archivo SegurosApi.postman_collections.json en la raíz del proyecto.

    Importar el archivo en Postman.

    Configurar la variable de entorno baseUrl con el valor https://localhost:7289.

    O importarla del archivo SegurosApi.postman_env.json

    Las peticiones ya incluyen scripts de prueba (Tests) para validar los códigos de estado.

# Manejo de Errores

    La API responde con códigos de estado HTTP semánticos:

    201 Created: Póliza emitida exitosamente.

    400 Bad Request: Error de validación (ej. Cliente no existe).

    404 Not Found: Recurso no existente en la base de datos.

    500 Internal Server Error: Error no controlado (manejado por el Middleware).

#  Problemas comunes (FAQ)
    ❌ Error: dotnet-ef no reconocido
    dotnet tool install --global dotnet-ef
    ❌ Error de conexión a SQL Server
    Verifica credenciales
    Verifica puerto (1433)
    Verifica que SQL esté corriendo
    ❌ Migraciones no aplican
    dotnet ef migrations add InitialCreate
    dotnet ef database update

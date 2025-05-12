📝 ToDoApp API (.NET Core)

Este es un proyecto educativo desarrollado con C# y .NET Core, que implementa una API REST para la gestión de tareas (To-Do App). El objetivo principal es aplicar y practicar patrones de diseño, principios de arquitectura limpia, y buenas prácticas de desarrollo moderno.

📌 Propósito del proyecto

Este proyecto fue creado exclusivamente con fines de aprendizaje. Permite experimentar con distintos patrones y herramientas ampliamente utilizadas en el desarrollo backend con .NET, como CQRS, MediatR, FluentValidation, entre otros.

Tecnologías utilizadas

    .NET Core

    ASP.NET Core MVC

    Entity Framework Core

    FluentValidation

    MediatR

    CQRS

    Filtros personalizados

    Inyección de dependencias

    Result<T> para manejo de resultados y errores


🧠 Conceptos aplicados

    Patrón Repositorio y Repositorio Genérico
    Para abstraer el acceso a datos y facilitar la reutilización del código.

    Patrón de Servicios
    Encapsula la lógica de negocio, como validaciones y transformaciones, fuera de los controladores.

    Unit of Work
    Manejo de múltiples repositorios de forma transaccional y coordinada.

    CQRS + MediatR
    Separación de comandos (escrituras) y queries (lecturas), cada uno manejado por su propio Handler usando MediatR.

    Configuración de Entidades y DTOs
    Separación clara entre modelos de dominio, DTOs y configuraciones de EF Core.

    Validación con FluentValidation
    Uso de AbstractValidator para validar entradas en los endpoints de la API.

    Filtros personalizados
    Para el manejo global de excepciones y validación automática de modelos enviados en las peticiones.

    Inyección de dependencias
    Registro centralizado de servicios, repositorios, validadores y otras capas mediante el contenedor de servicios de .NET Core.


Instalación y ejecución

    ⚠️ Este proyecto no está desplegado. Las siguientes instrucciones son para ejecutarlo en entorno local.

  1. Clonar proyecto
  2. dotnet restore
  3. dotnet ef database update
  4. dotnet run

Observacion, el proyecto es solo para fines de prueba, si hay muchas consultas a San Google, muchas preguntas a chatgpt, copilot, geminys :) ;), sin miedo al exito 
    

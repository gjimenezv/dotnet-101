# Backend .NET/SQL Resources

Curado para la ventana de prep de 3 días (GFT Sr. Full Stack). Prioridad: fuentes oficiales de Microsoft, cortas y accionables.

## Knowledge

### C# / .NET
- [A tour of C#](https://learn.microsoft.com/en-us/dotnet/csharp/tour-of-csharp/) — Microsoft Learn
  Overview oficial del lenguaje. Use for: sintaxis general, tipos, POO.
- [Tips for JavaScript and TypeScript Developers](https://learn.microsoft.com/en-us/dotnet/csharp/tour-of-csharp/tips-for-javascript-developers) — Microsoft Learn
  Puente directo JS/TS → C#: qué es familiar, qué no existe, alternativas. Use for: acelerar la lección 1 (mapeo conceptual).

### ASP.NET Core Web API
- [Tutorial: Create a controller-based web API with ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api) — Microsoft Learn
  Tutorial oficial paso a paso: proyecto, modelo, controller, CRUD contra una base de datos. Use for: lección 2, ejercicio de escribir un endpoint.
- [Create web APIs with ASP.NET Core (overview)](https://learn.microsoft.com/en-us/aspnet/core/web-api/) — Microsoft Learn
  Referencia de conceptos (controllers, routing, model binding). Use for: consulta rápida durante la prueba.
- [Tutorial: Create a Minimal API with ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/tutorials/min-web-api) — Microsoft Learn
  Alternativa moderna sin controllers. Use for: si la prueba pide algo rápido/minimal.

### SQL Server / T-SQL
- [T-SQL Tutorial: Write Transact-SQL Statements](https://learn.microsoft.com/en-us/sql/t-sql/tutorial-writing-transact-sql-statements) — Microsoft Learn
  Tutorial oficial: crear tabla, insertar, actualizar, leer, borrar, vistas y stored procedures. Use for: lección 3, base de T-SQL.
- [Create a stored procedure](https://learn.microsoft.com/en-us/sql/relational-databases/stored-procedures/create-a-stored-procedure) — Microsoft Learn
  Cómo crear y ejecutar stored procedures con parámetros. Use for: lección 3, ejercicio práctico.
- [CREATE PROCEDURE (Transact-SQL)](https://learn.microsoft.com/en-us/sql/t-sql/statements/create-procedure-transact-sql) — Microsoft Learn
  Referencia de sintaxis completa. Use for: consulta rápida.

### Entity Framework Core
- [Overview of Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/) — Microsoft Learn
  Punto de entrada oficial: qué es EF Core, DbContext, modelos. Use for: lección 4.
- [Tutorial: Get started with EF Core in an ASP.NET MVC web app](https://learn.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro) — Microsoft Learn
  Tutorial oficial conectando EF Core con una Web app real. Use for: lección 4, ejercicio práctico.
- [Implementing the Repository and Unit of Work Patterns in an ASP.NET MVC Application](https://learn.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application) — Microsoft Learn
  Explicación oficial del repository/unit-of-work pattern sobre EF. Nota importante: Microsoft aclara que EF Core *ya* implementa Repository/Unit of Work internamente (el `DbContext` es el Unit of Work, cada `DbSet<T>` es un Repository) — una capa repository adicional es útil en escenarios complejos, no un default obligatorio. Use for: lección 4, para responder con criterio (no solo memorizar el patrón) si preguntan "¿por qué/cuándo usarías repository pattern sobre EF Core?".

## Gaps
- No se cubren AWS, Snowflake, Hangfire ni Jenkins en esta ventana — fuera de alcance según `MISSION.md`. Si la prueba los toca, priorizar preguntar en vivo antes que improvisar sin fuente.

## Wisdom (Communities)
- No se buscaron comunidades en esta ventana — el tiempo es demasiado corto para que aporten valor antes del lunes. Revisar después de la entrevista si el usuario sigue en el stack .NET (ej. r/dotnet, r/csharp).

# Prueba práctica de API REST — Gestión de préstamos de biblioteca

**Duración:** 3 horas (16:00–19:00)  
**Puntuación máxima:** 10 puntos

Desarrolla una API REST utilizando ASP.NET Core con controladores para gestionar préstamos de libros de una biblioteca. La información se almacenará en memoria, sin utilizar bases de datos.

## Ejercicios

**1. Proyecto y control de versiones (1 punto)**

Crea un proyecto ASP.NET Core Web API utilizando controladores e inicializa un repositorio Git con un archivo `.gitignore` adecuado para .NET.

Desarrolla cada ejercicio de implementación en una rama independiente, utilizando nombres descriptivos con el prefijo `feature/`. Realiza al menos un commit por rama y fusiona cada rama con `main` antes de comenzar el siguiente ejercicio. Conserva las ramas y el historial de Git.

**2. Modelo de datos (0,5 puntos)**

Crea una clase `Prestamo` con las siguientes propiedades:

- `Id` (`int`)
- `NombreLector` (`string`)
- `TituloLibro` (`string`)
- `FechaPrestamo` (`DateTime`)
- `DuracionDias` (`int`)
- `EsRenovable` (`bool`)
- `Estado` (`EstadoPrestamo`)

Define el enumerado `EstadoPrestamo` con los valores `Activo` y `Devuelto`.

**3. Almacenamiento en memoria (0,5 puntos)**

Crea un controlador de préstamos con una colección estática `List<Prestamo>` inicializada con al menos tres préstamos diferentes, incluyendo valores `true` y `false` para `EsRenovable`.

Los datos deberán mantenerse entre peticiones mientras la aplicación esté en ejecución.

**4. Consulta de préstamos (1,25 puntos)**

Implementa los siguientes endpoints:

- `GET /api/prestamos`: devuelve todos los préstamos.
- `GET /api/prestamos/{id}`: devuelve el préstamo correspondiente al identificador indicado o `404 Not Found` si no existe.

**5. Creación de préstamos (1,25 puntos)**

Implementa `POST /api/prestamos` para registrar un nuevo préstamo.

El identificador deberá generarse automáticamente y el estado inicial será siempre `Activo`, independientemente de los valores recibidos en la petición.

Devuelve `201 Created` utilizando `CreatedAtAction`.

**6. Modificación y eliminación (2 puntos)**

Implementa los siguientes endpoints:

- `PUT /api/prestamos/{id}`: modifica el nombre del lector, el título del libro, la fecha del préstamo, la duración y `EsRenovable`, sin modificar el identificador ni el estado.
- `DELETE /api/prestamos/{id}`: elimina un préstamo existente.

Devuelve `204 No Content` cuando la operación se complete correctamente y `404 Not Found` cuando el préstamo no exista.

**7. Devolución de préstamos (1 punto)**

Implementa `PUT /api/prestamos/{id}/devolver` para cambiar el estado de un préstamo de `Activo` a `Devuelto`.

- Si el préstamo no existe, devuelve `404 Not Found`.
- Si ya está devuelto, devuelve `409 Conflict`.
- Si se devuelve correctamente, devuelve `204 No Content`.

**8. Consultas con LINQ (1,5 puntos)**

Implementa los siguientes endpoints utilizando LINQ:

- `GET /api/prestamos/recientes`: devuelve los préstamos ordenados por fecha de préstamo de mayor a menor. Incorpora un parámetro opcional `[FromQuery]` llamado `cantidad`, con valor predeterminado de 5, para limitar los resultados. Si la cantidad es menor o igual que cero, devuelve `400 Bad Request`.
- `GET /api/prestamos/buscar`: permite buscar préstamos cuyo `NombreLector` contenga el texto recibido mediante un parámetro `[FromQuery]` llamado `lector`, sin distinguir entre mayúsculas y minúsculas. Si no hay coincidencias, devuelve una lista vacía.

**9. Validaciones (0,5 puntos)**

En las operaciones de creación y modificación, comprueba que:

- El nombre del lector y el título del libro no estén vacíos.
- La duración sea mayor que cero.

Si alguna condición no se cumple, devuelve `400 Bad Request`.

**10. Pruebas de funcionamiento (0,5 puntos)**

Comprueba la API mediante Postman o Swagger y presenta capturas de al menos seis peticiones: una consulta, una creación, una modificación, una eliminación y dos peticiones que produzcan errores.

Las capturas deberán mostrar la petición, el código HTTP y, cuando corresponda, los datos devueltos.

## Indicaciones

- Se podrá utilizar .NET 8 o .NET 10.
- Es obligatorio utilizar controladores, no Minimal API.
- Se permite consultar apuntes, ejercicios anteriores y documentación.
- No está permitido utilizar herramientas de inteligencia artificial ni comunicarse con otros compañeros.
- No es necesario implementar DTO, servicios, repositorios, bases de datos ni Entity Framework.
- Las operaciones de Git deberán realizarse progresivamente. Si un ejercicio queda incompleto, se podrán integrar los avances realizados y continuar con el siguiente.
- Se valorará el funcionamiento correcto de los endpoints, el cumplimiento de los requisitos y la organización del código.

## Entrega

Entrega un **único archivo ZIP** que incluya:

- El proyecto completo, incluyendo `.git` y `.gitignore`, sin las carpetas `bin` ni `obj`. Los cambios desarrollados deberán estar integrados en la rama `main`.
- Una carpeta `evidencias` con las capturas obligatorias de las pruebas realizadas mediante Postman o Swagger. Podrás incluir también observaciones, incidencias o documentación complementaria (por ejemplo, archivos `.md`) en el formato que consideres adecuado.

Las observaciones o documentos complementarios no sustituyen las capturas obligatorias.
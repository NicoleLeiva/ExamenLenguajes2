# 🎫 SoporteLab - Mesa de Ayuda TI

Sistema de gestión de tickets de soporte técnico desarrollado con **.NET 8**, **ASP.NET Core Web API**, **Blazor Server**, **Entity Framework Core** y **SQLite**.

---

# 🚀 Tecnologías utilizadas

- .NET 8
- ASP.NET Core Web API
- Blazor Server
- Entity Framework Core
- SQLite
- Swagger/OpenAPI
- Visual Studio Code

---

# 📂 Estructura del proyecto

```text
SoporteLab
│
├── src
│   ├── SoporteLab.Api
│   └── SoporteLab.Web
│
├── SoporteLab.sln
└── README.md
```

---

# ⚙️ Funcionalidades implementadas

## API REST

- ✅ Obtener todos los tickets
- ✅ Obtener ticket por ID
- ✅ Crear ticket
- ✅ Actualizar ticket
- ✅ Eliminar ticket

## Aplicación Web

- ✅ Listado de tickets
- ✅ Crear tickets
- ✅ Editar tickets
- ✅ Eliminar tickets
- ✅ Búsqueda en tiempo real
- ✅ Filtrado por estado
- ✅ Filtrado por prioridad
- ✅ Indicadores visuales de estado y prioridad

---

# 🗄️ Base de datos
El proyecto utiliza SQLite como sistema de gestión de base de datos relacional.

El acceso a datos se implementó mediante Entity Framework Core.

La base de datos se crea automáticamente al iniciar la API mediante:

```csharp
db.Database.EnsureCreated();

# 🔗 Endpoints disponibles

| Método | Ruta |
|--------|------|
| GET | /api/tickets |
| GET | /api/tickets/{id} |
| POST | /api/tickets |
| PUT | /api/tickets/{id} |
| DELETE | /api/tickets/{id} |

---

# ▶️ Ejecución del proyecto

## Iniciar la API

```bash
cd src/SoporteLab.Api
dotnet run
```

Disponible en:

```text
http://localhost:5136
```

Swagger:

```text
http://localhost:5136/swagger
```

---

## Iniciar la aplicación Web

```bash
cd src/SoporteLab.Web
dotnet run
```

Disponible en:

```text
http://localhost:5163
```

---

# 👤 Autor

Nicole Leiva
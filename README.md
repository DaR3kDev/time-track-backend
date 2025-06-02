# 🕒 Time Track Backend

Sistema de gestión de horas laborales construido con **.NET 9.0**, **Entity Framework Core** y **PostgreSQL**, siguiendo el patrón de **Arquitectura Limpia (Clean Architecture)**.

---

## 🏗️ Estructura del Proyecto

```
time-track-backend/
├── Domain/                 # Entidades y lógica del dominio (Domain Layer)
├── Application/            # Casos de uso y servicios de aplicación (Application Layer)
├── Infrastructure/         # Implementaciones externas, como acceso a datos y servicios (Infrastructure Layer)
├── Persistence/            # EF Core DbContext, migraciones y configuración de base de datos (Submódulo de Infrastructure)
├── time-track-backend/     # Proyecto de inicio / configuración de dependencias (API Layer)
├── .env                    # Variables de entorno (no se sube al repositorio)
└── README.md
```

---

## ⚙️ Tecnologías Utilizadas

* ✅ [.NET 9.0](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
* ✅ [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/)
* ✅ [PostgreSQL](https://www.postgresql.org/)
* ✅ [Npgsql (EF Provider para PostgreSQL)](https://www.npgsql.org/)
* ✅ [DotNetEnv](https://www.nuget.org/packages/DotNetEnv)
* ✅ Arquitectura limpia

---

## 🔌 Configuración Inicial

### 1. Requisitos

* Tener instalado **.NET SDK 9.0**
* Tener una instancia local o remota de **PostgreSQL**
* Opcional: Tener configurado Docker si usarás contenedor

### 2. Variables de entorno

Crea un archivo `.env` en la raíz del proyecto con tu cadena de conexión:

```env
# .env
DATABASE_URL="Host=localhost;Port=5432;Database=db;Username=user;Password=password
```

> ⚠️ Asegúrate de que estos datos coincidan con tu configuración local o del contenedor de PostgreSQL.

Alternativamente, puedes exportarla en tu terminal (PowerShell):

```powershell
$Env:DATABASE_URL="Host=localhost;Port=5432;Database=db;Username=user;Password=password"
```
---

## 🧱 Migraciones y Base de Datos

### Crear una migración

Desde la raíz del proyecto Persistence:

```bash
dotnet ef migrations add InitialCreate 
```

### Aplicar migraciones

```bash
dotnet ef database update
```

---

## 🧠 Arquitectura Limpia

Este proyecto sigue el enfoque de **Clean Architecture**, dividiendo responsabilidades en capas bien definidas:

* **Dominio**: Lógica empresarial, entidades y reglas.
* **Infraestructura (Persistence)**: Acceso a datos, configuración de Entity Framework Core, migraciones.
* **Aplicación (opcional)**: Casos de uso, servicios de aplicación.
* **Presentación (Startup)**: API, controladores, configuración de dependencias.

## 🐘 Uso con Docker

Puedes levantar una instancia de PostgreSQL local usando Docker:
```bash
docker-composer up -d
```

---

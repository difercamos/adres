# 📌 ADRES - API REST en .NET 8 con SQLite 🏗

Este proyecto es una API REST desarrollada en **.NET 8** utilizando **Arquitectura DDD** con almacenamiento en **SQLite** y gestión de datos con **Entity Framework Core**.

## 🚀 Tecnologías Usadas

- **.NET 8** - Framework de desarrollo
- **Entity Framework Core** - ORM para gestionar la base de datos
- **SQLite** - Base de datos ligera y embebida
- **Swagger UI** - Documentación interactiva de la API

## 🛠 Instalación y Configuración
### 1️ **Clonar el Repositorio**
```sh
git clone https://github.com/difercamos/adres.git
cd adres/Adres
```

### 2️ **Instalar Dependencias**
```sh
dotnet restore
```

### 3 **Crear y aplicar migraciones**
```sh
dotnet ef migrations add InitialCreate --project src/Adres.Infrastructure --startup-project src/Adres.API
dotnet ef database update --project src/Adres.Infrastructure --startup-project src/Adres.API
```

### 4 **Ejecutar la API**
```sh
dotnet run --project src/Adres.API
```

### 5 **La API estará disponible en:**
```sh
http://localhost:5032
``` 

## Uso
- **Revisar la colección de POSTMAN con los servicios que se encuentra en la carpeta raíz del proyecto**  

## Licencia
Este proyecto se distribuye bajo la **licencia MIT**.  

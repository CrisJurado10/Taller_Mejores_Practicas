# Gestión de Vehículos - Proyecto ASP.NET Core

¡Bienvenido al proyecto de **Gestión de Vehículos**! Este proyecto es una aplicación web desarrollada en **ASP.NET Core**, que utiliza patrones de diseño como **Factory Method**, **Builder**, y un repositorio en memoria para gestionar vehículos.

Este proyecto forma parte de las tareas asignadas a Pepito, un Ingeniero de Software Junior en **Codificando Con Patrones Cía. Ltda.**. El objetivo principal es implementar y mejorar las funcionalidades de un sistema de gestión de automóviles utilizando patrones de diseño y buenas prácticas.

---

## **Requerimientos del Proyecto**

El proyecto cuenta con los siguientes requerimientos funcionales:

### **1. Implementar métodos para agregar vehículos**
- Agregar vehículos (**Mustang** y **Explorer**) desde la página principal (Home Page).
- El proyecto ya cuenta con un patrón **Repositorio** para manejar las operaciones CRUD de automóviles. Sin embargo, el equipo de QA ha reportado que no funciona como se espera. Es necesario revisarlo y corregirlo.

### **2. Probar funcionalidad sin conexión a la base de datos**
- El equipo de bases de datos indicó que el esquema de la base de datos aún no está listo.
- Es necesario probar las funcionalidades utilizando un repositorio **en memoria** como solución temporal, para luego conectar con la base de datos una vez esté disponible.

### **3. Agregar propiedades por defecto**
- El equipo de negocio solicitó agregar el año actual y **20 propiedades más** como valores por defecto en los vehículos.
- Implementar un patrón de diseño para agregar propiedades por defecto (por ejemplo, **Builder**) de manera que los cambios futuros sean mínimos.

### **4. Implementar un patrón Factory Method**
- El Arquitecto de Software sugirió implementar el patrón **Factory Method** para crear nuevos modelos de vehículos, anticipando que se agregarán más modelos en el futuro.

---

## **Implementación**

El proyecto utiliza patrones de diseño para cumplir con los requerimientos:

1. **Repositorio en memoria:**
   - Se creó el repositorio `InMemoryVehicleRepository` para almacenar los vehículos temporalmente sin necesidad de una base de datos.

2. **Métodos para agregar vehículos:**
   - Se implementaron los métodos `AddMustang` y `AddExplorer` en el `HomeController` para permitir agregar vehículos desde la interfaz de usuario.

3. **Patrón Builder:**
   - Se diseñó la clase `VehicleBuilder` para agregar propiedades por defecto a los vehículos. Esto permite una fácil extensibilidad para futuros cambios.

4. **Patrón Factory Method:**
   - Se creó la clase `VehicleFactory` para centralizar la creación de nuevos modelos de vehículos, facilitando la adición de nuevas variantes como el modelo **Escape**.

---

## **Tecnologías Utilizadas**

- **ASP.NET Core MVC:** Para el desarrollo de la aplicación web.
- **C#:** Lenguaje principal para la implementación del proyecto.
- **Bootstrap:** Framework CSS utilizado para mejorar la interfaz de usuario.
- **Patrones de Diseño:**
  - Factory Method
  - Builder
  - Repository

---

## **Guía de Uso**

### **1. Agregar vehículos**
Desde la página principal, haz clic en los botones:
- **Agregar Mustang**
- **Agregar Explorer**

Esto agregará los vehículos seleccionados al repositorio en memoria.

### **2. Gestionar vehículos**
- **Encender motor:** Haz clic en "Encender Motor ??" para arrancar el motor de un vehículo.
- **Apagar motor:** Haz clic en "Apagar Motor ??" para apagar el motor.
- **Llenar tanque:** Haz clic en "Llenar Tanque ?" para añadir gasolina.

### **3. Ver lista de vehículos**
En la tabla de la página principal podrás ver los siguientes datos:
- Identificador (ID)
- Tipo de vehículo
- Marca
- Modelo
- Color
- Nivel de gasolina
- Estado del motor (Encendido o Apagado)

---

## **Estructura del Proyecto**

```plaintext
DesignPatterns/
??? Controllers/          # Controladores para manejar las solicitudes HTTP
?   ??? HomeController.cs
??? Factories/            # Clase Factory Method para crear vehículos
?   ??? VehicleFactory.cs
??? Models/               # Modelos de datos del proyecto
?   ??? Vehicle.cs
?   ??? Car.cs
?   ??? Motorcycle.cs
??? ModelBuilders/        # Clase Builder para propiedades por defecto
?   ??? VehicleBuilder.cs
??? Repositories/         # Repositorios para manejar los datos
?   ??? InMemoryVehicleRepository.cs
??? Views/                # Vistas para la interfaz de usuario
?   ??? Home/
?       ??? Index.cshtml
??? wwwroot/              # Archivos estáticos (CSS, JS, imágenes)
??? appsettings.json      # Configuración de la aplicación
??? Program.cs            # Punto de entrada del proyecto
??? Startup.cs            # Configuración inicial del proyecto
## Tabla de Contenidos
1. [Descripción](#descripción)
2. [Características](#características)
3. [Requisitos Previos](#requisitos-previos)
4. [Instalación](#instalación)
5. [Ejecución](#ejecución)
6. [Estructura del Proyecto](#estructura-del-proyecto)
7. [Uso](#uso)
8. [Contribución](#contribución)
9. [Licencia](#licencia)

## Descripción

Esta aplicación permite gestionar vehículos como `Mustang`, `Explorer`, y `Escape`. Los usuarios pueden:
- Agregar vehículos a la lista.
- Encender o apagar el motor de los vehículos.
- Llenar el tanque de gasolina.
- Ver propiedades adicionales como el año de fabricación y otras configuraciones por defecto.

## Características

- **Patrón de Diseño Factory Method:** Crear vehículos centralizando la lógica de creación.
- **Patrón Builder:** Añadir propiedades por defecto a los vehículos de forma extensible.
- **Repositorio en Memoria:** Permite pruebas sin una base de datos.
- **Interfaz de Usuario Mejorada:** Diseño amigable con Bootstrap, emojis e imágenes.
- **Expansión Fácil:** Puedes agregar nuevos modelos de vehículos rápidamente.

## Requisitos Previos

Asegúrate de tener lo siguiente instalado en tu máquina:

1. **.NET Core SDK 6.0 o superior**
   - Descarga desde: [Descargar .NET](https://dotnet.microsoft.com/download)
2. **Visual Studio 2022** (o superior)
   - Incluye soporte para ASP.NET y C#.
3. **Git** (opcional, para clonar el repositorio)
   - Descarga desde: [Descargar Git](https://git-scm.com/).

## Instalación

Sigue estos pasos para configurar el proyecto:

1. **Clonar el repositorio:**

   ```bash
   git clone https://github.com/tu_usuario/gestion-vehiculos.git
   cd gestion-vehiculos

## Abrir el proyecto en Visual Studio

1. **Abre el archivo de solución:**
   - Localiza el archivo `DesignPatterns.sln` y ábrelo en Visual Studio.

2. **Restaurar paquetes NuGet:**
   - En Visual Studio, ve a `Herramientas > Administrador de paquetes NuGet > Restaurar paquetes`.

3. **Compilar la solución:**
   - En el menú principal, selecciona `Compilar > Recompilar Solución`.

---

## Ejecución

1. **Ejecuta la aplicación desde Visual Studio:**
   - Haz clic en el botón **Iniciar** (o presiona `F5`).

2. **Abre tu navegador:**
   - Accede a la URL: [https://localhost:5001](https://localhost:5001)

---

## Uso

### **1. Página Principal**
- Accede a la página principal para ver la lista de vehículos gestionados.

### **2. Agregar Vehículos**
- Haz clic en los botones **Agregar Mustang** o **Agregar Explorer** para añadir vehículos a la lista.

### **3. Gestionar Vehículos**
Puedes realizar las siguientes acciones en cada vehículo desde la tabla de la página principal:
- **Encender Motor:** Haz clic en el botón **Encender Motor ??**.
- **Apagar Motor:** Haz clic en el botón **Apagar Motor ??**.
- **Llenar Tanque:** Haz clic en el botón **Llenar Tanque ?**.

---

## Contribución

¿Tienes ideas o mejoras? ¡Eres bienvenido a contribuir!

1. **Haz un fork del proyecto.**
2. **Crea una nueva rama:**
   ```bash
   git checkout -b mi-nueva-funcionalidad

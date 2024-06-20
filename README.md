<!-- Improved compatibility of back to top link: See: https://github.com/othneildrew/Best-README-Template/pull/73 -->
<a name="readme-top"></a>

<div align="center">
  <h1 align="center">CleanShop</h1>

  <p align="center">
    Prueba realizada por Daniel Ibarra para IROX IT
  </p>
</div>

### Hecho con

La prueba fue realizada 100% con herramientas de .NET de Microsoft.

* .NET Core
* .NET Framework
* WinForms
* Blazor
* Radzen
* Bootstrap
* WebApiv2
* EF Core

<p align="right">(<a href="#readme-top">back to top</a>)</p>

### Prerequisitos
* El proyecto necesita una base de datos SQL Server con cuya cadena de conexion es la siguiente
  ```txt
  Data Source=localhost;User ID=CleanShopDbUser;Password=CleanShop123$%&;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False
  ```

### Installation

_Below is an example of how you can instruct your audience on installing and setting up your app. This template doesn't rely on any external dependencies or services._

1. Instalar SQL Server y crear una base de datos llamada CleanShopDb con usuario llamado CleanShopDbUser y el password CleanShop123$%&
2. Clone the repo
   ```sh
   git clone https://github.com/DanielIH94/CleanShop.git
   ```
3. Abrir la solucion CleanShop.sln que se encuentra dentro del proyecto en Visual Studio 2022.

### Ejemplo de consulta servicio web
#### 1. Obtener producto por ID
```json
   GET https://localhost:7291/odata/Productos(1)
   ### Expect {
      "@odata.context": "https://localhost:7291/odata/$metadata#Productos/$entity",
      "IdProductos": 1,
      "Titulo": "Maestro Limpio 1L",
      "Descripcion": "Limpiador multiusos.",
      "PrecioUnitario": 18.00,
      "Existencias": 997
  }
```
#### 2. Filtrar elementos
```json
   GET https://localhost:7291/odata/Productos?$filter=IdProductos eq 1 or IdProductos eq 
   ### Expect {
      {
      "@odata.context": "https://localhost:7291/odata/$metadata#Productos",
      "value": [
          {
              "IdProductos": 1,
              "Titulo": "Maestro Limpio 1L",
              "Descripcion": "Limpiador multiusos.",
              "PrecioUnitario": 18.00,
              "Existencias": 997
          },
          {
              "IdProductos": 3,
              "Titulo": "Cloralex Pastillas 10 Unidades",
              "Descripcion": "Cloro en pastillas para desinfección de inodoro.",
              "PrecioUnitario": 120.80,
              "Existencias": 90
          }
      ]
  }
  }
```
#### 3. Funciones de agregacion
```json
   GET https://localhost:7291/odata/Productos?$apply=aggregate(Existencias with sum as ExistenciasTotales)
   ### Expect {
      [
          {
              "ExistenciasTotales": 3872
          }
      ]
```
#### 4. Operaciones batch
```json
   POST https://localhost:7291/odata/$batch
   ### BODY {
        "requests": [
            {
                "id": "1",
                "method": "GET",
                "url": "https://localhost:7291/odata/Productos"
            },
            {
                "id": "2",
                "method": "GET",
                "url": "https://localhost:7291/odata/Ventas"
            }
        ]
    }
   ### Expect {
    "responses": [
        {
            "id": "1",
            "status": 200,
            "headers": {
                "content-type": "application/json; odata.metadata=minimal; odata.streaming=true; charset=utf-8",
                "odata-version": "4.0"
            },
            "body": {
                "@odata.context": "https://localhost:7291/odata/$metadata#Productos",
                "value": [
                    {
                        "IdProductos": 1,
                        "Titulo": "Maestro Limpio 1L",
                        "Descripcion": "Limpiador multiusos.",
                        "PrecioUnitario": 18.00,
                        "Existencias": 997
                    },
                    {
                        "IdProductos": 2,
                        "Titulo": "Cloralex 1L.",
                        "Descripcion": "Cloro para limpieza general.",
                        "PrecioUnitario": 14.50,
                        "Existencias": 500
                    },
                    ...
                ]
            }
        },
        {
            "id": "2",
            "status": 200,
            "headers": {
                "content-type": "application/json; odata.metadata=minimal; odata.streaming=true; charset=utf-8",
                "odata-version": "4.0"
            },
            "body": {
                "@odata.context": "https://localhost:7291/odata/$metadata#Ventas",
                "value": [
                    {
                        "IdVentas": 1,
                        "Idproductos": 2,
                        "CantidadVendida": 5,
                        "Fecha": "2017-01-08T11:25:57-06:00"
                    },
                    {
                        "IdVentas": 2,
                        "Idproductos": 3,
                        "CantidadVendida": 500,
                        "Fecha": "2017-01-08T11:25:57-06:00"
                    },
                    ...
                ]
            }
        }
    ]
}
```

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- USAGE EXAMPLES -->
## Usage

1. Ejecutar el proyecto llamado CleanShopServer
2. Ejecutar los proyectos llamado CleanShopWebApp, CleanShopWebApp y CleanShopDesktop 

<p align="right">(<a href="#readme-top">back to top</a>)</p>

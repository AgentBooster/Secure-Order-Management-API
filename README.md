# Contexto:

**Introducción**

Usted está desarrollando el Sistema de Gestión de Pedidos para LogiTrack, una plataforma de software de logística. Este sistema gestionará los artículos del inventario y los pedidos de los clientes a través de múltiples centros de cumplimiento.

En esta actividad, usted deberá:

* Crear dos clases de lógica de negocio: InventoryItem y Order.  
* Modelar sus datos e integrarlos en una base de datos relacional utilizando EF Core.  
* Construir la lógica básica para crear, ver y actualizar el inventario y los pedidos.  
* Utilizar Microsoft Copilot para ayudar a depurar y optimizar su trabajo.

Esta es la primera de las cinco actividades de su proyecto final. Las clases y la lógica que desarrolle aquí se ampliarán en las próximas partes para incluir puntos finales de API, acceso seguro y optimización del rendimiento.

**Instrucciones de la actividad**

**Paso 1**: Configure su proyecto

* Abra Visual Studio Code  
* Utilice la CLI para crear un nuevo proyecto de consola o ASP.NET Core Web API: **dotnet new webapi \-n LogiTrack cd LogiTrack**  
* Añada una carpeta Models y cree dos nuevos archivos de clase C\#:  
  * InventoryItem.cs  
  * Order.cs

**Paso 2**: Definir la clase InventoryItem

Cree una clase llamada **InventoryItem** con las siguientes propiedades:

* ItemId (int)  
* Nombre (string)  
* Cantidad (int)  
* Ubicación (cadena)

Incluye un método llamado **DisplayInfo()** que imprima: Artículo: Palet Jack | Cantidad: 12 | Ubicación: Almacén A

Pruebe este método con un objeto de ejemplo en Program.cs o un controlador de prueba.

**Paso 3**: Definir la clase Order

Cree una clase llamada **Order** con las siguientes propiedades:

* OrderId (int)  
* CustomerName (string)  
* DatePlaced (DateTime)  
* List (lista de artículos en el pedido)

Añade métodos a:

* AddItem(InventoryItem artículo)  
* RemoveItem(int itemId)  
* GetOrderSummary() \- devuelve una cadena como: Pedido \#1001 para Samir | Artículos: 2 | Realizado: 4/5/2025

Escriba un bloque de prueba para crear un pedido, añadir/eliminar artículos e imprimir el resumen.

**Paso 4**: Conectarse a una base de datos con EF Core

* Añada los paquetes de EF Core a través de NuGet o CLI:

1

2

* Cree una nueva clase DbContext en un archivo llamado LogiTrackContext.cs:

1

2

3

4

5

6

7

8

* Añada los atributos \[Key\], \[Required\] o \[ForeignKey\] adecuados si es necesario.  
* Utilice migraciones para crear su base de datos:

1

2

**Paso 5**: Sembrar y probar la base de datos

Ahora que su esquema de base de datos está creado, añada algunos datos de prueba para verificar que todo funciona como se espera.

* Abra **Program.cs** (o su controlador de prueba) y añada el siguiente bloque de código:

1

2

3

4

5

6

7

8

9

10

11

12

13

14

15

16

17

18

19

20

21

22

* Ejecute la aplicación para confirmar que los datos se guardan e imprimen como se espera.

Este paso asegura que su **DbContext** está funcionando, su tabla está rellenada y su método **DisplayInfo()** funciona correctamente.

**Paso 6**: Utilice Microsoft Copilot para revisar y optimizar Pruebe las siguientes indicaciones con Microsoft Copilot:

* "Genere código EF Core para uno-a-muchos entre Order e InventoryItem"  
* "Sugiera una forma de imprimir resúmenes de pedidos de forma eficaz  
* "Identifique cualquier mejora de rendimiento en mi método AddItem"

Después de revisar las sugerencias de Copilot:

* Refactorizar cualquier lógica según sea necesario  
* Asegúrese de que todo se compila y se ejecuta sin errores

Lista de comprobación de presentación

* Dos clases de trabajo: InventoryItem y Order  
* Datos de prueba con salida básica mostrada en consola o controlador  
* LogiTrackContext con integración EF Core  
* Base de datos creada y probada correctamente  
* Revisión asistida por Copilot aplicada  
* Código guardado para la integración en la Parte 2

## **Introducción**

Usted ha estructurado la lógica y la base de datos para el sistema de gestión de pedidos de LogiTrack. Ahora es el momento de construir la API web que permite a los sistemas interactuar con él. Esto hará que sus datos sean accesibles a través de rutas HTTP seguras para ver, crear y actualizar pedidos e inventario.

En esta actividad, usted hará lo siguiente

* Crear controladores API para inventario y pedidos  
* Implementar rutas GET, POST y DELETE  
* Probar sus puntos finales utilizando Swagger o Postman  
* Utilizar Microsoft Copilot para depurar y optimizar la lógica de enrutamiento

Esta es la segunda de las cinco actividades de su proyecto final. Los endpoints que construyas serán asegurados y optimizados en partes futuras.

## **Instrucciones de la actividad**

**Paso 1: Crear los Controladores**

* En la carpeta **Controllers**, cree dos nuevos archivos:  
  * **InventoryController.cs**  
  * **OrderController.cs**

**Paso 2: Construir los Endpoints de InventoryController**

En **InventoryController.cs**, implemente lo siguiente:

**\[HttpGet\] /api/inventory**

* Devolver una lista de todos los artículos del inventario

**\[HttpPost\] /api/inventory**

* Añadir un nuevo artículo al inventario

**\[HttpDelete\] /api/inventory/{id}**

* Eliminar un artículo por ID

Usar inyección de dependencias para obtener una instancia de **LogiTrackContext**.

**Paso 3: Construir los Endpoints de OrderController**

En **OrderController.cs**, implemente lo siguiente:

**\[HttpGet\] /api/orders**

* Devolver una lista de todos los pedidos

**\[HttpGet\] /api/orders/{id}**

* Devolver un pedido con sus artículos

**\[HttpPost\] /api/orders**

* Crear un nuevo pedido

**\[HttpDelete\] /api/orders/{id}**

* Eliminar un pedido por ID

Asegúrese de que el objeto **Order** enviado a través de la ruta POST puede incluir varios artículos de inventario.

**Paso 4: Pruebe sus puntos finales de API**

* Ejecute su proyecto  
* Utilice Swagger (autogenerado por ASP.NET Core) o Postman para probar sus endpoints  
* Confirme que:  
  * Se pueden crear, leer y eliminar artículos de inventario y pedidos  
  * Los datos persisten en la base de datos entre solicitudes

**Paso 5: Utilice Microsoft Copilot para revisar y mejorar**

Pruebe estas instrucciones en Copilot:

* "Generar un endpoint GET para devolver un pedido por ID incluyendo detalles del artículo"  
* "Sugiera cómo manejar las respuestas de error si no se encuentra un ID"  
* "Refactorice este controlador para utilizar métodos asíncronos"

Después de revisar las sugerencias:

* Aplique mejoras en el enrutamiento, la gestión de errores o el diseño del controlador.  
* Vuelva a realizar pruebas para garantizar la funcionalidad.

### **Lista de comprobación de presentación**

* Dos controladores API: Inventario y Pedido  
* Rutas GET, POST, DELETE funcionales para ambos controladores  
* Rutas probadas en Swagger o Postman  
* Aplicación de las sugerencias de Microsoft Copilot  
* Código guardado para su uso en la Parte 3

**Introducción**

Su API realiza ahora operaciones CRUD para pedidos e inventario. Pero sin autenticación y control de acceso, es vulnerable a usos indebidos. En esta actividad, protegerá la API mediante ASP.NET Identity y el acceso basado en funciones.

En esta actividad, usted:

* Añadir ASP.NET Identity a su proyecto  
* Crear la funcionalidad de registro e inicio de sesión  
* Proteger los puntos finales de la API con autenticación y funciones  
* Utilizar Copilot para validar su configuración de seguridad

Esta es la tercera de las cinco actividades de su proyecto final. La seguridad que implemente aquí proporcionará la base para la gestión del rendimiento y del estado en las Partes 4 y 5\.

## **Instrucciones de la actividad**

**Paso 1: Instalar ASP.NET Identity**

Instale los paquetes NuGet necesarios:

dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore

dotnet add paquete Microsoft.EntityFrameworkCore.Sqlite

Cree una clase **ApplicationUser** que herede de **IdentityUser**.

**Paso 2: Configure Identity en su proyecto**

* Modifique su **LogiTrackContext** para que herede de **IdentityDbContext\<ApplicationUser\>**.  
* Configure los servicios en **Program.cs** para que admitan Identity:

2

Actualice su base de datos y aplique una migración:

1

2

**Paso 3: Crear puntos finales de registro e inicio de sesión**

* Añade un **AuthController** con los siguientes puntos finales:  
  * **\[HttpPost\] /api/auth/register** \- registra un usuario  
  * **\[HttpPost\] /api/auth/login** \- inicia sesión y devuelve un JWT

Utilice los servicios **UserManager** y **SignInManager** para gestionar las operaciones de identidad.

**Paso 4: Proteger las rutas API con autorización**

* Utilice el atributo **\[Authorize\]** para proteger los puntos finales en **OrderController** y **InventoryController**.  
* Asigne un rol a los usuarios administradores (por ejemplo, "Manager") y limite rutas específicas con:

**\[Authorize(Roles \= "Manager")\]**

**Paso 5: Utilice Microsoft Copilot para la revisión de seguridad**

Utilice estas indicaciones con Copilot:

* "Añadir autenticación JWT a una API ASP.NET Core"  
* "¿Cómo restrinjo una ruta a usuarios con un rol específico?"  
* "Sugerir mejoras para asegurar el registro de usuarios"

Pruebe su API segura:

* Registrando un nuevo usuario  
* Iniciar sesión y recuperar un token  
* Acceso a rutas con y sin autenticación

### **Lista de comprobación de envío**

* Identidad ASP.NET instalada y configurada  
* **ApplicationUser** modelo creado  
* Rutas de registro e inicio de sesión añadidas  
* Autenticación basada en token JWT implementada  
* Rutas aseguradas con **\[Authorize\]** y roles  
* Revisión y aplicación de las sugerencias de Copilot  
* Base de datos actualizada con el esquema de identidad

**Introducción**

Ahora que tu API es funcional y segura, es hora de hacerla rápida y escalable. En esta actividad, implementará el almacenamiento en caché para reducir la carga y acelerar las respuestas. También refinará sus consultas y la lógica del controlador con la ayuda de Microsoft Copilot.

En esta actividad:

* Aplicar el almacenamiento en caché en memoria a los datos de acceso frecuente  
* Mejorar el rendimiento de la base de datos mediante optimizaciones de consultas  
* Utilizar Copilot para analizar y mejorar el rendimiento

Esta es la cuarta de las cinco actividades de su proyecto final. Estas optimizaciones asegurarán que su sistema permanezca estable bajo carga y tenga un buen rendimiento en el mundo real.

## **Instrucciones de la actividad**

**Paso 1: Activar Caché en Memoria**

* En **Program.cs**, añada:

**builder.Services.AddMemoryCache();**

En su controlador (por ejemplo, **InventoryController**), inyecte **IMemoryCache**:

1

2

3

4

5

6

**Paso 2: Almacenar en caché la lista de inventario**

Modifique el método **\[HttpGet\]** en **InventoryController** para utilizar el almacenamiento en caché:

* Almacenar el resultado de la consulta de inventario en memoria durante 30 segundos  
* Recuperarlo de la caché en las siguientes peticiones

Ejemplo de solicitud de Copilot:

* "Añadir almacenamiento en caché en memoria a una solicitud GET en ASP.NET Core"

**Paso 3: Analizar y optimizar las consultas**

* Utilice **.Include()** para eager-load datos relacionados y reducir los problemas de N+1  
* Utilice **.AsNoTracking()** cuando las consultas no requieran seguimiento

En **OrderController**, identifique y refactorice cualquier consulta que pueda ser lenta o repetitiva.

Utilice la siguiente instrucción de Copilot:

* "Optimizar consultas de Entity Framework en ASP.NET Core"

**Paso 4: Medir las mejoras**

* Utilice métodos de temporización **(Stopwatch)** o herramientas de creación de perfiles de rendimiento para medir la mejora antes y después del almacenamiento en caché  
* Asegúrese de que las rutas almacenadas en caché siguen devolviendo datos válidos y actualícelas adecuadamente

**Paso 5: Utilice Copilot para revisar y mejorar**

Pruebe estas indicaciones:

* "Sugiera mejoras de rendimiento en este controlador"  
* "¿Cómo puedo evitar repetidas llamadas a la base de datos para el mismo resultado?"  
* "Mejore la velocidad de este punto final de API"

Aplique las sugerencias de Copilot a su código y vuelva a probarlo.

### **Lista de comprobación**

* Caché en memoria implementada en al menos una ruta  
* Optimizaciones de consulta aplicadas en la lógica del controlador  
* Reducción o eliminación de consultas lentas o repetidas  
* Política de caducidad de la caché  
* Uso de avisos Copilot para perfeccionar la lógica  
* Mejoras verificadas mediante pruebas o medición del tiempo  
* Código guardado para su uso en la Parte 5

**Introducción**

Su API ya es funcional, segura y está optimizada. Para completar tu proyecto final, asegurarás la consistencia de los datos y probarás cómo se comporta tu sistema a través de las sesiones. Utilizará Copilot para la revisión final del proyecto y preparará su trabajo para enviarlo a sus compañeros.

En esta actividad

* Implementará la gestión de estado persistente para datos críticos  
* Realizar pruebas de todo el sistema para validar la funcionalidad  
* Aplicar mejoras finales de rendimiento y usabilidad con Copilot

Esta es la última actividad de su proyecto final. Al final, dispondrá de un sistema API completo y listo para presentar para su revisión por pares.

## **Instrucciones de la actividad**

**Paso 1: Implementar la persistencia de estado**

Elija una de las siguientes estrategias para la persistencia de datos clave:

* **Estrategia de almacenamiento en caché:** Utilizar **IMemoryCache** con una lógica de caducidad y rehidratación más larga  
* **Estrategia de base de datos:** Confirme la persistencia de la base de datos verificando que el estado sobrevive a los reinicios del servidor

Para datos de pedidos temporales o similares a los de un carro, considere la posibilidad de almacenar ID de sesión o tokens de usuario como parte del modelo de pedido.

**Paso 2: Validar el flujo de trabajo de la aplicación**

Pruebe todo el flujo de trabajo, incluyendo

* Inventario y creación de pedidos  
* Autenticación y control de acceso  
* Tiempos de respuesta de la API y almacenamiento en caché  
* Gestión de errores para entradas no válidas  
* Acceso seguro a rutas con funciones restringidas

Utilice Swagger o Postman para simular el uso real.

**Paso 3: Utilice Microsoft Copilot para las mejoras finales**

Pruebe con preguntas como

* "Revise esta base de código en busca de lógica redundante"  
* "Sugiera mejoras finales de rendimiento"  
* "¿Qué más debería incluir en una API lista para producción?

Aplique las sugerencias de Copilot y compruebe que mejoran la claridad, el rendimiento o la seguridad.

**Paso 4: Preparar la presentación final**

* Guarde todos los archivos y confirme que el proyecto se ha creado correctamente  
* Prepare un breve resumen de la arquitectura de su sistema y de las decisiones clave (utilizado en la revisión por pares)

### **Lista de comprobación de la presentación**

* Implementación de estado persistente verificada  
* Flujo de trabajo completo probado: autenticación, almacenamiento en caché, comportamiento de la API  
* Código optimizado siguiendo las recomendaciones de Copilot  
* Eliminación de lógica redundante o innecesaria  
* Versión final lista para su envío a los pares


# Estructura de la Aplicación:

![Estructura del proyecto](https://res.cloudinary.com/dz5rt0tjz/image/upload/v1712068660/k4icar6lhvq2xbvseqzq.png)

La aplicación está dividida en cuatro capas principales:

### API:
Esta capa actúa como punto de entrada para la interacción con la aplicación. Maneja las solicitudes del cliente y las rutas hacia los controladores correspondientes en la capa de aplicación. La API se comunica con las capas de aplicación e implementa al contenedor de inyecciones la interfaz de los repositories.

### Application:
En esta capa reside la lógica de la aplicación. Aquí se procesan las solicitudes entrantes, se realizan las validaciones necesarias y se orquestan las interacciones entre los diferentes componentes del sistema. La capa de aplicación se comunica con la capa de dominio.

### Domain:
La capa de dominio encapsula toda la lógica de negocio de la aplicación. Aquí se definen los modelos de dominio, las reglas de negocio y las interfaces para interactuar con el mundo exterior. La capa de dominio es independiente de cualquier tecnología específica y no depende de las capas superiores.

### Infrastructure:
En esta capa se encuentran las implementaciones concretas de los puertos definidos en el dominio. Esto incluye adaptadores para interactuar con bases de datos, servicios externos, sistemas de archivos, etc. La capa de infraestructura se comunica con la capa de dominio para realizar operaciones específicas, pero no contiene lógica de negocio.
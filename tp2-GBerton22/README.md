[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-24ddc0f5d75046c5622901739e7c5dd533143b0c8e959d652212380cedb1ea36.svg)](https://classroom.github.com/a/Vh9kXZsA)
# Trabajo Práctico 2

Una biblioteca necesita un software que le permita registrar los datos de los libros que posee y de sus préstamos. De cada libro conoce su código, título, precio de reposición (para el caso de extravíos o daños) y estado (1: disponible, 2: prestado, 3: extraviado).

Por otro lado, cada vez que un libro es prestado se registra el nombre del solicitante, la cantidad de días del préstamo y si fue devuelto o no. El conjunto de préstamos debe ser almacenado como un atributo del libro en cuestión.

Se necesita entonces un programa que permita cargar libros y préstamos en una base de datos SQL Server y que ofrezca los siguientes reportes:
* Cantidad de libros en cada estado (tres totales)
* Sumatoria del precio de reposición de todos los libros extraviados
* Nombre de todos los solicitantes de un libro en particular identificado por su título. Si hay más de un libro cuyos títulos coinciden con el ingresado por el usuario, presentarlos en un listado en pantalla y permitir que el usuario seleccione uno de ellos.
* Promedio de veces que fueron prestados los libros de la biblioteca. Es decir, se debe responder a la consulta de cuántas veces es prestado en promedio cada libro (es un promedio simple entre cantidad de prestamos y cantidad de libros)
* Listado con nombre del solicitante, titulo del libro y cantidad de prestamos de aquellos libros que fueron solicitados más de una vez por el mismo solicitante.

El diseño de la base de datos queda a elección de cada programador, pero debe incluir al menos una tabla de libros y otra de préstamos.

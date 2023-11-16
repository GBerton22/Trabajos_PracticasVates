
SET IDENTITY_INSERT Estados ON
INSERT INTO Estados (EstadoId,EstadoL) VALUES (1,'Disponible')
INSERT INTO Estados (EstadoId,EstadoL) VALUES (2,'Prestado')
INSERT INTO Estados (EstadoId,EstadoL) VALUES (3,'Extraviado')
SET IDENTITY_INSERT Estados OFF

 SET IDENTITY_INSERT Bibliotecas ON
 INSERT INTO Bibliotecas (BibliotecaId, NombreBiblioteca) VALUES (1,'Mundo Libro')
 INSERT INTO Bibliotecas (BibliotecaId, NombreBiblioteca) VALUES (2,'BooksMan')
 SET IDENTITY_INSERT Bibliotecas OFF

SET IDENTITY_INSERT Libros ON
INSERT INTO Libros (LibroId,Titulo,Precio,EstadoId,BibliotecaId) VALUES (1,'La casita azul',6500.00,1,1)
INSERT INTO Libros (LibroId,Titulo,Precio,EstadoId,BibliotecaId) VALUES (2,'Avatar',12000.00,2,2)
INSERT INTO Libros (LibroId,Titulo,Precio,EstadoId,BibliotecaId) VALUES (3,'Sapo pepe',4500.00,3,1)
INSERT INTO Libros (LibroId,Titulo,Precio,EstadoId,BibliotecaId) VALUES (4,'Los miserables',1500.00,2,2)
INSERT INTO Libros (LibroId,Titulo,Precio,EstadoId,BibliotecaId) VALUES (5,'El alquimista',6000.00,1,1)
INSERT INTO Libros (LibroId,Titulo,Precio,EstadoId,BibliotecaId) VALUES (6,'El principito',7800.00,3,1)
INSERT INTO Libros (LibroId,Titulo,Precio,EstadoId,BibliotecaId) VALUES (7,'Un mundo feliz',9300.00,1,2)
INSERT INTO Libros (LibroId,Titulo,Precio,EstadoId,BibliotecaId) VALUES (8,'A sangre fria',1200.00,3,2)
INSERT INTO Libros (LibroId,Titulo,Precio,EstadoId,BibliotecaId) VALUES (9,'La casita azul',5000.00,2,1)

INSERT INTO Libros (LibroId,Titulo,Precio,EstadoId,BibliotecaId) VALUES (10,'La casita azul',6300.00,1,1)
INSERT INTO Libros (LibroId,Titulo,Precio,EstadoId,BibliotecaId) VALUES (11,'A sangre fria',12000.00,2,1)
INSERT INTO Libros (LibroId,Titulo,Precio,EstadoId,BibliotecaId) VALUES (12,'Outlast',15000.00,3,1)
INSERT INTO Libros (LibroId,Titulo,Precio,EstadoId,BibliotecaId) VALUES (13,'Assasins Creed',7000.00,2,1)
INSERT INTO Libros (LibroId,Titulo,Precio,EstadoId,BibliotecaId) VALUES (14,'El bosque',6344.00,1,1)
INSERT INTO Libros (LibroId,Titulo,Precio,EstadoId,BibliotecaId) VALUES (15,'Viernes 13',2400.00,3,1)

INSERT INTO Libros (LibroId,Titulo,Precio,EstadoId,BibliotecaId) VALUES (16,'La casita azul',7426.00,3,2)
INSERT INTO Libros (LibroId,Titulo,Precio,EstadoId,BibliotecaId) VALUES (17,'El principito',9240.00,1,1)
INSERT INTO Libros (LibroId,Titulo,Precio,EstadoId,BibliotecaId) VALUES (18,'Los miserables',2512.00,2,2)
INSERT INTO Libros (LibroId,Titulo,Precio,EstadoId,BibliotecaId) VALUES (19,'Sapo pepe',2222.00,2,1)
INSERT INTO Libros (LibroId,Titulo,Precio,EstadoId,BibliotecaId) VALUES (20,'Avatar',9000.00,3,2)
SET IDENTITY_INSERT Libros OFF

SET IDENTITY_INSERT Prestamos ON
INSERT INTO Prestamos (PrestamoId,NombreSolicitante,CantidadDias,Devuelto,LibroId) VALUES (1,'Fabrizio','20',0,1)
INSERT INTO Prestamos (PrestamoId,NombreSolicitante,CantidadDias,Devuelto,LibroId) VALUES (2,'Pablo','5',1,2)
INSERT INTO Prestamos (PrestamoId,NombreSolicitante,CantidadDias,Devuelto,LibroId) VALUES (3,'Maria','15',1,3)
INSERT INTO Prestamos (PrestamoId,NombreSolicitante,CantidadDias,Devuelto,LibroId) VALUES (4,'Juan','12',0,4)
INSERT INTO Prestamos (PrestamoId,NombreSolicitante,CantidadDias,Devuelto,LibroId) VALUES (5,'Daniel','1',1,5)
INSERT INTO Prestamos (PrestamoId,NombreSolicitante,CantidadDias,Devuelto,LibroId) VALUES (6,'Marcos','16',0,6)
INSERT INTO Prestamos (PrestamoId,NombreSolicitante,CantidadDias,Devuelto,LibroId) VALUES (7,'Gonzalo','25',0,7)
INSERT INTO Prestamos (PrestamoId,NombreSolicitante,CantidadDias,Devuelto,LibroId) VALUES (8,'Marcelo','5',1,8)
INSERT INTO Prestamos (PrestamoId,NombreSolicitante,CantidadDias,Devuelto,LibroId) VALUES (9,'Martin','6',0,9)

INSERT INTO Prestamos (PrestamoId,NombreSolicitante,CantidadDias,Devuelto,LibroId) VALUES (10,'Meron','7',0,10)
INSERT INTO Prestamos (PrestamoId,NombreSolicitante,CantidadDias,Devuelto,LibroId) VALUES (11,'Astor','9',0,11)
INSERT INTO Prestamos (PrestamoId,NombreSolicitante,CantidadDias,Devuelto,LibroId) VALUES (12,'Issac','2',0,6)
INSERT INTO Prestamos (PrestamoId,NombreSolicitante,CantidadDias,Devuelto,LibroId) VALUES (13,'Jesus','6',0,8)
INSERT INTO Prestamos (PrestamoId,NombreSolicitante,CantidadDias,Devuelto,LibroId) VALUES (14,'Nestor','15',0,2)
INSERT INTO Prestamos (PrestamoId,NombreSolicitante,CantidadDias,Devuelto,LibroId) VALUES (15,'Nestor','5',1,20)
INSERT INTO Prestamos (PrestamoId,NombreSolicitante,CantidadDias,Devuelto,LibroId) VALUES (16,'Issac','52',0,16)
INSERT INTO Prestamos (PrestamoId,NombreSolicitante,CantidadDias,Devuelto,LibroId) VALUES (17,'Issac','23',1,17)

INSERT INTO Prestamos (PrestamoId,NombreSolicitante,CantidadDias,Devuelto,LibroId) VALUES (18,'Judas','23',0,18)
INSERT INTO Prestamos (PrestamoId,NombreSolicitante,CantidadDias,Devuelto,LibroId) VALUES (19,'Judas','23',1,19)
INSERT INTO Prestamos (PrestamoId,NombreSolicitante,CantidadDias,Devuelto,LibroId) VALUES (20,'Martin','23',0,20)
INSERT INTO Prestamos (PrestamoId,NombreSolicitante,CantidadDias,Devuelto,LibroId) VALUES (21,'Pedro','23',1,3)
INSERT INTO Prestamos (PrestamoId,NombreSolicitante,CantidadDias,Devuelto,LibroId) VALUES (22,'Diego','23',1,17)
SET IDENTITY_INSERT Prestamos OFF


Select * from Prestamos
SELECT* FROM Libros
select * from Bibliotecas


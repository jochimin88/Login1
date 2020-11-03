

 /* create database ejemplo;*/

CREATE DATABASE ejemplo

 /* use database ejemplo*/

USE ejemplo

/* create table Usuarios inside of database ejemplo
  with Nombre, Usuario, Password,and Tipo_usuario
*/

create table Usuarios(
Id_usuario INT NOT NULL PRIMARY KEY IDENTITY(1,1),
Nombre VARCHAR(50) NULL,
Usuario VARCHAR(50) NULL,
Password VARCHAR(50) NULL,
Tipo_usuario VARCHAR(50) NULL,
)


/* Insert this values in the tables*/

insert into Usuarios values ('Jochimin Contreras', 'jochimin', '123456789', 'Admin'),
                                ('Fidel Contreras', 'fidel', '123456789', 'Usuario');


/*Show all the tables from Usuarios table */

select * from Usuarios


if DB_ID('BD_ESCUELA') IS NOT NULL
	DROP DATABASE BD_ESCUELA
GO

create database BD_ESCUELA
go

use BD_ESCUELA

create table Profesor(
idProfesor int identity,
nombres varchar(50),
apellidoPat varchar(50),
apellidoMat varchar(50)
primary key(idProfesor)
)

create table Curso(
idCurso int identity,
curso varchar(40) not null,
idProfesor int
primary key(idCurso) 
)

alter table Curso add constraint fk_Curso_idProfesor foreign key(idProfesor) references Profesor(idProfesor)

insert into Profesor values('Juan Manuel', 'Lopez', 'Aliaga')
insert into Profesor values('Marcelo', 'Perez', 'Mamani')
insert into Profesor values('Marta Cristina', 'Berrospi', 'Uriol')
insert into Profesor values('Jose', 'Llerena', 'Moscol')
insert into Profesor values('Jose', 'Luna', 'Galvez')
insert into Profesor values('Marco', 'Reyes', 'Zeta')

insert into Curso values('Fundamentos de Programacion', 1)
insert into Curso values('Programacion Orientado Objetos', 2)
insert into Curso values('Desarrollo web', 3)
insert into Curso values('Aplicaciones Moviles', 4)
insert into Curso values('Cloud', 5)
insert into Curso values('Matematica', 6)


select*from Profesor
select*from Curso

create proc spListar_profesor
as
	begin
	select idProfesor 'ID', nombres 'NOMBRES', apellidoPat 'APELLIDO PATERNO', apellidoMat 'APELLIDO MATERNO'
	from Profesor
	END

EXEC spListar_profesor
------------insertar------

create proc spInsertar_profesor(@nombres varchar(50), @apePat varchar(50),@apeMat varchar(50))
as
insert into Profesor(nombres, apellidoPat, apellidoMat) 
values(@nombres, @apePat,@apeMat);

----------Buscar por ID-------

create proc spConsultarId(@id int)
as
	select idProfesor 'ID', nombres 'NOMBRES', apellidoPat 'APELLIDO PATERNO', apellidoMat 'APELLIDO MATERNO'
	from Profesor 
	WHERE idProfesor = @id


	exec spConsultarId 2
-----------Actualizar----------

create proc spActualizar_profesor(@id int,@nombres varchar(50), @apePat varchar(50),@apeMat varchar(50))
as
begin
	update Profesor set nombres = @nombres, apellidoPat = @apePat, apellidoMat = @apeMat
	where idProfesor = @id
end

------Eliminar--------
create proc spEliminar_profesor(@id int)
as
	begin
		DELETE Profesor WHERE idProfesor = @id
	end


-------Curso-------

create proc spListar_curso
as
	begin
		select c.idCurso 'ID', c.curso 'Curso', p.nombres 'PROFESOR'
		from Curso c inner join Profesor p
		on c.idProfesor = p.idProfesor
	end


create proc spInsetar_curso(@curso varchar(50), @idProfesor int)
as
	begin
		insert into Curso(curso, idProfesor) values(@curso, @idProfesor)
	end



create proc spActualizar_curso(@idCurso int, @curso varchar(40), @idProfesor int)
as
	begin
		UPDATE Curso SET curso=@curso, idProfesor = @idProfesor
		WHERE idCurso = @idCurso
	end


create proc spBuscarxId_curso(@idCurso int)
as
	begin
		select idCurso 'ID', c.curso 'Curso', p.nombres 'Profesor'
		from Curso c inner join Profesor p
		on c.idProfesor = p.idProfesor
		where idCurso = @idCurso
	end


create proc spElminiar_curso(@idCurso int)
as
	begin
		delete Curso where @idCurso = idCurso
	end
CREATE TABLE USUARIOS(
nombreUsr VARCHAR(20),
contrasena VARCHAR(40),
tipo VARCHAR(20),
PRIMARY KEY (nombreUsr),
)

CREATE TABLE AREA (
idArea varchar(10) primary key,
nombre varchar(50) not null,
fkArea varchar(10),
CONSTRAINT FK_AREA FOREIGN KEY (fkArea)
REFERENCES AREA(idArea)
)

CREATE TABLE MSJERROR(
mensaje VERCHAR(MAX) NOT NULL
)

--CREATE PROCEDURE [dbo].[procInsertArea]
--@idArea varchar(10),
--@nombre varchar(50),
--@fkArea varchar(10)
--AS
--BEGIN TRANSACTION 
--     BEGIN TRY 
--	 INSERT INTO AREA(idArea,nombre,fkArea)
--	 VALUES(@idArea,@nombre,@fkArea)
--	 COMMIT TRANSACTION
--	 END TRY
--	 BEGIN CATCH 
--	 ROLLBACK TRANSACTION
--	 INSERT INTO msjError (mensaje)
--	 values (ERROR_MESSAGE())
--	 END CATCH

CREATE PROCEDURE [dbo].[procModificarArea]
	@idArea varchar(10),
	@nombre varchar(50),
	@fkArea varchar(10)
AS
BEGIN TRANSACTION
	BEGIN TRY
		UPDATE AREA SET nombre = @nombre, fkArea = @fkArea WHERE idArea = @idArea;
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		INSERT INTO MSJERROR values (ERROR_MESSAGE())
	END CATCH
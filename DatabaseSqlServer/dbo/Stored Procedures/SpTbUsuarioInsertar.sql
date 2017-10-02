
CREATE PROCEDURE [dbo].[SpTbUsuarioInsertar]
@IdUsuario AS INT OUTPUT,
@Usuario AS VARCHAR(10),
@Nombre AS VARCHAR(50),
@Email AS VARCHAR(50),
@Contrasenha AS VARCHAR(10),
@Bloqueado AS BIT,
@Activo AS BIT,
@IdUsuarioCreador AS INT
AS
BEGIN
	INSERT INTO TbUsuario (Usuario,Nombre,Email,Contrasenha,Bloqueado,Activo,IdUsuarioCreador,FechaCreacion)
	VALUES (@Usuario,@Nombre,@Email,@Contrasenha,@Bloqueado,@Activo,@IdUsuarioCreador,GETDATE())

	SET @IdUsuario = @@IDENTITY
END
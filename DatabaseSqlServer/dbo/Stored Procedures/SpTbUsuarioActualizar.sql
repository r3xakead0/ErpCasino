
CREATE PROCEDURE [dbo].[SpTbUsuarioActualizar]
@IdUsuario AS INT,
@Usuario AS VARCHAR(10),
@Nombre AS VARCHAR(50),
@Email AS VARCHAR(50),
@Contrasenha AS VARCHAR(10),
@Bloqueado AS BIT,
@Activo AS BIT,
@IdUsuarioModificador INT
AS
BEGIN

	UPDATE TbUsuario
	SET Usuario = @Usuario,
		Nombre = @Nombre,
		Email = @Email,
		Contrasenha = @Contrasenha,
		Bloqueado = @Bloqueado,
		Activo = @Activo,
		IdUsuarioModificador = @IdUsuarioModificador,
		FechaModificacion = GETDATE()
	WHERE IdUsuario = @IdUsuario

END

CREATE PROCEDURE [dbo].[SpTbUsuarioObtener]
@IdUsuario AS INT
AS
BEGIN
	SELECT	TOP 1 
			IdUsuario,
			Usuario,
			Nombre,
			Email,
			Contrasenha,
			Bloqueado,
			Activo,
			IdUsuarioCreador,
			FechaCreacion,
			IdUsuarioModificador,
			FechaModificacion
	FROM	TbUsuario WITH(NOLOCK)
	WHERE	IdUsuario = @IdUsuario
END

CREATE PROCEDURE [dbo].[SpTbUsuarioListar]
AS
BEGIN
	SELECT	IdUsuario,
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
	FROM	TbUsuario
END
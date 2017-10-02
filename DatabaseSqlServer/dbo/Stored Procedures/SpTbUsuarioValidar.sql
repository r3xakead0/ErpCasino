
CREATE PROCEDURE [dbo].[SpTbUsuarioValidar]
@Usuario AS VARCHAR(10),
@Contrasenha AS VARCHAR(10)
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
FROM	TbUsuario
WHERE	Usuario = @Usuario
AND		Contrasenha = @Contrasenha
END
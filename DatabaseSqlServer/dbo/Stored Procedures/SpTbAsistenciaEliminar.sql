CREATE PROCEDURE [dbo].[SpTbAsistenciaEliminar]
@IdAsistencia AS INT
AS
BEGIN
	DELETE FROM TbAsistencia
	WHERE	IdAsistencia = @IdAsistencia
END
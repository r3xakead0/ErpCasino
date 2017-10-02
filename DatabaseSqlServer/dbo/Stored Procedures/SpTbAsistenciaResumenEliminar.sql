CREATE PROCEDURE [dbo].[SpTbAsistenciaResumenEliminar]
@FECHA AS DATE
AS
BEGIN

	DELETE FROM TbAsistencia
	WHERE FechaRegistro = @FECHA

END
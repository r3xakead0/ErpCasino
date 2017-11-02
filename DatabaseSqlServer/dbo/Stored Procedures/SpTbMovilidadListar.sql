
CREATE PROCEDURE [dbo].[SpTbMovilidadListar]
AS
BEGIN
	SELECT	IdMovilidad,
			Anho,
			Mes,
			CodigoEmpleado,
			Monto,
			IdUsuarioCreador,
			FechaCreacion,
			IdUsuarioModificador,
			FechaModificacion
	FROM	TbMovilidad WITH(NOLOCK) 
END
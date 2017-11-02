CREATE PROCEDURE SpTbMovilidadObtener
@IdMovilidad AS INT
AS
BEGIN
	SELECT	TOP 1 
			IdMovilidad,
			Anho,
			Mes,
			CodigoEmpleado,
			Monto,
			IdUsuarioCreador,
			FechaCreacion,
			IdUsuarioModificador,
			FechaModificacion
	FROM	TbMovilidad WITH(NOLOCK)
	WHERE	IdMovilidad = @IdMovilidad
END
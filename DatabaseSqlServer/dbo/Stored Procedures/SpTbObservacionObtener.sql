CREATE PROCEDURE SpTbObservacionObtener
@IdObservacion AS INT
AS
BEGIN
	SELECT	TOP 1 
			IdObservacion,
			Nombre,
			Descripcion,
			Activo
	FROM	TbObservacion
	WHERE	IdObservacion = @IdObservacion
END
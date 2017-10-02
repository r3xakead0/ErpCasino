
CREATE PROCEDURE [dbo].[SpTbPostulanteHistorialListar] 
@IdPostulante AS INTEGER
AS
BEGIN

	SELECT	T0.IdPostulante,
			T0.IdPostulanteEstado,
			T0.Acepto,
			T0.Nota
	FROM	TbPostulanteHistorial T0
	WHERE	T0.IdPostulante = @IdPostulante
	ORDER BY T0.IdPostulanteEstado

END
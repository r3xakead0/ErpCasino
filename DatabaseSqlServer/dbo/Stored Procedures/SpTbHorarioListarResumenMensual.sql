
CREATE PROC [dbo].[SpTbHorarioListarResumenMensual]
@IdSala AS INT = NULL
AS
BEGIN

	SELECT	TT.Anho,
			TT.Mes,
			TT.IdSala,
			TT.DscSala
	FROM	(
			SELECT	T0.Anho,
					MONTH(T0.Fecha) AS Mes,
					T0.IdSala,
					T1.Nombre AS DscSala
			FROM	TbHorario T0 
			INNER JOIN TbSala T1 ON T1.IdSala = T0.IdSala
			WHERE	(@IdSala IS NULL OR T0.IdSala = @IdSala)
			) TT
	GROUP BY TT.Anho,
			TT.Mes,
			TT.IdSala,
			TT.DscSala
	ORDER BY TT.Anho,
			TT.Mes,
			TT.IdSala

END
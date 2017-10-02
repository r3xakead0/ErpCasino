
CREATE PROC [dbo].[SpTbHorarioListarResumenSemanal]
@IdSala AS INT = NULL
AS
BEGIN

	SELECT	T0.Anho,
			T0.Semana,
			T0.IdSala,
			T1.Nombre AS DscSala,
			MIN(T0.Fecha) AS FechaInicio,
			MAX(T0.Fecha) AS FechaFinal
	FROM	TbHorario T0 
	INNER JOIN TbSala T1 ON T1.IdSala = T0.IdSala
	WHERE	(@IdSala IS NULL OR T0.IdSala = @IdSala)
	GROUP BY T0.Anho,
			T0.Semana,
			T0.IdSala,
			T1.Nombre
	ORDER BY T0.Anho,
			T0.Semana,
			T0.IdSala

END
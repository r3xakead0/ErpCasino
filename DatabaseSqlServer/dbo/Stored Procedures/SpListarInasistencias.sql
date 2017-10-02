-- exec SpListarInasistencias 2017, 5, 1
CREATE PROC [dbo].[SpListarInasistencias]
@Anho AS INT,
@Mes AS INT,
@IdSala AS INT = NULL
AS
BEGIN

	SELECT	T0.Anho,
			MONTH(T0.Fecha) AS Mes,
			T0.Semana,
			T0.IdSala,
			T0.IdCargo,
			T0.Codigo,
			T0.Fecha,
			T0.Dia,
			T0.Turno,
			T0.FechaInicio,
			T0.FechaFinal,
			T0.HoraInicio,
			T0.HoraFinal,
			T0.Horas
	INTO	#INASISTENCIAS
	FROM	TbHorario T0 
	LEFT JOIN TbAsistencia T1 ON T1.Codigo = T0.Codigo 
							AND T1.FechaRegistro = T0.Fecha 
	WHERE	MONTH(T0.Fecha) = @Mes
	AND		YEAR(T0.Fecha) = @Anho
	AND		(@IdSala IS NULL OR T0.IdSala = @IdSala)
	AND		ISNULL(DATEDIFF(HOUR,T1.FechaHoraEntrada,T1.FechaHoraSalida),0) = 0
	ORDER BY T0.Fecha 

	SELECT	ISNULL(T1.IdInasistencia,0) AS IdInasistencia, 
			T0.Anho,
			T0.Mes,
			T0.Semana,
			T0.IdSala,
			T0.IdCargo,
			T0.Codigo,
			T0.Fecha,
			T0.Dia,
			T0.Turno,
			T0.FechaInicio,
			T0.FechaFinal,
			T0.HoraInicio,
			T0.HoraFinal,
			T0.Horas,
			T1.Tipo,
			T1.Asunto,
			T1.Detalle,
			T1.CITT
	FROM	#INASISTENCIAS T0 
	LEFT JOIN TbInasistencia T1 ON T1.Codigo = T0.Codigo 
								AND	T1.FechaRegistro = T0.Fecha 
	
END
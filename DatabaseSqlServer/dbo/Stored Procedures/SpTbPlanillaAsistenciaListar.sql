CREATE PROC [dbo].[SpTbPlanillaAsistenciaListar]
@IdPlanilla AS INT
AS
BEGIN
	SELECT	T0.IdPlanillaAsistencia,
			T0.IdPlanilla,
			T0.CodigoEmpleado,
			T0.Fecha,
			T0.Semana,
			T0.FechaHoraInicio,
			T0.FechaHoraFinal,
			T0.MinutosAsistenciaTotal,
			T0.MinutosAsistenciaNormalDiurna,
			T0.MinutosAsistenciaNormalNocturna,
			T0.MinutosAsistenciaNormalDiurnaExtra1,
			T0.MinutosAsistenciaNormalNocturnaExtra1,
			T0.MinutosAsistenciaNormalDiurnaExtra2,
			T0.MinutosAsistenciaNormalNocturnaExtra2,
			T0.MinutosAsistenciaFeriadoDiurna,
			T0.MinutosAsistenciaFeriadoNocturna,
			T0.MinutosAsistenciaFeriadoDiurnaExtra1,
			T0.MinutosAsistenciaFeriadoNocturnaExtra1,
			T0.MinutosAsistenciaFeriadoDiurnaExtra2,
			T0.MinutosAsistenciaFeriadoNocturnaExtra2,
			T0.MinutosTardanzaTotal,
			T0.MinutosTardanzaNormalDiurna,
			T0.MinutosTardanzaNormalNocturna,
			T0.MinutosTardanzaFeriadoDiurna,
			T0.MinutosTardanzaFeriadoNocturna,
			T0.MinutosInasistenciaTotal,
			T0.MinutosInasistenciaNormal,
			T0.MinutosInasistenciaFeriado
	FROM	TbPlanillaAsistencia T0 WITH(NOLOCK)
	WHERE	T0.IdPlanilla = @IdPlanilla
END
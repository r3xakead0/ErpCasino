
CREATE PROC [dbo].[SpTbPlanillaAsistenciaResumen]
@Anho AS INT,
@Mes AS INT,
@CodigoEmpleado AS VARCHAR(10) = NULL
AS
BEGIN

	SELECT	T1.IdPlanilla,
			T0.CodigoEmpleado,
			COUNT(T0.MinutosAsistenciaTotal) AS CantidadAsistencias,
			COUNT(T0.MinutosTardanzaTotal) AS CantidadTardanzas,
			COUNT(T0.MinutosInasistenciaTotal) AS CantidadInasistencias
	FROM	TbPlanillaAsistencia T0 WITH(NOLOCK)
	INNER JOIN TbPlanilla T1 WITH(NOLOCK) ON T1.IdPlanilla = T0.IdPlanilla
	WHERE	T1.Anho = @Anho 
	AND		T1.Mes = @Mes
	AND		(@CodigoEmpleado IS NULL OR T0.CodigoEmpleado = @CodigoEmpleado)
	GROUP BY T1.IdPlanilla,
			T0.CodigoEmpleado

END
CREATE PROC [dbo].[SpObtenerPlanillaResumen]
@Anho INT,
@Mes INT
AS
SELECT	COUNT(T1.CodigoEmpleado) AS CantidadEmpleados,
		ISNULL(SUM(T1.TotalSueldoNeto),0) AS TotalSueldos,
		ISNULL(SUM(T1.TotaPago),0) AS TotalPagos,
		ISNULL(SUM(T1.SnpTotal),0) AS TotalSNP,
		ISNULL(SUM(T1.AfpTotal),0) AS TotalAFP,
		ISNULL(SUM(T1.EsSaludTotal),0) AS TotalEsSalud
FROM	TbPlanilla T0 
INNER JOIN TbPlanillaDetalle T1 ON T1.IdPlanilla = T0.IdPlanilla
WHERE	T0.Anho = @Anho
AND		T0.Mes = @Mes
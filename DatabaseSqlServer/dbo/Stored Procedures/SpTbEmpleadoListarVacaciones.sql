--EXEC SpTbEmpleadoListarVacaciones '20171101' 
CREATE PROCEDURE [dbo].[SpTbEmpleadoListarVacaciones]
@Fecha AS DATE
AS
BEGIN

	SELECT	T0.IdEmpleado,
			T0.Codigo,
			T0.ApellidoPaterno + ' ' + T0.ApellidoMaterno + ', ' + T0.Nombres AS ApellidosNombres,
			T1.FechaInicio AS FechaIngreso,
			T1.FechaUltimaVacacion AS FechaVacacion
	FROM	TbEmpleado T0 
	INNER JOIN TbEmpleadoRecurso T1 ON T1.IdEmpleado = T0.IdEmpleado 
	WHERE	T0.Activo = 1 
	AND		T1.Cesado = 0 
	AND		T1.FechaCese IS NULL
	AND		DATEDIFF(YEAR, T1.FechaInicio, @Fecha) > 0
	AND		(T1.FechaUltimaVacacion IS NULL OR DATEDIFF(YEAR, T1.FechaUltimaVacacion, @Fecha) > 0)
	ORDER BY T0.ApellidoPaterno, 
			T0.ApellidoMaterno,
			T0.Nombres

END
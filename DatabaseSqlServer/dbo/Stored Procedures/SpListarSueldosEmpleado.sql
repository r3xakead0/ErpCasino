CREATE PROC [dbo].[SpListarSueldosEmpleado]
AS
BEGIN

	SELECT	T0.Codigo,
			T0.ApellidoPaterno, 
			T0.ApellidoMaterno,
			T0.Nombres,
			T1.Sueldo,
			CAST(CASE WHEN T1.NumeroHijos > 0 THEN 1 ElSE 0 END AS BIT) AS Hijos
	FROM	TbEmpleado T0 
	INNER JOIN TbEmpleadoRecurso T1 ON T1.IdEmpleado = T0.IdEmpleado
	WHERE	T0.Activo = 1
	ORDER BY T0.Codigo

END
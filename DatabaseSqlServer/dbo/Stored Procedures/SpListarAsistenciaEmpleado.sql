-- Calculo al detalle por dia sobre
-- Horas asistidas e inasistidas en Minutos
-- Horas normales y extras en Minutos
-- Minutos de Tardanza
-- exec [SpListarAsistenciaEmpleado] 2017,10
CREATE PROC [dbo].[SpListarAsistenciaEmpleado]
@Anho AS INT,
@Mes AS INT
AS
BEGIN
SELECT	CAST(T0.Fecha AS DATETIME) + CAST('22:00:00' AS DATETIME) AS FechaHoraNocheInicial,
		DATEADD(HOUR,8,CAST(T0.Fecha AS DATETIME) + CAST('22:00:00' AS DATETIME)) AS FechaHoraNocheFinal,
		T0.Codigo,
		T2.ApellidoPaterno + ' ' + T2.ApellidoMaterno + ', ' + T2.Nombres AS Empleado,
		T0.Fecha,
		T0.Semana,
		T0.Anho,
		CAST(T0.FechaInicio AS DATETIME) + CAST(T0.HoraInicio AS DATETIME) AS FechaHoraHorarioInicial,
		CAST(T0.FechaFinal AS DATETIME) + CAST(T0.HoraFinal AS DATETIME) AS FechaHoraHorarioFinal,
		T0.Horas AS HorasHorario,
		T1.FechaHoraEntrada AS FechaHoraAsistenciaInicial,
		T1.FechaHoraSalida AS FechaHoraAsistenciaFinal,
		ISNULL(DATEDIFF(HOUR,T1.FechaHoraEntrada,T1.FechaHoraSalida),0) AS HorasAsistencia
FROM	TbHorario T0 
LEFT JOIN TbAsistencia T1 ON T1.Codigo = T0.Codigo 
						AND T1.FechaRegistro = T0.Fecha 
						AND T1.Turno = T0.Turno 
INNER JOIN TbEmpleado T2 ON T2.Codigo = T0.Codigo 
WHERE	MONTH(T0.Fecha) = @Mes
AND		YEAR(T0.Fecha) = @Anho
ORDER BY T0.Fecha 
END
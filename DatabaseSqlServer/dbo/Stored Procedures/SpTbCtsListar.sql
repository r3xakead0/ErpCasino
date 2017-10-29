CREATE PROCEDURE SpTbCtsListar
AS
BEGIN
	SELECT	IdCts,
			Anho,
			Periodo,
			PeriodoFechaInicial,
			PeriodoFechaFinal,
			EmpleadoCodigo,
			EmpleadoFechaIngreso,
			EmpleadoSueldo,
			EmpleadoAsigFam,
			TotalBonificacion,
			TotalHorasExtras,
			TotalGratificacion,
			PromedioBonificacion,
			PromedioHorasExtras,
			PromedioGratificacion,
			ComputableTotal,
			ComputableFechaInicial,
			ComputableFechaFinal,
			ComputableMeses,
			ComputableDias,
			ComputablePagar,
			BancoId,
			BancoCuenta,
			DepositoFecha,
			DepositoMonto,
			DepositoOperacion
	FROM	TbCts WITH(NOLOCK)
END
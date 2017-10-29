CREATE PROCEDURE SpTbCtsObtener
@IdCts AS INT
AS
BEGIN
	SELECT	TOP 1 
			IdCts,
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
	WHERE	IdCts = @IdCts
END
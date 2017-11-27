CREATE PROCEDURE [dbo].[SpTbVacacionListarPorEmpleado]
@CodigoEmpleado AS VARCHAR(10)
AS
BEGIN

	SELECT	IdVacacion,
			PeriodoFechaInicial,
			PeriodoFechaFinal,
			FechaInicial,
			FechaFinal,
			Dias,
			CodigoEmpleado,
			Sueldo,
			AsignacionFamiliar,
			PromedioHorasExtras,
			PromedioBonificacion,
			Redondeo,
			TotalBruto,
			idAfpComision,
			ComisionAfp,
			idOnpComision,
			PensionMonto,
			RetencionJudicialMonto,
			TotalDescuento,
			TotalNeto
	FROM	TbVacacion WITH(NOLOCK)
	WHERE	CodigoEmpleado = @CodigoEmpleado
	ORDER BY FechaInicial DESC

END
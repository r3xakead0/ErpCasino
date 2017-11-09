CREATE PROCEDURE SpTbVacacionListar
@Anho AS INT,
@Mes AS INT
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
			TotalBruto,
			idAfpComision,
			ComisionAfp,
			idOnpComision,
			PensionMonto,
			RetencionJudicialMonto,
			TotalDescuento,
			TotalNeto
	FROM	TbVacacion WITH(NOLOCK)
	WHERE	YEAR(FechaInicial) = @Anho 
	AND		MONTH(FechaInicial) = @Mes 
	ORDER BY FechaInicial DESC

END
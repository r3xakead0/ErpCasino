﻿CREATE PROCEDURE [dbo].[SpTbVacacionObtener]
@IdVacacion AS INT
AS
BEGIN
	SELECT	TOP 1 
			IdVacacion,
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
	FROM	TbVacacion
	WHERE	IdVacacion = @IdVacacion
END
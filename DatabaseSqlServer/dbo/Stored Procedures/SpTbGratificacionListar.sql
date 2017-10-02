CREATE PROCEDURE [dbo].[SpTbGratificacionListar]
AS
BEGIN
	SELECT	IdGratificacion,
			Periodo,
			FechaInicio,
			FechaFinal,
			Dias,
			CodigoEmpleado,
			BonoNocturnoPromedio,
			BonoHorasExtrasPromedio,
			SueldoBase,
			AsignacionFamiliar,
			DiasLaborados,
			GratificacionBruta,
			BonoExtraordinario,
			GratificacionNeta,
			DescuentoRetencionJudicial,
			DescuentoImpuesto,
			GratificacionPagar
	FROM	TbGratificacion
END

CREATE PROCEDURE [dbo].[SpTbGratificacionObtener]
@IdGratificacion AS INT
AS
BEGIN
	SELECT	TOP 1 
			IdGratificacion,
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
	WHERE	IdGratificacion = @IdGratificacion
END
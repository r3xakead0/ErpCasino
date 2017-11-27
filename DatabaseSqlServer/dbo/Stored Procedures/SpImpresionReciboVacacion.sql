-- EXEC SpImpresionReciboVacacion 3
CREATE PROC [dbo].[SpImpresionReciboVacacion]
@IdVacacion AS INT
AS
BEGIN

	SELECT	TOP 1 
			'RECIBO DE VACACIONES ' + CONVERT(VARCHAR(4),YEAR(VacacionInicio)) AS Titulo,
			EmpresaNombre AS EmpresaNombre,
			UPPER(EmpleadoNombres + ' ' + EmpleadoApellidos) AS EmpleadoNombresApellidos,
			EmpleadoNroDocumento AS EmpleadoDNI, 
			Detalle AS VacacionDetalle,
			'DEL ' + CONVERT(VARCHAR(10),PeriodoInicio,103) + 
			' AL ' + CONVERT(VARCHAR(10),PeriodoFinal,103) 
			AS VacacionPeriodoRango,
			'DEL ' + CONVERT(VARCHAR(10),VacacionInicio,103) + 
			' AL ' + CONVERT(VARCHAR(10),VacacionFinal,103)  AS VacacionDescansoRango,
			Sueldo AS VacacionSueldo,
			AsignacionFamiliar AS VacacionAsignacionFamiliar,
			Redondeo AS VacacionRedondeo,
			PromedioHorasExtras AS VacacionOtros,
			PromedioBonificacion AS VacacionBonificacion,
			TotalBruto AS VacacionBruto,
			RetencionJudicialMonto AS VacacionAlimentos,
			PensionEntidad AS VacacionPensionNombre,
			PensionMonto AS VacacionPensionMonto,
			TotalNeto AS VacacionNeto,
			TotalNetoLiteral AS VacacionNetoLetras,
			EmpresaDistrito + ', ' + CONVERT(VARCHAR(2),DAY(VacacionInicio)) + ' de ' + MesNombre + ' del ' + CONVERT(VARCHAR(4),Anho) AS FechaRecibo
	FROM	TbVacacionRecibo 
	WHERE	IdVacacion = @IdVacacion

END
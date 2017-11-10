-- EXEC SpImpresionReciboVacacion 2017, 9, 'GLA0200006'
CREATE PROC [dbo].[SpImpresionReciboVacacion]
@IdVacacion AS INT
AS
BEGIN

	DECLARE @Anho AS INT
	DECLARE @MES AS INT

	DECLARE @AnhoCadena AS VARCHAR(4) 
	SET @AnhoCadena = CONVERT(VARCHAR(4),@Anho)

	DECLARE @DiasMes AS VARCHAR(2) 
	SELECT @DiasMes = CONVERT(VARCHAR(2), DATEDIFF(DAY,
						DATEADD(DAY, 0, DATEADD(m, ((@Anho - 1900) * 12) + @Mes - 1, 0)),
						DATEADD(DAY, 0, DATEADD(m, ((@Anho - 1900) * 12) + @Mes, 0))
					   ))

	DECLARE @MesNombre AS VARCHAR(10) 
	SELECT	@MesNombre = 
			CASE @Mes
				WHEN 1 THEN 'Enero' 
				WHEN 2 THEN 'Febrero'  
				WHEN 3 THEN 'Marzo' 
				WHEN 4 THEN 'Abril' 
				WHEN 5 THEN 'Mayo'  
				WHEN 6 THEN 'Junio' 
				WHEN 7 THEN 'Julio' 
				WHEN 8 THEN 'Agosto'  
				WHEN 9 THEN 'Septiembre' 
				WHEN 10 THEN 'Octubre' 
				WHEN 11 THEN 'Noviembre'  
				WHEN 12 THEN 'Diciembre' 
				ELSE 'No definido' 
			END

	DECLARE @NombreEmpresa AS VARCHAR(100)
	DECLARE @DistritoEmpresa AS VARCHAR(255)
	SELECT	TOP 1 
			@NombreEmpresa = T0.RazonSocial,
			@DistritoEmpresa = T1.Nombre
	FROM	TbEmpresa T0 
	INNER JOIN TbUbigeo T1 ON T1.Codigo = T0.CodUbigeo
	
	SELECT	TOP 1 
			@NombreEmpresa AS EmpresaNombre,
			T1.Nombres + ' ' + T1.ApellidoPaterno + ' ' + T1.ApellidoMaterno AS EmpleadoNombresApellidos,
			T1.NumeroDocumento AS EmpleadoDNI, 
			T1.NumeroDocumento AS EmpleadoDNI, 
			'Vacaciones correspondiente al ejercicio' + @AnhoCadena AS VacacionDetalle,
			'DEL ' + CONVERT(VARCHAR(10),T0.PeriodoFechaInicial,103) + 
			'AL ' + CONVERT(VARCHAR(10),T0.PeriodoFechaFinal,103) 
			AS VacacionPeriodoRango,
			'DEL ' + CONVERT(VARCHAR(10),T0.FechaInicial,103) + 
			'AL ' + CONVERT(VARCHAR(10),T0.FechaFinal,103)  AS VacacionDescansoRango,
			T0.Sueldo AS VacacionSueldo,
			T0.AsignacionFamiliar AS VacacionAsignacionFamiliar,
			0.0 AS VacacionRedondeo,
			T0.PromedioHorasExtras AS VacacionOtros,
			T0.PromedioBonificacion AS VacacionBonificacion,
			T0.TotalBruto AS VacacionBruto,
			T0.RetencionJudicialMonto AS VacacionAlimentos,
			'AFP - PRIMA' AS VacacionPensionNombre,
			T0.PensionMonto AS VacacionPensionMonto,
			'' AS VacacionPensionMontoLetras,
			T0.TotalNeto AS VacacionNeto,
			@DistritoEmpresa + ', ' + @DiasMes + ' de ' + @MesNombre + ' del ' + @AnhoCadena AS FechaBoleta
	FROM	TbVacacion T0 
	INNER JOIN TbEmpleado T1 ON T1.Codigo = T0.CodigoEmpleado 
	INNER JOIN TbEmpleadoRecurso T2 ON T2.IdEmpleado = T1.IdEmpleado 
	WHERE	T0.IdVacacion = @IdVacacion

END
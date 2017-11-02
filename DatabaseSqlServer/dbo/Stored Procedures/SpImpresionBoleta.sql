-- EXEC SpImpresionBoleta 2017, 9, 'GLA0200006'
CREATE PROC [dbo].[SpImpresionBoleta]
@Anho AS SMALLINT,
@Mes AS TINYINT,
@CodigoEmpleado AS VARCHAR(10)
AS
BEGIN

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
	DECLARE @RucEmpresa AS VARCHAR(15)
	DECLARE @DomicilioEmpresa AS VARCHAR(255)
	DECLARE @DistritoEmpresa AS VARCHAR(255)
	SELECT	TOP 1 
			@NombreEmpresa = T0.RazonSocial, 
			@RucEmpresa = T0.RUC, 
			@DomicilioEmpresa = T0.DomicilioFiscal,
			@DistritoEmpresa = T1.Nombre
	FROM	TbEmpresa T0 
	INNER JOIN TbUbigeo T1 ON T1.Codigo = T0.CodUbigeo

	SELECT	TOP 1 
			@NombreEmpresa AS EmpresaNombre,
			@RucEmpresa AS EmpresaRuc,
			@DomicilioEmpresa AS EmpresaDireccion,
			'MES DE ' + UPPER(@MesNombre) + ' DEL ' + @AnhoCadena AS MesAnho,
			T2.ApellidoPaterno + ' ' + T2.ApellidoMaterno + ', ' + T2.Nombres AS EmpleadoApellidosNombres,
			T2.Nombres + ' ' + T2.ApellidoPaterno + ' ' + T2.ApellidoMaterno AS EmpleadoNombresApellidos,
			CONVERT(DATETIME,T3.FechaInicio) AS EmpleadoFechaIngreso,
			CONVERT(DATETIME,T3.FechaCese) AS EmpleadoFechaCese,
			'' AS EmpleadoAutoGenerado,
			T4.Nombre AS EmpleadoCargo,
			NULL AS EmpleadoFechaVacacionesSalida,
			NULL AS EmpleadoFechaVacacionesRetorno,
			T3.CUSPP AS EmpleadoCUSPP,
			T5.Nombre AS EmpleadoAFP,
			T2.NumeroDocumento AS EmpleadoDNI,
			0 AS DiasLaborados,
			0 AS DiasNoLaborados,	
			0 AS DiasSinGoceHaber,	
			0 AS DiasConGoceHaber,	
			0 AS HorasNormales,
			T1.Base AS Sueldo,	
			T1.AsignacionFamiliar AS AsignacionFamiliar,	
			T1.TotalBonoNocturno AS BonificacionNocturna,
			T1.MovilidadTotal AS MovilidadTranslado,
			0.0 AS SubsidioDescansoMedico,
			T1.TotalBonoHorasExtras AS BonificacionHorasExtras,
			CASE 
				WHEN T1.CalculoPor = 'M' THEN T1.CantidadBonoHorasExtras / 60 
				ELSE 0.0 
			END AS HorasExtras,
			0.0 AS Cts,
			0.0 AS Vacaciones,
			0.0 AS FeriadoDominical,
			0.0 AS Gratificacion,
			0.0 AS BonificacionGratificacion,
			T1.AfpAporteObligatorio AS AfpFondo,
			T1.AfpSeguro AS AfpSeguro,
			T1.AfpComision AS AfpComision,
			0.0 AS IpssVida,
			T1.SnpTotal AS Onp,
			0.0 AS Renta5Categoria,
			T1.TotalInasistencia AS Inasistencias,
			T1.CantidadInasistencia AS InasistenciasDias,
			T1.AdelantoTotal AS Adelanto,
			T1.TotalTardanzaNormalDiurno + 
			T1.TotalTardanzaNormalNocturno + 
			T1.TotalTardanzaFeriadoDiurno + 
			T1.TotalTardanzaFeriadoNocturno AS Tardanza,
			T1.CantidadTardanzaNormalDiurno + 
			T1.CantidadTardanzaNormalNocturno + 
			T1.CantidadTardanzaFeriadoDiurno + 
			T1.CantidadTardanzaFeriadoNocturno AS TardanzaMinutos,
			0.0 AS GratificacionTotal,
			T1.RetencionJudicialTotal AS RetencionJudicial,
			0.0 AS SeguroVida,
			T1.EsSaludTotal AS IpssSalud,
			T1.TotalSueldoBruto AS TotalBruto,
			T1.TotalDescuento AS TotalDescuentos,
			T1.TotaPago AS TotalApagar,
			@DistritoEmpresa + ', ' + @DiasMes + ' de ' + @MesNombre + ' del ' + @AnhoCadena AS FechaBoleta
	FROM	TbPlanilla T0 
	INNER JOIN TbPlanillaDetalle T1 ON T1.IdPlanilla = T0.IdPlanilla 
	INNER JOIN TbEmpleado T2 ON T2.Codigo = T1.CodigoEmpleado 
	INNER JOIN TbEmpleadoRecurso T3 ON T3.IdEmpleado = T2.IdEmpleado 
	INNER JOIN TbCargo T4 ON T4.IdCargo = T3.IdCargo  
	INNER JOIN TbAfp T5 ON T5.IdAfp = T3.IdAfp 
	WHERE	T0.Anho = @Anho 
	AND		T0.Mes = @Mes
	AND		T1.CodigoEmpleado = @CodigoEmpleado

END
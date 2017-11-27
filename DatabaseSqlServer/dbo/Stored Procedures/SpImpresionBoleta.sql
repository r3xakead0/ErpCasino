--EXEC [SpImpresionBoleta] 2017, 10, 'GLA0200006'
CREATE PROCEDURE [dbo].[SpImpresionBoleta]
@Anho AS SMALLINT,
@Mes AS TINYINT,
@CodigoEmpleado AS VARCHAR(10)
AS
BEGIN

	SELECT	TOP 1 
			EmpresaNombre,
			EmpresaRuc,
			EmpresaDistrito,
			EmpresaDireccion,
			UPPER(MesNombre) + ' DEL ' + CONVERT(VARCHAR(4),Anho) AS MesAnho,
			EmpleadoApellidos + ', ' + EmpleadoNombres AS EmpleadoApellidosNombres,
			EmpleadoNombres + ' ' + EmpleadoApellidos AS EmpleadoNombresApellidos,
			CONVERT(DATETIME,EmpleadoFechaIngreso) AS EmpleadoFechaIngreso,
			CONVERT(DATETIME,EmpleadoFechaCese) AS EmpleadoFechaCese,
			EmpleadoEsSaludCodigo AS EmpleadoAutoGenerado,
			EmpleadoCargo AS EmpleadoCargo,
			EmpleadoVacacionSalida AS EmpleadoFechaSalidaVacaciones,
			EmpleadoVacacionRetorno AS EmpleadoFechaRetornoVacaciones,
			EmpleadoSppCodigo AS EmpleadoCUSPP,
			EmpleadoSppEntidad AS EmpleadoAFP,
			EmpleadoNroDocumento AS EmpleadoDNI,
			DiasLaborados AS DiasLaborados,
			DiasNoLaborados AS DiasNoLaborados,
			DiasSinGoceHaber AS DiasSinGoceHaber,
			DiasSubsidiado AS DiasConGoceHaber,
			HorasNormales AS HorasNormales,
			Sueldo AS Sueldo,	
			AsignacionFamiliar AS AsignacionFamiliar,	
			BonificacionNocturna AS BonificacionNocturna,
			MovilidadTranslado AS MovilidadTranslado,
			SubsidioDescansoMedico AS SubsidioDescansoMedico,
			BonificacionHorasExtras AS BonificacionHorasExtras,
			RIGHT('0' + CAST(CantidadHorasExtras/60 AS VARCHAR(10)),2) + 
			':' + 
			LEFT(CAST(CantidadHorasExtras % 60 AS VARCHAR(2)) + '0',2) AS HorasExtras,
			Cts AS Cts,
			Vacaciones AS Vacaciones,
			FeriadoDominical AS FeriadoDominical,
			Gratificacion AS Gratificacion,
			BonificacionGratificacion AS BonificacionGratificacion,
			AfpFondoMonto AS AfpFondo,
			AfpSeguroMonto AS AfpSeguro,
			AfpComisionMonto AS AfpComision,
			IpssVidaMonto AS IpssVida,
			OnpMonto AS Onp,
			RentaQuintaMonto AS Renta5Categoria,
			InasistenciasMonto AS Inasistencias,
			CONVERT(INT,(InasistenciasDias / 60) / 8) AS InasistenciasDias,
			AdelantoMonto AS Adelanto,
			TardanzaMonto AS Tardanza,
			TardanzaMinutos AS TardanzaMinutos,
			GratificacionMonto AS GratificacionTotal,
			RetencionJudicialMonto AS RetencionJudicial,
			SeguroVidaTrabajadorMonto AS SeguroVida,
			IpssSaludTrabajadorMonto AS IpssSalud,
			SeguroVidaEmpleadoMonto AS SeguroVidaEmpleador,
			IpssSaludEmpleadoMonto AS IpssSaludEmpleador,
			TotalBruto AS TotalBruto,
			TotalDescuentos AS TotalDescuentos,
			TotalAportes AS TotalAportes,
			TotalNeto AS TotalApagar,
			EmpresaDistrito + ', ' + CONVERT(VARCHAR(2),MesDias) + ' de ' + MesNombre + ' del ' + CONVERT(VARCHAR(4),Anho) AS FechaBoleta
	FROM	TbPlanillaBoleta WITH(NOLOCK) 
	WHERE	Anho = @Anho
	AND		Mes = @Mes 
	AND		EmpleadoCodigo = @CodigoEmpleado 

END
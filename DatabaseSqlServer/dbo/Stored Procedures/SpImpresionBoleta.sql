-- EXEC SpImpresionBoleta 2017, 10, 'GLA0200006'
CREATE PROC [dbo].[SpImpresionBoleta]
@Anho AS SMALLINT,
@Mes AS TINYINT,
@CodigoEmpleado AS VARCHAR(10)
AS
SELECT	'' AS EmpresaNombre,
		'' AS EmpresaRuc,
		'' AS EmpresaDireccion,
		'' AS MesAnho,
		T2.ApellidoPaterno + ' ' + T2.ApellidoMaterno + ' ' + T2.Nombres AS EmpleadoApellidosNombres,
		T3.FechaInicio AS EmpleadoFechaIngreso,
		T3.FechaCese AS EmpleadoFechaCese,
		'' AS EmpleadoAutoGenerado,
		T4.Nombre AS EmpleadoCargo,
		GETDATE() AS EmpleadoFechaVacacionesSalida,
		GETDATE() AS EmpleadoFechaVacacionesRetorno,
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
		0.0 AS MovilidadTranslado,
		0.0 AS SubsidioDescansoMedico,
		T1.TotalBonoHorasExtras AS BonificacionHorasExtras,
		T1.CantidadBonoHorasExtras AS HorasExtras,
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
		0.0 AS Gratificacion,
		T1.RetencionJudicialTotal AS RetencionJudicial,
		0.0 AS SeguroVida,
		T1.EsSaludTotal AS IpssSalud,
		T1.TotalSueldoBruto AS TotalBruto,
		T1.TotalDescuento AS TotalDescuentos,
		T1.TotaPago AS TotalApagar
FROM	TbPlanilla T0 
INNER JOIN TbPlanillaDetalle T1 ON T1.IdPlanilla = T0.IdPlanilla 
INNER JOIN TbEmpleado T2 ON T2.Codigo = T1.CodigoEmpleado 
INNER JOIN TbEmpleadoRecurso T3 ON T3.IdEmpleado = T2.IdEmpleado 
INNER JOIN TbCargo T4 ON T4.IdCargo = T3.IdCargo  
INNER JOIN TbAfp T5 ON T5.IdAfp = T3.IdAfp 
WHERE	T0.Anho = @Anho 
AND		T0.Mes = @Mes
AND		T1.CodigoEmpleado = @CodigoEmpleado
-- EXEC SpImpresionCTS 2017, 1, 'GLA0200006'
-- EXEC SpImpresionCTS 2017, 2, 'GLA0200006'
-- EXEC SpImpresionCTS 2017, 3, 'GLA0200006'
CREATE PROC [dbo].[SpImpresionCTS]
@Anho AS SMALLINT,
@Periodo AS TINYINT, -- 1 (Mayo) y 2 (noviembre)
@CodigoEmpleado AS VARCHAR(10)
AS
BEGIN
	
	DECLARE @AnhoNombre AS VARCHAR(4) 
	SET @AnhoNombre = CONVERT(VARCHAR(4),@Anho)

	DECLARE @MesNombre AS VARCHAR(10) 
	SELECT	@MesNombre = 
			CASE @Periodo
				WHEN 1 THEN 'Mayo'   
				WHEN 2 THEN 'Noviembre' 
				ELSE 'No definido' 
			END

	DECLARE @CTSPeriodo AS VARCHAR(50) 
	SELECT	@CTSPeriodo = 
			CASE @Periodo
				WHEN 1 THEN 'Del 01 de Noviembre del ' + CONVERT(VARCHAR(4),@Anho - 1) + ' al 30 de Abril del ' + @AnhoNombre 
				WHEN 2 THEN 'Del 01 de Mayo del ' + @AnhoNombre + ' al 30 de Septiembre del ' + @AnhoNombre
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
			'Apellidos Completos, Nombres Completos' AS EmpleadoApellidosNombres,
			'Nombres Completos Apellidos Completos' AS EmpleadoNombresApellidos,
			GETDATE() AS EmpleadoFechaIngreso,
			'12345678' AS EmpleadoDNI,
			@CTSPeriodo AS CTSPeriodo,
			'Banco de Credito' AS CTSBanco,
			'191-43543535-0-71' AS CTSCuenta,
			0.0 AS EmpleadoSueldo,
			0.0 AS EmpleadoAsignacionFamiliar,
			0.0 AS EmpleadoPromedioBonoHE,
			0.0 AS EmpleadoPromedioGratificacion,
			0.0 AS EmpleadoRemuneracionAnual,
			0.0 AS EmpleadoRemuneracionMes,
			0 AS MesesCantidad,
			0.0 AS MesesMonto,
			0 AS DiasCantidad,
			0.0 AS DiasMonto,
			0 AS InteresCantidad,
			0.0 AS InteresMonto,
			0.0 AS Total,
			@DistritoEmpresa + ', 15 de ' + @MesNombre + ' del ' + @AnhoNombre AS FechaCTS
	WHERE	@Periodo IN (1, 2)

END
-- EXEC SpImpresionGratificacion 2017, 2, 'GLA0200006'
CREATE PROC [dbo].[SpImpresionGratificacion]
@Anho AS SMALLINT,
@Periodo AS TINYINT, -- 1 (Julio) y 2 (Diciembre)
@CodigoEmpleado AS VARCHAR(10)
AS
BEGIN
	
	DECLARE @AnhoNombre AS VARCHAR(4) 
	SET @AnhoNombre = CONVERT(VARCHAR(4),@Anho)

	DECLARE @MesNombre AS VARCHAR(10) 
	SELECT	@MesNombre = 
			CASE @Periodo
				WHEN 1 THEN 'Julio'   
				WHEN 2 THEN 'Diciembre' 
				ELSE 'No definido' 
			END

	DECLARE @GratificacionConcepto AS VARCHAR(20) 
	SELECT	@GratificacionConcepto = 
			CASE @Periodo
				WHEN 1 THEN 'FIESTAS PATRIAS'   
				WHEN 2 THEN 'NAVIDAD' 
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
			'GRATIFICACION POR ' + @GratificacionConcepto + ' ' + @AnhoNombre AS GratificacionConcepto,
			154.97 AS GratificacionBruto,
			13.95 AS GratificacionBonificacion,
			0.0 AS GratificacionAdelanto,
			168.92 AS GratificacionNeto,
			dbo.FnCantidadConLetra(168.92) AS GratificacionNetoLetra,
			@DistritoEmpresa + ', 15 de ' + @MesNombre + ' del ' + @AnhoNombre AS FechaGratificacion
	WHERE	@Periodo IN (1, 2)

END
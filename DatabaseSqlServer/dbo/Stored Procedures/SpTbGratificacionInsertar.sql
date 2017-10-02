CREATE PROCEDURE [dbo].[SpTbGratificacionInsertar]
@IdGratificacion AS INT OUTPUT,
@Periodo AS VARCHAR(8),
@FechaInicio AS DATE,
@FechaFinal AS DATE,
@Dias AS INT,
@CodigoEmpleado AS VARCHAR(10),
@BonoNocturnoPromedio AS DECIMAL(9,4),
@BonoHorasExtrasPromedio AS DECIMAL(9,4),
@SueldoBase AS DECIMAL(9,4),
@AsignacionFamiliar AS DECIMAL(9,4),
@DiasLaborados AS INT,
@GratificacionBruta AS DECIMAL(9,4),
@BonoExtraordinario AS DECIMAL(9,4),
@GratificacionNeta AS DECIMAL(9,4),
@DescuentoRetencionJudicial AS DECIMAL(9,4),
@DescuentoImpuesto AS DECIMAL(9,4),
@GratificacionPagar AS DECIMAL(9,4)
AS
BEGIN
	INSERT INTO TbGratificacion (Periodo,FechaInicio,FechaFinal,Dias,CodigoEmpleado,BonoNocturnoPromedio,BonoHorasExtrasPromedio,SueldoBase,AsignacionFamiliar,DiasLaborados,GratificacionBruta,BonoExtraordinario,GratificacionNeta,DescuentoRetencionJudicial,DescuentoImpuesto,GratificacionPagar)
	VALUES (@Periodo,@FechaInicio,@FechaFinal,@Dias,@CodigoEmpleado,@BonoNocturnoPromedio,@BonoHorasExtrasPromedio,@SueldoBase,@AsignacionFamiliar,@DiasLaborados,@GratificacionBruta,@BonoExtraordinario,@GratificacionNeta,@DescuentoRetencionJudicial,@DescuentoImpuesto,@GratificacionPagar)
	SET @IdGratificacion = @@IDENTITY
END
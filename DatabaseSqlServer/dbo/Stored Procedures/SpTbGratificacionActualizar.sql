
CREATE PROCEDURE [dbo].[SpTbGratificacionActualizar]
@IdGratificacion AS INT,
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
UPDATE TbGratificacion
SET Periodo = @Periodo,
FechaInicio = @FechaInicio,
FechaFinal = @FechaFinal,
Dias = @Dias,
CodigoEmpleado = @CodigoEmpleado,
BonoNocturnoPromedio = @BonoNocturnoPromedio,
BonoHorasExtrasPromedio = @BonoHorasExtrasPromedio,
SueldoBase = @SueldoBase,
AsignacionFamiliar = @AsignacionFamiliar,
DiasLaborados = @DiasLaborados,
GratificacionBruta = @GratificacionBruta,
BonoExtraordinario = @BonoExtraordinario,
GratificacionNeta = @GratificacionNeta,
DescuentoRetencionJudicial = @DescuentoRetencionJudicial,
DescuentoImpuesto = @DescuentoImpuesto,
GratificacionPagar = @GratificacionPagar
WHERE IdGratificacion = @IdGratificacion
END
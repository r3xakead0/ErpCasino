CREATE PROC [dbo].[SpTbPlanillaDetalleCostoInsertar]
@IdPlanillaDetalleCosto AS INT OUTPUT,
@IdPlanilla AS INT,
@CodigoEmpleado AS VARCHAR(10),
@Base AS DECIMAL(9,4),
@AsignacionFamiliar AS DECIMAL(9,4),
@Sueldo AS DECIMAL(9,4),
@CostoMinutoNormalDiurno AS DECIMAL(9,4),
@CostoMinutoNormalNocturno AS DECIMAL(9,4),
@CostoMinutoNormalDiurnoExtras1 AS DECIMAL(9,4),
@CostoMinutoNormalNocturnoExtras1 AS DECIMAL(9,4),
@CostoMinutoNormalDiurnoExtras2 AS DECIMAL(9,4),
@CostoMinutoNormalNocturnoExtras2 AS DECIMAL(9,4),
@CostoMinutoFeriadoDiurno AS DECIMAL(9,4),
@CostoMinutoFeriadoNocturno AS DECIMAL(9,4),
@CostoMinutoFeriadoDiurnoExtras1 AS DECIMAL(9,4),
@CostoMinutoFeriadoNocturnoExtras1 AS DECIMAL(9,4),
@CostoMinutoFeriadoDiurnoExtras2 AS DECIMAL(9,4),
@CostoMinutoFeriadoNocturnoExtras2 AS DECIMAL(9,4),
@DescuentoMinutoTardanzaNormalDiurno AS DECIMAL(9,4),
@DescuentoMinutoTardanzaNormalNocturno AS DECIMAL(9,4),
@DescuentoMinutoTardanzaFeriadoDiurno AS DECIMAL(9,4),
@DescuentoMinutoTardanzaFeriadoNocturno AS DECIMAL(9,4),
@DescuentoMinutoDominical AS DECIMAL(9,4),
@DescuentoMinutoInasistencia AS DECIMAL(9,4)
AS
BEGIN
	INSERT INTO TbPlanillaDetalleCosto (IdPlanilla,CodigoEmpleado,Base,AsignacionFamiliar,Sueldo,CostoMinutoNormalDiurno,CostoMinutoNormalNocturno,CostoMinutoNormalDiurnoExtras1,CostoMinutoNormalNocturnoExtras1,CostoMinutoNormalDiurnoExtras2,CostoMinutoNormalNocturnoExtras2,CostoMinutoFeriadoDiurno,CostoMinutoFeriadoNocturno,CostoMinutoFeriadoDiurnoExtras1,CostoMinutoFeriadoNocturnoExtras1,CostoMinutoFeriadoDiurnoExtras2,CostoMinutoFeriadoNocturnoExtras2,DescuentoMinutoTardanzaNormalDiurno,DescuentoMinutoTardanzaNormalNocturno,DescuentoMinutoTardanzaFeriadoDiurno,DescuentoMinutoTardanzaFeriadoNocturno,DescuentoMinutoDominical,DescuentoMinutoInasistencia)
	VALUES (@IdPlanilla,@CodigoEmpleado,@Base,@AsignacionFamiliar,@Sueldo,@CostoMinutoNormalDiurno,@CostoMinutoNormalNocturno,@CostoMinutoNormalDiurnoExtras1,@CostoMinutoNormalNocturnoExtras1,@CostoMinutoNormalDiurnoExtras2,@CostoMinutoNormalNocturnoExtras2,@CostoMinutoFeriadoDiurno,@CostoMinutoFeriadoNocturno,@CostoMinutoFeriadoDiurnoExtras1,@CostoMinutoFeriadoNocturnoExtras1,@CostoMinutoFeriadoDiurnoExtras2,@CostoMinutoFeriadoNocturnoExtras2,@DescuentoMinutoTardanzaNormalDiurno,@DescuentoMinutoTardanzaNormalNocturno,@DescuentoMinutoTardanzaFeriadoDiurno,@DescuentoMinutoTardanzaFeriadoNocturno,@DescuentoMinutoDominical,@DescuentoMinutoInasistencia)
	SET @IdPlanillaDetalleCosto = @@IDENTITY
END
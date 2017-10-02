CREATE PROC [dbo].[SpTbPlanillaDetalleCostoListar]
@IdPlanilla AS INT
AS
BEGIN
	SELECT	T0.IdPlanillaDetalleCosto, 
			T0.IdPlanilla, 
			T0.CodigoEmpleado, 
			T0.Base, 
			T0.AsignacionFamiliar, 
			T0.Sueldo, 
			T0.CostoMinutoNormalDiurno, 
			T0.CostoMinutoNormalDiurnoExtras1, 
			T0.CostoMinutoNormalDiurnoExtras2, 
			T0.CostoMinutoNormalNocturno, 
			T0.CostoMinutoNormalNocturnoExtras1, 
			T0.CostoMinutoNormalNocturnoExtras2, 
			T0.CostoMinutoFeriadoDiurno, 
			T0.CostoMinutoFeriadoDiurnoExtras1, 
			T0.CostoMinutoFeriadoDiurnoExtras2, 
			T0.CostoMinutoFeriadoNocturno, 
			T0.CostoMinutoFeriadoNocturnoExtras1, 
			T0.CostoMinutoFeriadoNocturnoExtras2, 
			T0.DescuentoMinutoTardanzaNormalDiurno, 
			T0.DescuentoMinutoTardanzaNormalDiurno, 
			T0.DescuentoMinutoTardanzaNormalNocturno, 
			T0.DescuentoMinutoTardanzaFeriadoDiurno, 
			T0.DescuentoMinutoTardanzaFeriadoNocturno, 
			T0.DescuentoMinutoInasistencia 
	FROM	TbPlanillaDetalleCosto T0 
	WHERE	T0.IdPlanilla = @IdPlanilla 

END
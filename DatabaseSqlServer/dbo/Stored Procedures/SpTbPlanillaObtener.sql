
CREATE PROC [dbo].[SpTbPlanillaObtener] 
@Anho AS SMALLINT,
@Mes AS TINYINT
AS
BEGIN
	SELECT	TOP 1 
			T0.IdPlanilla,
			T0.Anho,
			T0.Mes,
			T0.DiasMes,
			T0.DiasBase,
			T0.HorasBase,
			T0.SueldoMinimo,
			T0.AsignacionFamiliar,
			T0.PrimerasDosHorasExtras,
			T0.PosteriorDosHorasExtras,
			T0.ONP,
			T0.EsSalud,
			T0.HorasNocturnas,
			T0.Feriado
	FROM	TbPlanilla T0
	WHERE	T0.Anho = @Anho
	AND		T0.Mes = @Mes
END
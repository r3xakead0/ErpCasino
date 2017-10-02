CREATE PROC [dbo].[SpTbPlanillaInsertar] 
@IdPlanilla AS INT OUTPUT,
@Anho AS SMALLINT,
@Mes AS TINYINT,
@DiasMes AS TINYINT,
@DiasBase AS TINYINT,
@HorasBase AS TINYINT,
@SueldoMinimo AS DECIMAL(8, 2),
@AsignacionFamiliar AS DECIMAL(5, 2),
@PrimerasDosHorasExtras AS DECIMAL(5, 2),
@PosteriorDosHorasExtras AS DECIMAL(5, 2),
@ONP AS DECIMAL(5, 2),
@EsSalud AS DECIMAL(5, 2),
@HorasNocturnas AS DECIMAL(5, 2),
@Feriado AS DECIMAL(5, 2)
AS
BEGIN
	INSERT INTO TbPlanilla (Anho,Mes,DiasMes,DiasBase,HorasBase,SueldoMinimo,AsignacionFamiliar,PrimerasDosHorasExtras,PosteriorDosHorasExtras,ONP,EsSalud,HorasNocturnas,Feriado)
	VALUES (@Anho,@Mes,@DiasMes,@DiasBase,@HorasBase,@SueldoMinimo,@AsignacionFamiliar,@PrimerasDosHorasExtras,@PosteriorDosHorasExtras,@ONP,@EsSalud,@HorasNocturnas,@Feriado)
	SET @IdPlanilla = @@IDENTITY
END

CREATE PROC [dbo].[SpTbPlanillaEliminar] 
@Anho AS SMALLINT,
@Mes AS TINYINT
AS
BEGIN
	DELETE FROM	TbPlanilla
	WHERE	Anho = @Anho
	AND		Mes = @Mes
END
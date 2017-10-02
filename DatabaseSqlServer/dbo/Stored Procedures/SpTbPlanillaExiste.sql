
--EXEC SpTbPlanillaExiste 2017, 5
CREATE PROC [dbo].[SpTbPlanillaExiste] 
@Anho AS SMALLINT,
@Mes AS TINYINT
AS
BEGIN
	SELECT	CASE WHEN COUNT(T0.IdPlanilla) > 0 THEN 1 ELSE 0 END Existe
	FROM	TbPlanilla T0
	WHERE	T0.Anho = @Anho
	AND		T0.Mes = @Mes
END
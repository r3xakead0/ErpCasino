
-- exec SpTbHorarioListarSemana 2017, 9, 1
CREATE PROC [dbo].[SpTbHorarioListarColaboradores]
@Anho AS SMALLINT,
@Mes AS TINYINT,
@IdSala AS INT
AS
BEGIN

	SELECT	DISTINCT 
			T0.Codigo
	FROM	TbHorario T0
	WHERE	T0.Anho = @Anho 
	AND		MONTH(T0.Fecha) = @Mes
	AND		T0.IdSala = @IdSala
	ORDER BY T0.Codigo 

END
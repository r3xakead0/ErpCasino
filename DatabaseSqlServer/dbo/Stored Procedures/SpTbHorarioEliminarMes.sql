CREATE PROCEDURE [dbo].[SpTbHorarioEliminarMes]
	@Anho AS SMALLINT,
	@Mes AS TINYINT,
	@IdSala AS INT
AS
BEGIN
	DELETE FROM TbHorario
	WHERE	Anho = @Anho
	AND		MONTH(Fecha) = @Mes
	AND		IdSala = @IdSala
END
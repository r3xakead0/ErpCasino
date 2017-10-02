CREATE PROCEDURE [dbo].[SpTbHorarioEliminarSemana]
	@Anho AS SMALLINT,
	@Semana AS TINYINT,
	@IdSala AS INT
AS
BEGIN
	DELETE FROM TbHorario
	WHERE	Anho = @Anho
	AND		Semana = @Semana
	AND		IdSala = @IdSala
END
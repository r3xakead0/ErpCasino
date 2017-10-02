CREATE PROCEDURE [dbo].[SpTbHorarioEliminar]
	@IdHorario AS INT
AS
BEGIN
	DELETE FROM TbHorario
	WHERE	IdHorario = @IdHorario
END
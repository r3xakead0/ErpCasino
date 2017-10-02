CREATE PROCEDURE [dbo].[SpTbPlantillaHorarioEliminar]
@IdPlantillaHorario AS INT
AS
BEGIN
	DELETE FROM TbPlantillaHorario 
	WHERE IdPlantillaHorario = @IdPlantillaHorario
END
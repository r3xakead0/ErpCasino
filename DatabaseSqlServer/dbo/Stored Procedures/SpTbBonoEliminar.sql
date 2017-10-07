
CREATE PROCEDURE [dbo].[SpTbBonoEliminar]
@IdBono AS INT
AS
BEGIN
	DELETE FROM TbBono
	WHERE	IdBono = @IdBono
	AND		Calculado = 0
END
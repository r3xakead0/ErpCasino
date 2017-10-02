CREATE PROCEDURE [dbo].[SpTbAfpComisionEliminar]
@IdAfpComision AS INT
AS
BEGIN
	DELETE FROM TbAfpComision
	WHERE IdAfpComision = @IdAfpComision
END
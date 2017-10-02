
CREATE PROCEDURE [dbo].[SpTbPostulanteTelefonoEliminar]
@IdPostulanteTelefono AS INT
AS
BEGIN
	DELETE FROM TbPostulanteTelefono
	WHERE IdPostulanteTelefono = @IdPostulanteTelefono
END
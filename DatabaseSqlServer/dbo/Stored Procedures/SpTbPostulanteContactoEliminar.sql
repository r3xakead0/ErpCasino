
CREATE PROCEDURE [dbo].[SpTbPostulanteContactoEliminar]
@IdPostulante AS INT
AS
BEGIN
	DELETE FROM TbPostulanteContacto
	WHERE IdPostulante = @IdPostulante
END
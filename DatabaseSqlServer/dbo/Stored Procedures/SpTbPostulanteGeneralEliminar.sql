
CREATE PROCEDURE [dbo].[SpTbPostulanteGeneralEliminar]
@IdPostulante AS INT
AS
BEGIN
DELETE FROM TbPostulante
WHERE IdPostulante = @IdPostulante
END
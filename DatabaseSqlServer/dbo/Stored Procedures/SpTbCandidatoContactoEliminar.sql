
CREATE PROCEDURE [dbo].[SpTbCandidatoContactoEliminar]
@IdCandidato AS INT
AS
BEGIN
	DELETE FROM TbCandidatoContacto
	WHERE IdCandidato = @IdCandidato
END
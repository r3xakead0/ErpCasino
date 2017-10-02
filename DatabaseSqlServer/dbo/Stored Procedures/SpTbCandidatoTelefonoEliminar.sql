
CREATE PROCEDURE [dbo].[SpTbCandidatoTelefonoEliminar]
@IdCandidatoTelefono AS NCHAR(20)
AS
BEGIN
	DELETE FROM TbCandidatoTelefono
	WHERE IdCandidatoTelefono = @IdCandidatoTelefono
END


CREATE PROCEDURE [dbo].[SpTbCandidatoGeneralEliminar]
@IdCandidato AS INT
AS
BEGIN
	DELETE FROM TbCandidato
	WHERE IdCandidato = @IdCandidato
END
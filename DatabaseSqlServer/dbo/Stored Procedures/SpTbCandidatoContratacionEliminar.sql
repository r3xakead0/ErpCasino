
CREATE PROCEDURE [dbo].[SpTbCandidatoContratacionEliminar]
@IdCandidato AS INT
AS
BEGIN
	DELETE FROM TbCandidatoContratacion
	WHERE IdCandidato = @IdCandidato
END
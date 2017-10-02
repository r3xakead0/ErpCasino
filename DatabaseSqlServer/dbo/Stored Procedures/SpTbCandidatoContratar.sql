
CREATE PROCEDURE [dbo].[SpTbCandidatoContratar]
@IdCandidato AS INT
AS
BEGIN
	UPDATE	TbCandidato
	SET		Contratado = 1
	WHERE	IdCandidato = @IdCandidato
END
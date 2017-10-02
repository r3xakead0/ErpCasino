
CREATE PROCEDURE [dbo].[SpTbCandidatoTelefonoListar]
@IdCandidato AS INT
AS
BEGIN
	SELECT	IdCandidatoTelefono,
			IdCandidato,
			CodTipoTelefono,
			Numero
	FROM	TbCandidatoTelefono 
	WHERE	IdCandidato = @IdCandidato
END
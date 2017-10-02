
CREATE PROCEDURE [dbo].[SpTbCandidatoTelefonoActualizar]
@IdCandidatoTelefono AS NCHAR(20),
@IdCandidato AS INT,
@CodTipoTelefono AS VARCHAR(10),
@Numero AS VARCHAR(20)
AS
BEGIN
	UPDATE	TbCandidatoTelefono
	SET		IdCandidato = @IdCandidato,
			CodTipoTelefono = @CodTipoTelefono,
			Numero = @Numero
	WHERE	IdCandidatoTelefono = @IdCandidatoTelefono
END
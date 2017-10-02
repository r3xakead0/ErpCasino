
CREATE PROCEDURE [dbo].[SpTbPostulanteTelefonoActualizar]
@IdPostulanteTelefono AS NCHAR(20),
@IdPostulante AS INT,
@CodTipoTelefono AS VARCHAR(10),
@Numero AS VARCHAR(20)
AS
BEGIN
	UPDATE	TbPostulanteTelefono
	SET		IdPostulante = @IdPostulante,
			CodTipoTelefono = @CodTipoTelefono,
			Numero = @Numero
	WHERE	IdPostulanteTelefono = @IdPostulanteTelefono
END
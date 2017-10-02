
CREATE PROCEDURE [dbo].[SpTbPostulanteTelefonoListar]
@IdPostulante AS INT
AS
BEGIN
	SELECT	IdPostulanteTelefono,
			IdPostulante,
			CodTipoTelefono,
			Numero
	FROM	TbPostulanteTelefono 
	WHERE	IdPostulante = @IdPostulante
END
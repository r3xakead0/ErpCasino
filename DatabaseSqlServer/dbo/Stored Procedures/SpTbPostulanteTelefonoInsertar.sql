
CREATE PROCEDURE [dbo].[SpTbPostulanteTelefonoInsertar]
@IdPostulanteTelefono AS INT OUTPUT,
@IdPostulante AS INT,
@CodTipoTelefono AS VARCHAR(10),
@Numero AS VARCHAR(20)
AS
BEGIN
	INSERT INTO TbPostulanteTelefono (IdPostulante,CodTipoTelefono,Numero)
	VALUES (@IdPostulante,@CodTipoTelefono,@Numero)
	SET @IdPostulanteTelefono = @@IDENTITY
END
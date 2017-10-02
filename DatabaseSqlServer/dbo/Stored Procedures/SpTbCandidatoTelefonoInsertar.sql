
CREATE PROCEDURE [dbo].[SpTbCandidatoTelefonoInsertar]
@IdCandidatoTelefono AS INT OUTPUT,
@IdCandidato AS INT,
@CodTipoTelefono AS VARCHAR(10),
@Numero AS VARCHAR(20)
AS
BEGIN
	INSERT INTO TbCandidatoTelefono (IdCandidato,CodTipoTelefono,Numero)
	VALUES (@IdCandidato,@CodTipoTelefono,@Numero)
	SET @IdCandidatoTelefono = @@IDENTITY
END

CREATE PROCEDURE [dbo].[SpTbCandidatoContactoActualizar]
@IdCandidato AS INT,
@CodUbigeo AS CHAR(6),
@Zona AS VARCHAR(100),
@Direccion AS VARCHAR(255),
@Referencia AS VARCHAR(255),
@Email AS VARCHAR(50)
AS
BEGIN
	UPDATE	TbCandidatoContacto
	SET		CodUbigeo = @CodUbigeo,
			Zona = @Zona,
			Direccion = @Direccion,
			Referencia = @Referencia,
			Email = @Email
	WHERE	IdCandidato = @IdCandidato
END
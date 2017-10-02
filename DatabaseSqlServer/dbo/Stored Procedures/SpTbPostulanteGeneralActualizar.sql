
CREATE PROCEDURE [dbo].[SpTbPostulanteGeneralActualizar]
@IdPostulante AS INT,
@Nombres AS VARCHAR(50),
@ApellidoPaterno AS VARCHAR(50),
@ApellidoMaterno AS VARCHAR(50),
@FechaNacimiento AS DATE,
@CodSexo AS VARCHAR(10),
@CodDocumentoIdentidad AS VARCHAR(10),
@NumeroDocumento AS VARCHAR(20),
@CodPais AS CHAR(3),
@CodEstadoCivil AS VARCHAR(10),
@Activo AS BIT,
@Candidato AS BIT,
@CodNacimiento AS CHAR(6)
AS
BEGIN
	UPDATE	TbPostulante
	SET		Nombres = @Nombres,
			ApellidoPaterno = @ApellidoPaterno,
			ApellidoMaterno = @ApellidoMaterno,
			FechaNacimiento = @FechaNacimiento,
			CodSexo = @CodSexo,
			CodDocumentoIdentidad = @CodDocumentoIdentidad,
			NumeroDocumento = @NumeroDocumento,
			CodPais = @CodPais,
			CodEstadoCivil = @CodEstadoCivil,
			Activo = @Activo,
			Candidato = @Candidato,
			CodNacimiento = @CodNacimiento
	WHERE	IdPostulante = @IdPostulante
END
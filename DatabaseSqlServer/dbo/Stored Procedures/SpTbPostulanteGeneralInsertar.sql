
CREATE PROCEDURE [dbo].[SpTbPostulanteGeneralInsertar]
@IdPostulante AS INT OUTPUT,
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
	INSERT INTO TbPostulante (Nombres,ApellidoPaterno,ApellidoMaterno,FechaNacimiento,CodSexo,CodDocumentoIdentidad,NumeroDocumento,CodPais,CodNacimiento,CodEstadoCivil,Activo,Candidato)
	VALUES (@Nombres,@ApellidoPaterno,@ApellidoMaterno,@FechaNacimiento,@CodSexo,@CodDocumentoIdentidad,@NumeroDocumento,@CodPais,@CodNacimiento,@CodEstadoCivil,@Activo,@Candidato)
	SET @IdPostulante = @@IDENTITY
END
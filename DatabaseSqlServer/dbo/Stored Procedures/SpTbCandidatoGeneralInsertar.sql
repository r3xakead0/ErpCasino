
CREATE PROCEDURE [dbo].[SpTbCandidatoGeneralInsertar]
@IdCandidato AS INT OUTPUT,
@Codigo AS VARCHAR(10),
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
@Contratado AS BIT,
@CodNacimiento AS CHAR(6)
AS
BEGIN
	INSERT INTO TbCandidato (Codigo,Nombres,ApellidoPaterno,ApellidoMaterno,FechaNacimiento,CodSexo,CodDocumentoIdentidad,NumeroDocumento,CodPais,CodEstadoCivil,Activo,Contratado,CodNacimiento)
	VALUES (@Codigo,@Nombres,@ApellidoPaterno,@ApellidoMaterno,@FechaNacimiento,@CodSexo,@CodDocumentoIdentidad,@NumeroDocumento,@CodPais,@CodEstadoCivil,@Activo,@Contratado,@CodNacimiento)
	SET @IdCandidato = @@IDENTITY
END
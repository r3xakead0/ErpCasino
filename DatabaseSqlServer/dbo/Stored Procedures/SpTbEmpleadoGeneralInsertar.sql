
CREATE PROCEDURE [dbo].[SpTbEmpleadoGeneralInsertar]
@IdEmpleado AS INT OUTPUT,
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
@CodNacimiento AS CHAR(6),
@IdCandidato AS INT
AS
BEGIN
	INSERT INTO TbEmpleado (Codigo,Nombres,ApellidoPaterno,ApellidoMaterno,FechaNacimiento,CodSexo,CodDocumentoIdentidad,NumeroDocumento,CodPais,CodEstadoCivil,Activo,CodNacimiento,IdCandidato)
	VALUES (@Codigo,@Nombres,@ApellidoPaterno,@ApellidoMaterno,@FechaNacimiento,@CodSexo,@CodDocumentoIdentidad,@NumeroDocumento,@CodPais,@CodEstadoCivil,@Activo,@CodNacimiento,@IdCandidato)
	SET @IdEmpleado = @@IDENTITY
END
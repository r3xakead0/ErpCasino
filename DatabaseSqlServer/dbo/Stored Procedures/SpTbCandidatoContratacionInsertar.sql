CREATE PROCEDURE [dbo].[SpTbCandidatoContratacionInsertar]
@IdCandidato AS INT,
@InduccionFechaInicio AS DATE,
@InduccionFechaFin AS DATE = NULL,
@InduccionEstado AS INT,
@InformeDisciplinarioEstado AS INT,
@InformeAdministrativoEstado AS INT,
@DocumentacionEstado AS INT,
@Observacion AS TEXT,
@Sueldo AS DECIMAL(10,2)
AS
BEGIN

	INSERT INTO TbCandidatoContratacion (IdCandidato,InduccionFechaInicio,InduccionFechaFin,InduccionEstado,InformeDisciplinarioEstado,InformeAdministrativoEstado,DocumentacionEstado,Observacion,Sueldo)
	VALUES (@IdCandidato,@InduccionFechaInicio,@InduccionFechaFin,@InduccionEstado,@InformeDisciplinarioEstado,@InformeAdministrativoEstado,@DocumentacionEstado,@Observacion,@Sueldo)

END
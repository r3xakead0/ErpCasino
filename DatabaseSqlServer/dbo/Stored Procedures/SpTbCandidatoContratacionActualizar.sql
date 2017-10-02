
CREATE PROCEDURE [dbo].[SpTbCandidatoContratacionActualizar]
@IdCandidato AS INT,
@InduccionFechaInicio AS DATE,
@InduccionFechaFin AS DATE = NULL,
@InduccionEstado AS INT,
@InformeDisciplinarioEstado AS INT,
@InformeAdministrativoEstado AS INT,
@DocumentacionEstado AS INT,
@Observacion AS TEXT
AS
BEGIN
	UPDATE	TbCandidatoContratacion
	SET		InduccionFechaInicio = @InduccionFechaInicio,
			InduccionFechaFin = @InduccionFechaFin,
			InduccionEstado = @InduccionEstado,
			InformeDisciplinarioEstado = @InformeDisciplinarioEstado,
			InformeAdministrativoEstado = @InformeAdministrativoEstado,
			DocumentacionEstado = @DocumentacionEstado,
			Observacion = @Observacion
	WHERE	IdCandidato = @IdCandidato
END
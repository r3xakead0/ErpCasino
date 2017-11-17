
CREATE PROCEDURE [dbo].[SpTbCandidatoContratacionActualizar]
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
	UPDATE	TbCandidatoContratacion
	SET		InduccionFechaInicio = @InduccionFechaInicio,
			InduccionFechaFin = @InduccionFechaFin,
			InduccionEstado = @InduccionEstado,
			InformeDisciplinarioEstado = @InformeDisciplinarioEstado,
			InformeAdministrativoEstado = @InformeAdministrativoEstado,
			DocumentacionEstado = @DocumentacionEstado,
			Observacion = @Observacion,
			Sueldo = @Sueldo
	WHERE	IdCandidato = @IdCandidato
END
CREATE PROCEDURE [dbo].[SpTbCandidatoContratacionObtener]
@IdCandidato AS INT
AS
BEGIN
	SELECT	TOP 1 
			T0.IdCandidato,
			T0.InduccionFechaInicio,
			T0.InduccionFechaFin,
			T0.InduccionEstado,
			T0.InformeDisciplinarioEstado,
			T0.InformeAdministrativoEstado,
			T0.DocumentacionEstado,
			T0.Observacion,
			T0.Sueldo
	FROM	TbCandidatoContratacion T0
	WHERE	T0.IdCandidato = @IdCandidato
END
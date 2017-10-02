
CREATE PROCEDURE [dbo].[SpTbCandidatoListar]
AS
BEGIN

	SELECT	T0.IdCandidato,
			T0.Codigo,
			T0.Nombres,
			T0.ApellidoPaterno,
			T0.ApellidoMaterno,
			T0.FechaNacimiento,
			T0.CodSexo,
			T0.CodDocumentoIdentidad,
			T0.NumeroDocumento,
			T0.CodPais,
			T0.CodEstadoCivil,
			T0.Activo,
			T0.Contratado,
			T0.CodNacimiento,
			T0.IdPostulante,
			T1.InduccionEstado AS Induccion,
			T1.InformeDisciplinarioEstado AS Disciplina,
			T1.InformeAdministrativoEstado AS Informe,
			T1.DocumentacionEstado AS Documentacion,
			T0.Contratado AS Contratado
	FROM	TbCandidato T0
	INNER JOIN TbCandidatoContratacion T1 ON T1.IdCandidato = T0.IdCandidato

END
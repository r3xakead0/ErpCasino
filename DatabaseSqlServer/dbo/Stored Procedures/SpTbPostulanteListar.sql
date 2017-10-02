
CREATE PROCEDURE [dbo].[SpTbPostulanteListar]
AS
BEGIN
	SELECT	T0.IdPostulante,
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
			T0.Candidato,
			T0.CodNacimiento,
			(SELECT TT1.Nombre FROM TbPostulanteEstado TT1
			WHERE TT1.IdPostulanteEstado = (SELECT MAX(TT0.IdPostulanteEstado) AS IdPostulanteEstado 
			FROM TbPostulanteHistorial TT0 
			WHERE TT0.IdPostulante = T0.IdPostulante)) AS Estado
	FROM	TbPostulante T0
	INNER JOIN TbCategoria T1 ON T1.Codigo = T0.CodSexo AND T1.IdTipo = 1 
	ORDER BY T0.IdPostulante
END
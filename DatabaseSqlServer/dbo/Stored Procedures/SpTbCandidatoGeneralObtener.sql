
CREATE PROCEDURE [dbo].[SpTbCandidatoGeneralObtener]
@IdCandidato AS INT
AS
BEGIN

	SELECT	TOP 1 
			T0.IdCandidato,
			T0.Codigo, 
			T0.Nombres,
			T0.ApellidoPaterno,
			T0.ApellidoMaterno,
			T0.FechaNacimiento,
			T0.CodSexo,
			T2.Nombre AS DscSexo,
			T0.CodDocumentoIdentidad,
			T4.Nombre AS DscDocumentoIdentidad,
			T0.NumeroDocumento,
			T0.CodPais,
			T1.Nombre AS DscPais,
			T0.CodEstadoCivil,
			T3.Nombre AS DscEstadoCivil,
			T0.Activo,
			T0.Contratado, 
			T0.CodNacimiento
	FROM	TbCandidato T0
	INNER JOIN TbPais T1 ON T1.CodPais = T0.CodPais 
	INNER JOIN TbCategoria T2 ON T2.Codigo = T0.CodSexo AND T2.IdTipo = 1 
	INNER JOIN TbCategoria T3 ON T3.Codigo = T0.CodEstadoCivil AND T3.IdTipo = 2 
	INNER JOIN TbCategoria T4 ON T4.Codigo = T0.CodDocumentoIdentidad AND T4.IdTipo = 3
	WHERE	T0.IdCandidato = @IdCandidato

END

CREATE PROCEDURE [dbo].[SpTbCandidatoGeneralObtenerCodigo]
@Codigo AS VARCHAR(10)
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
			T0.CodDocumentoIdentidad,
			T0.NumeroDocumento,
			T0.CodPais,
			T0.CodEstadoCivil,
			T0.Activo,
			T0.Contratado,
			T0.CodNacimiento,
			T0.IdPostulante
	FROM	TbCandidato T0
	WHERE	T0.Codigo = @Codigo

END
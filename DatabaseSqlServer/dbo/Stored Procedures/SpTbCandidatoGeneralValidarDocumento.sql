CREATE PROCEDURE [dbo].[SpTbCandidatoGeneralValidarDocumento]
@IdCandidato AS INT = NULL,
@CodDocumentoIdentidad AS VARCHAR(10),
@NumeroDocumento AS VARCHAR(20)
AS
BEGIN
	SELECT	CONVERT(BIT, CASE WHEN COUNT(T0.IdCandidato) > 0 THEN 1 ELSE 0 END) AS Existe
	FROM	TbCandidato T0
	WHERE	T0.CodDocumentoIdentidad = @CodDocumentoIdentidad
	AND		T0.NumeroDocumento = @NumeroDocumento
	AND		(@IdCandidato IS NULL OR T0.IdCandidato <> @IdCandidato)
END
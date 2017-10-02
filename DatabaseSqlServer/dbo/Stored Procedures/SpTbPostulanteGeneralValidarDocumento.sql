CREATE PROCEDURE [dbo].[SpTbPostulanteGeneralValidarDocumento]
@IdPostulante AS INT = NULL,
@CodDocumentoIdentidad AS VARCHAR(10),
@NumeroDocumento AS VARCHAR(20)
AS
BEGIN
	SELECT	CONVERT(BIT, CASE WHEN COUNT(T0.IdPostulante) > 0 THEN 1 ELSE 0 END) AS Existe
	FROM	TbPostulante T0
	WHERE	T0.CodDocumentoIdentidad = @CodDocumentoIdentidad
	AND		T0.NumeroDocumento = @NumeroDocumento
	AND		(@IdPostulante IS NULL OR T0.IdPostulante <> @IdPostulante)
END
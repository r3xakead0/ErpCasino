CREATE PROCEDURE [dbo].[SpTbCandidatoGeneralValidarCodigo]
@IdCandidato AS INT = NULL,
@Codigo AS VARCHAR(10)
AS

	SELECT	CONVERT(BIT, CASE WHEN COUNT(T0.IdCandidato) > 0 THEN 1 ELSE 0 END) AS Existe
	FROM	TbCandidato T0
	WHERE	T0.Codigo = @Codigo
	AND		(@IdCandidato IS NULL OR T0.IdCandidato <> @IdCandidato)
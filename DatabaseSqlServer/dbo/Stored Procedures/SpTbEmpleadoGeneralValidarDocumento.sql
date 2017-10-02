
CREATE PROCEDURE [dbo].[SpTbEmpleadoGeneralValidarDocumento]
@IdEmpleado AS INT = NULL,
@CodDocumentoIdentidad AS VARCHAR(10),
@NumeroDocumento AS VARCHAR(20)
AS

	SELECT	CONVERT(BIT, CASE WHEN COUNT(T0.IdEmpleado) > 0 THEN 1 ELSE 0 END) AS Existe
	FROM	TbEmpleado T0
	WHERE	T0.CodDocumentoIdentidad = @CodDocumentoIdentidad
	AND		T0.NumeroDocumento = @NumeroDocumento 
	AND		(@IdEmpleado IS NULL OR T0.IdEmpleado <> @IdEmpleado)
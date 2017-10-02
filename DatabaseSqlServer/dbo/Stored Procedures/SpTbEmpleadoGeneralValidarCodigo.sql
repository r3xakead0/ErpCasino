CREATE PROCEDURE [dbo].[SpTbEmpleadoGeneralValidarCodigo]
@IdEmpleado AS INT = NULL,
@Codigo AS VARCHAR(10)
AS

	SELECT	CONVERT(BIT, CASE WHEN COUNT(T0.IdEmpleado) > 0 THEN 1 ELSE 0 END) AS Existe
	FROM	TbEmpleado T0
	WHERE	T0.Codigo = @Codigo
	AND		(@IdEmpleado IS NULL OR T0.IdEmpleado <> @IdEmpleado)
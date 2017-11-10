
--EXEC SpTbEmpleadoRecursoVacacion GLA02000041, '20171010'
CREATE PROCEDURE [dbo].[SpTbEmpleadoRecursoVacacion]
@Codigo AS VARCHAR(10),
@FechaVacacion AS DATE
AS
BEGIN
	DECLARE @IdEmpleado AS INT

	SELECT	TOP 1 
			@IdEmpleado = IdEmpleado
	FROM	TbEmpleado 
	WHERE	Codigo = @Codigo

	IF NOT @IdEmpleado IS NULL
	BEGIN
		UPDATE	TbEmpleadoRecurso
		SET		FechaUltimaVacacion = @FechaVacacion
		WHERE	IdEmpleado = @IdEmpleado
	END
END
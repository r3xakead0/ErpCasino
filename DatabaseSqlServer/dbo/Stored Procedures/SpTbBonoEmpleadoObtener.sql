
CREATE PROCEDURE [dbo].[SpTbBonoEmpleadoObtener]
@IdBonoEmpleado AS INT
AS
BEGIN
	SELECT	TOP 1 
			T0.IdBonoEmpleado,
			T0.Fecha,
			T0.CodigoEmpleado,
			T0.IdBono,
			T0.Motivo,
			T0.Monto
	FROM	TbBonoEmpleado T0
	WHERE	T0.IdBonoEmpleado = @IdBonoEmpleado
END
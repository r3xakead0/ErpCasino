
CREATE PROCEDURE [dbo].[SpTbBonoEmpleadoListar]
@ANHO AS INT,
@MES AS INT,
@CODIGO AS VARCHAR(10) = NULL
AS
BEGIN
	SELECT	T0.IdBonoEmpleado,
			T0.Fecha,
			T0.CodigoEmpleado,
			T0.IdBono,
			T0.Motivo,
			T0.Monto
	FROM	TbBonoEmpleado T0 WITH(NOLOCK)
	WHERE	YEAR(T0.Fecha) = @ANHO 
	AND		MONTH(T0.Fecha) = @MES 
	AND		(@CODIGO IS NULL OR T0.CodigoEmpleado = @CODIGO)
END
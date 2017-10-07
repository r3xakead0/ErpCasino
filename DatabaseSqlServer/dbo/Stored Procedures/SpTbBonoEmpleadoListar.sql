
CREATE PROCEDURE [dbo].[SpTbBonoEmpleadoListar]
@ANHO AS INT,
@MES AS INT
AS
BEGIN
	SELECT	IdBonoEmpleado,
			Fecha,
			CodigoEmpleado,
			IdBono,
			Motivo,
			Monto
	FROM	TbBonoEmpleado 
	WHERE	YEAR(Fecha) = @ANHO 
	AND		MONTH(Fecha) = @MES 
END
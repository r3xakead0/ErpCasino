


CREATE PROCEDURE SpTbDescuentoEmpleadoListar
@ANHO AS INT,
@MES AS INT
AS
BEGIN
	SELECT	IdDescuentoEmpleado,
			Fecha,
			CodigoEmpleado,
			IdDescuento,
			Motivo,
			Monto
	FROM	TbDescuentoEmpleado
	WHERE	YEAR(Fecha) = @ANHO 
	AND		MONTH(Fecha) = @MES
END
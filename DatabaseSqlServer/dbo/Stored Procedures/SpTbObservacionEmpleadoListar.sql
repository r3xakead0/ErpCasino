
CREATE PROCEDURE SpTbObservacionEmpleadoListar
@ANHO AS INT,
@MES AS INT
AS
BEGIN
	SELECT	IdObservacionEmpleado,
			Fecha,
			IdSala,
			CodigoEmpleado,
			IdObservacion,
			Descripcion
	FROM	TbObservacionEmpleado 
	WHERE	YEAR(Fecha) = @ANHO 
	AND		MONTH(Fecha) = @MES
END
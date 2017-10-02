
CREATE PROCEDURE [dbo].[SpTbAdelantoListar]
@ANHO AS INT,
@MES AS INT
AS
BEGIN
	SELECT	IdAdelanto,
			Fecha,
			CodigoEmpleado,
			Tipo,
			IdBanco,
			Numero,
			Monto
	FROM	TbAdelanto
	WHERE	YEAR(Fecha) = @ANHO 
	AND		MONTH(Fecha) = @MES
END
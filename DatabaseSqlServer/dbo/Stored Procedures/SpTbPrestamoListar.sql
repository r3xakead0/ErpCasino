CREATE PROCEDURE [dbo].[SpTbPrestamoListar]
@ANHO AS INT,
@MES AS INT
AS
BEGIN
	SELECT	IdPrestamo,
			Fecha,
			CodigoEmpleado,
			Motivo,
			Monto,
			Cuotas,
			Pagado
	FROM	TbPrestamo WITH(NOLOCK)
	WHERE	YEAR(Fecha) = @ANHO 
	and		MONTH(Fecha) = @MES
	ORDER BY Fecha DESC
END
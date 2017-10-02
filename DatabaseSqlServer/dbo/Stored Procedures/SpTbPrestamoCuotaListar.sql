CREATE PROCEDURE [dbo].[SpTbPrestamoCuotaListar]
@IdPrestamo AS INT
AS
BEGIN
	SELECT	IdPrestamoCuota,
			IdPrestamo,
			Fecha,
			Monto,
			Pagado 
	FROM	TbPrestamoCuota
	WHERE	IdPrestamo = @IdPrestamo
END
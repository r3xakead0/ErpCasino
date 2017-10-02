CREATE PROCEDURE [dbo].[SpTbPrestamoCuotaInsertar]
@IdPrestamoCuota AS INT OUTPUT,
@IdPrestamo AS INT,
@Fecha AS DATE,
@Monto AS DECIMAL(9,2),
@Pagado AS BIT
AS
BEGIN
	INSERT INTO TbPrestamoCuota (IdPrestamo,Fecha,Monto,Pagado)
	VALUES (@IdPrestamo,@Fecha,@Monto,@Pagado)
	SET @IdPrestamoCuota = @@IDENTITY
END
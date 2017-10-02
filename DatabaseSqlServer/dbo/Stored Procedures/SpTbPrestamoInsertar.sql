CREATE PROCEDURE [dbo].[SpTbPrestamoInsertar]
@IdPrestamo AS INT OUTPUT,
@Fecha AS DATE,
@CodigoEmpleado AS VARCHAR(10),
@Motivo AS VARCHAR(255),
@Monto AS DECIMAL(9,2),
@Cuotas AS INT,
@Pagado AS BIT
AS
BEGIN
	INSERT INTO TbPrestamo (Fecha,CodigoEmpleado,Motivo,Monto,Cuotas,Pagado)
	VALUES (@Fecha,@CodigoEmpleado,@Motivo,@Monto,@Cuotas,@Pagado)
	SET @IdPrestamo = @@IDENTITY
END
CREATE PROCEDURE [dbo].[SpTbReciboInsertar]
@IdRecibo AS INT OUTPUT,
@Anho AS SMALLINT,
@Mes AS TINYINT,
@CodigoEmpleado AS VARCHAR(10),
@Tipo AS VARCHAR(10),
@Concepto AS VARCHAR(50),
@Fecha AS DATE,
@Monto AS DECIMAL(9,2)
AS
BEGIN
	INSERT INTO TbRecibo (Anho,Mes,CodigoEmpleado,Tipo,Concepto,Fecha,Monto)
	VALUES (@Anho,@Mes,@CodigoEmpleado,@Tipo,@Concepto,@Fecha,@Monto)
	SET @IdRecibo = @@IDENTITY
END
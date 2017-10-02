CREATE PROC [dbo].[SpTbPlanillaDetalleResumenInsertar]
@IdPlanillaDetalleResumen AS INT OUTPUT,
@IdPlanilla AS INT,
@CodigoEmpleado AS VARCHAR(10),
@SueldoBase AS DECIMAL(9,4),
@SueldoBruto AS DECIMAL(9,4),
@Pension AS DECIMAL(9,4),
@Impuesto AS DECIMAL(9,4),
@SueldoNeto AS DECIMAL(9,4),
@Deduccion AS DECIMAL(9,4),
@SueldoPago AS DECIMAL(9,4)
AS
BEGIN
	INSERT INTO TbPlanillaDetalleResumen (IdPlanilla,CodigoEmpleado,SueldoBase,SueldoBruto,Pension,Impuesto,SueldoNeto,Deduccion,SueldoPago)
	VALUES (@IdPlanilla,@CodigoEmpleado,@SueldoBase,@SueldoBruto,@Pension,@Impuesto,@SueldoNeto,@Deduccion,@SueldoPago)
	SET @IdPlanillaDetalleResumen = @@IDENTITY
END
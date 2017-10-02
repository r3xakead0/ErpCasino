
CREATE PROCEDURE SpTbSueldoMinimoActualizar
	@IdSueldoMinimo AS INT,
	@FechaInicio AS DATE,
	@Monto AS DECIMAL(10,2),
	@Activo AS BIT
AS
BEGIN
	UPDATE TbSueldoMinimo
	SET FechaInicio = @FechaInicio,
	Monto = @Monto,
	Activo = @Activo
	WHERE IdSueldoMinimo = @IdSueldoMinimo
END
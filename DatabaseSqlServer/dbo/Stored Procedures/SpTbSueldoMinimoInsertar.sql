
CREATE PROCEDURE SpTbSueldoMinimoInsertar
	@IdSueldoMinimo AS INT OUTPUT,
	@FechaInicio AS DATE,
	@Monto AS DECIMAL(10,2),
	@Activo AS BIT
AS
BEGIN
	INSERT INTO TbSueldoMinimo (FechaInicio,Monto,Activo)
	VALUES (@FechaInicio,@Monto,@Activo)
	SET @IdSueldoMinimo = @@IDENTITY
END
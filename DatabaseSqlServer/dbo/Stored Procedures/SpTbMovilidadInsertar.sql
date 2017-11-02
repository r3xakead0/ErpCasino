CREATE PROCEDURE SpTbMovilidadInsertar
@IdMovilidad AS INT OUTPUT,
@Anho AS SMALLINT,
@Mes AS TINYINT,
@CodigoEmpleado AS VARCHAR(10),
@Monto AS DECIMAL(9,2),
@IdUsuarioCreador AS INT,
@FechaCreacion AS DATETIME
AS
BEGIN
	INSERT INTO TbMovilidad (Anho,Mes,CodigoEmpleado,Monto,IdUsuarioCreador,FechaCreacion)
	VALUES (@Anho,@Mes,@CodigoEmpleado,@Monto,@IdUsuarioCreador,@FechaCreacion)
	SET @IdMovilidad = @@IDENTITY
END
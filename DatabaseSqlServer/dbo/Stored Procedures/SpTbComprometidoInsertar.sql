CREATE PROCEDURE SpTbComprometidoInsertar
@IdComprometido AS INT OUTPUT,
@Anho AS SMALLINT,
@Mes AS TINYINT,
@IdSala AS INT,
@CodigoEmpleado AS VARCHAR(10),
@Comprometido AS BIT
AS
BEGIN
	INSERT INTO TbComprometido (Anho,Mes,IdSala,CodigoEmpleado,Comprometido)
	VALUES (@Anho,@Mes,@IdSala,@CodigoEmpleado,@Comprometido)
	SET @IdComprometido = @@IDENTITY
END
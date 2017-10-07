CREATE PROCEDURE SpTbComprometidoActualizar
@IdComprometido AS INT,
@Anho AS SMALLINT,
@Mes AS TINYINT,
@IdSala AS INT,
@CodigoEmpleado AS VARCHAR(10),
@Comprometido AS BIT
AS
BEGIN
	UPDATE	TbComprometido
	SET		Anho = @Anho,
			Mes = @Mes,
			IdSala = @IdSala,
			CodigoEmpleado = @CodigoEmpleado,
			Comprometido = @Comprometido
	WHERE	IdComprometido = @IdComprometido
END
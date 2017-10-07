CREATE PROCEDURE SpTbComprometidoEliminar
@IdComprometido AS INT
AS
BEGIN
	DELETE FROM TbComprometido
	WHERE IdComprometido = @IdComprometido
END
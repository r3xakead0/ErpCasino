CREATE PROCEDURE SpTbComprometidoObtener
@IdComprometido AS INT
AS
BEGIN
	SELECT	TOP 1 
			T0.IdComprometido,
			T0.Anho,
			T0.Mes,
			T0.IdSala,
			T0.CodigoEmpleado,
			T0.Comprometido
	FROM	TbComprometido T0 
	WHERE	T0.IdComprometido = @IdComprometido
END
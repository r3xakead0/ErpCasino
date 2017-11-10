CREATE PROCEDURE SpTbVacacionDetalleListar
@IdVacacion AS INT
AS
BEGIN
	SELECT	IdVacacionDetalle,
			IdVacacion,
			Numero,
			Anho,
			Mes,
			HorasExtrasMonto,
			BonificacionMonto
	FROM	TbVacacionDetalle
	WHERE	IdVacacion = @IdVacacion
END
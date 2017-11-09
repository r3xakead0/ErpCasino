
CREATE PROCEDURE SpTbVacacionDetalleListar
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
END
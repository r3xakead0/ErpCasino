
CREATE PROCEDURE SpTbSueldoMinimoListar
AS
BEGIN
	SELECT IdSueldoMinimo,
	FechaInicio,
	Monto,
	Activo
	FROM TbSueldoMinimo
	ORDER BY FechaInicio
END
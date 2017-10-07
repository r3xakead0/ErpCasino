CREATE PROCEDURE SpTbMetaSalaListar
AS
BEGIN
	SELECT	IdMetaSala,
			IdSala,
			Anho,
			Mes,
			CantidadPersonal,
			MontoPersonal,
			MontoGrupal,
			Cumplido
	FROM	TbMetaSala WITH(NOLOCK) 
	ORDER BY Anho,
			Mes,
			IdSala
END
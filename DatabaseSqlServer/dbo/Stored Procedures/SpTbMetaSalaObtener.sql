CREATE PROCEDURE SpTbMetaSalaObtener
@IdSala AS INT,
@Anho AS SMALLINT,
@Mes AS TINYINT
AS
BEGIN
	SELECT	TOP 1 
			IdMetaSala,
			IdSala,
			Anho,
			Mes,
			CantidadPersonal,
			MontoPersonal,
			MontoGrupal,
			Cumplido
	FROM	TbMetaSala
	WHERE	IdSala  = @IdSala 
	AND		Anho = @Anho 
	AND		Mes = @Mes
END
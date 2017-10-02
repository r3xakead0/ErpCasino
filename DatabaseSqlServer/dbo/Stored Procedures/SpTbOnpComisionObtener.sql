
CREATE PROCEDURE [dbo].[SpTbOnpComisionObtener]
@Anho AS INT,
@Mes AS INT
AS
BEGIN
	SELECT	TOP 1 
			IdOnpComision,
			Anho,
			Mes,
			PorcentajeAporte
	FROM	TbOnpComision WITH(NOLOCK)
	WHERE	Anho = @Anho
	AND		Mes = @Mes
END
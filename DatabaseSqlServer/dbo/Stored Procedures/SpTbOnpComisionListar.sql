
CREATE PROCEDURE [dbo].[SpTbOnpComisionListar]
AS
BEGIN
	SELECT	IdOnpComision,
			Anho,
			Mes,
			PorcentajeAporte
	FROM	TbOnpComision WITH(NOLOCK) 
	ORDER BY Anho, Mes DESC
END
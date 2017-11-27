
CREATE PROCEDURE [dbo].[SpTbOnpComisionObtener2]
@IdOnpComision AS INT
AS
BEGIN
	SELECT	TOP 1 
			IdOnpComision,
			Anho,
			Mes,
			PorcentajeAporte
	FROM	TbOnpComision WITH(NOLOCK)
	WHERE	IdOnpComision = @IdOnpComision
END
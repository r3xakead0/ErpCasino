
CREATE PROCEDURE [dbo].[SpTbBonoObtener]
@IdBono AS INT
AS
BEGIN
	SELECT	TOP 1 
			T0.IdBono,
			T0.Nombre,
			T0.Descripcion,
			T0.Activo,
			T0.Calculado,
			T0.Monto
	FROM	TbBono T0
	WHERE	T0.IdBono = @IdBono
END

CREATE PROCEDURE [dbo].[SpTbBonoListar]
AS
BEGIN
	SELECT	IdBono,
			Nombre,
			Descripcion,
			Activo,
			Calculado,
			Monto
	FROM	TbBono
END
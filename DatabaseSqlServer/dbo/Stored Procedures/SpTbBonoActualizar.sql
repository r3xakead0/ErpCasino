
CREATE PROCEDURE [dbo].[SpTbBonoActualizar]
@IdBono AS INT,
@Nombre AS VARCHAR(50),
@Descripcion AS VARCHAR(255),
@Activo AS BIT,
@Calculado AS BIT,
@Monto AS DECIMAL(9,2)
AS
BEGIN
	UPDATE TbBono
	SET Nombre = @Nombre,
		Descripcion = @Descripcion,
		Activo = @Activo,
		Calculado = @Calculado,
		Monto = @Monto
	WHERE IdBono = @IdBono
END
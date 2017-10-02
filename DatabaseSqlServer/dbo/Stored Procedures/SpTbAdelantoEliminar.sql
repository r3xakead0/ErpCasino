
CREATE PROCEDURE SpTbAdelantoEliminar
@IdAdelanto AS INT
AS
BEGIN
DELETE FROM TbAdelanto
WHERE IdAdelanto = @IdAdelanto
END
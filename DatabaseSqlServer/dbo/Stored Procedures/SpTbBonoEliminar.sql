﻿
CREATE PROCEDURE SpTbBonoEliminar
@IdBono AS INT
AS
BEGIN
DELETE FROM TbBono
WHERE IdBono = @IdBono
END
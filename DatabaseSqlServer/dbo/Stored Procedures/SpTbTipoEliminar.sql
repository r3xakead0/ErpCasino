﻿
CREATE PROCEDURE SpTbTipoEliminar
@IdTipo AS INT
AS
BEGIN
DELETE FROM TbTipo
WHERE IdTipo = @IdTipo
END
﻿
CREATE PROCEDURE SpTbAfpEliminar
@IdAfp AS INT
AS
BEGIN
DELETE FROM TbAfp
WHERE IdAfp = @IdAfp
END
﻿
CREATE PROCEDURE SpTbCargoEliminar
@IdCargo AS INT
AS
BEGIN
	DELETE FROM TbCargo
	WHERE IdCargo = @IdCargo
END
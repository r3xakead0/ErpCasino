﻿
CREATE PROCEDURE SpTbBancoEliminar
@IdBanco AS INT
AS
BEGIN
DELETE FROM TbBanco
WHERE IdBanco = @IdBanco
END
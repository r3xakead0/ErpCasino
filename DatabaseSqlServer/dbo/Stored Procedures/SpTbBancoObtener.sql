
CREATE PROCEDURE SpTbBancoObtener
@IdBanco AS INT
AS
BEGIN
SELECT TOP 1 
IdBanco,
Codigo,
Nombre,
Descripcion,
Activo
FROM TbBanco
WHERE IdBanco = @IdBanco
END
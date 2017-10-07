CREATE PROCEDURE SpTbMetaSalaEliminar
@IdMetaSala AS INT
AS
BEGIN
	DELETE FROM TbMetaSala
	WHERE IdMetaSala = @IdMetaSala
END
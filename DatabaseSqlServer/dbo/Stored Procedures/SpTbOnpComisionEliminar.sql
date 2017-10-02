
CREATE PROCEDURE SpTbOnpComisionEliminar
@IdOnpComision AS INT
AS
BEGIN
DELETE FROM TbOnpComision
WHERE IdOnpComision = @IdOnpComision
END

CREATE PROCEDURE [dbo].[SpTbUsuarioEliminar]
@IdUsuario AS INT
AS
BEGIN

	IF @IdUsuario > 1
	BEGIN
		DELETE FROM TbUsuario
		WHERE IdUsuario = @IdUsuario
	END

END
CREATE PROCEDURE [dbo].[SpTbMetaSalaActualizar]
@IdMetaSala AS INT,
@IdSala AS INT,
@Anho AS SMALLINT,
@Mes AS TINYINT,
@CantidadPersonal AS INT,
@MontoPersonal AS DECIMAL(9,2),
@MontoGrupal AS DECIMAL(9,2),
@Cumplido AS BIT
AS
BEGIN
	UPDATE	TbMetaSala
	SET		IdSala = @IdSala,
			Anho = @Anho,
			Mes = @Mes,
			CantidadPersonal = @CantidadPersonal,
			MontoPersonal = @MontoPersonal,
			MontoGrupal = @MontoGrupal,
			Cumplido = @Cumplido
	WHERE	IdMetaSala = @IdMetaSala
END
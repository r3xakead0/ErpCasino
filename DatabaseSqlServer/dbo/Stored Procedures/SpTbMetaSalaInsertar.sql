CREATE PROCEDURE [dbo].[SpTbMetaSalaInsertar]
@IdMetaSala AS INT OUTPUT,
@IdSala AS INT,
@Anho AS SMALLINT,
@Mes AS TINYINT,
@CantidadPersonal AS INT,
@MontoPersonal AS DECIMAL(9,2),
@MontoGrupal AS DECIMAL(9,2),
@Cumplido AS BIT
AS
BEGIN
	INSERT INTO TbMetaSala (IdSala,Anho,Mes,CantidadPersonal,MontoPersonal,MontoGrupal,Cumplido)
	VALUES (@IdSala,@Anho,@Mes,@CantidadPersonal,@MontoPersonal,@MontoGrupal,@Cumplido)
	SET @IdMetaSala = @@IDENTITY
END
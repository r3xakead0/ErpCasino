CREATE PROCEDURE SpTbVacacionDetalleInsertar
@IdVacacionDetalle AS INT OUTPUT,
@IdVacacion AS INT,
@Numero AS TINYINT,
@Anho AS SMALLINT,
@Mes AS TINYINT,
@HorasExtrasMonto AS DECIMAL(9,2),
@BonificacionMonto AS DECIMAL(9,2)
AS
BEGIN
	INSERT INTO TbVacacionDetalle (IdVacacion,Numero,Anho,Mes,HorasExtrasMonto,BonificacionMonto)
	VALUES (@IdVacacion,@Numero,@Anho,@Mes,@HorasExtrasMonto,@BonificacionMonto)
	SET @IdVacacionDetalle = @@IDENTITY
END
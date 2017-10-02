CREATE PROCEDURE SpTbOnpComisionInsertar
@IdOnpComision AS INT OUTPUT,
@Anho AS INT,
@Mes AS INT,
@PorcentajeAporte AS DECIMAL(10,2)
AS
BEGIN
INSERT INTO TbOnpComision (Anho,Mes,PorcentajeAporte)
VALUES (@Anho,@Mes,@PorcentajeAporte)
SET @IdOnpComision = @@IDENTITY
END
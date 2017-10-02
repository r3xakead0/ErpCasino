
CREATE PROCEDURE SpTbAdelantoInsertar
@IdAdelanto AS INT OUTPUT,
@Fecha AS DATE,
@CodigoEmpleado AS VARCHAR(10),
@Tipo AS VARCHAR(10),
@IdBanco AS INT,
@Numero AS VARCHAR(20),
@Monto AS DECIMAL(9,2)
AS
BEGIN
INSERT INTO TbAdelanto (Fecha,CodigoEmpleado,Tipo,IdBanco,Numero,Monto)
VALUES (@Fecha,@CodigoEmpleado,@Tipo,@IdBanco,@Numero,@Monto)
SET @IdAdelanto = @@IDENTITY
END
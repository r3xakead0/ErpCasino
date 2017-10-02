
CREATE PROCEDURE SpTbCtsInsertar
@IdCts AS INT OUTPUT,
@CodigoEmpleado AS VARCHAR(10),
@Monto AS DECIMAL(9,4),
@FechaPeriodoInicial AS DATE,
@FechaPeriodoFinal AS DATE,
@FechaDeposito AS DATE
AS
BEGIN
INSERT INTO TbCts (CodigoEmpleado,Monto,FechaPeriodoInicial,FechaPeriodoFinal,FechaDeposito)
VALUES (@CodigoEmpleado,@Monto,@FechaPeriodoInicial,@FechaPeriodoFinal,@FechaDeposito)
SET @IdCts = @@IDENTITY
END
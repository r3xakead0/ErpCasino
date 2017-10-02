
CREATE PROCEDURE SpTbCtsActualizar
@IdCts AS INT,
@CodigoEmpleado AS VARCHAR(10),
@Monto AS DECIMAL(9,4),
@FechaPeriodoInicial AS DATE,
@FechaPeriodoFinal AS DATE,
@FechaDeposito AS DATE
AS
BEGIN
UPDATE TbCts
SET CodigoEmpleado = @CodigoEmpleado,
Monto = @Monto,
FechaPeriodoInicial = @FechaPeriodoInicial,
FechaPeriodoFinal = @FechaPeriodoFinal,
FechaDeposito = @FechaDeposito
WHERE IdCts = @IdCts
END
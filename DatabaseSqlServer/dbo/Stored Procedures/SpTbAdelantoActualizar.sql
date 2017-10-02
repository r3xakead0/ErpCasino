
CREATE PROCEDURE SpTbAdelantoActualizar
@IdAdelanto AS INT,
@Fecha AS DATE,
@CodigoEmpleado AS VARCHAR(10),
@Tipo AS VARCHAR(10),
@IdBanco AS INT,
@Numero AS VARCHAR(20),
@Monto AS DECIMAL(9,2)
AS
BEGIN
UPDATE	TbAdelanto
SET		Fecha = @Fecha,
		CodigoEmpleado = @CodigoEmpleado,
		Tipo = @Tipo,
		IdBanco = @IdBanco,
		Numero = @Numero,
		Monto = @Monto
WHERE	IdAdelanto = @IdAdelanto
END
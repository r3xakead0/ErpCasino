CREATE PROCEDURE SpTbCtsInsertar
@IdCts AS INT OUTPUT,
@Anho AS SMALLINT,
@Periodo AS TINYINT,
@PeriodoFechaInicial AS DATE,
@PeriodoFechaFinal AS DATE,
@EmpleadoCodigo AS VARCHAR(10),
@EmpleadoFechaIngreso AS DATE,
@EmpleadoSueldo AS DECIMAL(9,2),
@EmpleadoAsigFam AS DECIMAL(9,2),
@TotalBonificacion AS DECIMAL(9,2),
@TotalHorasExtras AS DECIMAL(9,2),
@TotalGratificacion AS DECIMAL(9,2),
@PromedioBonificacion AS DECIMAL(9,2),
@PromedioHorasExtras AS DECIMAL(9,2),
@PromedioGratificacion AS DECIMAL(9,2),
@ComputableTotal AS DECIMAL(9,2),
@ComputableFechaInicial AS DATE,
@ComputableFechaFinal AS DATE,
@ComputableMeses AS TINYINT,
@ComputableDias AS TINYINT,
@ComputablePagar AS DECIMAL(9,2),
@BancoId AS INT,
@BancoCuenta AS VARCHAR(50),
@DepositoFecha AS DATE,
@DepositoMonto AS DECIMAL(9,2),
@DepositoOperacion AS VARCHAR(50)
AS
BEGIN
	INSERT INTO TbCts (Anho,Periodo,PeriodoFechaInicial,PeriodoFechaFinal,EmpleadoCodigo,EmpleadoFechaIngreso,EmpleadoSueldo,EmpleadoAsigFam,TotalBonificacion,TotalHorasExtras,TotalGratificacion,PromedioBonificacion,PromedioHorasExtras,PromedioGratificacion,ComputableTotal,ComputableFechaInicial,ComputableFechaFinal,ComputableMeses,ComputableDias,ComputablePagar,BancoId,BancoCuenta,DepositoFecha,DepositoMonto,DepositoOperacion)
	VALUES (@Anho,@Periodo,@PeriodoFechaInicial,@PeriodoFechaFinal,@EmpleadoCodigo,@EmpleadoFechaIngreso,@EmpleadoSueldo,@EmpleadoAsigFam,@TotalBonificacion,@TotalHorasExtras,@TotalGratificacion,@PromedioBonificacion,@PromedioHorasExtras,@PromedioGratificacion,@ComputableTotal,@ComputableFechaInicial,@ComputableFechaFinal,@ComputableMeses,@ComputableDias,@ComputablePagar,@BancoId,@BancoCuenta,@DepositoFecha,@DepositoMonto,@DepositoOperacion)
	SET @IdCts = @@IDENTITY
END
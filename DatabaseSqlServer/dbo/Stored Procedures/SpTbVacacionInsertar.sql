CREATE PROCEDURE [dbo].[SpTbVacacionInsertar]
@IdVacacion AS INT OUTPUT,
@PeriodoFechaInicial AS DATE,
@PeriodoFechaFinal AS DATE,
@FechaInicial AS DATE,
@FechaFinal AS DATE,
@Dias AS TINYINT,
@CodigoEmpleado AS VARCHAR(10),
@Sueldo AS DECIMAL(9,2),
@AsignacionFamiliar AS DECIMAL(9,2),
@PromedioHorasExtras AS DECIMAL(9,2),
@PromedioBonificacion AS DECIMAL(9,2),
@Redondeo AS DECIMAL(9,2),
@TotalBruto AS DECIMAL(9,2),
@idAfpComision AS INT,
@ComisionAfp AS VARCHAR(10),
@idOnpComision AS INT,
@PensionMonto AS DECIMAL(9,2),
@RetencionJudicialMonto AS DECIMAL(9,2),
@TotalDescuento AS DECIMAL(9,2),
@TotalNeto AS DECIMAL(9,2)
AS
BEGIN
	INSERT INTO TbVacacion (PeriodoFechaInicial,PeriodoFechaFinal,FechaInicial,FechaFinal,Dias,CodigoEmpleado,Sueldo,AsignacionFamiliar,PromedioHorasExtras,PromedioBonificacion,Redondeo,TotalBruto,idAfpComision,ComisionAfp,idOnpComision,PensionMonto,RetencionJudicialMonto,TotalDescuento,TotalNeto)
	VALUES (@PeriodoFechaInicial,@PeriodoFechaFinal,@FechaInicial,@FechaFinal,@Dias,@CodigoEmpleado,@Sueldo,@AsignacionFamiliar,@PromedioHorasExtras,@PromedioBonificacion,@Redondeo,@TotalBruto,@idAfpComision,@ComisionAfp,@idOnpComision,@PensionMonto,@RetencionJudicialMonto,@TotalDescuento,@TotalNeto)
	SET @IdVacacion = @@IDENTITY
END
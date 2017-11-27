CREATE PROCEDURE [dbo].[SpTbVacacionReciboInsertar]
@IdVacacionRecibo AS INT OUTPUT,
@IdVacacion AS INT,
@Anho AS SMALLINT,
@Mes AS TINYINT,
@MesNombre AS VARCHAR(15),
@EmpresaNombre AS VARCHAR(100),
@EmpresaDistrito AS VARCHAR(150),
@EmpleadoCodigo AS VARCHAR(10),
@EmpleadoNombres AS VARCHAR(100),
@EmpleadoApellidos AS VARCHAR(100),
@EmpleadoNroDocumento AS VARCHAR(20),
@Detalle AS VARCHAR(100),
@PeriodoInicio AS DATE,
@PeriodoFinal AS DATE,
@VacacionInicio AS DATE,
@VacacionFinal AS DATE,
@Sueldo AS DECIMAL(9,2),
@AsignacionFamiliar AS DECIMAL(9,2),
@PromedioHorasExtras AS DECIMAL(9,2),
@PromedioBonificacion AS DECIMAL(9,2),
@Redondeo AS DECIMAL(9,2),
@TotalBruto AS DECIMAL(9,2),
@RetencionJudicialMonto AS DECIMAL(9,2),
@PensionEntidad AS VARCHAR(50),
@PensionMonto AS DECIMAL(9,2),
@TotalDescuento AS DECIMAL(9,2),
@TotalNeto AS DECIMAL(9,2),
@TotalNetoLiteral AS VARCHAR(255)
AS
BEGIN
INSERT INTO TbVacacionRecibo (IdVacacion,Anho,Mes,MesNombre,EmpresaNombre,EmpresaDistrito,EmpleadoCodigo,EmpleadoNombres,EmpleadoApellidos,EmpleadoNroDocumento,Detalle,PeriodoInicio,PeriodoFinal,VacacionInicio,VacacionFinal,Sueldo,AsignacionFamiliar,PromedioHorasExtras,PromedioBonificacion,Redondeo,TotalBruto,RetencionJudicialMonto,PensionEntidad,PensionMonto,TotalDescuento,TotalNeto,TotalNetoLiteral)
VALUES (@IdVacacion,@Anho,@Mes,@MesNombre,@EmpresaNombre,@EmpresaDistrito,@EmpleadoCodigo,@EmpleadoNombres,@EmpleadoApellidos,@EmpleadoNroDocumento,@Detalle,@PeriodoInicio,@PeriodoFinal,@VacacionInicio,@VacacionFinal,@Sueldo,@AsignacionFamiliar,@PromedioHorasExtras,@PromedioBonificacion,@Redondeo,@TotalBruto,@RetencionJudicialMonto,@PensionEntidad,@PensionMonto,@TotalDescuento,@TotalNeto,@TotalNetoLiteral)
SET @IdVacacionRecibo = @@IDENTITY
END
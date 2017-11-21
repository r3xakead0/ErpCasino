
CREATE PROCEDURE [dbo].[SpTbEmpleadoRecursoInsertar]
@IdEmpleado AS INT,
@IdArea AS INT,
@IdCargo AS INT,
@IdSala AS INT,
@FechaInicio AS DATE,
@FechaCese AS DATE,
@Cesado AS BIT,
@NumeroHijos AS TINYINT,
@IdBanco AS INT,
@CuentaBanco AS VARCHAR(50),
@CCI AS VARCHAR(50),
@ONP AS BIT,
@IdAfp AS INT,
@CUSPP AS VARCHAR(50),
@CodComision AS VARCHAR(10),
@IdBancoCTS AS INT,
@CuentaCTS AS VARCHAR(50),
@Sueldo AS DECIMAL(10,2),
@RetencionJudicialNominal AS DECIMAL(10,2),
@RetencionJudicialPorcentual AS DECIMAL(10,2),
@FechaUltimaVacacion AS DATE,
@Autogenerado AS VARCHAR(50)
AS
BEGIN
	INSERT INTO TbEmpleadoRecurso (IdEmpleado,IdArea,IdCargo,IdSala,FechaInicio,FechaCese,Cesado,NumeroHijos,IdBanco,CuentaBanco,CCI,ONP,IdAfp,CUSPP,CodComision,IdBancoCTS,CuentaCTS,Sueldo,RetencionJudicialNominal,RetencionJudicialPorcentual,FechaUltimaVacacion,Autogenerado)
	VALUES (@IdEmpleado,@IdArea,@IdCargo,@IdSala,@FechaInicio,@FechaCese,@Cesado,@NumeroHijos,@IdBanco,@CuentaBanco,@CCI,@ONP,@IdAfp,@CUSPP,@CodComision,@IdBancoCTS,@CuentaCTS,@Sueldo,@RetencionJudicialNominal,@RetencionJudicialPorcentual,@FechaUltimaVacacion,@Autogenerado)
END
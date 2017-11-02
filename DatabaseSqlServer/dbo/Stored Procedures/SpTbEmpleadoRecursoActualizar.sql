
CREATE PROCEDURE [dbo].[SpTbEmpleadoRecursoActualizar]
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
@FechaUltimaVacacion AS DATE
AS
BEGIN
	UPDATE	TbEmpleadoRecurso
	SET		IdArea = @IdArea,
			IdCargo = @IdCargo,
			IdSala = @IdSala,
			FechaInicio = @FechaInicio,
			FechaCese = @FechaCese,
			Cesado = @Cesado,
			NumeroHijos = @NumeroHijos,
			IdBanco = @IdBanco,
			CuentaBanco = @CuentaBanco,
			CCI = @CCI,
			ONP = @ONP,
			IdAfp = @IdAfp,
			CUSPP = @CUSPP,
			CodComision = @CodComision,
			IdBancoCTS = @IdBancoCTS,
			CuentaCTS = @CuentaCTS,
			Sueldo = @Sueldo,
			RetencionJudicialNominal = @RetencionJudicialNominal,
			RetencionJudicialPorcentual = @RetencionJudicialPorcentual,
			FechaUltimaVacacion = @FechaUltimaVacacion
	WHERE	IdEmpleado = @IdEmpleado
END

CREATE PROCEDURE [dbo].[SpTbEmpleadoRecursoObtener]
@IdEmpleado AS INT
AS
BEGIN
	SELECT	TOP 1
			T0.IdEmpleado,
			T0.IdArea,
			T1.Nombre AS NombreArea,
			T0.IdCargo,
			T2.Nombre AS NombreCargo,
			T0.IdSala,
			T3.Nombre AS NombreSala,
			T0.FechaInicio,
			T0.FechaCese,
			T0.Cesado,
			T0.NumeroHijos,
			T0.IdBanco,
			T3.Nombre AS NombreBanco,
			T0.CuentaBanco,
			T0.CCI,
			T0.ONP,
			T0.IdAfp,
			T4.Nombre AS NombreAfp,
			T0.CUSPP,
			T0.CodComision,
			T0.IdBancoCTS,
			T3.Nombre AS NombreBancoCTS,
			T0.CuentaCTS,
			T0.Sueldo,
			T0.RetencionJudicialNominal,
			T0.RetencionJudicialPorcentual,
			T0.FechaUltimaVacacion,
			T0.Autogenerado 
	FROM	TbEmpleadoRecurso T0
	INNER JOIN TbArea T1 ON T1.IdArea = T0.IdArea 
	INNER JOIN TbCargo T2 ON T2.IdCargo = T0.IdCargo 
	INNER JOIN TbSala T3 ON T3.IdSala = T0.IdSala 
	LEFT JOIN TbBanco T4 ON T4.IdBanco = T0.IdBanco 
	LEFT JOIN TbBanco T5 ON T5.IdBanco = T0.IdBancoCTS  
	LEFT JOIN TbAfp T6 ON T6.IdAfp = T0.IdAfp 
	WHERE	T0.IdEmpleado = @IdEmpleado
END
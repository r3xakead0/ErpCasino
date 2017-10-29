-- EXEC SpReporteCumpleanhos 9, 0
-- EXEC SpReporteCumpleanhos 9, 1
-- EXEC SpReporteCumpleanhos 9, 2
CREATE PROC [dbo].[SpReporteAsistencias]
@Mes AS TINYINT,
@Tipo AS TINYINT
AS
BEGIN

	DECLARE @Cumpleanhos TABLE
	(
		Tipo VARCHAR(20),
		Codigo VARCHAR(10),
		ApellidosNombres VARCHAR(255),
		Dia TINYINT
	)

	IF @Tipo = 0 --TODOS
	BEGIN
		INSERT @Cumpleanhos (Tipo, Codigo, ApellidosNombres, Dia)
		SELECT	'Candidato',
				T0.Codigo,
				T0.ApellidoPaterno + ' ' + T0.ApellidoMaterno + ', ' + T0.Nombres AS ApellidosNombres,
				DAY(T0.FechaNacimiento) AS Dia
		FROM	TbCandidato T0 
		WHERE	MONTH(T0.FechaNacimiento) = @Mes
		UNION ALL 
		SELECT	'Empleado',
				T0.Codigo,
				T0.ApellidoPaterno + ' ' + T0.ApellidoMaterno + ', ' + T0.Nombres AS ApellidosNombres,
				DAY(T0.FechaNacimiento) AS Dia
		FROM	TbEmpleado T0 
		WHERE	MONTH(T0.FechaNacimiento) = @Mes
	END
	ELSE IF @Tipo = 1 --Candidato
	BEGIN
		INSERT @Cumpleanhos (Tipo, Codigo, ApellidosNombres, Dia)
		SELECT	'Candidato',
				T0.Codigo,
				T0.ApellidoPaterno + ' ' + T0.ApellidoMaterno + ', ' + T0.Nombres AS ApellidosNombres,
				DAY(T0.FechaNacimiento) AS Dia
		FROM	TbCandidato T0 
		WHERE	MONTH(T0.FechaNacimiento) = @Mes
	END
	ELSE IF @Tipo = 2 --EMPLEADOS
	BEGIN
		INSERT @Cumpleanhos (Tipo, Codigo, ApellidosNombres, Dia)
		SELECT	'Empleado',
				T0.Codigo,
				T0.ApellidoPaterno + ' ' + T0.ApellidoMaterno + ', ' + T0.Nombres AS ApellidosNombres,
				DAY(T0.FechaNacimiento) AS Dia
		FROM	TbEmpleado T0 
		WHERE	MONTH(T0.FechaNacimiento) = @Mes
	END

	SELECT	* 
	FROM	@Cumpleanhos
	ORDER BY Dia, Tipo, ApellidosNombres

END
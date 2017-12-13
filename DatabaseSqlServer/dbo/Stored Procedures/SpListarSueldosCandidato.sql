CREATE PROC [dbo].[SpListarSueldosCandidato]
AS
BEGIN

	SELECT	T0.Codigo,
			T0.ApellidoPaterno, 
			T0.ApellidoMaterno,
			T0.Nombres,
			T1.Sueldo
	FROM	TbCandidato T0 
	INNER JOIN TbCandidatoContratacion T1 ON T1.IdCandidato = T0.IdCandidato
	WHERE	T0.Activo = 1
	AND		T0.Contratado = 0
	ORDER BY T0.Codigo

END

CREATE PROCEDURE [dbo].[SpTbCandidatoComboNombres]
AS
BEGIN
	SELECT	T0.Codigo,
			T0.ApellidoPaterno + ' ' + T0.ApellidoMaterno + ', ' + T0.Nombres AS Candidato 
	FROM	TbCandidato T0
	WHERE	T0.Contratado = 0 
	AND		T0.Activo = 1
END
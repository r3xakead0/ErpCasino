
CREATE PROCEDURE [dbo].[SpTbCandidatoListaSimple]
AS
BEGIN

	SELECT	T0.Codigo,
			T0.Nombres,
			T0.ApellidoPaterno,
			T0.ApellidoMaterno,
			T0.Activo
	FROM	TbCandidato T0 WITH(NOLOCK)
	WHERE	T0.Contratado = 0

END
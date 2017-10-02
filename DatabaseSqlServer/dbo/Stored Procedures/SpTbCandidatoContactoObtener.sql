
CREATE PROCEDURE [dbo].[SpTbCandidatoContactoObtener]
@IdCandidato AS INT
AS
BEGIN
	SELECT	TOP 1 
			T0.IdCandidato,
			T0.CodUbigeo,
			T0.Zona,
			T0.Direccion,
			T0.Referencia,
			T0.Email
	FROM	TbCandidatoContacto T0
	WHERE	T0.IdCandidato = @IdCandidato
END
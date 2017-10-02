
CREATE PROCEDURE [dbo].[SpTbPostulanteContactoObtener]
@IdPostulante AS INT
AS
BEGIN
	SELECT	TOP 1 
			T0.IdPostulante,
			T0.CodUbigeo,
			T0.Zona,
			T0.Direccion,
			T0.Referencia,
			T0.Email
	FROM	TbPostulanteContacto T0
	WHERE	T0.IdPostulante = @IdPostulante
END
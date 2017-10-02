

CREATE PROCEDURE [dbo].[SpTbPostulanteEstadoObtener]
@IdPostulanteEstado AS INT
AS
BEGIN

	SELECT	TOP 1 
			T0.IdPostulanteEstado,
			T0.Nivel,
			T0.Nombre,
			T0.Descripcion,
			T0.Dependencia,
			T0.Activo
	FROM	TbPostulanteEstado T0
	WHERE	T0.IdPostulanteEstado = @IdPostulanteEstado

END
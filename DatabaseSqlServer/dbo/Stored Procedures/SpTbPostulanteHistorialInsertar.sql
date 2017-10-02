
CREATE PROCEDURE [dbo].[SpTbPostulanteHistorialInsertar]
@IdPostulante AS INT,
@IdPostulanteEstado AS INT,
@Acepto AS BIT,
@Nota AS VARCHAR(255)
AS
BEGIN
	INSERT INTO TbPostulanteHistorial (IdPostulante,IdPostulanteEstado,Acepto,Nota)
	VALUES (@IdPostulante,@IdPostulanteEstado,@Acepto,@Nota)
END
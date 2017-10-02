CREATE PROCEDURE [dbo].[SpTbObservacionEmpleadoInsertar]
@IdObservacionEmpleado AS INT OUTPUT,
@Fecha AS DATE,
@IdSala AS INT,
@CodigoEmpleado AS VARCHAR(10),
@IdObservacion AS INT,
@Descripcion AS VARCHAR(255)
AS
BEGIN
INSERT INTO TbObservacionEmpleado (Fecha,IdSala,CodigoEmpleado,IdObservacion,Descripcion)
VALUES (@Fecha,@IdSala,@CodigoEmpleado,@IdObservacion,@Descripcion)
SET @IdObservacionEmpleado = @@IDENTITY
END
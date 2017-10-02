CREATE FUNCTION [dbo].[FnObtenerNombreCompleto](
@codigo varchar(10)
)
RETURNS varchar(150)
WITH RETURNS NULL ON NULL INPUT
AS
BEGIN
RETURN (
SELECT	TOP 1 
		T0.ApellidoPaterno + ' ' + T0.ApellidoMaterno + ', ' + T0.Nombres 
FROM	TbEmpleado T0 
WHERE	T0.Codigo = @codigo
UNION ALL
SELECT	TOP 1 
		T0.ApellidoPaterno + ' ' + T0.ApellidoMaterno + ', ' + T0.Nombres 
FROM	TbCandidato T0 
WHERE	T0.Contratado = 0
AND		T0.Codigo = @codigo
);
END;
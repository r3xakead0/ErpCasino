CREATE FUNCTION dbo.FnCalcularEdad(
@dt1 date,
@dt2 date
)
RETURNS smallint
WITH RETURNS NULL ON NULL INPUT
AS
BEGIN
RETURN (
SELECT
	DATEDIFF([year], @dt1, @dt2) - 
	CASE 
	WHEN (MONTH(@dt2) * 100) + DAY(@dt2) < (MONTH(@dt1) * 100) + DAY(@dt1) THEN 1
	ELSE 0
	END
);
END;
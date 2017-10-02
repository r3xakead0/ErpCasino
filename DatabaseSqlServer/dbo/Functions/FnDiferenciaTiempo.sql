CREATE FUNCTION [dbo].[FnDiferenciaTiempo](
@StartDate datetime,
@EndDate datetime
)
RETURNS VARCHAR(9)
WITH RETURNS NULL ON NULL INPUT
AS
BEGIN
DECLARE @TimeInSecond AS INT
DECLARE @Negative AS BIT
SELECT @TimeInSecond = DATEDIFF(SECOND, @StartDate, @EndDate)
IF @TimeInSecond < 0
BEGIN
	SET @Negative = 1
	SET @TimeInSecond = -1 * @TimeInSecond
END
RETURN (
SELECT	CASE WHEN @Negative = 1 THEN '-' ELSE '+' END + 
		RIGHT('0' + CAST(@TimeInSecond / 3600 AS VARCHAR),2) + ':' +
		RIGHT('0' + CAST((@TimeInSecond / 60) % 60 AS VARCHAR),2) + ':' +
		RIGHT('0' + CAST(@TimeInSecond % 60 AS VARCHAR),2)	
);
END;
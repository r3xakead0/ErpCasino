CREATE FUNCTION IsOverlapDates 
(
    @startDate1 as datetime,
    @endDate1 as datetime,
    @startDate2 as datetime,
    @endDate2 as datetime
)
RETURNS int
AS
BEGIN
DECLARE @Overlap as int
SET @Overlap = (SELECT CASE WHEN  (
        (@startDate1 BETWEEN @startDate2 AND @endDate2) -- caters for inner and end date outer
        OR
        (@endDate1 BETWEEN @startDate2 AND @endDate2) -- caters for inner and start date outer
        OR
        (@startDate2 BETWEEN @startDate1 AND @endDate1) -- only one needed for outer range where dates are inside.
        ) THEN 1 ELSE 0 END
    )
    RETURN @Overlap

END
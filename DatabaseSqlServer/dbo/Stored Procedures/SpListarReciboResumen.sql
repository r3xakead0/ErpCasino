--exec SpListarReciboResumen 2017, 10
CREATE PROC [dbo].[SpListarReciboResumen] 
@Anho AS SMALLINT,
@Mes AS TINYINT
AS
DECLARE @Resumen TABLE
(
  CodigoEmpleado varchar(10), 
  Bono decimal(9,2),
  Descuento decimal(9,2)
)

INSERT INTO @Resumen (CodigoEmpleado, Bono, Descuento)
select	T0.CodigoEmpleado, 
		T0.Monto as Bono,
		0.0 as Descuento
from	TbBonoEmpleado T0 
where	YEAR(T0.Fecha) = @Anho 
and		MONTH(T0.Fecha) = @Mes 

INSERT INTO @Resumen (CodigoEmpleado, Bono, Descuento)
select	T0.CodigoEmpleado, 
		0.0 as Bono,
		T0.Monto as Descuento
from	TbDescuentoEmpleado T0
where	YEAR(T0.Fecha) = @Anho 
and		MONTH(T0.Fecha) = @Mes 

select	@Anho as Anho,
		@Mes as Mes,
		TT.CodigoEmpleado, 
		SUM(TT.Bono) as TotalBonos,
		SUM(TT.Descuento) as TotalDescuentos 
from	@Resumen TT
group by TT.CodigoEmpleado
order by TT.CodigoEmpleado
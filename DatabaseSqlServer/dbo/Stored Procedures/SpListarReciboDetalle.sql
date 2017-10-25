--exec SpListarReciboDetalle 2017, 10
CREATE PROC SpListarReciboDetalle
@Anho AS INT,
@Mes AS INT,
@CodigoEmpleado AS VARCHAR(10) = NULL
AS
DECLARE @Detalle TABLE
(
  CodigoEmpleado varchar(10), 
  Tipo varchar(10),
  Concepto varchar(50),
  Fecha date,
  Monto decimal(9,2)
)

INSERT INTO @Detalle (CodigoEmpleado, Tipo, Concepto, Fecha, Monto)
select	T0.CodigoEmpleado, 
		'Bono' as Tipo,
		T1.Nombre as Concepto,
		T0.Fecha,
		T0.Monto
from	TbBonoEmpleado T0 
inner join TbBono T1 on T1.IdBono = T0.IdBono
where	YEAR(T0.Fecha) = @Anho 
and		MONTH(T0.Fecha) = @Mes 
and		(@CodigoEmpleado IS NULL OR T0.CodigoEmpleado = @CodigoEmpleado)

INSERT INTO @Detalle (CodigoEmpleado, Tipo, Concepto, Fecha, Monto)
select	T0.CodigoEmpleado, 
		'Descuento' as Tipo,
		T1.Nombre as Concepto,
		T0.Fecha,
		T0.Monto
from	TbDescuentoEmpleado T0 
inner join TbDescuento T1 on T1.IdDescuento = T0.IdDescuento
where	YEAR(T0.Fecha) = @Anho 
and		MONTH(T0.Fecha) = @Mes 
and		(@CodigoEmpleado IS NULL OR T0.CodigoEmpleado = @CodigoEmpleado)

select	@Anho as Anho,
		@Mes as Mes,
		TT.CodigoEmpleado, 
		TT.Tipo, 
		TT.Concepto,
		TT.Fecha, 
		TT.Monto
from	@Detalle TT
order by TT.CodigoEmpleado, TT.Fecha, TT.Tipo, TT.Concepto
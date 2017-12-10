using BE = ErpCasino.BusinessLibrary.BE;
using DA = ErpCasino.BusinessLibrary.DA;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System;

namespace ErpCasino.BusinessLibrary.LN
{

    public class Prestamo
    {

        #region Traductores

        private List<BE.PrestamoCuota> ListPrestamoCuotaUItoBE(List<BE.UI.Cuota> lstUiPrestamoCuota)
        {
            List<BE.PrestamoCuota> lstBePrestamoCuota = new List<BE.PrestamoCuota>();
            foreach (var uiPrestamoCuota in lstUiPrestamoCuota)
            {
                var beCuota = this.PrestamoCuotaUItoBE(uiPrestamoCuota);
                lstBePrestamoCuota.Add(beCuota);
            }
            return lstBePrestamoCuota;
        }

        private List<BE.UI.Cuota> ListPrestamoCuotaBEtoUI(List<BE.PrestamoCuota> lstBePrestamoCuota)
        {
            List<BE.UI.Cuota> lstUiPrestamoCuota = new List<BE.UI.Cuota>();
            int i = 1;
            foreach (var bePrestamoCuota in lstBePrestamoCuota)
            {
                var uiPrestamoCuota = this.PrestamoCuotaBEtoUI(bePrestamoCuota);
                uiPrestamoCuota.Numero = i;
                i++;
                lstUiPrestamoCuota.Add(uiPrestamoCuota);
            }
            return lstUiPrestamoCuota;
        }

        private BE.UI.Cuota PrestamoCuotaBEtoUI(BE.PrestamoCuota bePrestamoCuota)
        {
            var uiPrestamoCuota = new BE.UI.Cuota();
            uiPrestamoCuota.IdCuota = bePrestamoCuota.IdPrestamoCuota;
            uiPrestamoCuota.Fecha = bePrestamoCuota.Fecha;
            uiPrestamoCuota.Importe = bePrestamoCuota.Importe;
            uiPrestamoCuota.Pagado = bePrestamoCuota.Pagado;
            return uiPrestamoCuota;
        }

        private BE.PrestamoCuota PrestamoCuotaUItoBE(BE.UI.Cuota uiPrestamoCuota)
        {
            var bePrestamoCuota = new BE.PrestamoCuota();
            bePrestamoCuota.IdPrestamoCuota = uiPrestamoCuota.IdCuota;
            bePrestamoCuota.Fecha = uiPrestamoCuota.Fecha;
            bePrestamoCuota.Importe = uiPrestamoCuota.Importe;
            bePrestamoCuota.Pagado = uiPrestamoCuota.Pagado;
            return bePrestamoCuota;
        }

        private BE.UI.Prestamo PrestamoBEtoUI(BE.Prestamo bePrestamo)
        {
            var UiPrestamo = new BE.UI.Prestamo();
            UiPrestamo.IdPrestamo = bePrestamo.IdPrestamo;
            UiPrestamo.Fecha = bePrestamo.Fecha;
            UiPrestamo.CodigoEmpleado = bePrestamo.CodigoEmpleado;
            UiPrestamo.Motivo = bePrestamo.Motivo;
            UiPrestamo.Monto = bePrestamo.Monto;
            UiPrestamo.Pagado = bePrestamo.Pagado;
            UiPrestamo.NumeroCuotas = bePrestamo.NumeroCuotas;
            return UiPrestamo;
        }

        private BE.Prestamo PrestamoUItoBE(BE.UI.Prestamo UiPrestamo)
        {
            var bePrestamo = new BE.Prestamo();
            bePrestamo.IdPrestamo = UiPrestamo.IdPrestamo;
            bePrestamo.Fecha = UiPrestamo.Fecha;
            bePrestamo.CodigoEmpleado = UiPrestamo.CodigoEmpleado;
            bePrestamo.Motivo = UiPrestamo.Motivo;
            bePrestamo.Monto = UiPrestamo.Monto;
            bePrestamo.Pagado = UiPrestamo.Pagado;
            bePrestamo.NumeroCuotas = UiPrestamo.NumeroCuotas;
            return bePrestamo;
        }

        #endregion

        public bool Insertar(ref BE.UI.Prestamo uiPrestamo)
        {
            try
            {
                var bePrestamo = this.PrestamoUItoBE(uiPrestamo);
                bePrestamo.Cuotas = this.ListPrestamoCuotaUItoBE(uiPrestamo.Cuotas);

                return new DA.Prestamo().Insertar(ref bePrestamo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Actualizar(BE.UI.Prestamo uiPrestamo,
            List<BE.UI.Cuota> lstUiCuotasNuevas, 
            List<BE.UI.Cuota> lstUiCuotasEliminadas)
        {
            try
            {
                var bePrestamo = this.PrestamoUItoBE(uiPrestamo);
                List<BE.PrestamoCuota> lstBeCuotasNuevas = this.ListPrestamoCuotaUItoBE(lstUiCuotasNuevas);
                List<BE.PrestamoCuota> lstBeCuotasEliminadas = this.ListPrestamoCuotaUItoBE(lstUiCuotasEliminadas);

                return new DA.Prestamo().Actualizar(bePrestamo, lstBeCuotasNuevas, lstBeCuotasEliminadas);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Eliminar(int idPrestamo)
        {
            try
            {
                return new DA.Prestamo().Eliminar(idPrestamo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.UI.Cuota> ListarCuotas(int idPrestamo)
        {
            try
            {
                var lstUiCuotas = new List<BE.UI.Cuota>();

                List<BE.PrestamoCuota> lstBeCuotas = new DA.Prestamo().ListarCuotas(idPrestamo);
                lstUiCuotas = this.ListPrestamoCuotaBEtoUI(lstBeCuotas);

                return lstUiCuotas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.UI.Prestamo> ListarSinCuotas(int anho, int mes)
        {
          try
            {
                List<BE.Prestamo> lstbePrestamo = new DA.Prestamo().Listar(anho, mes, false);

                var lstUiPrestamo = new List<BE.UI.Prestamo>();
                foreach (var bePrestamo in lstbePrestamo)
                {
                    BE.UI.Prestamo uiPrestamo = this.PrestamoBEtoUI(bePrestamo);
                    uiPrestamo.NombreCompletoEmpleado = new DA.Trabajador().ObtenerNombreCompleto(bePrestamo.CodigoEmpleado);
                    lstUiPrestamo.Add(uiPrestamo);
                }
                return lstUiPrestamo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.UI.Prestamo> ListarConCuotas(int anho, int mes)
        {
            try
            {
                List<BE.Prestamo> lstbePrestamo = new DA.Prestamo().Listar(anho, mes, true);

                var lstUiPrestamo = new List<BE.UI.Prestamo>();
                foreach (var bePrestamo in lstbePrestamo)
                {
                    BE.UI.Prestamo uiPrestamo = this.PrestamoBEtoUI(bePrestamo);
                    uiPrestamo.NombreCompletoEmpleado = new DA.Trabajador().ObtenerNombreCompleto(bePrestamo.CodigoEmpleado);
                    uiPrestamo.Cuotas = this.ListPrestamoCuotaBEtoUI(bePrestamo.Cuotas);

                    lstUiPrestamo.Add(uiPrestamo);
                }
                return lstUiPrestamo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BE.UI.Prestamo ObtenerSinCuotas(int idPrestamo)
        {
            try
            {
                BE.UI.Prestamo uiPrestamo = null;

                BE.Prestamo bePrestamo = new DA.Prestamo().Obtener(idPrestamo, false);
                if (bePrestamo != null)
                {
                    uiPrestamo = this.PrestamoBEtoUI(bePrestamo);
                    uiPrestamo.NombreCompletoEmpleado = new DA.Trabajador().ObtenerNombreCompleto(bePrestamo.CodigoEmpleado);
                }

                return uiPrestamo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BE.UI.Prestamo ObtenerConCuotas(int idPrestamo)
        {
            try
            {
                BE.UI.Prestamo uiPrestamo = null;

                BE.Prestamo bePrestamo = new DA.Prestamo().Obtener(idPrestamo, true);
                if (bePrestamo != null)
                {
                    uiPrestamo = this.PrestamoBEtoUI(bePrestamo);
                    uiPrestamo.NombreCompletoEmpleado = new DA.Trabajador().ObtenerNombreCompleto(bePrestamo.CodigoEmpleado);
                    uiPrestamo.Cuotas = this.ListPrestamoCuotaBEtoUI(bePrestamo.Cuotas);
                }

                return uiPrestamo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public double ObtenerTotal(int anho, int mes, string codigoEmpleado)
        {
            double total = 0;
            try
            {
                var lstUiPrestamos = this.ListarSinCuotas(anho, mes);

                lstUiPrestamos = lstUiPrestamos.Where(x => x.CodigoEmpleado == codigoEmpleado).ToList();

                if (lstUiPrestamos != null && lstUiPrestamos.Count > 0)
                    total = lstUiPrestamos.Select(x => x.Monto).Sum();

                return total;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public double ObtenerCuotaTotal(int anho, int mes, string codigoEmpleado)
        {
            double total = 0;
            try
            {
                var lstUiCuotas = this.ListarCuotas(anho, mes, codigoEmpleado);

                total = lstUiCuotas.Sum(x => x.Importe);

                return total;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.UI.Cuota> ListarCuotas(int anho, int mes, string codigoEmpleado)
        {
            List<BE.UI.Cuota> lstUiCuotas = new List<BE.UI.Cuota>();
            try
            {
               var lstBeCuotas = new DA.Prestamo().ListarCuotas(anho, mes, codigoEmpleado);

                foreach (BE.PrestamoCuota beCuota in lstBeCuotas)
                {
                    BE.UI.Cuota uiCuota = this.PrestamoCuotaBEtoUI(beCuota);
                    lstUiCuotas.Add(uiCuota);
                }

                return lstUiCuotas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
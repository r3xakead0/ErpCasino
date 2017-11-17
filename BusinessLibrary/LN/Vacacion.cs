using BE = ErpCasino.BusinessLibrary.BE;
using DA = ErpCasino.BusinessLibrary.DA;
using System.Collections.Generic;
using System;

namespace ErpCasino.BusinessLibrary.LN
{

    public class Vacacion
    {

        private string NombreMes(int numeroMes)
        {
            string nombreMes = "";

            switch (numeroMes)
            {
                case 1:
                    nombreMes = "Enero";
                    break;
                case 2:
                    nombreMes = "Febrero";
                    break;
                case 3:
                    nombreMes = "Marzo";
                    break;
                case 4:
                    nombreMes = "Abril";
                    break;
                case 5:
                    nombreMes = "Mayo";
                    break;
                case 6:
                    nombreMes = "Junio";
                    break;
                case 7:
                    nombreMes = "Julio";
                    break;
                case 8:
                    nombreMes = "Agosto";
                    break;
                case 9:
                    nombreMes = "Septiembre";
                    break;
                case 10:
                    nombreMes = "Octubre";
                    break;
                case 11:
                    nombreMes = "Noviembre";
                    break;
                default:
                    nombreMes = "Diciembre";
                    break;
            }

            return nombreMes;
        }

        private BE.UI.VacacionDetalle BeDetalleToUiDetalle(BE.VacacionDetalle beVacacionDetalle)
        {
            var uiVacacionDetalle = new BE.UI.VacacionDetalle();

            uiVacacionDetalle.Id = beVacacionDetalle.IdVacacionDetalle;
            uiVacacionDetalle.Numero = beVacacionDetalle.Numero;
            uiVacacionDetalle.Anho = beVacacionDetalle.Anho;
            uiVacacionDetalle.MesNumero = beVacacionDetalle.Mes;
            uiVacacionDetalle.MesNombre = this.NombreMes(beVacacionDetalle.Mes);
            uiVacacionDetalle.HorasExtrasMonto = beVacacionDetalle.HorasExtrasMonto;
            uiVacacionDetalle.BonificacionMonto = beVacacionDetalle.BonificacionMonto;

            return uiVacacionDetalle;
        }

        private BE.VacacionDetalle UiDetalleToBeDetalle(BE.UI.VacacionDetalle uiVacacionDetalle)
        {
            var beVacacionDetalle = new BE.VacacionDetalle();

            beVacacionDetalle.IdVacacionDetalle = uiVacacionDetalle.Id;
            beVacacionDetalle.Numero = uiVacacionDetalle.Numero;
            beVacacionDetalle.Anho = uiVacacionDetalle.Anho;
            beVacacionDetalle.Mes = uiVacacionDetalle.MesNumero;
            beVacacionDetalle.HorasExtrasMonto = uiVacacionDetalle.HorasExtrasMonto;
            beVacacionDetalle.BonificacionMonto = uiVacacionDetalle.BonificacionMonto;

            return beVacacionDetalle;
        }

        private BE.Vacacion UiToBe(BE.UI.Vacacion uiVacacion)
        {
            var beVacacion = new BE.Vacacion();

            beVacacion.IdVacacion = uiVacacion.Id;

            beVacacion.CodigoEmpleado = uiVacacion.EmpleadoCodigo;
            beVacacion.PeriodoFechaInicial = uiVacacion.PeriodoFechaInicial;
            beVacacion.PeriodoFechaFinal = uiVacacion.PeriodoFechaFinal;
            beVacacion.FechaInicial = uiVacacion.VacacionFechaInicial;
            beVacacion.FechaFinal = uiVacacion.VacacionFechaFinal;
            beVacacion.Dias = uiVacacion.VacacionDias;

            beVacacion.Sueldo = uiVacacion.EmpleadoSueldo;
            beVacacion.AsignacionFamiliar = uiVacacion.EmpleadoAsignacionFamiliar;
            beVacacion.PromedioHorasExtras = uiVacacion.PromedioHorasExtras;
            beVacacion.PromedioBonificacion = uiVacacion.PromedioBonificacion;

            beVacacion.TipoComisionAfp = uiVacacion.PensionTipoComision;
            beVacacion.PensionMonto = uiVacacion.PensionMonto;

            int anho = beVacacion.FechaInicial.Year;
            int mes = beVacacion.FechaInicial.Month;
            if (uiVacacion.PensionTipo == BE.UI.TipoPensionEnum.AFP)
            {
                var beComisionAfp = new DA.AfpComision().Obtener(uiVacacion.PensionId, anho, mes);
                beVacacion.ComisionAfp = beComisionAfp;
            }
            else if (uiVacacion.PensionTipo == BE.UI.TipoPensionEnum.ONP)
            {
                var beComisionOnp = new DA.OnpComision().Obtener(anho, mes);
                beVacacion.ComisionOnp = beComisionOnp;
            }
            
            beVacacion.RetencionJudicialMonto = uiVacacion.RetencionJudicialMonto;

            beVacacion.TotalBruto = uiVacacion.TotalBruto;
            beVacacion.TotalDescuento = uiVacacion.TotalDescuento;
            beVacacion.TotalNeto = uiVacacion.TotalNeto;

            beVacacion.Detalle = new List<BE.VacacionDetalle>();
            foreach (BE.UI.VacacionDetalle uiVacacionDetalle in uiVacacion.Detalle)
            {
                var beVacacionDetalle = UiDetalleToBeDetalle(uiVacacionDetalle);
                beVacacion.Detalle.Add(beVacacionDetalle);
            }

            return beVacacion;
        }

        private BE.UI.Vacacion BeToUi(BE.Vacacion beVacacion)
        {
            var uiVacacion = new BE.UI.Vacacion();

            uiVacacion.Id = beVacacion.IdVacacion;

            uiVacacion.PeriodoFechaInicial = beVacacion.PeriodoFechaInicial;
            uiVacacion.PeriodoFechaFinal = beVacacion.PeriodoFechaFinal;
            uiVacacion.VacacionFechaInicial = beVacacion.FechaInicial;
            uiVacacion.VacacionFechaFinal = beVacacion.FechaFinal;
            uiVacacion.VacacionDias = beVacacion.Dias;

            uiVacacion.EmpleadoCodigo = beVacacion.CodigoEmpleado;
            uiVacacion.EmpleadoNombreCompleto = new LN.Empleado().ObtenerNombreCompleto(beVacacion.CodigoEmpleado);
            uiVacacion.EmpleadoSueldo = beVacacion.Sueldo;
            uiVacacion.EmpleadoAsignacionFamiliar = beVacacion.AsignacionFamiliar;
            uiVacacion.PromedioHorasExtras = beVacacion.PromedioHorasExtras;
            uiVacacion.PromedioBonificacion = beVacacion.PromedioBonificacion;

            if (beVacacion.ComisionAfp != null)
            {
                uiVacacion.PensionId = beVacacion.ComisionAfp.Afp.IdAfp;
                uiVacacion.PensionTipo = BE.UI.TipoPensionEnum.AFP;
                uiVacacion.PensionNombre = beVacacion.ComisionAfp.Afp.Nombre;
                uiVacacion.PensionMonto = beVacacion.PensionMonto;

                uiVacacion.PensionTipoComision = beVacacion.TipoComisionAfp;

                double porcentaje = beVacacion.ComisionAfp.PorcentajeFondo + beVacacion.ComisionAfp.PorcentajeSeguro;
                switch (uiVacacion.PensionTipoComision)
                {
                    case "FLUJO":
                        porcentaje += beVacacion.ComisionAfp.PorcentajeComisionFlujo;
                        break;
                    case "MIXTA":
                        porcentaje += beVacacion.ComisionAfp.PorcentajeComisionMixta;
                        break;
                    //case "SALDO":
                    //    porcentaje += beVacacion.ComisionAfp.PorcentajeComisionFlujo;
                    //    break;
                    default:
                        porcentaje += 0.0;
                        break;
                }
                uiVacacion.PensionPorcentaje = porcentaje;


            }
            else if(beVacacion.ComisionOnp != null)
            {
                uiVacacion.PensionId = 0;
                uiVacacion.PensionTipo = BE.UI.TipoPensionEnum.ONP;
                uiVacacion.PensionNombre = "ONP";
                uiVacacion.PensionMonto = beVacacion.PensionMonto;

                uiVacacion.PensionTipoComision = "";
                uiVacacion.PensionPorcentaje = beVacacion.ComisionOnp.PorcentajeAporte;
            }

            uiVacacion.RetencionJudicialMonto = beVacacion.RetencionJudicialMonto;

            //uiVacacion.TotalBruto = beVacacion.TotalBruto;
            //uiVacacion.TotalDescuento = beVacacion.TotalDescuento;
            //uiVacacion.TotalNeto = beVacacion.TotalNeto;

            uiVacacion.Detalle = new List<BE.UI.VacacionDetalle>();
            foreach (BE.VacacionDetalle beVacacionDetalle in beVacacion.Detalle)
            {
                var uiVacacionDetalle = this.BeDetalleToUiDetalle(beVacacionDetalle);
                uiVacacion.Detalle.Add(uiVacacionDetalle);
            }

            return uiVacacion;
        }

        public bool Insertar(ref BE.UI.Vacacion uiVacacion)
        {
            try
            {
                var beVacacion = this.UiToBe(uiVacacion);

                int rowsAffected = new DA.Vacacion().Insertar(ref beVacacion);

                uiVacacion.Id = beVacacion.IdVacacion;

                if (uiVacacion.Id > 0)
                {
                    string codEmpleado = uiVacacion.EmpleadoCodigo;
                    DateTime fechaVacacion = uiVacacion.VacacionFechaInicial;
                    int rpta = new DA.ClsDaTbEmpleado().Vacacion(codEmpleado, fechaVacacion);
                }

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Eliminar(BE.UI.Vacacion uiVacacion)
        {
            try
            {
                bool rpta = this.Eliminar(uiVacacion.Id);

                if (rpta)
                    new DA.ClsDaTbEmpleado().Vacacion(uiVacacion.EmpleadoCodigo);

                return rpta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Eliminar(int idVacacion)
        {
            try
            {
                int rowsAffected = new DA.Vacacion().Eliminar(idVacacion);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.UI.Vacacion> Listar(int anho, int mes)
        {
            try
            {
                List<BE.UI.Vacacion> lstUiVacaciones = new List<BE.UI.Vacacion>();

                List<BE.Vacacion> lstBeVacaciones = new DA.Vacacion().Listar(anho, mes);
                foreach (BE.Vacacion beVacacion in lstBeVacaciones)
                {
                    BE.UI.Vacacion uiVacacion = this.BeToUi(beVacacion);
                    lstUiVacaciones.Add(uiVacacion);
                }

                return lstUiVacaciones;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BE.UI.Vacacion Obtener(int idVacacion)
        {
            try
            {
                BE.UI.Vacacion uiVacacion = null;

                var daVacacion = new DA.Vacacion();

                BE.Vacacion beVacacion = daVacacion.Obtener(idVacacion);
                if (beVacacion != null)
                {
                    beVacacion.Detalle = daVacacion.ListarDetalle(idVacacion);

                    uiVacacion = this.BeToUi(beVacacion);
                }

                return uiVacacion;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}
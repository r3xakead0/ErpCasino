using BE = ErpCasino.BusinessLibrary.BE;
using DA = ErpCasino.BusinessLibrary.DA;
using System.Collections.Generic;
using System;

namespace ErpCasino.BusinessLibrary.LN
{

    public class Vacacion
    {

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
            if (uiVacacion.PensionTipo == BE.UI.TipoPension.AFP)
            {
                var beComisionAfp = new DA.AfpComision().Obtener(uiVacacion.PensionId, anho, mes);
                beVacacion.ComisionAfp = beComisionAfp;
            }
            else if (uiVacacion.PensionTipo == BE.UI.TipoPension.AFP)
            {
                var beComisionOnp = new DA.OnpComision().Obtener(anho, mes);
                beVacacion.ComisionOnp = beComisionOnp;
            }
            
            beVacacion.RetencionJudicialMonto = uiVacacion.RetencionJudicialMonto;

            beVacacion.TotalBruto = uiVacacion.TotalBruto;
            beVacacion.TotalDescuento = uiVacacion.TotalDescuento;
            beVacacion.TotalNeto = uiVacacion.TotalNeto;

            return beVacacion;
        }

        private BE.UI.Vacacion BeToUi(BE.Vacacion beVacacion)
        {
            var uiVacacion = new BE.UI.Vacacion();

            uiVacacion.Id = beVacacion.IdVacacion;

            uiVacacion.EmpleadoCodigo = beVacacion.CodigoEmpleado;
            uiVacacion.PeriodoFechaInicial = beVacacion.PeriodoFechaInicial;
            uiVacacion.PeriodoFechaFinal = beVacacion.PeriodoFechaFinal;
            uiVacacion.VacacionFechaInicial = beVacacion.FechaInicial;
            uiVacacion.VacacionFechaFinal = beVacacion.FechaFinal;
            uiVacacion.VacacionDias = beVacacion.Dias;

            uiVacacion.EmpleadoSueldo = beVacacion.Sueldo;
            uiVacacion.EmpleadoAsignacionFamiliar = beVacacion.AsignacionFamiliar;
            uiVacacion.PromedioHorasExtras = beVacacion.PromedioHorasExtras;
            uiVacacion.PromedioBonificacion = beVacacion.PromedioBonificacion;

            if (beVacacion.ComisionAfp != null)
            {
                uiVacacion.PensionTipo = BE.UI.TipoPension.AFP;
                uiVacacion.PensionNombre = beVacacion.ComisionAfp.Afp.Nombre;
                uiVacacion.PensionMonto = beVacacion.PensionMonto;

                uiVacacion.PensionTipoComision = beVacacion.TipoComisionAfp;
                switch (uiVacacion.PensionTipoComision)
                {
                    case "FLUJO":
                        uiVacacion.PensionPorcentaje = beVacacion.ComisionAfp.PorcentajeComisionFlujo;
                        break;
                    case "MIXTA":
                        uiVacacion.PensionPorcentaje = beVacacion.ComisionAfp.PorcentajeComisionMixta;
                        break;
                    //case "SALDO":
                    //    uiVacacion.PensionPorcentaje = beVacacion.ComisionAfp.PorcentajeComisionFlujo;
                    //    break;
                    default:
                        uiVacacion.PensionPorcentaje = 0.0;
                        break;
                }
                
            }
            else if(beVacacion.ComisionOnp != null)
            {
                uiVacacion.PensionTipo = BE.UI.TipoPension.ONP;
                uiVacacion.PensionNombre = "ONP";
                uiVacacion.PensionMonto = beVacacion.PensionMonto;

                uiVacacion.PensionTipoComision = "";
                uiVacacion.PensionPorcentaje = beVacacion.ComisionOnp.PorcentajeAporte;
            }

            uiVacacion.RetencionJudicialMonto = beVacacion.RetencionJudicialMonto;

            //uiVacacion.TotalBruto = beVacacion.TotalBruto;
            //uiVacacion.TotalDescuento = beVacacion.TotalDescuento;
            //uiVacacion.TotalNeto = beVacacion.TotalNeto;

            return uiVacacion;
        }

        public bool Insertar(ref BE.UI.Vacacion uiVacacion)
        {
            try
            {
                var beVacacion = this.UiToBe(uiVacacion);

                int rowsAffected = new DA.Vacacion().Insertar(ref beVacacion);

                uiVacacion.Id = beVacacion.IdVacacion;

                return rowsAffected > 0;
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

    }

}
using BE = ErpCasino.BusinessLibrary.BE;
using DA = ErpCasino.BusinessLibrary.DA;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System;

namespace ErpCasino.BusinessLibrary.LN
{

    public class Movilidad
    {

        public double ObtenerTotal(int anho, int mes, string codigoEmpleado)
        {
            double total = 0.0;
            try
            {

                var lstUiMovilidades = this.Listar();

                lstUiMovilidades = lstUiMovilidades.Where(x => x.EmpleadoCodigo.Equals(codigoEmpleado) 
                                                            && x.Anho == anho 
                                                            && x.MesNumero == mes).ToList();

                if (lstUiMovilidades != null && lstUiMovilidades.Count > 0)
                    total = lstUiMovilidades.Select(x => x.Monto).Sum();

                return total;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private BE.Movilidad UiToBe(BE.UI.Movilidad uiMovilidad)
        {
            var beMovilidad = new BE.Movilidad();
            beMovilidad.IdMovilidad = uiMovilidad.Id;
            beMovilidad.Anho = uiMovilidad.Anho;
            beMovilidad.Mes = uiMovilidad.MesNumero;
            beMovilidad.CodigoEmpleado = uiMovilidad.EmpleadoCodigo;
            beMovilidad.Monto = uiMovilidad.Monto;
            return beMovilidad;
        }

        private BE.UI.Movilidad BeToUi(BE.Movilidad beMovilidad)
        {
            var uiMovilidad = new BE.UI.Movilidad();
            uiMovilidad.Id = beMovilidad.IdMovilidad;
            uiMovilidad.Anho = beMovilidad.Anho;
            uiMovilidad.MesNumero = beMovilidad.Mes;
            uiMovilidad.MesNombre = this.NombreMes(beMovilidad.Mes);
            uiMovilidad.EmpleadoCodigo = beMovilidad.CodigoEmpleado;
            uiMovilidad.EmpleadoNombreCompleto = this.NombreCompletoEmpleado(beMovilidad.CodigoEmpleado);
            uiMovilidad.Monto = beMovilidad.Monto;
            return uiMovilidad;
        }

        private string NombreCompletoEmpleado(string codigo) => new LN.Empleado().ObtenerNombreCompleto(codigo);
        private string NombreMes(int numeroMes)
        {
            string nameMonth = "";

            switch (numeroMes)
            {
                case 1:
                    nameMonth = "Enero";
                    break;
                case 2:
                    nameMonth = "Febrero";
                    break;
                case 3:
                    nameMonth = "Marzo";
                    break;
                case 4:
                    nameMonth = "Abril";
                    break;
                case 5:
                    nameMonth = "Mayo";
                    break;
                case 6:
                    nameMonth = "Junio";
                    break;
                case 7:
                    nameMonth = "Julio";
                    break;
                case 8:
                    nameMonth = "Agosto";
                    break;
                case 9:
                    nameMonth = "Septiembre";
                    break;
                case 10:
                    nameMonth = "Octubre";
                    break;
                case 11:
                    nameMonth = "Noviembre";
                    break;
                default:
                    nameMonth = "Diciembre";
                    break;
            }

            return nameMonth;
        }

        public bool Insertar(ref BE.UI.Movilidad uiMovilidad)
        {
            try
            {
                var beMovilidad = this.UiToBe(uiMovilidad);

                int rowsAffected = new DA.Movilidad().Insertar(ref beMovilidad);

                uiMovilidad = this.BeToUi(beMovilidad);

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Actualizar(BE.UI.Movilidad uiMovilidad)
        {
            try
            {
                var beMovilidad = this.UiToBe(uiMovilidad);
                int rowsAffected = new DA.Movilidad().Actualizar(beMovilidad);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Eliminar(int idMovilidad)
        {
            try
            {
                int rowsAffected = new DA.Movilidad().Eliminar(idMovilidad);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.UI.Movilidad> Listar()
        {
            try
            {
                List<BE.UI.Movilidad> lstUiMovilidads = new List<BE.UI.Movilidad>();

                List<BE.Movilidad> lstBeMovilidades = new DA.Movilidad().Listar();
                foreach (BE.Movilidad beMovilidad in lstBeMovilidades)
                {
                    var uiMovilidad = this.BeToUi(beMovilidad);
                    lstUiMovilidads.Add(uiMovilidad);
                }

                return lstUiMovilidads;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BE.UI.Movilidad Obtener(int idMovilidad)
        {
            try
            {
                var beMovilidad = new DA.Movilidad().Obtener(idMovilidad);

                var uiMovilidad = this.BeToUi(beMovilidad);

                return uiMovilidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}
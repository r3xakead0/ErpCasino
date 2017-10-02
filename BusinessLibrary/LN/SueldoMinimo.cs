using BE = ErpCasino.BusinessLibrary.BE;
using DA = ErpCasino.BusinessLibrary.DA;
using System.Collections.Generic;
using System;
using System.Linq;

namespace ErpCasino.BusinessLibrary.LN
{

    public class SueldoMinimo
    {

        public bool Insertar(ref BE.SueldoMinimo beSueldoMinimo)
        {
            try
            {
                int nroRegistros = new DA.SueldoMinimo().Insertar(ref beSueldoMinimo);
                return (nroRegistros > 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Actualizar(BE.SueldoMinimo beSueldoMinimo)
        {
            try
            {
                int nroRegistros = new DA.SueldoMinimo().Actualizar(beSueldoMinimo);
                return (nroRegistros > 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Eliminar(int idSueldoMinimo)
        {
            try
            {
                int nroRegistros = new DA.SueldoMinimo().Eliminar(idSueldoMinimo);
                return (nroRegistros > 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.UI.SueldoMinimo> Listar()
        {
          try
            {
                var lstUiSueldosMinimos = new List<BE.UI.SueldoMinimo>();

                var lstBeSueldosMinimos = new DA.SueldoMinimo().Listar();
                foreach (BE.SueldoMinimo beSueldoMinimo in lstBeSueldosMinimos)
                {
                    var uiSueldoMinimo = new BE.UI.SueldoMinimo();

                    uiSueldoMinimo.Id = beSueldoMinimo.IdSueldoMinimo;
                    uiSueldoMinimo.FechaInicio = beSueldoMinimo.FechaInicio;
                    uiSueldoMinimo.Monto = beSueldoMinimo.Monto;
                    uiSueldoMinimo.Activo = (beSueldoMinimo.Activo == true ? "Si" : "No");

                    lstUiSueldosMinimos.Add(uiSueldoMinimo);
                }

                return lstUiSueldosMinimos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BE.SueldoMinimo Obtener(int idSueldoMinimo)
        {
            try
            {
                var lstBeSueldosMinimos = new DA.SueldoMinimo().Listar();

                var beSueldoMinimo = lstBeSueldosMinimos.Where(x => x.IdSueldoMinimo == idSueldoMinimo).FirstOrDefault();

                return beSueldoMinimo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtener el sueldo minimo a la fecha de la consulta
        /// </summary>
        /// <param name="fecha">Fecha de consulta</param>
        /// <returns></returns>
        public BE.SueldoMinimo Actual(DateTime fecha)
        {
            try
            {
                var lstBeSueldosMinimos = new DA.SueldoMinimo().Listar();

                var beSueldoMinimo = lstBeSueldosMinimos.Where(x => x.FechaInicio <= fecha).LastOrDefault();

                return beSueldoMinimo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtener el sueldo minimo a la fecha de la consulta
        /// </summary>
        /// <param name="anho">Año de consulta</param>
        /// <param name="mes">Mes de consulta</param>
        /// <returns></returns>
        public BE.SueldoMinimo Actual(int anho, int mes)
        {
            try
            {
                int dia = DateTime.DaysInMonth(anho, mes);
                DateTime fecha = new DateTime(anho, mes, dia);

                return this.Actual(fecha);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
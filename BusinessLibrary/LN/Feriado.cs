using BE = ErpCasino.BusinessLibrary.BE;
using DA = ErpCasino.BusinessLibrary.DA;
using System.Collections.Generic;
using System;

namespace ErpCasino.BusinessLibrary.LN
{

    public class Feriado
    {

        private string boolToString(bool activo) => activo == true ? "Si" : "No";
        private bool stringToBool(string activo) => activo.Equals("Si") ? true : false;

        private BE.UI.Feriado BeToUi(BE.Feriado beFeriado) => new BE.UI.Feriado()
        {
            Anho = beFeriado.Fecha.Year,
            Mes = beFeriado.Fecha.Month,
            Fecha = beFeriado.Fecha,
            Motivo = beFeriado.Motivo,
            Activo = boolToString(beFeriado.Activo),
            Festivo = boolToString(beFeriado.Festivo),
        };

        private BE.Feriado UiToBe(BE.UI.Feriado uiFeriado) => new BE.Feriado()
        {
            Fecha = uiFeriado.Fecha,
            Motivo = uiFeriado.Motivo,
            Activo = stringToBool(uiFeriado.Activo),
            Festivo = stringToBool(uiFeriado.Festivo),
        };

        public bool EsFeriado(DateTime fecha)
        {
            bool esFeriado = false;
            try
            {
                BE.Feriado beFeriado = new DA.Feriado().Obtener(fecha);
                if (beFeriado != null)
                {
                    if (beFeriado.Activo == true && beFeriado.Festivo == false)
                        esFeriado = true;
                }

                return esFeriado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Registrar(BE.UI.Feriado uiFeriado)
        {
            try
            {
                int rowsAffected = 0;

                var daFeriado = new DA.Feriado();

                var beFeriado = daFeriado.Obtener(uiFeriado.Fecha);
                if (beFeriado != null)
                {
                    beFeriado = this.UiToBe(uiFeriado);
                    rowsAffected = daFeriado.Actualizar(beFeriado);
                }
                else
                {
                    beFeriado = this.UiToBe(uiFeriado);
                    rowsAffected = daFeriado.Insertar(beFeriado);
                }

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Eliminar(DateTime fecha)
        {
            try
            {
                int rowsAffected = new DA.Feriado().Eliminar(fecha);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.UI.Feriado> ListarAnho(int anho)
        {
            try
            {
                var lstBeFeriados = new DA.Feriado().ListarAnho(anho);

                var lstUiFeriados = new List<BE.UI.Feriado>();
                foreach (BE.Feriado beFeriado in lstBeFeriados)
                {
                    var uiFeriado = this.BeToUi(beFeriado);
                    lstUiFeriados.Add(uiFeriado);
                }

                return lstUiFeriados;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.UI.Feriado> ListarMes(int anho, int mes)
        {
            try
            {
                var lstBeFeriados = new DA.Feriado().ListarAnho(anho);

                var lstUiFeriados = new List<BE.UI.Feriado>();
                foreach (BE.Feriado beFeriado in lstBeFeriados)
                {
                    var uiFeriado = this.BeToUi(beFeriado);
                    lstUiFeriados.Add(uiFeriado);
                }

                return lstUiFeriados;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}
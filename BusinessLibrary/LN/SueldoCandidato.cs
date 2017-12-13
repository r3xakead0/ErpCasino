using BE = ErpCasino.BusinessLibrary.BE;
using DA = ErpCasino.BusinessLibrary.DA;
using System.Collections.Generic;
using System;

namespace ErpCasino.BusinessLibrary.LN
{

    public class SueldoCandidato
    {

        private BE.UI.SueldoCandidato BeToUI(BE.SueldoCandidato beSueldoCandidato)
        {
            try
            {
                var uiSueldoCandidato = new BE.UI.SueldoCandidato();

                uiSueldoCandidato.ID = beSueldoCandidato.IdSueldoCandidato;
                uiSueldoCandidato.Fecha = beSueldoCandidato.Fecha;
                uiSueldoCandidato.CandidatoCodigo = beSueldoCandidato.CodigoCandidato;
                uiSueldoCandidato.CandidatoNombreCompleto = new LN.Trabajador().ObtenerNombreCompleto(beSueldoCandidato.CodigoCandidato);
                uiSueldoCandidato.Sueldo = beSueldoCandidato.Sueldo;
                uiSueldoCandidato.AsignacionFamiliar = 0.0;
                uiSueldoCandidato.BonoNocturnoMinutos = beSueldoCandidato.BonoNocturnoMinutos;
                uiSueldoCandidato.BonoNocturnoTotal = beSueldoCandidato.BonoNocturnoTotal;
                uiSueldoCandidato.BonoHorasExtrasMinutos = beSueldoCandidato.BonoHorasExtrasMinutos;
                uiSueldoCandidato.BonoHorasExtrasTotal = beSueldoCandidato.BonoHorasExtrasTotal;
                uiSueldoCandidato.BonoFeriadoMinutos = beSueldoCandidato.BonoFeriadoMinutos;
                uiSueldoCandidato.BonoFeriadoTotal = beSueldoCandidato.BonoFeriadoTotal;
                uiSueldoCandidato.DescuentoTardanzaMinutos = beSueldoCandidato.DescuentoTardanzaMinutos;
                uiSueldoCandidato.DescuentoTardanzaTotal = beSueldoCandidato.DescuentoTardanzaTotal;
                uiSueldoCandidato.DescuentoInasistenciaMinutos = beSueldoCandidato.DescuentoInasistenciaMinutos;
                uiSueldoCandidato.DescuentoInasistenciaTotal = beSueldoCandidato.DescuentoInasistenciaTotal;

                return uiSueldoCandidato;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private BE.SueldoCandidato UiToBe(BE.UI.SueldoCandidato uiSueldoCandidato)
        {
            try
            {
                var beSueldoCandidato = new BE.SueldoCandidato();

                beSueldoCandidato.IdSueldoCandidato = uiSueldoCandidato.ID;
                beSueldoCandidato.Fecha = uiSueldoCandidato.Fecha;
                beSueldoCandidato.CodigoCandidato = uiSueldoCandidato.CandidatoCodigo;
                beSueldoCandidato.Sueldo = uiSueldoCandidato.Sueldo;
                beSueldoCandidato.BonoNocturnoMinutos = uiSueldoCandidato.BonoNocturnoMinutos;
                beSueldoCandidato.BonoNocturnoTotal = uiSueldoCandidato.BonoNocturnoTotal;
                beSueldoCandidato.BonoHorasExtrasMinutos = uiSueldoCandidato.BonoHorasExtrasMinutos;
                beSueldoCandidato.BonoHorasExtrasTotal = uiSueldoCandidato.BonoHorasExtrasTotal;
                beSueldoCandidato.BonoFeriadoMinutos = uiSueldoCandidato.BonoFeriadoMinutos;
                beSueldoCandidato.BonoFeriadoTotal = uiSueldoCandidato.BonoFeriadoTotal;
                beSueldoCandidato.DescuentoTardanzaMinutos = uiSueldoCandidato.DescuentoTardanzaMinutos;
                beSueldoCandidato.DescuentoTardanzaTotal = uiSueldoCandidato.DescuentoTardanzaTotal;
                beSueldoCandidato.DescuentoInasistenciaMinutos = uiSueldoCandidato.DescuentoInasistenciaMinutos;
                beSueldoCandidato.DescuentoInasistenciaTotal = uiSueldoCandidato.DescuentoInasistenciaTotal;

                return beSueldoCandidato;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insertar(ref BE.UI.SueldoCandidato uiSueldoCandidato)
        {
            try
            {
                var beSueldoCandidato = this.UiToBe(uiSueldoCandidato);
                int rowsAffected = new DA.SueldoCandidato().Insertar(ref beSueldoCandidato);
                uiSueldoCandidato.ID = beSueldoCandidato.IdSueldoCandidato;
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Actualizar(BE.UI.SueldoCandidato uiSueldoCandidato)
        {
            try
            {
                var beSueldoCandidato = this.UiToBe(uiSueldoCandidato);
                int rowsAffected = new DA.SueldoCandidato().Actualizar(beSueldoCandidato);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Eliminar(BE.UI.SueldoCandidato uiSueldoCandidato)
        {
            try
            {
                var beSueldoCandidato = this.UiToBe(uiSueldoCandidato);
                int rowsAffected = new DA.SueldoCandidato().Eliminar(beSueldoCandidato.IdSueldoCandidato);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Eliminar(int idSueldoCandidato)
        {
            try
            {
                int rowsAffected = new DA.SueldoCandidato().Eliminar(idSueldoCandidato);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.UI.SueldoCandidato> Listar(int anho, int mes)
        {
            try
            {
                var lstUiSueldoCandidatos = new List<BE.UI.SueldoCandidato>();

                var lstBeSueldoCandidatos = new DA.SueldoCandidato().Listar(anho, mes);
                foreach (BE.SueldoCandidato beSueldoCandidato in lstBeSueldoCandidatos)
                {
                    BE.UI.SueldoCandidato uiSueldoCandidato = this.BeToUI(beSueldoCandidato);
                    lstUiSueldoCandidatos.Add(uiSueldoCandidato);
                }

                return lstUiSueldoCandidatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Validar si existe descuentos calculados para el periodo (año y mes) 
        /// </summary>
        /// <param name="anho">Año de consulta en formato yyyy. Ejm: 2017</param>
        /// <param name="mes">Mes de consulta en rango del 1 al 12. Ejm: 1</param>
        /// <returns></returns>
        public bool ExisteCalculo(int anho, int mes)
        {
            try
            {
                return new DA.SueldoCandidato().ExisteCalculo(anho, mes);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
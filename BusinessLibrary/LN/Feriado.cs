using BE = ErpCasino.BusinessLibrary.BE;
using DA = ErpCasino.BusinessLibrary.DA;
using System.Collections.Generic;
using System;

namespace ErpCasino.BusinessLibrary.LN
{

    public class Feriado
    {

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

        public List<BE.Feriado> Listar(int anho, int mes)
        {
            try
            {
                return new DA.Feriado().Listar(anho, mes);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}
using BE = ErpCasino.BusinessLibrary.BE;
using DA = ErpCasino.BusinessLibrary.DA;
using System.Data;
using System.Collections.Generic;
using System;

namespace ErpCasino.BusinessLibrary.LN
{

    public class Pais
    {

        public List<BE.Pais> Listar()
        {

            List<BE.Pais> lst = new List<BE.Pais>();

            try
            {

                var daPais = new DA.Pais();

                DataTable dt = daPais.Listar();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var bePais = new BE.Pais();

                    DataRow dr = dt.Rows[i];
                    daPais.Cargar(ref bePais, ref dr);

                    lst.Add(bePais);
                }


                return lst;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Obtener(ref BE.Pais oBeTbPais)
        {
            bool exists = false;
            try
            {
                var daPais = new DA.Pais();

                exists = daPais.Obtener(ref oBeTbPais);

                return exists;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 

    }

}
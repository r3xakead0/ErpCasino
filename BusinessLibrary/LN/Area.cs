using BE = ErpCasino.BusinessLibrary.BE;
using DA = ErpCasino.BusinessLibrary.DA;
using System.Data;
using System.Collections.Generic;
using System;

namespace ErpCasino.BusinessLibrary.LN
{

    public class Area
    {

        public List<BE.Area> ListarCombo()
        {

            List<BE.Area> lst = new List<BE.Area>();

            try
            {

                var daArea = new DA.Area();

                DataTable dt = daArea.Listar(new BE.Area() { Activo = true });

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var dr = dt.Rows[i];
                    var beArea = new BE.Area();
                    daArea.Cargar(ref beArea,ref dr);
                    lst.Add(beArea);
                }

                return lst;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BE.Area Obtener (int IdArea)
        {
            try
            {
                var beArea = new BE.Area();
                beArea.IdArea = IdArea;

                if (new DA.Area().Obtener(ref beArea) == false)
                    beArea = null;
                
                return beArea;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }

}
using BE = ErpCasino.BusinessLibrary.BE;
using DA = ErpCasino.BusinessLibrary.DA;
using System.Data;
using System.Collections.Generic;
using System;

namespace ErpCasino.BusinessLibrary.LN
{

    public class Afp
    {

        public List<BE.Afp> ListarCombo()
        {

            List<BE.Afp> lstAfp = new List<BE.Afp>();

            try
            {

                var daAfp = new DA.Afp();

                DataTable dt = daAfp.Listar(new BE.Afp() { Activo = true });

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var dr = dt.Rows[i];
                    var beAFP = new BE.Afp();
                    daAfp.Cargar(ref beAFP,ref dr);
                    lstAfp.Add(beAFP);
                }

                return lstAfp;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }

}
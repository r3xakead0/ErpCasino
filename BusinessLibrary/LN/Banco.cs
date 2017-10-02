using BE = ErpCasino.BusinessLibrary.BE;
using DA = ErpCasino.BusinessLibrary.DA;
using System.Data;
using System.Collections.Generic;
using System;

namespace ErpCasino.BusinessLibrary.LN
{

    public class Banco
    {

        /// <summary>
        /// Obtiene la lista de bancos
        /// </summary>
        /// <returns>Lista de objetos bancos</returns>
        public List<BE.Banco> Listar()
        {

            List<BE.Banco> lst = new List<BE.Banco>();

            try
            {

                var daBanco = new DA.Banco();

                DataTable dt = daBanco.Listar(new BE.Banco() { Activo = true });

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var dr = dt.Rows[i];
                    var beBanco = new BE.Banco();
                    daBanco.Cargar(ref beBanco,ref dr);
                    lst.Add(beBanco);
                }

                return lst;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }

}
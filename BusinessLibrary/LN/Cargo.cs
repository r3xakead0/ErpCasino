using ErpCasino.BusinessLibrary.BE;
using ErpCasino.BusinessLibrary.DA;
using System.Data;
using System.Collections.Generic;
using System;

namespace ErpCasino.BusinessLibrary.LN
{

    public class Cargo
    {

        public List<BE.Cargo> Listar()
        {

            var lstBeCargos = new List<BE.Cargo>();

            try
            {

                var daCargo = new DA.Cargo();

                DataTable dt = daCargo.Listar();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var dr = dt.Rows[i];
                    var beCargo = new BE.Cargo();
                    daCargo.Cargar(ref beCargo, ref dr);
                    lstBeCargos.Add(beCargo);
                }

                return lstBeCargos;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BE.Cargo Obtener (int idCargo)
        {
            try
            {
                var beCargo = new BE.Cargo() { IdCargo = idCargo };

                bool rpta = new DA.Cargo().Obtener(ref beCargo);
                if (rpta == false)
                {
                    beCargo = null;
                }

                return beCargo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.Cargo> ListarCombo()
        {

            List<BE.Cargo> lst = new List<BE.Cargo>();

            try
            {

                var daCargo = new DA.Cargo();

                DataTable dt = daCargo.Listar(new BE.Cargo() { Activo = true });

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var dr = dt.Rows[i];
                    var beCargo = new BE.Cargo();
                    daCargo.Cargar(ref beCargo,ref dr);
                    lst.Add(beCargo);
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
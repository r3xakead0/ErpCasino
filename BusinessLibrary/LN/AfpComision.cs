using BE = ErpCasino.BusinessLibrary.BE;
using DA = ErpCasino.BusinessLibrary.DA;
using System.Data;
using System.Collections.Generic;
using System;

namespace ErpCasino.BusinessLibrary.LN
{

    public class AfpComision
    {

        public int Insertar(ref BE.AfpComision beAfpComision)
        {
            int rowsAffected = 0;

            try
            {
                var daAfpComision = new DA.AfpComision();

                rowsAffected = daAfpComision.Insertar(ref beAfpComision);

                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Actualizar(BE.AfpComision beAfpComision)
        {
            int rowsAffected = 0;

            try
            {
                var daAfpComision = new DA.AfpComision();

                rowsAffected = daAfpComision.Actualizar(ref beAfpComision);

                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Eliminar(BE.AfpComision beAfpComision)
        {
            int rowsAffected = 0;

            try
            {
                var daAfpComision = new DA.AfpComision();

                rowsAffected = daAfpComision.Eliminar(beAfpComision);

                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.AfpComision> Listar(int anho, int mes)
        {
            try
            {
                var beAfpComision = new BE.AfpComision();
                beAfpComision.Anho = anho;
                beAfpComision.Mes = mes;
                return Listar(beAfpComision);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.AfpComision> Listar(BE.AfpComision beAfpComision)
        {

            List<BE.AfpComision> lstAfpComision = new List<BE.AfpComision>();

            try
            {

                var daAfpComision = new DA.AfpComision();

                DataTable dt = daAfpComision.Listar(beAfpComision);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var beComision = new BE.AfpComision();

                    DataRow dr = dt.Rows[i];
                    daAfpComision.Cargar(ref beComision, ref dr);

                    var afp = beComision.Afp;
                    new DA.Afp().Obtener(ref afp);
                    beComision.Afp = afp;

                    lstAfpComision.Add(beComision);
                }


                return lstAfpComision;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BE.AfpComision Obtener(int idAfp, int anho, int mes)
        {
            BE.AfpComision beAfpComision = null;
            try
            {
                var daAfpComision = new DA.AfpComision();

                beAfpComision = daAfpComision.Obtener(idAfp, anho, mes);

                return beAfpComision;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}
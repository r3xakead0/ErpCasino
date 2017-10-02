using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.DA;
using System.Data;
using System.Collections.Generic;
using System;

namespace ErpCasino.BusinessLibrary.LN
{

    public class Turno
    {
        public int Insertar(ref BE.Turno beTurno)
        {
            int rowsAffected = 0;

            try
            {
                var daTurno = new DA.Turno();

                rowsAffected = daTurno.Insertar(ref beTurno);

                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Actualizar(BE.Turno beTurno)
        {
            int rowsAffected = 0;

            try
            {
                var daTurno = new DA.Turno();

                rowsAffected = daTurno.Actualizar(beTurno);

                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Eliminar(BE.Turno beTurno)
        {
            int rowsAffected = 0;

            try
            {
                var daTurno = new DA.Turno();

                rowsAffected = daTurno.Eliminar(beTurno);

                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.Turno> Listar()
        {

            List<BE.Turno> lst = new List<BE.Turno>();

            try
            {

                var daTurno = new DA.Turno();

                DataTable dt = daTurno.Listar();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var beTurno = new BE.Turno();

                    DataRow dr = dt.Rows[i];
                    daTurno.Cargar(ref beTurno, ref dr);

                    lst.Add(beTurno);
                }


                return lst;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Obtener(ref BE.Turno beTurno)
        {
            bool exists = false;
            try
            {
                var daTurno = new DA.Turno();

                exists = daTurno.Obtener(ref beTurno);

                return exists;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 

    }

}
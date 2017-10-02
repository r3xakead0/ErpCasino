using ErpCasino.BusinessLibrary.BE;
using ErpCasino.BusinessLibrary.DA;
using System.Data;
using System.Collections.Generic;
using System;

namespace ErpCasino.BusinessLibrary.LN
{

    public class ClsLnTbPlantillaHorario
    {

        public List<ClsBeTbPlantillaHorario> Listar(int idSala, int idCargo)
        {

            List<ClsBeTbPlantillaHorario> lstPlantillaHorario = new List<ClsBeTbPlantillaHorario>();

            try
            {

                var daPlantilla = new ClsDaTbPlantillaHorario();

                DataTable dtPlantilla = daPlantilla.Listar(new ClsBeTbPlantillaHorario()
                {
                    Sala = new BE.Sala() { IdSala = idSala },
                    Cargo = new BE.Cargo() { IdCargo = idCargo }
                });

                if (dtPlantilla.Rows.Count > 0)
                {
                    foreach (DataRow drPlantilla in dtPlantilla.Rows)
                    {
                        var bePlantilla = new ClsBeTbPlantillaHorario();
                        daPlantilla.Cargar(ref bePlantilla, drPlantilla);
                        lstPlantillaHorario.Add(bePlantilla);
                    }
                }

                return lstPlantillaHorario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insertar(ref ClsBeTbPlantillaHorario oBeTbPlantillaHorario)
        {
            bool flag = false;

            try
            {
                flag = new ClsDaTbPlantillaHorario().Insertar(ref oBeTbPlantillaHorario);
                return flag;
            }
            catch (Exception ex)
            {
                throw ex;
            } 
        }

        public bool Eliminar(ClsBeTbPlantillaHorario oBeTbPlantillaHorario)
        {
            bool flag = false;

            try
            {
                flag = new ClsDaTbPlantillaHorario().Eliminar(oBeTbPlantillaHorario);
                return flag;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Eliminar(int IdPlantillaHorario)
        {
            bool flag = false;

            try
            {
                var oBeTbPlantillaHorario = new ClsBeTbPlantillaHorario() { IdPlantillaHorario = IdPlantillaHorario };
                flag = new ClsDaTbPlantillaHorario().Eliminar(oBeTbPlantillaHorario);
                return flag;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
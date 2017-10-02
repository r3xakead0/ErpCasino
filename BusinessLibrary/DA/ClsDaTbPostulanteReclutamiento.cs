using BE = ErpCasino.BusinessLibrary.BE;
using System.Data.SqlClient;
using System.Data;
using System;

namespace ErpCasino.BusinessLibrary.DA
{
    public class ClsDaTbPostulanteReclutamiento
    {

        public BE.ClsBeTbPostulanteReclutamiento Obtener(int idPostulante)
        {
            BE.ClsBeTbPostulanteReclutamiento bePostulanteReclutamiento = null;
            try
            {
                string sp = "SpTbPostulanteReclutamientoObtener";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@IDPOSTULANTE", idPostulante));

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    bePostulanteReclutamiento = new BE.ClsBeTbPostulanteReclutamiento();

                    bePostulanteReclutamiento.IdPostulante = reader["IdPostulante"] == DBNull.Value ? 0 : int.Parse(reader["IdPostulante"].ToString());
                    bePostulanteReclutamiento.CargoCurriculum = reader["CargoCurriculum"] == DBNull.Value ? "" : reader["CargoCurriculum"].ToString();
                    bePostulanteReclutamiento.FechaRecepcion = reader["FechaRecepcion"] == DBNull.Value ? DateTime.Now : DateTime.Parse(reader["FechaRecepcion"].ToString());
                    bePostulanteReclutamiento.Observacion = reader["Observacion"] == DBNull.Value ? "" : reader["Observacion"].ToString();

                }

                return bePostulanteReclutamiento;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}

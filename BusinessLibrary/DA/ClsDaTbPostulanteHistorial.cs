using BE = ErpCasino.BusinessLibrary.BE;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace ErpCasino.BusinessLibrary.DA
{
    public class ClsDaTbPostulanteHistorial
    {

        public List<BE.ClsBeTbPostulanteHistorial> Listar(int idPostulante)
        {
            var lstBePostulanteHistorial = new List<BE.ClsBeTbPostulanteHistorial>();
            try
            {
                string sp = "SpTbPostulanteHistorialListar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@IDPOSTULANTE", idPostulante));

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var bePostulanteHistorial = new BE.ClsBeTbPostulanteHistorial();

                    bePostulanteHistorial.IdPostulante = reader["IdPostulante"] == DBNull.Value ? 0 : int.Parse(reader["IdPostulante"].ToString());
                    bePostulanteHistorial.Acepto = reader["Acepto"] == DBNull.Value ? false : bool.Parse(reader["Acepto"].ToString());
                    bePostulanteHistorial.Nota = reader["Nota"] == DBNull.Value ? "" : reader["Nota"].ToString();
                    bePostulanteHistorial.Estado.IdPostulanteEstado = reader["IdPostulanteEstado"] == DBNull.Value ? 0 : int.Parse(reader["IdPostulanteEstado"].ToString());

                    lstBePostulanteHistorial.Add(bePostulanteHistorial);
                }

                return lstBePostulanteHistorial;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        

    }

}

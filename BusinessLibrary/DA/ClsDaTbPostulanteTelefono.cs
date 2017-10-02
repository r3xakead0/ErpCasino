using ErpCasino.BusinessLibrary.BE;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace ErpCasino.BusinessLibrary.DA
{

    public class ClsDaTbPostulanteTelefono
    {
        
        public List<BE.ClsBeTbPostulanteTelefono> Listar(int idPostulante)
        {
            var lstBePostulanteTelefonos = new List<BE.ClsBeTbPostulanteTelefono>();
            try
            {
                string sp = "SpTbPostulanteTelefonoListar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@IDPOSTULANTE", idPostulante));

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var bePostulanteTelefono = new BE.ClsBeTbPostulanteTelefono();

                    bePostulanteTelefono.IdPostulanteTelefono = int.Parse(reader["IdPostulanteTelefono"].ToString());
                    bePostulanteTelefono.IdPostulante = int.Parse(reader["IdPostulante"].ToString());
                    bePostulanteTelefono.CodTipoTelefono = reader["CodTipoTelefono"].ToString();
                    bePostulanteTelefono.Numero = reader["Numero"].ToString();

                    lstBePostulanteTelefonos.Add(bePostulanteTelefono);
                }

                return lstBePostulanteTelefonos;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}

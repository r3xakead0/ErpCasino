using BE = ErpCasino.BusinessLibrary.BE;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace ErpCasino.BusinessLibrary.DA
{

    public class ClsDaTbCandidatoTelefono
    {
        
        public List<BE.ClsBeTbCandidatoTelefono> Listar(int idCandidato)
        {
            var lstBeCandidatoTelefonos = new List<BE.ClsBeTbCandidatoTelefono>();
            try
            {
                string sp = "SpTbCandidatoTelefonoListar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@IDCANDIDATO", idCandidato));

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var beCandidatoTelefono = new BE.ClsBeTbCandidatoTelefono();

                    beCandidatoTelefono.IdCandidatoTelefono = int.Parse(reader["IdCandidatoTelefono"].ToString());
                    beCandidatoTelefono.IdCandidato = int.Parse(reader["IdCandidato"].ToString());
                    beCandidatoTelefono.CodTipoTelefono = reader["CodTipoTelefono"].ToString();
                    beCandidatoTelefono.Numero = reader["Numero"].ToString();

                    lstBeCandidatoTelefonos.Add(beCandidatoTelefono);
                }

                return lstBeCandidatoTelefonos;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}

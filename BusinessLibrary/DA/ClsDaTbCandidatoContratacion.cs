using BE = ErpCasino.BusinessLibrary.BE;
using System.Data.SqlClient;
using System.Data;
using System;

namespace ErpCasino.BusinessLibrary.DA
{
    public class ClsDaTbCandidatoContratacion
    {

        public BE.ClsBeTbCandidatoContratacion Obtener(int idCandidato)
        {
            BE.ClsBeTbCandidatoContratacion beCandidatoContratacion = null;
            try
            {
                string sp = "SpTbCandidatoContratacionObtener";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@IDCANDIDATO", idCandidato));

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        beCandidatoContratacion = new BE.ClsBeTbCandidatoContratacion();

                        beCandidatoContratacion.IdCandidato = reader["IdCandidato"] == DBNull.Value ? 0 : int.Parse(reader["IdCandidato"].ToString());
                        beCandidatoContratacion.InduccionFechaInicio = reader["InduccionFechaInicio"] == DBNull.Value ? DateTime.Now : DateTime.Parse(reader["InduccionFechaInicio"].ToString());
                        beCandidatoContratacion.InduccionFechaFin = reader["InduccionFechaFin"] == DBNull.Value ? null : (DateTime?)DateTime.Parse(reader["InduccionFechaFin"].ToString());
                        beCandidatoContratacion.Induccion = reader["InduccionEstado"] == DBNull.Value ? false : bool.Parse(reader["InduccionEstado"].ToString());
                        beCandidatoContratacion.Disciplina = reader["InformeDisciplinarioEstado"] == DBNull.Value ? false : bool.Parse(reader["InformeDisciplinarioEstado"].ToString());
                        beCandidatoContratacion.Informe = reader["InformeAdministrativoEstado"] == DBNull.Value ? false : bool.Parse(reader["InformeAdministrativoEstado"].ToString());
                        beCandidatoContratacion.Documentacion = reader["DocumentacionEstado"] == DBNull.Value ? false : bool.Parse(reader["DocumentacionEstado"].ToString());
                        beCandidatoContratacion.Observacion = reader["Observacion"] == DBNull.Value ? "" : reader["Observacion"].ToString();
                    }

                }
  
                return beCandidatoContratacion;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}

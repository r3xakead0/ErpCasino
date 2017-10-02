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

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter dad = new SqlDataAdapter(cmd);
                dad.SelectCommand.Parameters.Add(new SqlParameter("@IDCANDIDATO", idCandidato));

                DataTable dt = new DataTable();
                dad.Fill(dt);

                if ((dt.Rows.Count == 1))
                {
                    DataRow dr = dt.Rows[0];

                    beCandidatoContratacion = new BE.ClsBeTbCandidatoContratacion();

                    beCandidatoContratacion.IdCandidato = dr["IdCandidato"] == DBNull.Value ? 0 : int.Parse(dr["IdCandidato"].ToString());
                    beCandidatoContratacion.InduccionFechaInicio = dr["InduccionFechaInicio"] == DBNull.Value ? DateTime.Now : DateTime.Parse(dr["InduccionFechaInicio"].ToString());
                    beCandidatoContratacion.InduccionFechaFin = dr["InduccionFechaFin"] == DBNull.Value ? null : (DateTime?)DateTime.Parse(dr["InduccionFechaFin"].ToString());
                    beCandidatoContratacion.Induccion = dr["InduccionEstado"] == DBNull.Value ? false : bool.Parse(dr["InduccionEstado"].ToString());
                    beCandidatoContratacion.Disciplina = dr["InformeDisciplinarioEstado"] == DBNull.Value ? false : bool.Parse(dr["InformeDisciplinarioEstado"].ToString());
                    beCandidatoContratacion.Informe = dr["InformeAdministrativoEstado"] == DBNull.Value ? false : bool.Parse(dr["InformeAdministrativoEstado"].ToString());
                    beCandidatoContratacion.Documentacion = dr["DocumentacionEstado"] == DBNull.Value ? false : bool.Parse(dr["DocumentacionEstado"].ToString());
                    beCandidatoContratacion.Observacion = dr["Observacion"] == DBNull.Value ? "" : dr["Observacion"].ToString();

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

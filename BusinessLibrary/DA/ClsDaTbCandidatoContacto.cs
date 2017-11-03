using BE = ErpCasino.BusinessLibrary.BE;
using System.Data.SqlClient;
using System.Data;
using System;

namespace ErpCasino.BusinessLibrary.DA
{
    public class ClsDaTbCandidatoContacto
    {

        public BE.ClsBeTbCandidatoContacto Obtener(int idCandidato)
        {
            BE.ClsBeTbCandidatoContacto beCandidatoContacto = null;

            try
            {
                string sp = "SpTbCandidatoContactoObtener";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@IDCANDIDATO", idCandidato));

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        beCandidatoContacto = new BE.ClsBeTbCandidatoContacto();

                        beCandidatoContacto.IdCandidato = reader["IdCandidato"] == DBNull.Value ? 0 : int.Parse(reader["IdCandidato"].ToString());
                        beCandidatoContacto.Zona = reader["Zona"] == DBNull.Value ? "" : reader["Zona"].ToString();
                        beCandidatoContacto.Direccion = reader["Direccion"] == DBNull.Value ? "" : reader["Direccion"].ToString();
                        beCandidatoContacto.Referencia = reader["Referencia"] == DBNull.Value ? "" : reader["Referencia"].ToString();
                        beCandidatoContacto.Email = reader["Email"] == DBNull.Value ? "" : reader["Email"].ToString();

                        if (reader["CodUbigeo"] == DBNull.Value)
                        {
                            beCandidatoContacto.Ubigeo = null;
                        }
                        else
                        {
                            var oBeUbigeo = new BE.Ubigeo();
                            oBeUbigeo.Codigo = reader["CodUbigeo"].ToString();

                            if (new Ubigeo().Obtener(ref oBeUbigeo))
                                beCandidatoContacto.Ubigeo = oBeUbigeo;
                            else
                                beCandidatoContacto.Ubigeo = null;
                        }
                    }

         
                }
 
                return beCandidatoContacto;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}

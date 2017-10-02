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

                    beCandidatoContacto = new BE.ClsBeTbCandidatoContacto();

                    beCandidatoContacto.IdCandidato = dr["IdCandidato"] == DBNull.Value ? 0 : int.Parse(dr["IdCandidato"].ToString());
                    beCandidatoContacto.Zona = dr["Zona"] == DBNull.Value ? "" : dr["Zona"].ToString();
                    beCandidatoContacto.Direccion = dr["Direccion"] == DBNull.Value ? "" : dr["Direccion"].ToString();
                    beCandidatoContacto.Referencia = dr["Referencia"] == DBNull.Value ? "" : dr["Referencia"].ToString();
                    beCandidatoContacto.Email = dr["Email"] == DBNull.Value ? "" : dr["Email"].ToString();

                    if (dr["CodUbigeo"] == DBNull.Value)
                    {
                        beCandidatoContacto.Ubigeo = null;
                    }
                    else
                    {
                        var oBeUbigeo = new BE.Ubigeo();
                        oBeUbigeo.Codigo = dr["CodUbigeo"].ToString();

                        if (new Ubigeo().Obtener(ref oBeUbigeo))
                            beCandidatoContacto.Ubigeo = oBeUbigeo;
                        else
                            beCandidatoContacto.Ubigeo = null;
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

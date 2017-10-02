using BE = ErpCasino.BusinessLibrary.BE;
using System.Data.SqlClient;
using System.Data;
using System;

namespace ErpCasino.BusinessLibrary.DA
{
    public class ClsDaTbPostulanteContacto
    {

        public BE.ClsBeTbPostulanteContacto Obtener(int idPostulante)
        {
            BE.ClsBeTbPostulanteContacto bePostulanteContacto = null;
            try
            {
                string sp = "SpTbPostulanteContactoObtener";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter dad = new SqlDataAdapter(cmd);
                dad.SelectCommand.Parameters.Add(new SqlParameter("@IDPOSTULANTE", idPostulante));

                DataTable dt = new DataTable();
                dad.Fill(dt);

                if ((dt.Rows.Count == 1))
                {
                    DataRow dr = dt.Rows[0];

                    bePostulanteContacto = new BE.ClsBeTbPostulanteContacto();
                    bePostulanteContacto.IdPostulante = dr["IdPostulante"] == DBNull.Value ? 0 : int.Parse(dr["IdPostulante"].ToString());
                    bePostulanteContacto.Zona = dr["Zona"] == DBNull.Value ? "" : dr["Zona"].ToString();
                    bePostulanteContacto.Direccion = dr["Direccion"] == DBNull.Value ? "" : dr["Direccion"].ToString();
                    bePostulanteContacto.Referencia = dr["Referencia"] == DBNull.Value ? "" : dr["Referencia"].ToString();
                    bePostulanteContacto.Email = dr["Email"] == DBNull.Value ? "" : dr["Email"].ToString();

                    if (dr["CodUbigeo"] == DBNull.Value)
                    {
                        bePostulanteContacto.Ubigeo = null;
                    }
                    else
                    {
                        var oBeUbigeo = new BE.Ubigeo();
                        oBeUbigeo.Codigo = dr["CodUbigeo"].ToString();

                        if (new Ubigeo().Obtener(ref oBeUbigeo))
                            bePostulanteContacto.Ubigeo = oBeUbigeo;
                        else
                            bePostulanteContacto.Ubigeo = null;
                    }
                }

                return bePostulanteContacto;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}

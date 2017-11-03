using BE = ErpCasino.BusinessLibrary.BE;
using System.Data.SqlClient;
using System.Data;
using System;

namespace ErpCasino.BusinessLibrary.DA
{
    public class AfpComision
    {

        public void Cargar(ref BE.AfpComision beAfpComision, ref DataRow dr)
        {
            try
            {
                beAfpComision.IdAfpComision = dr["IdAfpComision"] == DBNull.Value ? 0 : int.Parse(dr["IdAfpComision"].ToString());
                beAfpComision.Anho = dr["Anho"] == DBNull.Value ? 0 : int.Parse(dr["Anho"].ToString());
                beAfpComision.Mes = dr["Mes"] == DBNull.Value ? 0 : int.Parse(dr["Mes"].ToString());
                beAfpComision.PorcentajeFondo = dr["PorcentajeFondo"] == DBNull.Value ? 0.0 : double.Parse(dr["PorcentajeFondo"].ToString());
                beAfpComision.PorcentajeSeguro = dr["PorcentajeSeguro"] == DBNull.Value ? 0.0 : double.Parse(dr["PorcentajeSeguro"].ToString());
                beAfpComision.PorcentajeComisionFlujo = dr["PorcentajeComisionFlujo"] == DBNull.Value ? 0.0 : double.Parse(dr["PorcentajeComisionFlujo"].ToString());
                beAfpComision.PorcentajeComisionMixta = dr["PorcentajeComisionMixta"] == DBNull.Value ? 0.0 : double.Parse(dr["PorcentajeComisionMixta"].ToString());

                if (dr["IdAfp"] != DBNull.Value)
                {
                    int idAfp = dr["IdAfp"] == DBNull.Value ? 0 : int.Parse(dr["IdAfp"].ToString());
                    beAfpComision.Afp = new BE.Afp()
                    {
                        IdAfp = idAfp
                    };
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Insertar(ref BE.AfpComision beAfpComision)
        {
            try
            {
                string sp = "SpTbAfpComisionInsertar";
                int rowsAffected = 0;

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {

                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@IDAFPCOMISION", beAfpComision.IdAfpComision));
                    cmd.Parameters["@IDAFPCOMISION"].Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(new SqlParameter("@ANHO", beAfpComision.Anho));
                    cmd.Parameters.Add(new SqlParameter("@MES", beAfpComision.Mes));
                    cmd.Parameters.Add(new SqlParameter("@IDAFP", beAfpComision.Afp.IdAfp));
                    cmd.Parameters.Add(new SqlParameter("@PORCENTAJEFONDO", beAfpComision.PorcentajeFondo));
                    cmd.Parameters.Add(new SqlParameter("@PORCENTAJESEGURO", beAfpComision.PorcentajeSeguro));
                    cmd.Parameters.Add(new SqlParameter("@PORCENTAJECOMISIONFLUJO", beAfpComision.PorcentajeComisionFlujo));
                    cmd.Parameters.Add(new SqlParameter("@PORCENTAJECOMISIONMIXTA", beAfpComision.PorcentajeComisionMixta));

                    rowsAffected = cmd.ExecuteNonQuery();
                    beAfpComision.IdAfpComision = int.Parse(cmd.Parameters["@IDAfpComision"].Value.ToString());

                }

                return rowsAffected;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Actualizar(ref BE.AfpComision beAfpComision)
        {
            try
            {
                string sp = "SpTbAfpComisionActualizar";
                int rowsAffected = 0;

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@IDAFPCOMISION", beAfpComision.IdAfpComision));
                    cmd.Parameters.Add(new SqlParameter("@ANHO", beAfpComision.Anho));
                    cmd.Parameters.Add(new SqlParameter("@MES", beAfpComision.Mes));
                    cmd.Parameters.Add(new SqlParameter("@IDAFP", beAfpComision.Afp.IdAfp));
                    cmd.Parameters.Add(new SqlParameter("@PORCENTAJEFONDO", beAfpComision.PorcentajeFondo));
                    cmd.Parameters.Add(new SqlParameter("@PORCENTAJESEGURO", beAfpComision.PorcentajeSeguro));
                    cmd.Parameters.Add(new SqlParameter("@PORCENTAJECOMISIONFLUJO", beAfpComision.PorcentajeComisionFlujo));
                    cmd.Parameters.Add(new SqlParameter("@PORCENTAJECOMISIONMIXTA", beAfpComision.PorcentajeComisionMixta));

                    rowsAffected = cmd.ExecuteNonQuery();
                }
 
                return rowsAffected;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Eliminar(BE.AfpComision beAfpComision)
        {
            try
            {
                string sp = "SpTbAfpComisionEliminar";
                int rowsAffected = 0;

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@IDAFPCOMISION", beAfpComision.IdAfpComision));

                    rowsAffected = cmd.ExecuteNonQuery();
                }

                return rowsAffected;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Listar(BE.AfpComision beAfpComision)
        {
            try
            {
                string sp = "SpTbAfpComisionListar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter dad = new SqlDataAdapter(cmd);
                dad.SelectCommand.Parameters.Add(new SqlParameter("@ANHO", beAfpComision.Anho));
                dad.SelectCommand.Parameters.Add(new SqlParameter("@MES", beAfpComision.Mes));

                DataTable dt = new DataTable();
                dad.Fill(dt); 

                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BE.AfpComision Obtener(int idAfp, int anho, int mes)
        {
            BE.AfpComision beAfpComision = null;
            try
            {
                string sp = "SpTbAfpComisionObtener";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter dad = new SqlDataAdapter(cmd);
                dad.SelectCommand.Parameters.Add(new SqlParameter("@IDAFP", idAfp));
                dad.SelectCommand.Parameters.Add(new SqlParameter("@ANHO", anho));
                dad.SelectCommand.Parameters.Add(new SqlParameter("@MES", mes));

                DataTable dt = new DataTable();
                dad.Fill(dt);

                if ((dt.Rows.Count == 1))
                {
                    DataRow dr = dt.Rows[0];
                    beAfpComision = new BE.AfpComision();
                    Cargar(ref beAfpComision, ref dr);

                    var beAfp = beAfpComision.Afp;
                    if (new Afp().Obtener(ref beAfp) == true)
                    {
                        beAfpComision.Afp = beAfp;
                    }
                }

                return beAfpComision;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}

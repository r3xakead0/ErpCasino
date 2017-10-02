using BE = ErpCasino.BusinessLibrary.BE;
using System.Data.SqlClient;
using System.Data;
using System;

namespace ErpCasino.BusinessLibrary.DA
{
    public class Cargo
    {
        public void Cargar(ref BE.Cargo beCargo, ref DataRow dr)
        {
            try
            {
                beCargo.IdCargo = dr["IdCargo"] == DBNull.Value ? 0 : int.Parse(dr["IdCargo"].ToString());
                beCargo.Nombre = dr["Nombre"] == DBNull.Value ? "" : dr["Nombre"].ToString();
                beCargo.Descripcion = dr["Descripcion"] == DBNull.Value ? "" : dr["Descripcion"].ToString();
                beCargo.Activo = dr["Activo"] == DBNull.Value ? false : bool.Parse(dr["Activo"].ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Listar(BE.Cargo beCargo = null)
        {
            try
            {
                string sp = "SpTbCargoListar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter dad = new SqlDataAdapter(cmd);
                if (beCargo != null)
                    dad.SelectCommand.Parameters.Add(new SqlParameter("@ACTIVO", beCargo.Activo));
                
                DataTable dt = new DataTable();
                dad.Fill(dt);

                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Obtener(ref BE.Cargo beCargo)
        {
            bool rpta = false;
            try
            {
                string sp = "SpTbCargoObtener";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter dad = new SqlDataAdapter(cmd);
                    dad.SelectCommand.Parameters.Add(new SqlParameter("@IDCARGO", beCargo.IdCargo));

                    DataTable dt = new DataTable();
                    dad.Fill(dt);

                    if ((dt.Rows.Count == 1))
                    {
                        DataRow dr = dt.Rows[0];
                        Cargar(ref beCargo, ref dr);
                        rpta = true;
                    }
                }

                return rpta;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }

}

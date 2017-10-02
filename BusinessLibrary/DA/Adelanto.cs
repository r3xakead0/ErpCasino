using BE = ErpCasino.BusinessLibrary.BE;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace ErpCasino.BusinessLibrary.DA
{
    public class Adelanto
    {

        public bool Insertar(ref BE.Adelanto oBeTbAdelanto)
        {
            try
            {
                string sp = "SpTbAdelantoInsertar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                int rowsAffected = 0;
                cnn.Open();

                cmd.Parameters.Add(new SqlParameter("@IDADELANTO", oBeTbAdelanto.IdAdelanto));
                cmd.Parameters["@IDADELANTO"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new SqlParameter("@FECHA", oBeTbAdelanto.Fecha));
                cmd.Parameters.Add(new SqlParameter("@CODIGOEMPLEADO", oBeTbAdelanto.CodigoEmpleado));
                cmd.Parameters.Add(new SqlParameter("@TIPO", oBeTbAdelanto.Tipo));
                if (oBeTbAdelanto.IdBanco == 0)
                    cmd.Parameters.Add(new SqlParameter("@IDBANCO", DBNull.Value));
                else
                    cmd.Parameters.Add(new SqlParameter("@IDBANCO", oBeTbAdelanto.IdBanco));
                cmd.Parameters.Add(new SqlParameter("@NUMERO", oBeTbAdelanto.Numero));
                cmd.Parameters.Add(new SqlParameter("@MONTO", oBeTbAdelanto.Monto));

                rowsAffected = cmd.ExecuteNonQuery();
                oBeTbAdelanto.IdAdelanto = int.Parse(cmd.Parameters["@IDADELANTO"].Value.ToString());

                return (rowsAffected > 0 ? true : false);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Actualizar(BE.Adelanto oBeTbAdelanto)
        {
            try
            {
                string sp = "SpTbAdelantoActualizar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                int rowsAffected = 0;
                cnn.Open();

                cmd.Parameters.Add(new SqlParameter("@IDADELANTO", oBeTbAdelanto.IdAdelanto));
                cmd.Parameters.Add(new SqlParameter("@FECHA", oBeTbAdelanto.Fecha));
                cmd.Parameters.Add(new SqlParameter("@CODIGOEMPLEADO", oBeTbAdelanto.CodigoEmpleado));
                cmd.Parameters.Add(new SqlParameter("@TIPO", oBeTbAdelanto.Tipo));
                if (oBeTbAdelanto.IdBanco == 0)
                    cmd.Parameters.Add(new SqlParameter("@IDBANCO", DBNull.Value));
                else
                    cmd.Parameters.Add(new SqlParameter("@IDBANCO", oBeTbAdelanto.IdBanco));
                cmd.Parameters.Add(new SqlParameter("@NUMERO", oBeTbAdelanto.Numero));
                cmd.Parameters.Add(new SqlParameter("@MONTO", oBeTbAdelanto.Monto));

                rowsAffected = cmd.ExecuteNonQuery();

                return (rowsAffected > 0 ? true : false);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Eliminar(int idAdelanto)
        {
            try
            {
                string sp = "SpTbAdelantoEliminar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                int rowsAffected = 0;
                cnn.Open();

                cmd.Parameters.Add(new SqlParameter("@IDADELANTO", idAdelanto));

                rowsAffected = cmd.ExecuteNonQuery();

                return (rowsAffected > 0 ? true : false);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.Adelanto> Listar(int anho, int mes)
        {
            var lstAdelanto = new List<BE.Adelanto>();
            try
            {
                string sp = "SpTbAdelantoListar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ANHO", anho));
                cmd.Parameters.Add(new SqlParameter("@MES", mes));

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var beAdelanto = new BE.Adelanto();

                    beAdelanto.IdAdelanto = int.Parse(reader["IdAdelanto"].ToString());
                    beAdelanto.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                    beAdelanto.CodigoEmpleado = reader["CodigoEmpleado"].ToString();
                    beAdelanto.Tipo = reader["Tipo"].ToString();
                    beAdelanto.Numero = reader["Numero"].ToString();
                    beAdelanto.Monto = double.Parse(reader["Monto"].ToString());

                    string idBanco = reader["IdBanco"].ToString();
                    beAdelanto.IdBanco = idBanco == "" ? 0 : int.Parse(idBanco);

                    lstAdelanto.Add(beAdelanto);
                }

                return lstAdelanto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BE.Adelanto Obtener(int idAdelanto)
        {
            BE.Adelanto beAdelanto = null;

            try
            {
                string sp = "SpTbAdelantoObtener";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@IDADELANTO", idAdelanto));

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    beAdelanto = new BE.Adelanto();

                    beAdelanto.IdAdelanto = int.Parse(reader["IdAdelanto"].ToString());
                    beAdelanto.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                    beAdelanto.CodigoEmpleado = reader["CodigoEmpleado"].ToString();
                    beAdelanto.Tipo = reader["Tipo"].ToString();
                    beAdelanto.Numero = reader["Numero"].ToString();
                    beAdelanto.Monto = double.Parse(reader["Monto"].ToString());

                    string idBanco = reader["IdBanco"].ToString();
                    beAdelanto.IdBanco = idBanco == "" ? 0 : int.Parse(idBanco);
                }

                return beAdelanto;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}

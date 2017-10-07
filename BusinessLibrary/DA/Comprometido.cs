using BE = ErpCasino.BusinessLibrary.BE;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace ErpCasino.BusinessLibrary.DA
{
    public class Comprometido
    {

        public bool Insertar(ref BE.Comprometido beComprometido)
        {
            try
            {
                string sp = "SpTbComprometidoInsertar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@IDCOMPROMETIDO", beComprometido.IdComprometido));
                cmd.Parameters["@IDCOMPROMETIDO"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new SqlParameter("@ANHO", beComprometido.Anho));
                cmd.Parameters.Add(new SqlParameter("@MES", beComprometido.Mes));
                cmd.Parameters.Add(new SqlParameter("@IDSALA", beComprometido.Sala.IdSala));
                cmd.Parameters.Add(new SqlParameter("@CODIGOEMPLEADO", beComprometido.CodigoEmpleado));
                cmd.Parameters.Add(new SqlParameter("@COMPROMETIDO", beComprometido.Estado));

                int rowsAffected = cmd.ExecuteNonQuery();
                beComprometido.IdComprometido = int.Parse(cmd.Parameters["@IDCOMPROMETIDO"].Value.ToString());

                return (rowsAffected > 0 ? true : false);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Actualizar(BE.Comprometido beComprometido)
        {
            try
            {
                string sp = "SpTbComprometidoActualizar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@IDCOMPROMETIDO", beComprometido.IdComprometido));
                cmd.Parameters.Add(new SqlParameter("@ANHO", beComprometido.Anho));
                cmd.Parameters.Add(new SqlParameter("@MES", beComprometido.Mes));
                cmd.Parameters.Add(new SqlParameter("@IDSALA", beComprometido.Sala.IdSala));
                cmd.Parameters.Add(new SqlParameter("@CODIGOEMPLEADO", beComprometido.CodigoEmpleado));
                cmd.Parameters.Add(new SqlParameter("@COMPROMETIDO", beComprometido.Estado));

                int rowsAffected = cmd.ExecuteNonQuery();

                return (rowsAffected > 0 ? true : false);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Eliminar(int idComprometido)
        {
            try
            {
                string sp = "SpTbComprometidoEliminar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@IDCOMPROMETIDO", idComprometido));

                int rowsAffected = cmd.ExecuteNonQuery();

                return (rowsAffected > 0 ? true : false);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.Comprometido> Listar(int anho, int mes, 
                                    int? idSala = null, string codigoEmpleado = null)
        {
            var lstComprometido = new List<BE.Comprometido>();
            try
            {
                string sp = "SpTbComprometidoListar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ANHO", anho));
                cmd.Parameters.Add(new SqlParameter("@MES", mes));

                if (idSala == null || idSala == 0)
                    cmd.Parameters.Add(new SqlParameter("@IDSALA", DBNull.Value));
                else
                    cmd.Parameters.Add(new SqlParameter("@IDSALA", (int)idSala));

                if (codigoEmpleado == null || codigoEmpleado.Length == 0)
                    cmd.Parameters.Add(new SqlParameter("@IDSALA", DBNull.Value));
                else
                    cmd.Parameters.Add(new SqlParameter("@CODIGOEMPLEADO", codigoEmpleado));

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var beComprometido = new BE.Comprometido();

                    beComprometido.IdComprometido = reader["IdComprometido"] == DBNull.Value ? 0 : int.Parse(reader["IdComprometido"].ToString());
                    beComprometido.Anho = reader["Anho"] == DBNull.Value ? 0 : int.Parse(reader["Anho"].ToString());
                    beComprometido.Mes = reader["Mes"] == DBNull.Value ? 0 : int.Parse(reader["Mes"].ToString());
                    beComprometido.CodigoEmpleado = reader["CodigoEmpleado"] == DBNull.Value ? "" : reader["CodigoEmpleado"].ToString();
                    beComprometido.Estado = reader["Comprometido"] == DBNull.Value ? false : bool.Parse(reader["Comprometido"].ToString());

                    beComprometido.Sala = new BE.Sala()
                    {
                        IdSala = reader["IdSala"] == DBNull.Value ? 0 : int.Parse(reader["IdSala"].ToString())
                    };

                    lstComprometido.Add(beComprometido);
                }

                return lstComprometido;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BE.Comprometido Obtener(int idComprometido)
        {
            BE.Comprometido beComprometido = null;

            try
            {
                string sp = "SpTbComprometidoObtener";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@IDCOMPROMETIDO", idComprometido));

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    beComprometido = new BE.Comprometido();

                    beComprometido.IdComprometido = reader["IdComprometido"] == DBNull.Value ? 0 : int.Parse(reader["IdComprometido"].ToString());
                    beComprometido.Anho = reader["Anho"] == DBNull.Value ? 0 : int.Parse(reader["Anho"].ToString());
                    beComprometido.Mes = reader["Mes"] == DBNull.Value ? 0 : int.Parse(reader["Mes"].ToString());
                    beComprometido.CodigoEmpleado = reader["CodigoEmpleado"] == DBNull.Value ? "" : reader["CodigoEmpleado"].ToString();
                    beComprometido.Estado = reader["Comprometido"] == DBNull.Value ? false : bool.Parse(reader["Comprometido"].ToString());

                    beComprometido.Sala = new BE.Sala()
                    {
                        IdSala = reader["IdSala"] == DBNull.Value ? 0 : int.Parse(reader["IdSala"].ToString())
                    };

                }

                return beComprometido;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}

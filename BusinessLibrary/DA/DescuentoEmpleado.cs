using BE = ErpCasino.BusinessLibrary.BE;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace ErpCasino.BusinessLibrary.DA
{
    public class DescuentoEmpleado
    {

        public int Insertar(ref BE.DescuentoEmpleado beDescuentoEmpleado)
        {
            try
            {
                string sp = "SpTbDescuentoEmpleadoInsertar";
                int rowsAffected = 0;

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@IDDESCUENTOEMPLEADO", beDescuentoEmpleado.IdDescuentoEmpleado));
                    cmd.Parameters["@IDDESCUENTOEMPLEADO"].Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(new SqlParameter("@FECHA", beDescuentoEmpleado.Fecha));
                    cmd.Parameters.Add(new SqlParameter("@CODIGOEMPLEADO", beDescuentoEmpleado.CodigoEmpleado));
                    cmd.Parameters.Add(new SqlParameter("@IDDESCUENTO", beDescuentoEmpleado.Descuento.IdDescuento));
                    cmd.Parameters.Add(new SqlParameter("@MOTIVO", beDescuentoEmpleado.Motivo));
                    cmd.Parameters.Add(new SqlParameter("@MONTO", beDescuentoEmpleado.Monto));

                    rowsAffected = cmd.ExecuteNonQuery();
                    beDescuentoEmpleado.IdDescuentoEmpleado = int.Parse(cmd.Parameters["@IDDESCUENTOEMPLEADO"].Value.ToString());

                }

                return rowsAffected;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Actualizar(BE.DescuentoEmpleado beDescuentoEmpleado)
        {
            try
            {
                string sp = "SpTbDescuentoEmpleadoActualizar";
                int rowsAffected = 0;

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@IDDESCUENTOEMPLEADO", beDescuentoEmpleado.IdDescuentoEmpleado));
                    cmd.Parameters.Add(new SqlParameter("@FECHA", beDescuentoEmpleado.Fecha));
                    cmd.Parameters.Add(new SqlParameter("@CODIGOEMPLEADO", beDescuentoEmpleado.CodigoEmpleado));
                    cmd.Parameters.Add(new SqlParameter("@IDDESCUENTO", beDescuentoEmpleado.Descuento.IdDescuento));
                    cmd.Parameters.Add(new SqlParameter("@MOTIVO", beDescuentoEmpleado.Motivo));
                    cmd.Parameters.Add(new SqlParameter("@MONTO", beDescuentoEmpleado.Monto));

                    rowsAffected = cmd.ExecuteNonQuery();
                }

                return rowsAffected;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Eliminar(int idDescuentoEmpleado)
        {
            try
            {
                string sp = "SpTbDescuentoEmpleadoEliminar";
                int rowsAffected = 0;

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    cmd.Parameters.Add(new SqlParameter("@IDDESCUENTOEMPLEADO", idDescuentoEmpleado));

                    rowsAffected = cmd.ExecuteNonQuery();
                }

                return rowsAffected;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.DescuentoEmpleado> Listar(int anho, int mes)
        {
            var lstBeObservaciones = new List<BE.DescuentoEmpleado>();

            try
            {
                string sp = "SpTbDescuentoEmpleadoListar";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ANHO", anho));
                    cmd.Parameters.Add(new SqlParameter("@MES", mes));

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var beDescuentoEmpleado = new BE.DescuentoEmpleado();

                        beDescuentoEmpleado.IdDescuentoEmpleado = reader["IdDescuentoEmpleado"] == DBNull.Value ? 0 : int.Parse(reader["IdDescuentoEmpleado"].ToString());
                        beDescuentoEmpleado.Fecha = reader["Fecha"] == DBNull.Value ? DateTime.Now : DateTime.Parse(reader["Fecha"].ToString());
                        beDescuentoEmpleado.CodigoEmpleado = reader["CodigoEmpleado"] == DBNull.Value ? "" : reader["CodigoEmpleado"].ToString();
                        beDescuentoEmpleado.Motivo = reader["Motivo"] == DBNull.Value ? "" : reader["Motivo"].ToString();
                        beDescuentoEmpleado.Monto = reader["Monto"] == DBNull.Value ? 0.0 : double.Parse(reader["Monto"].ToString());

                        if (reader["idDescuento"] != DBNull.Value)
                        {
                            int idDescuento = int.Parse(reader["idDescuento"].ToString());

                            var beDescuento = new DA.Descuento().Obtener(idDescuento);
                            if (beDescuento != null)
                                beDescuentoEmpleado.Descuento = beDescuento;

                            beDescuento = null;   
                        }

                        lstBeObservaciones.Add(beDescuentoEmpleado);
                    }

                }

                return lstBeObservaciones;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        
    }

}

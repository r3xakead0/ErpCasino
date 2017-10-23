using BE = ErpCasino.BusinessLibrary.BE;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace ErpCasino.BusinessLibrary.DA
{
    public class BonoEmpleado
    {

        public int Insertar(ref BE.BonoEmpleado beBonoEmpleado)
        {
            try
            {
                string sp = "SpTbBonoEmpleadoInsertar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                int rowsAffected = 0;

                cmd.Parameters.Add(new SqlParameter("@IDBONOEMPLEADO", beBonoEmpleado.IdBonoEmpleado));
                cmd.Parameters["@IDBONOEMPLEADO"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new SqlParameter("@FECHA", beBonoEmpleado.Fecha));
                cmd.Parameters.Add(new SqlParameter("@CODIGOEMPLEADO", beBonoEmpleado.CodigoEmpleado));
                cmd.Parameters.Add(new SqlParameter("@IDBONO", beBonoEmpleado.Bono.IdBono));
                cmd.Parameters.Add(new SqlParameter("@MOTIVO", beBonoEmpleado.Motivo));
                cmd.Parameters.Add(new SqlParameter("@MONTO", beBonoEmpleado.Monto));

                rowsAffected = cmd.ExecuteNonQuery();
                beBonoEmpleado.IdBonoEmpleado = int.Parse(cmd.Parameters["@IDBONOEMPLEADO"].Value.ToString());

                return rowsAffected;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Actualizar(BE.BonoEmpleado beBonoEmpleado)
        {
            try
            {
                string sp = "SpTbBonoEmpleadoActualizar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                int rowsAffected = 0;

                cmd.Parameters.Add(new SqlParameter("@IDBONOEMPLEADO", beBonoEmpleado.IdBonoEmpleado));
                cmd.Parameters.Add(new SqlParameter("@FECHA", beBonoEmpleado.Fecha));
                cmd.Parameters.Add(new SqlParameter("@CODIGOEMPLEADO", beBonoEmpleado.CodigoEmpleado));
                cmd.Parameters.Add(new SqlParameter("@IDBONO", beBonoEmpleado.Bono.IdBono));
                cmd.Parameters.Add(new SqlParameter("@MOTIVO", beBonoEmpleado.Motivo));
                cmd.Parameters.Add(new SqlParameter("@MONTO", beBonoEmpleado.Monto));

                rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Eliminar(int idBonoEmpleado)
        {
            try
            {
                string sp = "SpTbBonoEmpleadoEliminar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                int rowsAffected = 0;

                cmd.Parameters.Add(new SqlParameter("@IDBONOEMPLEADO", idBonoEmpleado));

                rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.BonoEmpleado> Listar(int anho, int mes, string codigoEmpleado)
        {
            var lstBeObservaciones = new List<BE.BonoEmpleado>();

            try
            {
                string sp = "SpTbBonoEmpleadoListar";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ANHO", anho));
                    cmd.Parameters.Add(new SqlParameter("@MES", mes));

                    if (codigoEmpleado.Trim().Length == 0)
                        cmd.Parameters.Add(new SqlParameter("@CODIGO", DBNull.Value));
                    else
                        cmd.Parameters.Add(new SqlParameter("@CODIGO", codigoEmpleado));

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var beBonoEmpleado = new BE.BonoEmpleado();

                        beBonoEmpleado.IdBonoEmpleado = reader["IdBonoEmpleado"] == DBNull.Value ? 0 : int.Parse(reader["IdBonoEmpleado"].ToString());
                        beBonoEmpleado.Fecha = reader["Fecha"] == DBNull.Value ? DateTime.Now : DateTime.Parse(reader["Fecha"].ToString());
                        beBonoEmpleado.CodigoEmpleado = reader["CodigoEmpleado"] == DBNull.Value ? "" : reader["CodigoEmpleado"].ToString();
                        beBonoEmpleado.Motivo = reader["Motivo"] == DBNull.Value ? "" : reader["Motivo"].ToString();
                        beBonoEmpleado.Monto = reader["Monto"] == DBNull.Value ? 0.0 : double.Parse(reader["Monto"].ToString());

                        if (reader["idBono"] != DBNull.Value)
                        {
                            int idBono = int.Parse(reader["idBono"].ToString());

                            var beBono = new DA.Bono().Obtener(idBono);
                            if (beBono != null)
                                beBonoEmpleado.Bono = beBono;

                            beBono = null;   
                        }

                        lstBeObservaciones.Add(beBonoEmpleado);
                    }

                }

                return lstBeObservaciones;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        /// <summary>
        /// Validar si existe bonos calcululados para el periodo (año y mes) y tipo de bono
        /// </summary>
        /// <param name="anho">Año de consulta en formato yyyy. Ejm: 2017</param>
        /// <param name="mes">Mes de consulta en rango del 1 al 12. Ejm: 1</param>
        /// <param name="idBono">ID del tipo de bono</param>
        /// <returns></returns>
        public bool ExisteCalculo (int anho, int mes, int idBono)
        {
            int cantidad = 0;

            try
            {
                string sp = "SpTbBonoEmpleadoExisteCalculo";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ANHO", anho));
                    cmd.Parameters.Add(new SqlParameter("@MES", mes));
                    cmd.Parameters.Add(new SqlParameter("@IDBONO", idBono));

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        cantidad = reader["Cantidad"] == DBNull.Value ? 0 : int.Parse(reader["Cantidad"].ToString());
                    }

                }

                return cantidad > 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }

}

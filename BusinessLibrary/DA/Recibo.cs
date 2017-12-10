using BE = ErpCasino.BusinessLibrary.BE;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System;

namespace ErpCasino.BusinessLibrary.DA
{
    public class Recibo
    {

        /// <summary>
        /// Calculo al detalle por dia sobre : 
        /// - Horas asistidas e inasistidas en Minutos
        /// - Horas normales y extras en Minutos
        /// - Minutos de Tardanza
        /// </summary>
        /// <param name="anho">Numero del año</param>
        /// <param name="mes">Numero del mes</param>
        /// <returns></returns>
        public DataTable ListarAsistencias(int anho, int mes)
        {
            try
            {
                string sp = "SpListarAsistenciaCandidato";
                DataTable dt = new DataTable();

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ANHO", anho));
                    cmd.Parameters.Add(new SqlParameter("@MES", mes));

                    SqlDataAdapter dad = new SqlDataAdapter(cmd);
                    dad.Fill(dt);

                    cnn.Close();
                }

                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Lista de sueldos de los candidatos que esten activos
        /// </summary>
        /// <returns></returns>
        public DataTable ListarSueldos()
        {
            DataTable dt = new DataTable();
            try
            {
                string sp = "SpListarSueldosCandidato";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter dad = new SqlDataAdapter(cmd);
                    dad.Fill(dt);

                    cnn.Close();
                }

                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Insertar(ref List<BE.Recibo> lstBeRecibos)
        {
            SqlTransaction tns = null;
            SqlCommand cmd = null;

            try
            {

                int rowsAffected = 0;
                string sp = "SpTbReciboInsertar";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();
                    tns = cnn.BeginTransaction();

                    for (int i = 0; i < lstBeRecibos.Count; i++)
                    {
                        BE.Recibo beRecibo = lstBeRecibos[i];

                        cmd = new SqlCommand(sp, cnn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Transaction = tns;

                        cmd.Parameters.Add(new SqlParameter("@IDRECIBO", beRecibo.IdRecibo));
                        cmd.Parameters["@IDRECIBO"].Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(new SqlParameter("@ANHO", beRecibo.Anho));
                        cmd.Parameters.Add(new SqlParameter("@MES", beRecibo.Mes));
                        cmd.Parameters.Add(new SqlParameter("@CODIGOEMPLEADO", beRecibo.CodigoEmpleado));
                        cmd.Parameters.Add(new SqlParameter("@TIPO", beRecibo.Tipo));
                        cmd.Parameters.Add(new SqlParameter("@CONCEPTO", beRecibo.Concepto));
                        cmd.Parameters.Add(new SqlParameter("@FECHA", beRecibo.Fecha));
                        cmd.Parameters.Add(new SqlParameter("@MONTO", beRecibo.Monto));

                        rowsAffected += cmd.ExecuteNonQuery();
                        lstBeRecibos[i].IdRecibo = int.Parse(cmd.Parameters["@IDRECIBO"].Value.ToString());
                    }

                    if (tns != null)
                        tns.Commit();

                }

                return rowsAffected;

            }
            catch (Exception ex)
            {
                if (tns != null)
                    tns.Rollback();

                throw ex;
            }
        }

        public DataTable Listar(int anho, int mes)
        {
            try
            {
                string sp = "SpTbReciboListar";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter dad = new SqlDataAdapter(cmd);
                    dad.SelectCommand.Parameters.Add(new SqlParameter("@ANHO", anho));
                    dad.SelectCommand.Parameters.Add(new SqlParameter("@MES", mes));

                    DataTable dt = new DataTable();
                    dad.Fill(dt);

                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ResumenExistente(int anho, int mes)
        {
            try
            {
                string sp = "SpTbReciboResumen";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter dad = new SqlDataAdapter(cmd);
                    dad.SelectCommand.Parameters.Add(new SqlParameter("@ANHO", anho));
                    dad.SelectCommand.Parameters.Add(new SqlParameter("@MES", mes));

                    DataTable dt = new DataTable();
                    dad.Fill(dt);

                    return dt;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ResumenCalculado(int anho, int mes)
        {
            try
            {
                string sp = "SpListarReciboResumen";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter dad = new SqlDataAdapter(cmd);
                    dad.SelectCommand.Parameters.Add(new SqlParameter("@ANHO", anho));
                    dad.SelectCommand.Parameters.Add(new SqlParameter("@MES", mes));

                    DataTable dt = new DataTable();
                    dad.Fill(dt);

                    return dt;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Detalle(int anho, int mes, string codigoEmpleado = "")
        {
            try
            {
                string sp = "SpListarReciboDetalle";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter dad = new SqlDataAdapter(cmd);
                    dad.SelectCommand.Parameters.Add(new SqlParameter("@ANHO", anho));
                    dad.SelectCommand.Parameters.Add(new SqlParameter("@MES", mes));
                    if (codigoEmpleado == "")
                        dad.SelectCommand.Parameters.Add(new SqlParameter("@CODIGOEMPLEADO", DBNull.Value));
                    else
                        dad.SelectCommand.Parameters.Add(new SqlParameter("@CODIGOEMPLEADO", codigoEmpleado));

                    DataTable dt = new DataTable();
                    dad.Fill(dt);

                    return dt;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }

}

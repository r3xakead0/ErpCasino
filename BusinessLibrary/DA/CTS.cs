using BE = ErpCasino.BusinessLibrary.BE;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System;

namespace ErpCasino.BusinessLibrary.DA
{
    public class CTS
    {

        public bool Insertar(ref BE.CTS beCTS)
        {
            try
            {
                string sp = "SpTbCtsInsertar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@IDCTS", beCTS.IdCts));
                cmd.Parameters["@IDCTS"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new SqlParameter("@CODIGOEMPLEADO", beCTS.CodigoEmpleado));
                cmd.Parameters.Add(new SqlParameter("@MONTO", beCTS.Monto));
                cmd.Parameters.Add(new SqlParameter("@FECHAPERIODOINICIAL", beCTS.FechaPeriodoInicial));
                cmd.Parameters.Add(new SqlParameter("@FECHAPERIODOFINAL", beCTS.FechaPeriodoFinal));
                cmd.Parameters.Add(new SqlParameter("@FECHADEPOSITO", beCTS.FechaDeposito));

                int rowsAffected = 0;
                rowsAffected = cmd.ExecuteNonQuery();
                beCTS.IdCts = int.Parse(cmd.Parameters["@IDCTS"].Value.ToString());

                return (rowsAffected > 0);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Actualizar(BE.CTS beCTS)
        {
            try
            {
                string sp = "SpTbCtsActualizar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@IDCTS", beCTS.IdCts));
                cmd.Parameters.Add(new SqlParameter("@CODIGOEMPLEADO", beCTS.CodigoEmpleado));
                cmd.Parameters.Add(new SqlParameter("@MONTO", beCTS.Monto));
                cmd.Parameters.Add(new SqlParameter("@FECHAPERIODOINICIAL", beCTS.FechaPeriodoInicial));
                cmd.Parameters.Add(new SqlParameter("@FECHAPERIODOFINAL", beCTS.FechaPeriodoFinal));
                cmd.Parameters.Add(new SqlParameter("@FECHADEPOSITO", beCTS.FechaDeposito));

                int rowsAffected = 0;
                rowsAffected = cmd.ExecuteNonQuery();

                return (rowsAffected > 0);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Eliminar(int idCts)
        {
            try
            {
                string sp = "SpTbCtsEliminar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@IDCTS", idCts));

                int rowsAffected = 0;
                rowsAffected = cmd.ExecuteNonQuery();

                return (rowsAffected > 0);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.CTS> Listar()
        {
            var lstCts = new List<BE.CTS>();
            try
            {
                string sp = "SpTbCtsListar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var beCts = new BE.CTS();

                    beCts.IdCts = int.Parse(reader["IdCts"].ToString());
                    beCts.CodigoEmpleado = reader["CodigoEmpleado"].ToString();
                    beCts.Monto = double.Parse(reader["Monto"].ToString());
                    beCts.FechaPeriodoInicial = DateTime.Parse(reader["FechaPeriodoInicial"].ToString());
                    beCts.FechaPeriodoFinal = DateTime.Parse(reader["FechaPeriodoFinal"].ToString());
                    beCts.FechaDeposito = DateTime.Parse(reader["FechaDeposito"].ToString());

                    lstCts.Add(beCts);
                }

                return lstCts;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BE.CTS Obtener(int idCts)
        {
            BE.CTS beCts = null;
            try
            {
                string sp = "SpTbCtsObtener";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@IDCTS", idCts));

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    beCts = new BE.CTS();

                    beCts.IdCts = int.Parse(reader["IdCts"].ToString());
                    beCts.CodigoEmpleado = reader["CodigoEmpleado"].ToString();
                    beCts.Monto = double.Parse(reader["Monto"].ToString());
                    beCts.FechaPeriodoInicial = DateTime.Parse(reader["FechaPeriodoInicial"].ToString());
                    beCts.FechaPeriodoFinal = DateTime.Parse(reader["FechaPeriodoFinal"].ToString());
                    beCts.FechaDeposito = DateTime.Parse(reader["FechaDeposito"].ToString());
                }

                return beCts;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}

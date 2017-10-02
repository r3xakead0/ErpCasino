using BE = ErpCasino.BusinessLibrary.BE;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace ErpCasino.BusinessLibrary.DA
{

    public class ClsDaTbEmpleadoTelefono
    {

        public void Cargar(ref BE.ClsBeTbEmpleadoTelefono beEmpleadoTelefono, DataRow dr)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public List<BE.ClsBeTbEmpleadoTelefono> Listar(int IdEmpleado)
        {
            var lstBeEmpleadoTelefonos = new List<BE.ClsBeTbEmpleadoTelefono>();
            try
            {
                string sp = "SpTbEmpleadoTelefonoListar";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IDEMPLEADO", IdEmpleado));

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var beCandidatoTelefono = new BE.ClsBeTbEmpleadoTelefono();

                        beCandidatoTelefono.IdEmpleadoTelefono = reader["IdEmpleadoTelefono"] == DBNull.Value ? 0 : int.Parse(reader["IdEmpleadoTelefono"].ToString());
                        beCandidatoTelefono.IdEmpleado = reader["IdEmpleado"] == DBNull.Value ? 0 : int.Parse(reader["IdEmpleado"].ToString());
                        beCandidatoTelefono.CodTipoTelefono = reader["CodTipoTelefono"] == DBNull.Value ? "" : reader["CodTipoTelefono"].ToString();
                        beCandidatoTelefono.Numero = reader["Numero"] == DBNull.Value ? "" : reader["Numero"].ToString();

                        lstBeEmpleadoTelefonos.Add(beCandidatoTelefono);
                    }
                }

                return lstBeEmpleadoTelefonos;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}

using BE = ErpCasino.BusinessLibrary.BE;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace ErpCasino.BusinessLibrary.DA
{
    public class Empresa
    {

        public int Insertar(ref BE.Empresa beEmpresa)
        {
            try
            {
                int rowsAffected = 0;
                string sp = "SpTbEmpresaInsertar";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@IDEMPRESA", beEmpresa.IdEmpresa));
                    cmd.Parameters["@IDEMPRESA"].Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(new SqlParameter("@NOMBRECOMERCIAL", beEmpresa.NombreComercial));
                    cmd.Parameters.Add(new SqlParameter("@RAZONSOCIAL", beEmpresa.RazonSocial));
                    cmd.Parameters.Add(new SqlParameter("@RUC", beEmpresa.RUC));
                    cmd.Parameters.Add(new SqlParameter("@DOMICILIOFISCAL", beEmpresa.DomicilioFiscal));
                    cmd.Parameters.Add(new SqlParameter("@CODUBIGEO", beEmpresa.Ubigeo.Codigo));

                    rowsAffected = cmd.ExecuteNonQuery();
                    beEmpresa.IdEmpresa = int.Parse(cmd.Parameters["@IDEMPRESA"].Value.ToString());

                }

                return rowsAffected;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Actualizar(BE.Empresa beEmpresa)
        {
            try
            {
                int rowsAffected = 0;
                string sp = "SpTbEmpresaActualizar";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@IDEMPRESA", beEmpresa.IdEmpresa));
                    cmd.Parameters.Add(new SqlParameter("@NOMBRECOMERCIAL", beEmpresa.NombreComercial));
                    cmd.Parameters.Add(new SqlParameter("@RAZONSOCIAL", beEmpresa.RazonSocial));
                    cmd.Parameters.Add(new SqlParameter("@RUC", beEmpresa.RUC));
                    cmd.Parameters.Add(new SqlParameter("@DOMICILIOFISCAL", beEmpresa.DomicilioFiscal));
                    cmd.Parameters.Add(new SqlParameter("@CODUBIGEO", beEmpresa.Ubigeo.Codigo));

                    rowsAffected = cmd.ExecuteNonQuery();
                    
                }

                return rowsAffected;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public BE.Empresa Obtener()
        {
            BE.Empresa beEmpresa = null;

            try
            {
                string sp = "SpTbEmpresaObtener";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        beEmpresa = new BE.Empresa();

                        beEmpresa.IdEmpresa = reader["IdEmpresa"] == DBNull.Value ? 0 : int.Parse(reader["IdEmpresa"].ToString());
                        beEmpresa.NombreComercial = reader["NombreComercial"] == DBNull.Value ? "" : reader["NombreComercial"].ToString();
                        beEmpresa.RazonSocial = reader["RazonSocial"] == DBNull.Value ? "" : reader["RazonSocial"].ToString();
                        beEmpresa.RUC = reader["RUC"] == DBNull.Value ? "" : reader["RUC"].ToString();
                        beEmpresa.DomicilioFiscal = reader["DomicilioFiscal"] == DBNull.Value ? "" : reader["DomicilioFiscal"].ToString();

                        beEmpresa.Ubigeo = new BE.Ubigeo()
                        {
                            Codigo = reader["CodUbigeo"] == DBNull.Value ? "" : reader["CodUbigeo"].ToString()
                        };
                    }
                }

                return beEmpresa;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}

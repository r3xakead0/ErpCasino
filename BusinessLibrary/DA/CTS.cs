using BE = ErpCasino.BusinessLibrary.BE;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System;

namespace ErpCasino.BusinessLibrary.DA
{
    public class CTS
    {

        public int Insertar(ref BE.CTS beCTS)
        {
            try
            {
                string sp = "SpTbCtsInsertar";
                int rowsAffected = 0;

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {

                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@IDCTS", beCTS.IdCts));
                    cmd.Parameters["@IDCTS"].Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(new SqlParameter("@ANHO", beCTS.Anho));
                    cmd.Parameters.Add(new SqlParameter("@PERIODO", beCTS.Periodo));
                    cmd.Parameters.Add(new SqlParameter("@PERIODOFECHAINICIAL", beCTS.PeriodoFechaInicial));
                    cmd.Parameters.Add(new SqlParameter("@PERIODOFECHAFINAL", beCTS.PeriodoFechaFinal));
                    cmd.Parameters.Add(new SqlParameter("@EMPLEADOCODIGO", beCTS.EmpleadoCodigo));
                    cmd.Parameters.Add(new SqlParameter("@EMPLEADOFECHAINGRESO", beCTS.EmpleadoFechaIngreso));
                    cmd.Parameters.Add(new SqlParameter("@EMPLEADOSUELDO", beCTS.EmpleadoSueldo));
                    cmd.Parameters.Add(new SqlParameter("@EMPLEADOASIGFAM", beCTS.EmpleadoAsigFam));
                    cmd.Parameters.Add(new SqlParameter("@TOTALBONIFICACION", beCTS.TotalBonificacion));
                    cmd.Parameters.Add(new SqlParameter("@TOTALHORASEXTRAS", beCTS.TotalHorasExtras));
                    cmd.Parameters.Add(new SqlParameter("@TOTALGRATIFICACION", beCTS.TotalGratificacion));
                    cmd.Parameters.Add(new SqlParameter("@PROMEDIOBONIFICACION", beCTS.PromedioBonificacion));
                    cmd.Parameters.Add(new SqlParameter("@PROMEDIOHORASEXTRAS", beCTS.PromedioHorasExtras));
                    cmd.Parameters.Add(new SqlParameter("@PROMEDIOGRATIFICACION", beCTS.PromedioGratificacion));
                    cmd.Parameters.Add(new SqlParameter("@COMPUTABLETOTAL", beCTS.ComputableTotal));
                    cmd.Parameters.Add(new SqlParameter("@COMPUTABLEFECHAINICIAL", beCTS.ComputableFechaInicial));
                    cmd.Parameters.Add(new SqlParameter("@COMPUTABLEFECHAFINAL", beCTS.ComputableFechaFinal));
                    cmd.Parameters.Add(new SqlParameter("@COMPUTABLEMESES", beCTS.ComputableMeses));
                    cmd.Parameters.Add(new SqlParameter("@COMPUTABLEDIAS", beCTS.ComputableDias));
                    cmd.Parameters.Add(new SqlParameter("@COMPUTABLEPAGAR", beCTS.ComputablePagar));
                    cmd.Parameters.Add(new SqlParameter("@BANCOID", beCTS.Banco.IdBanco));
                    cmd.Parameters.Add(new SqlParameter("@BANCOCUENTA", beCTS.Cuenta));
                    cmd.Parameters.Add(new SqlParameter("@DEPOSITOFECHA", beCTS.DepositoFecha));
                    cmd.Parameters.Add(new SqlParameter("@DEPOSITOMONTO", beCTS.DepositoMonto));
                    cmd.Parameters.Add(new SqlParameter("@DEPOSITOOPERACION", beCTS.DepositoOperacion));

                    rowsAffected = cmd.ExecuteNonQuery();
                    beCTS.IdCts = int.Parse(cmd.Parameters["@IDCTS"].Value.ToString());
                }

                return rowsAffected;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Actualizar(BE.CTS beCTS)
        {
            try
            {
                string sp = "SpTbCtsActualizar";
                int rowsAffected = 0;

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@IDCTS", beCTS.IdCts));
                    cmd.Parameters.Add(new SqlParameter("@ANHO", beCTS.Anho));
                    cmd.Parameters.Add(new SqlParameter("@PERIODO", beCTS.Periodo));
                    cmd.Parameters.Add(new SqlParameter("@PERIODOFECHAINICIAL", beCTS.PeriodoFechaInicial));
                    cmd.Parameters.Add(new SqlParameter("@PERIODOFECHAFINAL", beCTS.PeriodoFechaFinal));
                    cmd.Parameters.Add(new SqlParameter("@EMPLEADOCODIGO", beCTS.EmpleadoCodigo));
                    cmd.Parameters.Add(new SqlParameter("@EMPLEADOFECHAINGRESO", beCTS.EmpleadoFechaIngreso));
                    cmd.Parameters.Add(new SqlParameter("@EMPLEADOSUELDO", beCTS.EmpleadoSueldo));
                    cmd.Parameters.Add(new SqlParameter("@EMPLEADOASIGFAM", beCTS.EmpleadoAsigFam));
                    cmd.Parameters.Add(new SqlParameter("@TOTALBONIFICACION", beCTS.TotalBonificacion));
                    cmd.Parameters.Add(new SqlParameter("@TOTALHORASEXTRAS", beCTS.TotalHorasExtras));
                    cmd.Parameters.Add(new SqlParameter("@TOTALGRATIFICACION", beCTS.TotalGratificacion));
                    cmd.Parameters.Add(new SqlParameter("@PROMEDIOBONIFICACION", beCTS.PromedioBonificacion));
                    cmd.Parameters.Add(new SqlParameter("@PROMEDIOHORASEXTRAS", beCTS.PromedioHorasExtras));
                    cmd.Parameters.Add(new SqlParameter("@PROMEDIOGRATIFICACION", beCTS.PromedioGratificacion));
                    cmd.Parameters.Add(new SqlParameter("@COMPUTABLETOTAL", beCTS.ComputableTotal));
                    cmd.Parameters.Add(new SqlParameter("@COMPUTABLEFECHAINICIAL", beCTS.ComputableFechaInicial));
                    cmd.Parameters.Add(new SqlParameter("@COMPUTABLEFECHAFINAL", beCTS.ComputableFechaFinal));
                    cmd.Parameters.Add(new SqlParameter("@COMPUTABLEMESES", beCTS.ComputableMeses));
                    cmd.Parameters.Add(new SqlParameter("@COMPUTABLEDIAS", beCTS.ComputableDias));
                    cmd.Parameters.Add(new SqlParameter("@COMPUTABLEPAGAR", beCTS.ComputablePagar));
                    cmd.Parameters.Add(new SqlParameter("@BANCOID", beCTS.Banco.IdBanco));
                    cmd.Parameters.Add(new SqlParameter("@BANCOCUENTA", beCTS.Cuenta));
                    cmd.Parameters.Add(new SqlParameter("@DEPOSITOFECHA", beCTS.DepositoFecha));
                    cmd.Parameters.Add(new SqlParameter("@DEPOSITOMONTO", beCTS.DepositoMonto));
                    cmd.Parameters.Add(new SqlParameter("@DEPOSITOOPERACION", beCTS.DepositoOperacion));

                    rowsAffected = cmd.ExecuteNonQuery();
                }

                return rowsAffected;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Eliminar(int idCTS)
        {
            try
            {
                string sp = "SpTbCtsEliminar";
                int rowsAffected = 0;

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@IDCTS", idCTS));

                    rowsAffected = cmd.ExecuteNonQuery();

                }

                return rowsAffected;
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

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {

                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var beCTS = new BE.CTS();

                        beCTS.IdCts = reader["IdCts"] == DBNull.Value ? 0 : int.Parse(reader["IdCts"].ToString());
                        beCTS.Anho = reader["Anho"] == DBNull.Value ? 0 : int.Parse(reader["Anho"].ToString());
                        beCTS.Periodo = reader["Periodo"] == DBNull.Value ? 0 : int.Parse(reader["Periodo"].ToString());
                        beCTS.PeriodoFechaInicial = reader["PeriodoFechaInicial"] == DBNull.Value ? DateTime.Now : DateTime.Parse(reader["PeriodoFechaInicial"].ToString());
                        beCTS.PeriodoFechaFinal = reader["PeriodoFechaFinal"] == DBNull.Value ? DateTime.Now : DateTime.Parse(reader["PeriodoFechaFinal"].ToString());
                        beCTS.EmpleadoCodigo = reader["EmpleadoCodigo"] == DBNull.Value ? "" : reader["EmpleadoCodigo"].ToString();
                        beCTS.EmpleadoFechaIngreso = reader["EmpleadoFechaIngreso"] == DBNull.Value ? DateTime.Now : DateTime.Parse(reader["EmpleadoFechaIngreso"].ToString());
                        beCTS.EmpleadoSueldo = reader["EmpleadoSueldo"] == DBNull.Value ? 0.0 : double.Parse(reader["EmpleadoSueldo"].ToString());
                        beCTS.EmpleadoAsigFam = reader["EmpleadoAsigFam"] == DBNull.Value ? 0.0 : double.Parse(reader["EmpleadoAsigFam"].ToString());
                        beCTS.TotalBonificacion = reader["TotalBonificacion"] == DBNull.Value ? 0.0 : double.Parse(reader["TotalBonificacion"].ToString());
                        beCTS.TotalHorasExtras = reader["TotalHorasExtras"] == DBNull.Value ? 0.0 : double.Parse(reader["TotalHorasExtras"].ToString());
                        beCTS.TotalGratificacion = reader["TotalGratificacion"] == DBNull.Value ? 0.0 : double.Parse(reader["TotalGratificacion"].ToString());
                        beCTS.PromedioBonificacion = reader["PromedioBonificacion"] == DBNull.Value ? 0.0 : double.Parse(reader["PromedioBonificacion"].ToString());
                        beCTS.PromedioHorasExtras = reader["PromedioHorasExtras"] == DBNull.Value ? 0.0 : double.Parse(reader["PromedioHorasExtras"].ToString());
                        beCTS.PromedioGratificacion = reader["PromedioGratificacion"] == DBNull.Value ? 0.0 : double.Parse(reader["PromedioGratificacion"].ToString());
                        beCTS.ComputableTotal = reader["ComputableTotal"] == DBNull.Value ? 0.0 : double.Parse(reader["ComputableTotal"].ToString());
                        beCTS.ComputableFechaInicial = reader["ComputableFechaInicial"] == DBNull.Value ? DateTime.Now : DateTime.Parse(reader["ComputableFechaInicial"].ToString());
                        beCTS.ComputableFechaFinal = reader["ComputableFechaFinal"] == DBNull.Value ? DateTime.Now : DateTime.Parse(reader["ComputableFechaFinal"].ToString());
                        beCTS.ComputableMeses = reader["ComputableMeses"] == DBNull.Value ? 0 : int.Parse(reader["ComputableMeses"].ToString());
                        beCTS.ComputableDias = reader["ComputableDias"] == DBNull.Value ? 0 : int.Parse(reader["ComputableDias"].ToString());
                        beCTS.ComputablePagar = reader["ComputablePagar"] == DBNull.Value ? 0.0 : double.Parse(reader["ComputablePagar"].ToString());

                        beCTS.Banco = new BE.Banco()
                        {
                            IdBanco = reader["BancoId"] == DBNull.Value ? 0 : int.Parse(reader["BancoId"].ToString()),
                        };

                        beCTS.Cuenta = reader["BancoCuenta"] == DBNull.Value ? "" : reader["BancoCuenta"].ToString();

                        beCTS.DepositoFecha = reader["DepositoFecha"] == DBNull.Value ? DateTime.Now : DateTime.Parse(reader["DepositoFecha"].ToString());
                        beCTS.DepositoMonto = reader["DepositoMonto"] == DBNull.Value ? 0.0 : double.Parse(reader["DepositoMonto"].ToString());
                        beCTS.DepositoOperacion = reader["DepositoOperacion"] == DBNull.Value ? "" : reader["DepositoOperacion"].ToString();

                        lstCts.Add(beCTS);
                    }

                }
                    
                return lstCts;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BE.CTS Obtener(int idCTS)
        {
            BE.CTS beCTS = null;
            try
            {
                string sp = "SpTbCtsObtener";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IDCTS", idCTS));

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        beCTS = new BE.CTS();

                        beCTS.IdCts = reader["IdCts"] == DBNull.Value ? 0 : int.Parse(reader["IdCts"].ToString());
                        beCTS.Anho = reader["Anho"] == DBNull.Value ? 0 : int.Parse(reader["Anho"].ToString());
                        beCTS.Periodo = reader["Periodo"] == DBNull.Value ? 0 : int.Parse(reader["Periodo"].ToString());
                        beCTS.PeriodoFechaInicial = reader["PeriodoFechaInicial"] == DBNull.Value ? DateTime.Now : DateTime.Parse(reader["PeriodoFechaInicial"].ToString());
                        beCTS.PeriodoFechaFinal = reader["PeriodoFechaFinal"] == DBNull.Value ? DateTime.Now : DateTime.Parse(reader["PeriodoFechaFinal"].ToString());
                        beCTS.EmpleadoCodigo = reader["EmpleadoCodigo"] == DBNull.Value ? "" : reader["EmpleadoCodigo"].ToString();
                        beCTS.EmpleadoFechaIngreso = reader["EmpleadoFechaIngreso"] == DBNull.Value ? DateTime.Now : DateTime.Parse(reader["EmpleadoFechaIngreso"].ToString());
                        beCTS.EmpleadoSueldo = reader["EmpleadoSueldo"] == DBNull.Value ? 0.0 : double.Parse(reader["EmpleadoSueldo"].ToString());
                        beCTS.EmpleadoAsigFam = reader["EmpleadoAsigFam"] == DBNull.Value ? 0.0 : double.Parse(reader["EmpleadoAsigFam"].ToString());
                        beCTS.TotalBonificacion = reader["TotalBonificacion"] == DBNull.Value ? 0.0 : double.Parse(reader["TotalBonificacion"].ToString());
                        beCTS.TotalHorasExtras = reader["TotalHorasExtras"] == DBNull.Value ? 0.0 : double.Parse(reader["TotalHorasExtras"].ToString());
                        beCTS.TotalGratificacion = reader["TotalGratificacion"] == DBNull.Value ? 0.0 : double.Parse(reader["TotalGratificacion"].ToString());
                        beCTS.PromedioBonificacion = reader["PromedioBonificacion"] == DBNull.Value ? 0.0 : double.Parse(reader["PromedioBonificacion"].ToString());
                        beCTS.PromedioHorasExtras = reader["PromedioHorasExtras"] == DBNull.Value ? 0.0 : double.Parse(reader["PromedioHorasExtras"].ToString());
                        beCTS.PromedioGratificacion = reader["PromedioGratificacion"] == DBNull.Value ? 0.0 : double.Parse(reader["PromedioGratificacion"].ToString());
                        beCTS.ComputableTotal = reader["ComputableTotal"] == DBNull.Value ? 0.0 : double.Parse(reader["ComputableTotal"].ToString());
                        beCTS.ComputableFechaInicial = reader["ComputableFechaInicial"] == DBNull.Value ? DateTime.Now : DateTime.Parse(reader["ComputableFechaInicial"].ToString());
                        beCTS.ComputableFechaFinal = reader["ComputableFechaFinal"] == DBNull.Value ? DateTime.Now : DateTime.Parse(reader["ComputableFechaFinal"].ToString());
                        beCTS.ComputableMeses = reader["ComputableMeses"] == DBNull.Value ? 0 : int.Parse(reader["ComputableMeses"].ToString());
                        beCTS.ComputableDias = reader["ComputableDias"] == DBNull.Value ? 0 : int.Parse(reader["ComputableDias"].ToString());
                        beCTS.ComputablePagar = reader["ComputablePagar"] == DBNull.Value ? 0.0 : double.Parse(reader["ComputablePagar"].ToString());

                        beCTS.Banco = new BE.Banco()
                        {
                            IdBanco = reader["BancoId"] == DBNull.Value ? 0 : int.Parse(reader["BancoId"].ToString()),
                        };

                        beCTS.Cuenta = reader["BancoCuenta"] == DBNull.Value ? "" : reader["BancoCuenta"].ToString();

                        beCTS.DepositoFecha = reader["DepositoFecha"] == DBNull.Value ? DateTime.Now : DateTime.Parse(reader["DepositoFecha"].ToString());
                        beCTS.DepositoMonto = reader["DepositoMonto"] == DBNull.Value ? 0.0 : double.Parse(reader["DepositoMonto"].ToString());
                        beCTS.DepositoOperacion = reader["DepositoOperacion"] == DBNull.Value ? "" : reader["DepositoOperacion"].ToString();

                    }
                }

                return beCTS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}

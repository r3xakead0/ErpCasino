using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using BE = ErpCasino.BusinessLibrary.BE;

namespace ErpCasino.BusinessLibrary.DA
{
    internal class Vacacion
    {
        internal int Eliminar(int idVacacion)
        {
            try
            {
                string sp = "SpTbVacacionEliminar";
                int rowsAffected = 0;

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IDVACACION", idVacacion));

                    rowsAffected += cmd.ExecuteNonQuery();
                }

                return rowsAffected;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Lista las vacaciones sin el detalle y filtradas por año y mes
        /// </summary>
        /// <param name="anho">Año en formato de 4 digitos. Ejm:  2017</param>
        /// <param name="mes">Mes en el rango de 1 al 12. Ejm: 10</param>
        /// <returns></returns>
        internal List<BE.Vacacion> Listar(int anho, int mes)
        {
            try
            {
                var lstBeVacaciones = new List<BE.Vacacion>();

                string sp = "SpTbVacacionListar";

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
                        var beVacacion = new BE.Vacacion();

                        beVacacion.IdVacacion = reader["IdVacacion"] == DBNull.Value ? 0 : int.Parse(reader["IdVacacion"].ToString());
                        beVacacion.PeriodoFechaInicial = reader["PeriodoFechaInicial"] == DBNull.Value ? DateTime.Now : DateTime.Parse(reader["PeriodoFechaInicial"].ToString());
                        beVacacion.PeriodoFechaFinal = reader["PeriodoFechaFinal"] == DBNull.Value ? DateTime.Now : DateTime.Parse(reader["PeriodoFechaFinal"].ToString());
                        beVacacion.FechaInicial = reader["FechaInicial"] == DBNull.Value ? DateTime.Now : DateTime.Parse(reader["FechaInicial"].ToString());
                        beVacacion.FechaFinal = reader["FechaFinal"] == DBNull.Value ? DateTime.Now : DateTime.Parse(reader["FechaFinal"].ToString());
                        beVacacion.Dias = reader["Dias"] == DBNull.Value ? 0 : int.Parse(reader["Dias"].ToString());
                        beVacacion.CodigoEmpleado = reader["CodigoEmpleado"] == DBNull.Value ? "" : reader["CodigoEmpleado"].ToString();
                        beVacacion.Sueldo = reader["Sueldo"] == DBNull.Value ? 0.0 : double.Parse(reader["Sueldo"].ToString());
                        beVacacion.AsignacionFamiliar = reader["AsignacionFamiliar"] == DBNull.Value ? 0.0 : double.Parse(reader["AsignacionFamiliar"].ToString());
                        beVacacion.PromedioHorasExtras = reader["PromedioHorasExtras"] == DBNull.Value ? 0.0 : double.Parse(reader["PromedioHorasExtras"].ToString());
                        beVacacion.PromedioBonificacion = reader["PromedioBonificacion"] == DBNull.Value ? 0.0 : double.Parse(reader["PromedioBonificacion"].ToString());
                        beVacacion.TotalBruto = reader["TotalBruto"] == DBNull.Value ? 0.0 : double.Parse(reader["TotalBruto"].ToString());
                        
                        int idAfpComision = reader["idAfpComision"] == DBNull.Value ? 0 : int.Parse(reader["idAfpComision"].ToString());
                        if (idAfpComision > 0)
                        {
                            var beAfpComision = new DA.AfpComision().Obtener(idAfpComision, anho, mes);
                            beVacacion.ComisionAfp = beAfpComision;

                            beVacacion.TipoComisionAfp = reader["ComisionAfp"] == DBNull.Value ? "" : reader["ComisionAfp"].ToString();
                        }

                        int idOnpComision = reader["idOnpComision"] == DBNull.Value ? 0 : int.Parse(reader["idOnpComision"].ToString());
                        if (idOnpComision > 0)
                        {
                            var beOnpComision = new DA.OnpComision().Obtener(anho, mes);
                            beVacacion.ComisionOnp = beOnpComision;
                        }

                        beVacacion.PensionMonto = reader["PensionMonto"] == DBNull.Value ? 0.0 : double.Parse(reader["PensionMonto"].ToString());
                        beVacacion.RetencionJudicialMonto = reader["RetencionJudicialMonto"] == DBNull.Value ? 0.0 : double.Parse(reader["RetencionJudicialMonto"].ToString());
                        beVacacion.TotalDescuento = reader["TotalDescuento"] == DBNull.Value ? 0.0 : double.Parse(reader["TotalDescuento"].ToString());
                        beVacacion.TotalNeto = reader["TotalNeto"] == DBNull.Value ? 0.0 : double.Parse(reader["TotalNeto"].ToString());

                        lstBeVacaciones.Add(beVacacion);
                    }
                }

                return lstBeVacaciones;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<BE.VacacionDetalle> ListarDetalle(int idVacacion)
        {
            try
            {
                var lstBeDetallesVacacion = new List<BE.VacacionDetalle>();

                string sp = "SpTbVacacionDetalleListar";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IDVACACION", idVacacion));

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var beVacacionDetalle = new BE.VacacionDetalle();

                        beVacacionDetalle.IdVacacionDetalle = reader["IdVacacionDetalle"] == DBNull.Value ? 0 : int.Parse(reader["IdVacacionDetalle"].ToString());
                        beVacacionDetalle.Numero = reader["Numero"] == DBNull.Value ? 0 : int.Parse(reader["Numero"].ToString());
                        beVacacionDetalle.Anho = reader["Anho"] == DBNull.Value ? 0 : int.Parse(reader["Anho"].ToString());
                        beVacacionDetalle.Mes = reader["Mes"] == DBNull.Value ? 0 : int.Parse(reader["Mes"].ToString());
                        beVacacionDetalle.HorasExtrasMonto = reader["HorasExtrasMonto"] == DBNull.Value ? 0.0 : double.Parse(reader["HorasExtrasMonto"].ToString());
                        beVacacionDetalle.BonificacionMonto = reader["BonificacionMonto"] == DBNull.Value ? 0.0 : double.Parse(reader["BonificacionMonto"].ToString());

                        lstBeDetallesVacacion.Add(beVacacionDetalle);
                    }
                }

                return lstBeDetallesVacacion;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal int Insertar(ref BE.Vacacion beVacacion)
        {
            SqlTransaction tns = null;

            try
            {
                string sp = "SpTbVacacionInsertar";
                int rowsAffected = 0;

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    tns = cnn.BeginTransaction();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Transaction = tns;

                    cmd.Parameters.Add(new SqlParameter("@IDVACACION", beVacacion.IdVacacion));
                    cmd.Parameters["@IDVACACION"].Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(new SqlParameter("@PERIODOFECHAINICIAL", beVacacion.PeriodoFechaInicial));
                    cmd.Parameters.Add(new SqlParameter("@PERIODOFECHAFINAL", beVacacion.PeriodoFechaFinal));
                    cmd.Parameters.Add(new SqlParameter("@FECHAINICIAL", beVacacion.FechaInicial));
                    cmd.Parameters.Add(new SqlParameter("@FECHAFINAL", beVacacion.FechaFinal));
                    cmd.Parameters.Add(new SqlParameter("@DIAS", beVacacion.Dias));
                    cmd.Parameters.Add(new SqlParameter("@CODIGOEMPLEADO", beVacacion.CodigoEmpleado));
                    cmd.Parameters.Add(new SqlParameter("@SUELDO", beVacacion.Sueldo));
                    cmd.Parameters.Add(new SqlParameter("@ASIGNACIONFAMILIAR", beVacacion.AsignacionFamiliar));
                    cmd.Parameters.Add(new SqlParameter("@PROMEDIOHORASEXTRAS", beVacacion.PromedioHorasExtras));
                    cmd.Parameters.Add(new SqlParameter("@PROMEDIOBONIFICACION", beVacacion.PromedioBonificacion));
                    cmd.Parameters.Add(new SqlParameter("@TOTALBRUTO", beVacacion.TotalBruto));

                    if (beVacacion.ComisionAfp != null)
                    {
                        cmd.Parameters.Add(new SqlParameter("@IDAFPCOMISION", beVacacion.ComisionAfp.IdAfpComision));
                        cmd.Parameters.Add(new SqlParameter("@COMISIONAFP", beVacacion.TipoComisionAfp));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("@IDAFPCOMISION", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@COMISIONAFP", DBNull.Value));
                    }

                    if (beVacacion.ComisionOnp != null)
                    {
                        cmd.Parameters.Add(new SqlParameter("@IDONPCOMISION", beVacacion.ComisionOnp.IdOnpComision));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("@IDONPCOMISION", DBNull.Value));
                    }

                    cmd.Parameters.Add(new SqlParameter("@PENSIONMONTO", beVacacion.PensionMonto));
                    cmd.Parameters.Add(new SqlParameter("@RETENCIONJUDICIALMONTO", beVacacion.RetencionJudicialMonto));
                    cmd.Parameters.Add(new SqlParameter("@TOTALDESCUENTO", beVacacion.TotalDescuento));
                    cmd.Parameters.Add(new SqlParameter("@TOTALNETO", beVacacion.TotalNeto));

                    rowsAffected += cmd.ExecuteNonQuery();
                    beVacacion.IdVacacion = int.Parse(cmd.Parameters["@IDVACACION"].Value.ToString());

                    foreach (BE.VacacionDetalle beVacacionDetalle in beVacacion.Detalle)
                    {

                        sp = "SpTbVacacionDetalleInsertar";

                        cmd = new SqlCommand(sp, cnn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Transaction = tns;

                        cmd.Parameters.Add(new SqlParameter("@IDVACACIONDETALLE", beVacacionDetalle.IdVacacionDetalle));
                        cmd.Parameters["@IDVACACIONDETALLE"].Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(new SqlParameter("@IDVACACION", beVacacion.IdVacacion));
                        cmd.Parameters.Add(new SqlParameter("@NUMERO", beVacacionDetalle.Numero));
                        cmd.Parameters.Add(new SqlParameter("@ANHO", beVacacionDetalle.Anho));
                        cmd.Parameters.Add(new SqlParameter("@MES", beVacacionDetalle.Mes));
                        cmd.Parameters.Add(new SqlParameter("@HORASEXTRASMONTO", beVacacionDetalle.HorasExtrasMonto));
                        cmd.Parameters.Add(new SqlParameter("@BONIFICACIONMONTO", beVacacionDetalle.BonificacionMonto));

                        rowsAffected += cmd.ExecuteNonQuery();
                        beVacacionDetalle.IdVacacionDetalle = int.Parse(cmd.Parameters["@IDVACACIONDETALLE"].Value.ToString());

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

        internal BE.Vacacion Obtener(int idVacacion)
        {
            BE.Vacacion beVacacion = null;
            try
            {

                string sp = "SpTbVacacionObtener";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IDVACACION", idVacacion));

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        beVacacion = new BE.Vacacion();

                        beVacacion.IdVacacion = reader["IdVacacion"] == DBNull.Value ? 0 : int.Parse(reader["IdVacacion"].ToString());
                        beVacacion.PeriodoFechaInicial = reader["PeriodoFechaInicial"] == DBNull.Value ? DateTime.Now : DateTime.Parse(reader["PeriodoFechaInicial"].ToString());
                        beVacacion.PeriodoFechaFinal = reader["PeriodoFechaFinal"] == DBNull.Value ? DateTime.Now : DateTime.Parse(reader["PeriodoFechaFinal"].ToString());
                        beVacacion.FechaInicial = reader["FechaInicial"] == DBNull.Value ? DateTime.Now : DateTime.Parse(reader["FechaInicial"].ToString());
                        beVacacion.FechaFinal = reader["FechaFinal"] == DBNull.Value ? DateTime.Now : DateTime.Parse(reader["FechaFinal"].ToString());
                        beVacacion.Dias = reader["Dias"] == DBNull.Value ? 0 : int.Parse(reader["Dias"].ToString());
                        beVacacion.CodigoEmpleado = reader["CodigoEmpleado"] == DBNull.Value ? "" : reader["CodigoEmpleado"].ToString();
                        beVacacion.Sueldo = reader["Sueldo"] == DBNull.Value ? 0.0 : double.Parse(reader["Sueldo"].ToString());
                        beVacacion.AsignacionFamiliar = reader["AsignacionFamiliar"] == DBNull.Value ? 0.0 : double.Parse(reader["AsignacionFamiliar"].ToString());
                        beVacacion.PromedioHorasExtras = reader["PromedioHorasExtras"] == DBNull.Value ? 0.0 : double.Parse(reader["PromedioHorasExtras"].ToString());
                        beVacacion.PromedioBonificacion = reader["PromedioBonificacion"] == DBNull.Value ? 0.0 : double.Parse(reader["PromedioBonificacion"].ToString());
                        beVacacion.TotalBruto = reader["TotalBruto"] == DBNull.Value ? 0.0 : double.Parse(reader["TotalBruto"].ToString());

                        int anho = beVacacion.FechaInicial.Year;
                        int mes = beVacacion.FechaInicial.Month;

                        int idAfpComision = reader["idAfpComision"] == DBNull.Value ? 0 : int.Parse(reader["idAfpComision"].ToString());
                        if (idAfpComision > 0)
                        {
                            var beAfpComision = new DA.AfpComision().Obtener(idAfpComision);
                            beVacacion.ComisionAfp = beAfpComision;

                            beVacacion.TipoComisionAfp = reader["ComisionAfp"] == DBNull.Value ? "" : reader["ComisionAfp"].ToString();
                        }

                        int idOnpComision = reader["idOnpComision"] == DBNull.Value ? 0 : int.Parse(reader["idOnpComision"].ToString());
                        if (idOnpComision > 0)
                        {
                            var beOnpComision = new DA.OnpComision().Obtener(anho, mes);
                            beVacacion.ComisionOnp = beOnpComision;
                        }

                        beVacacion.PensionMonto = reader["PensionMonto"] == DBNull.Value ? 0.0 : double.Parse(reader["PensionMonto"].ToString());
                        beVacacion.RetencionJudicialMonto = reader["RetencionJudicialMonto"] == DBNull.Value ? 0.0 : double.Parse(reader["RetencionJudicialMonto"].ToString());
                        beVacacion.TotalDescuento = reader["TotalDescuento"] == DBNull.Value ? 0.0 : double.Parse(reader["TotalDescuento"].ToString());
                        beVacacion.TotalNeto = reader["TotalNeto"] == DBNull.Value ? 0.0 : double.Parse(reader["TotalNeto"].ToString());
                        
                    }
                }

                return beVacacion;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
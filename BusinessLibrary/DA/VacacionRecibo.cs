using System;
using BE = ErpCasino.BusinessLibrary.BE;
using System.Data.SqlClient;
using System.Data;

namespace ErpCasino.BusinessLibrary.DA
{
    public class VacacionRecibo
    {
        public BE.VacacionRecibo Obtener(int idVacacion)
        {
            BE.VacacionRecibo beVacacionRecibo = null;
            try
            {
                string sp = "SpTbVacacionReciboObtener";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IDVACACION", idVacacion));

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        beVacacionRecibo = new BE.VacacionRecibo();

                        beVacacionRecibo.IdVacacionRecibo = reader["IdVacacionRecibo"] == DBNull.Value ? 0 : int.Parse(reader["IdVacacionRecibo"].ToString());
                        beVacacionRecibo.IdVacacion = reader["IdVacacion"] == DBNull.Value ? 0 : int.Parse(reader["IdVacacion"].ToString());
                        beVacacionRecibo.Anho = reader["Anho"] == DBNull.Value ? 0 : int.Parse(reader["Anho"].ToString());
                        beVacacionRecibo.Mes = reader["Mes"] == DBNull.Value ? 0 : int.Parse(reader["Mes"].ToString());
                        beVacacionRecibo.MesNombre = reader["MesNombre"] == DBNull.Value ? "" : reader["MesNombre"].ToString();
                        beVacacionRecibo.EmpresaNombre = reader["EmpresaNombre"] == DBNull.Value ? "" : reader["EmpresaNombre"].ToString();
                        beVacacionRecibo.EmpresaDistrito = reader["EmpresaDistrito"] == DBNull.Value ? "" : reader["EmpresaDistrito"].ToString();
                        beVacacionRecibo.EmpleadoCodigo = reader["EmpleadoCodigo"] == DBNull.Value ? "" : reader["EmpleadoCodigo"].ToString();
                        beVacacionRecibo.EmpleadoNombres = reader["EmpleadoNombres"] == DBNull.Value ? "" : reader["EmpleadoNombres"].ToString();
                        beVacacionRecibo.EmpleadoApellidos = reader["EmpleadoApellidos"] == DBNull.Value ? "" : reader["EmpleadoApellidos"].ToString();
                        beVacacionRecibo.EmpleadoNroDocumento = reader["EmpleadoNroDocumento"] == DBNull.Value ? "" : reader["EmpleadoNroDocumento"].ToString();
                        beVacacionRecibo.Detalle = reader["Detalle"] == DBNull.Value ? "" : reader["Detalle"].ToString();
                        beVacacionRecibo.PeriodoInicio = reader["PeriodoInicio"] == DBNull.Value ? DateTime.Now : DateTime.Parse(reader["PeriodoInicio"].ToString());
                        beVacacionRecibo.PeriodoFinal = reader["PeriodoFinal"] == DBNull.Value ? DateTime.Now : DateTime.Parse(reader["PeriodoFinal"].ToString());
                        beVacacionRecibo.VacacionInicio = reader["VacacionInicio"] == DBNull.Value ? DateTime.Now : DateTime.Parse(reader["VacacionInicio"].ToString());
                        beVacacionRecibo.VacacionFinal = reader["VacacionFinal"] == DBNull.Value ? DateTime.Now : DateTime.Parse(reader["VacacionFinal"].ToString());
                        beVacacionRecibo.Sueldo = reader["Sueldo"] == DBNull.Value ? 0.0 : double.Parse(reader["Sueldo"].ToString());
                        beVacacionRecibo.AsignacionFamiliar = reader["AsignacionFamiliar"] == DBNull.Value ? 0.0 : double.Parse(reader["AsignacionFamiliar"].ToString());
                        beVacacionRecibo.PromedioHorasExtras = reader["PromedioHorasExtras"] == DBNull.Value ? 0.0 : double.Parse(reader["PromedioHorasExtras"].ToString());
                        beVacacionRecibo.PromedioBonificacion = reader["PromedioBonificacion"] == DBNull.Value ? 0.0 : double.Parse(reader["PromedioBonificacion"].ToString());
                        beVacacionRecibo.Redondeo = reader["Redondeo"] == DBNull.Value ? 0.0 : double.Parse(reader["Redondeo"].ToString());
                        beVacacionRecibo.TotalBruto = reader["TotalBruto"] == DBNull.Value ? 0.0 : double.Parse(reader["TotalBruto"].ToString());
                        beVacacionRecibo.RetencionJudicialMonto = reader["RetencionJudicialMonto"] == DBNull.Value ? 0.0 : double.Parse(reader["RetencionJudicialMonto"].ToString());
                        beVacacionRecibo.PensionEntidad = reader["PensionEntidad"] == DBNull.Value ? "" : reader["PensionEntidad"].ToString();
                        beVacacionRecibo.PensionMonto = reader["PensionMonto"] == DBNull.Value ? 0.0 : double.Parse(reader["PensionMonto"].ToString());
                        beVacacionRecibo.TotalDescuento = reader["TotalDescuento"] == DBNull.Value ? 0.0 : double.Parse(reader["TotalDescuento"].ToString());
                        beVacacionRecibo.TotalNeto = reader["TotalNeto"] == DBNull.Value ? 0.0 : double.Parse(reader["TotalNeto"].ToString());
                        beVacacionRecibo.TotalNetoLiteral = reader["TotalNetoLiteral"] == DBNull.Value ? "" : reader["TotalNetoLiteral"].ToString();

                    }
                }

                return beVacacionRecibo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Insertar(ref BE.VacacionRecibo beVacacionRecibo)
        {
            int rowsAffected = 0;
            try
            {
                string sp = "SpTbVacacionReciboInsertar";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@IDVACACIONRECIBO", beVacacionRecibo.IdVacacionRecibo));
                    cmd.Parameters["@IDVACACIONRECIBO"].Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(new SqlParameter("@IDVACACION", beVacacionRecibo.IdVacacion));
                    cmd.Parameters.Add(new SqlParameter("@ANHO", beVacacionRecibo.Anho));
                    cmd.Parameters.Add(new SqlParameter("@MES", beVacacionRecibo.Mes));
                    cmd.Parameters.Add(new SqlParameter("@MESNOMBRE", beVacacionRecibo.MesNombre));
                    cmd.Parameters.Add(new SqlParameter("@EMPRESANOMBRE", beVacacionRecibo.EmpresaNombre));
                    cmd.Parameters.Add(new SqlParameter("@EMPRESADISTRITO", beVacacionRecibo.EmpresaDistrito));
                    cmd.Parameters.Add(new SqlParameter("@EMPLEADOCODIGO", beVacacionRecibo.EmpleadoCodigo));
                    cmd.Parameters.Add(new SqlParameter("@EMPLEADONOMBRES", beVacacionRecibo.EmpleadoNombres));
                    cmd.Parameters.Add(new SqlParameter("@EMPLEADOAPELLIDOS", beVacacionRecibo.EmpleadoApellidos));
                    cmd.Parameters.Add(new SqlParameter("@EMPLEADONRODOCUMENTO", beVacacionRecibo.EmpleadoNroDocumento));
                    cmd.Parameters.Add(new SqlParameter("@DETALLE", beVacacionRecibo.Detalle));
                    cmd.Parameters.Add(new SqlParameter("@PERIODOINICIO", beVacacionRecibo.PeriodoInicio.Date));
                    cmd.Parameters.Add(new SqlParameter("@PERIODOFINAL", beVacacionRecibo.PeriodoFinal.Date));
                    cmd.Parameters.Add(new SqlParameter("@VACACIONINICIO", beVacacionRecibo.VacacionInicio.Date));
                    cmd.Parameters.Add(new SqlParameter("@VACACIONFINAL", beVacacionRecibo.VacacionFinal.Date));
                    cmd.Parameters.Add(new SqlParameter("@SUELDO", beVacacionRecibo.Sueldo));
                    cmd.Parameters.Add(new SqlParameter("@ASIGNACIONFAMILIAR", beVacacionRecibo.AsignacionFamiliar));
                    cmd.Parameters.Add(new SqlParameter("@PROMEDIOHORASEXTRAS", beVacacionRecibo.PromedioHorasExtras));
                    cmd.Parameters.Add(new SqlParameter("@PROMEDIOBONIFICACION", beVacacionRecibo.PromedioBonificacion));
                    cmd.Parameters.Add(new SqlParameter("@REDONDEO", beVacacionRecibo.Redondeo));
                    cmd.Parameters.Add(new SqlParameter("@TOTALBRUTO", beVacacionRecibo.TotalBruto));
                    cmd.Parameters.Add(new SqlParameter("@RETENCIONJUDICIALMONTO", beVacacionRecibo.RetencionJudicialMonto));
                    cmd.Parameters.Add(new SqlParameter("@PENSIONENTIDAD", beVacacionRecibo.PensionEntidad));
                    cmd.Parameters.Add(new SqlParameter("@PENSIONMONTO", beVacacionRecibo.PensionMonto));
                    cmd.Parameters.Add(new SqlParameter("@TOTALDESCUENTO", beVacacionRecibo.TotalDescuento));
                    cmd.Parameters.Add(new SqlParameter("@TOTALNETO", beVacacionRecibo.TotalNeto));
                    cmd.Parameters.Add(new SqlParameter("@TOTALNETOLITERAL", beVacacionRecibo.TotalNetoLiteral));

                    rowsAffected = cmd.ExecuteNonQuery();
                    beVacacionRecibo.IdVacacionRecibo = int.Parse(cmd.Parameters["@IDVACACIONRECIBO"].Value.ToString());

                }

                return rowsAffected;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Actualizar(BE.VacacionRecibo beVacacionRecibo)
        {
            int rowsAffected = 0;
            try
            {
                string sp = "SpTbVacacionReciboActualizar";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cnn.Open();

                    cmd.Parameters.Add(new SqlParameter("@IDVACACIONRECIBO", beVacacionRecibo.IdVacacionRecibo));
                    cmd.Parameters.Add(new SqlParameter("@IDVACACION", beVacacionRecibo.IdVacacion));
                    cmd.Parameters.Add(new SqlParameter("@ANHO", beVacacionRecibo.Anho));
                    cmd.Parameters.Add(new SqlParameter("@MES", beVacacionRecibo.Mes));
                    cmd.Parameters.Add(new SqlParameter("@MESNOMBRE", beVacacionRecibo.MesNombre));
                    cmd.Parameters.Add(new SqlParameter("@EMPRESANOMBRE", beVacacionRecibo.EmpresaNombre));
                    cmd.Parameters.Add(new SqlParameter("@EMPRESADISTRITO", beVacacionRecibo.EmpresaDistrito));
                    cmd.Parameters.Add(new SqlParameter("@EMPLEADOCODIGO", beVacacionRecibo.EmpleadoCodigo));
                    cmd.Parameters.Add(new SqlParameter("@EMPLEADONOMBRES", beVacacionRecibo.EmpleadoNombres));
                    cmd.Parameters.Add(new SqlParameter("@EMPLEADOAPELLIDOS", beVacacionRecibo.EmpleadoApellidos));
                    cmd.Parameters.Add(new SqlParameter("@EMPLEADONRODOCUMENTO", beVacacionRecibo.EmpleadoNroDocumento));
                    cmd.Parameters.Add(new SqlParameter("@DETALLE", beVacacionRecibo.Detalle));
                    cmd.Parameters.Add(new SqlParameter("@PERIODOINICIO", beVacacionRecibo.PeriodoInicio));
                    cmd.Parameters.Add(new SqlParameter("@PERIODOFINAL", beVacacionRecibo.PeriodoFinal));
                    cmd.Parameters.Add(new SqlParameter("@VACACIONINICIO", beVacacionRecibo.VacacionInicio));
                    cmd.Parameters.Add(new SqlParameter("@VACACIONFINAL", beVacacionRecibo.VacacionFinal));
                    cmd.Parameters.Add(new SqlParameter("@SUELDO", beVacacionRecibo.Sueldo));
                    cmd.Parameters.Add(new SqlParameter("@ASIGNACIONFAMILIAR", beVacacionRecibo.AsignacionFamiliar));
                    cmd.Parameters.Add(new SqlParameter("@PROMEDIOHORASEXTRAS", beVacacionRecibo.PromedioHorasExtras));
                    cmd.Parameters.Add(new SqlParameter("@PROMEDIOBONIFICACION", beVacacionRecibo.PromedioBonificacion));
                    cmd.Parameters.Add(new SqlParameter("@REDONDEO", beVacacionRecibo.Redondeo));
                    cmd.Parameters.Add(new SqlParameter("@TOTALBRUTO", beVacacionRecibo.TotalBruto));
                    cmd.Parameters.Add(new SqlParameter("@RETENCIONJUDICIALMONTO", beVacacionRecibo.RetencionJudicialMonto));
                    cmd.Parameters.Add(new SqlParameter("@PENSIONENTIDAD", beVacacionRecibo.PensionEntidad));
                    cmd.Parameters.Add(new SqlParameter("@PENSIONMONTO", beVacacionRecibo.PensionMonto));
                    cmd.Parameters.Add(new SqlParameter("@TOTALDESCUENTO", beVacacionRecibo.TotalDescuento));
                    cmd.Parameters.Add(new SqlParameter("@TOTALNETO", beVacacionRecibo.TotalNeto));
                    cmd.Parameters.Add(new SqlParameter("@TOTALNETOLITERAL", beVacacionRecibo.TotalNetoLiteral));

                    rowsAffected = cmd.ExecuteNonQuery();
                }

                return rowsAffected;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
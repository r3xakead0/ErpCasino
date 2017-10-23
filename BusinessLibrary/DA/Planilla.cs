using BE = ErpCasino.BusinessLibrary.BE;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace ErpCasino.BusinessLibrary.DA
{

    public class Planilla
    {
        

        public bool Existe(int anho, int mes)
        {
            bool flag = false;
            try
            {
                string sp = "SpTbPlanillaExiste";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ANHO", anho));
                    cmd.Parameters.Add(new SqlParameter("@MES", mes));

                    int num = int.Parse(cmd.ExecuteScalar().ToString());
                    flag = num == 0 ? false : true;

                    cnn.Close();
                }
                return flag;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BE.Planilla Obtener(int anho, int mes)
        {
            BE.Planilla bePlanilla = null;
            try
            {
                string sp = "SpTbPlanillaObtener";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ANHO", anho));
                    cmd.Parameters.Add(new SqlParameter("@MES", mes));

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        bePlanilla = new BE.Planilla();

                        bePlanilla.ID = int.Parse(reader["IdPlanilla"].ToString());
                        bePlanilla.Anho = int.Parse(reader["Anho"].ToString());
                        bePlanilla.Mes = int.Parse(reader["Mes"].ToString());
                        bePlanilla.Dias = int.Parse(reader["DiasMes"].ToString());
                        bePlanilla.DiasBase = int.Parse(reader["DiasBase"].ToString());
                        bePlanilla.HorasBase = int.Parse(reader["HorasBase"].ToString());
                        bePlanilla.SueldoMinimo = double.Parse(reader["SueldoMinimo"].ToString());
                        bePlanilla.AsignacionFamiliar = double.Parse(reader["AsignacionFamiliar"].ToString());
                        bePlanilla.PrimerasDosHorasExtras = double.Parse(reader["PrimerasDosHorasExtras"].ToString());
                        bePlanilla.PosterioresDosHorasExtras = double.Parse(reader["PosteriorDosHorasExtras"].ToString());
                        bePlanilla.Onp = double.Parse(reader["ONP"].ToString());
                        bePlanilla.EsSalud = double.Parse(reader["EsSalud"].ToString());
                        bePlanilla.Nocturno = double.Parse(reader["HorasNocturnas"].ToString());
                        bePlanilla.Feriado = double.Parse(reader["Feriado"].ToString());
                    }

                    cnn.Close();
                }

                return bePlanilla;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ListarSueldos()
        {
            DataTable dt = new DataTable();
            try
            {
                string sp = "SpListarSueldosEmpleado";

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
        
        public DataTable Resumen(int anho, int mes)
        {
            DataTable dt = new DataTable();
            try
            {
                string sp = "SpObtenerPlanillaResumen";

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

        public List<BE.PlanillaDetalle> Detalle(int idPlanilla)
        {
            var lstUiPlanillaDetalle = new List<BE.PlanillaDetalle>(); ;
            try
            {
                string sp = "SpTbPlanillaDetalleListar";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IDPLANILLA", idPlanilla));

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var beDetalle = new BE.PlanillaDetalle();

                        beDetalle.ID = int.Parse(reader["IdPlanillaDetalle"].ToString());

                        #region Empleado
                        beDetalle.CodigoEmpleado = reader["CodigoEmpleado"].ToString();
                        beDetalle.IdCargo = int.Parse(reader["IdCargo"].ToString());
                        beDetalle.SueldoBase = double.Parse(reader["Base"].ToString());
                        beDetalle.AsignacionFamiliar = double.Parse(reader["AsignacionFamiliar"].ToString());
                        #endregion

                        #region Asistencia Normal
                        beDetalle.CantidadMinutosAsistenciaNormalDiurno = int.Parse(reader["CantidadAsistenciaNormalDiurno"].ToString());
                        beDetalle.CostoMinutoNormalDiurno = double.Parse(reader["CostoAsistenciaNormalDiurno"].ToString());
                        beDetalle.CantidadMinutosAsistenciaNormalDiurnoExtras1 = int.Parse(reader["CantidadAsistenciaNormalDiurnoExtras1"].ToString());
                        beDetalle.CostoMinutoNormalDiurnoExtras1 = double.Parse(reader["CostoAsistenciaNormalDiurnoExtras1"].ToString());
                        beDetalle.CantidadMinutosAsistenciaNormalDiurnoExtras2 = int.Parse(reader["CantidadAsistenciaNormalDiurnoExtras2"].ToString());
                        beDetalle.CostoMinutoNormalDiurnoExtras2 = double.Parse(reader["CostoAsistenciaNormalDiurnoExtras2"].ToString());
                        beDetalle.CantidadMinutosAsistenciaNormalNocturno = int.Parse(reader["CantidadAsistenciaNormalNocturno"].ToString());
                        beDetalle.CostoMinutoNormalNocturno = double.Parse(reader["CostoAsistenciaNormalNocturno"].ToString());
                        beDetalle.CantidadMinutosAsistenciaNormalNocturnoExtras1 = int.Parse(reader["CantidadAsistenciaNormalNocturnoExtras1"].ToString());
                        beDetalle.CostoMinutoNormalNocturnoExtras1 = double.Parse(reader["CostoAsistenciaNormalNocturnoExtras1"].ToString());
                        beDetalle.CantidadMinutosAsistenciaNormalNocturnoExtras2 = int.Parse(reader["CantidadAsistenciaNormalNocturnoExtras2"].ToString());
                        beDetalle.CostoMinutoNormalNocturnoExtras2 = double.Parse(reader["CostoAsistenciaNormalNocturnoExtras2"].ToString());
                        #endregion

                        #region Tardanza Normal
                        beDetalle.CantidadMinutosTardanzaNormalDiurno = int.Parse(reader["CantidadTardanzaNormalDiurno"].ToString());
                        beDetalle.DescuentoMinutoTardanzaNormalDiurno = double.Parse(reader["DescuentoTardanzaNormalDiurno"].ToString());
                        beDetalle.CantidadMinutosTardanzaNormalNocturno = int.Parse(reader["CantidadTardanzaNormalNocturno"].ToString());
                        beDetalle.DescuentoMinutoTardanzaNormalNocturno = double.Parse(reader["DescuentoTardanzaNormalNocturno"].ToString());
                        #endregion

                        #region Asistencia Feriado
                        beDetalle.CantidadMinutosAsistenciaFeriadoDiurno = int.Parse(reader["CantidadAsistenciaFeriadoDiurno"].ToString());
                        beDetalle.CostoMinutoFeriadoDiurno = double.Parse(reader["CostoAsistenciaFeriadoDiurno"].ToString());
                        beDetalle.CantidadMinutosAsistenciaFeriadoDiurnoExtras1 = int.Parse(reader["CantidadAsistenciaFeriadoDiurnoExtras1"].ToString());
                        beDetalle.CostoMinutoFeriadoDiurnoExtras1 = double.Parse(reader["CostoAsistenciaFeriadoDiurnoExtras1"].ToString());
                        beDetalle.CantidadMinutosAsistenciaFeriadoDiurnoExtras2 = int.Parse(reader["CantidadAsistenciaFeriadoDiurnoExtras2"].ToString());
                        beDetalle.CostoMinutoFeriadoDiurnoExtras2 = double.Parse(reader["CostoAsistenciaFeriadoDiurnoExtras2"].ToString());
                        beDetalle.CantidadMinutosAsistenciaFeriadoNocturno = int.Parse(reader["CantidadAsistenciaFeriadoNocturno"].ToString());
                        beDetalle.CostoMinutoFeriadoNocturno = double.Parse(reader["CostoAsistenciaFeriadoNocturno"].ToString());
                        beDetalle.CantidadMinutosAsistenciaFeriadoNocturnoExtras1 = int.Parse(reader["CantidadAsistenciaFeriadoNocturnoExtras1"].ToString());
                        beDetalle.CostoMinutoFeriadoNocturnoExtras1 = double.Parse(reader["CostoAsistenciaFeriadoNocturnoExtras1"].ToString());
                        beDetalle.CantidadMinutosAsistenciaFeriadoNocturnoExtras2 = int.Parse(reader["CantidadAsistenciaFeriadoNocturnoExtras2"].ToString());
                        beDetalle.CostoMinutoFeriadoNocturnoExtras2 = double.Parse(reader["CostoAsistenciaFeriadoNocturnoExtras2"].ToString());
                        #endregion

                        #region Tardanza Feriado
                        beDetalle.CantidadMinutosTardanzaFeriadoDiurno = int.Parse(reader["CantidadTardanzaFeriadoDiurno"].ToString());
                        beDetalle.DescuentoMinutoTardanzaFeriadoDiurno = double.Parse(reader["DescuentoTardanzaFeriadoDiurno"].ToString());
                        beDetalle.CantidadMinutosTardanzaFeriadoNocturno = int.Parse(reader["CantidadTardanzaFeriadoNocturno"].ToString());
                        beDetalle.DescuentoMinutoTardanzaFeriadoNocturno = double.Parse(reader["DescuentoTardanzaFeriadoNocturno"].ToString());
                        #endregion

                        #region Inasistencia
                        beDetalle.CantidadMinutosInasistencia = int.Parse(reader["CantidadInasistencia"].ToString());
                        beDetalle.DescuentoMinutoInasistencia = double.Parse(reader["DescuentoInasistencia"].ToString());
                        #endregion

                        #region Pension

                        #region Pension Publica - SNP
                        beDetalle.Snp = bool.Parse(reader["Snp"].ToString());
                        beDetalle.SnpTotal = double.Parse(reader["SnpTotal"].ToString());
                        #endregion

                        #region Pension Privada - AFP
                        if (reader["AfpID"] != DBNull.Value)
                        {
                            beDetalle.Afp = new BE.Afp()
                            {
                                IdAfp = int.Parse(reader["AfpID"].ToString())
                            };
                        }

                        if (reader["AfpTipo"] != DBNull.Value)
                        {
                            beDetalle.AfpTipo = reader["AfpTipo"].ToString();
                        }

                        beDetalle.AfpAporteObligatorio = double.Parse(reader["AfpAporteObligatorio"].ToString());
                        beDetalle.AfpAporteVoluntario = double.Parse(reader["AfpAporteVoluntario"].ToString());
                        beDetalle.AfpSeguro = double.Parse(reader["AfpSeguro"].ToString());
                        beDetalle.AfpComision = double.Parse(reader["AfpComision"].ToString());
                        #endregion

                        #endregion

                        #region Impuestos
                        beDetalle.ImpuestoTotal = double.Parse(reader["TotalImpuesto"].ToString());
                        #endregion

                        #region Retencion Judicial
                        beDetalle.RetencionJudicialPorcentual = double.Parse(reader["RetencionJudicialPorcentual"].ToString());
                        beDetalle.RetencionJudicialNominal = double.Parse(reader["RetencionJudicialNominal"].ToString());
                        #endregion

                        #region Adelanto
                        beDetalle.AdelantoEfectivo = double.Parse(reader["AdelantoEfectivo"].ToString());
                        beDetalle.AdelantoBanco = double.Parse(reader["AdelantoBanco"].ToString());
                        #endregion

                        #region Pestamo
                        beDetalle.PrestamoTotal = double.Parse(reader["PrestamoTotal"].ToString());
                        #endregion

                        #region EsSalud
                        beDetalle.EsSaludTotal = double.Parse(reader["EsSaludTotal"].ToString());
                        #endregion

                        lstUiPlanillaDetalle.Add(beDetalle);

                    }

                    cnn.Close();
                }

                return lstUiPlanillaDetalle;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Registrar detalles de planilla (Costo, Resumen de Asistencias, Detalle y Resumen)
        /// </summary>
        /// <param name="idPlanilla">ID de Planilla</param>
        /// <param name="bePlanillaDetalle">Objeto Detalle de Planilla</param>
        /// <param name="cnn">Referencia al Objeto conexion</param>
        /// <param name="tns">Referencia al Objeto transaccion</param>
        /// <returns></returns>
        private int InsertarPlanillaDetalle(int idPlanilla,
                                                BE.PlanillaDetalle bePlanillaDetalle,
                                                ref SqlConnection cnn,
                                                ref SqlTransaction tns)
        {
            int rowsAffected = 0;
            try
            {

                string sp = "";
                SqlCommand cmd = null;

                #region Registro de Costos
                sp = "SpTbPlanillaDetalleCostoInsertar";

                cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = tns;

                cmd.Parameters.Add(new SqlParameter("@IDPLANILLADETALLECOSTO", bePlanillaDetalle.ID));
                cmd.Parameters["@IDPLANILLADETALLECOSTO"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add(new SqlParameter("@IDPLANILLA", idPlanilla));

                cmd.Parameters.Add(new SqlParameter("@CODIGOEMPLEADO", bePlanillaDetalle.CodigoEmpleado));

                #region Sueldo
                cmd.Parameters.Add(new SqlParameter("@BASE", bePlanillaDetalle.SueldoBase));
                cmd.Parameters.Add(new SqlParameter("@ASIGNACIONFAMILIAR", bePlanillaDetalle.AsignacionFamiliar));
                cmd.Parameters.Add(new SqlParameter("@SUELDO", bePlanillaDetalle.TotalSueldoBase));
                #endregion

                #region Costos
                cmd.Parameters.Add(new SqlParameter("@COSTOMINUTONORMALDIURNO", bePlanillaDetalle.CostoMinutoNormalDiurno));
                cmd.Parameters.Add(new SqlParameter("@COSTOMINUTONORMALNOCTURNO", bePlanillaDetalle.CostoMinutoNormalNocturno));
                cmd.Parameters.Add(new SqlParameter("@COSTOMINUTONORMALDIURNOEXTRAS1", bePlanillaDetalle.CostoMinutoNormalDiurnoExtras1));
                cmd.Parameters.Add(new SqlParameter("@COSTOMINUTONORMALNOCTURNOEXTRAS1", bePlanillaDetalle.CostoMinutoNormalNocturnoExtras1));
                cmd.Parameters.Add(new SqlParameter("@COSTOMINUTONORMALDIURNOEXTRAS2", bePlanillaDetalle.CostoMinutoNormalDiurnoExtras2));
                cmd.Parameters.Add(new SqlParameter("@COSTOMINUTONORMALNOCTURNOEXTRAS2", bePlanillaDetalle.CostoMinutoNormalNocturnoExtras2));

                cmd.Parameters.Add(new SqlParameter("@COSTOMINUTOFERIADODIURNO", bePlanillaDetalle.CostoMinutoFeriadoDiurno));
                cmd.Parameters.Add(new SqlParameter("@COSTOMINUTOFERIADONOCTURNO", bePlanillaDetalle.CostoMinutoFeriadoNocturno));
                cmd.Parameters.Add(new SqlParameter("@COSTOMINUTOFERIADODIURNOEXTRAS1", bePlanillaDetalle.CostoMinutoFeriadoDiurnoExtras1));
                cmd.Parameters.Add(new SqlParameter("@COSTOMINUTOFERIADONOCTURNOEXTRAS1", bePlanillaDetalle.CostoMinutoFeriadoNocturnoExtras1));
                cmd.Parameters.Add(new SqlParameter("@COSTOMINUTOFERIADODIURNOEXTRAS2", bePlanillaDetalle.CostoMinutoFeriadoDiurnoExtras2));
                cmd.Parameters.Add(new SqlParameter("@COSTOMINUTOFERIADONOCTURNOEXTRAS2", bePlanillaDetalle.CostoMinutoFeriadoNocturnoExtras2));
                #endregion

                #region Descuentos
                cmd.Parameters.Add(new SqlParameter("@DESCUENTOMINUTOTARDANZANORMALDIURNO", bePlanillaDetalle.DescuentoMinutoTardanzaNormalDiurno));
                cmd.Parameters.Add(new SqlParameter("@DESCUENTOMINUTOTARDANZANORMALNOCTURNO", bePlanillaDetalle.DescuentoMinutoTardanzaNormalNocturno));
                cmd.Parameters.Add(new SqlParameter("@DESCUENTOMINUTOTARDANZAFERIADODIURNO", bePlanillaDetalle.DescuentoMinutoTardanzaFeriadoDiurno));
                cmd.Parameters.Add(new SqlParameter("@DESCUENTOMINUTOTARDANZAFERIADONOCTURNO", bePlanillaDetalle.DescuentoMinutoTardanzaFeriadoNocturno));

                cmd.Parameters.Add(new SqlParameter("@DESCUENTOMINUTODOMINICAL", bePlanillaDetalle.DescuentoMinutoDominical));
                cmd.Parameters.Add(new SqlParameter("@DESCUENTOMINUTOINASISTENCIA", bePlanillaDetalle.DescuentoMinutoInasistencia));
                #endregion

                rowsAffected += cmd.ExecuteNonQuery();
                bePlanillaDetalle.ID = int.Parse(cmd.Parameters["@IDPLANILLADETALLECOSTO"].Value.ToString());

                #endregion

                #region Registro de Cantidad (Asistencias, Inasistencias y Tardanzas)
                sp = "SpTbPlanillaDetalleCantidadInsertar";

                cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = tns;

                cmd.Parameters.Add(new SqlParameter("@IDPLANILLADETALLECANTIDAD", bePlanillaDetalle.ID));
                cmd.Parameters["@IDPLANILLADETALLECANTIDAD"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add(new SqlParameter("@IDPLANILLA", idPlanilla));

                cmd.Parameters.Add(new SqlParameter("@CODIGOEMPLEADO", bePlanillaDetalle.CodigoEmpleado));

                #region Asistencia Normal
                cmd.Parameters.Add(new SqlParameter("@CANTIDADMINUTOSASISTENCIANORMALDIURNO", bePlanillaDetalle.CantidadMinutosAsistenciaNormalDiurno));
                cmd.Parameters.Add(new SqlParameter("@CANTIDADMINUTOSASISTENCIANORMALDIURNOEXTRAS1", bePlanillaDetalle.CantidadMinutosAsistenciaNormalDiurnoExtras1));
                cmd.Parameters.Add(new SqlParameter("@CANTIDADMINUTOSASISTENCIANORMALDIURNOEXTRAS2", bePlanillaDetalle.CantidadMinutosAsistenciaNormalDiurnoExtras2));
                cmd.Parameters.Add(new SqlParameter("@CANTIDADMINUTOSASISTENCIANORMALNOCTURNO", bePlanillaDetalle.CantidadMinutosAsistenciaNormalNocturno));
                cmd.Parameters.Add(new SqlParameter("@CANTIDADMINUTOSASISTENCIANORMALNOCTURNOEXTRAS1", bePlanillaDetalle.CantidadMinutosAsistenciaNormalNocturnoExtras1));
                cmd.Parameters.Add(new SqlParameter("@CANTIDADMINUTOSASISTENCIANORMALNOCTURNOEXTRAS2", bePlanillaDetalle.CantidadMinutosAsistenciaNormalNocturnoExtras2));
                #endregion

                #region Asistencia Feriado
                cmd.Parameters.Add(new SqlParameter("@CANTIDADMINUTOSASISTENCIAFERIADODIURNO", bePlanillaDetalle.CantidadMinutosAsistenciaFeriadoDiurno));
                cmd.Parameters.Add(new SqlParameter("@CANTIDADMINUTOSASISTENCIAFERIADODIURNOEXTRAS1", bePlanillaDetalle.CantidadMinutosAsistenciaFeriadoDiurnoExtras1));
                cmd.Parameters.Add(new SqlParameter("@CANTIDADMINUTOSASISTENCIAFERIADODIURNOEXTRAS2", bePlanillaDetalle.CantidadMinutosAsistenciaFeriadoDiurnoExtras2));
                cmd.Parameters.Add(new SqlParameter("@CANTIDADMINUTOSASISTENCIAFERIADONOCTURNO", bePlanillaDetalle.CantidadMinutosAsistenciaFeriadoNocturno));
                cmd.Parameters.Add(new SqlParameter("@CANTIDADMINUTOSASISTENCIAFERIADONOCTURNOEXTRAS1", bePlanillaDetalle.CantidadMinutosAsistenciaFeriadoNocturnoExtras1));
                cmd.Parameters.Add(new SqlParameter("@CANTIDADMINUTOSASISTENCIAFERIADONOCTURNOEXTRAS2", bePlanillaDetalle.CantidadMinutosAsistenciaFeriadoNocturnoExtras2));
                #endregion

                #region Tardanzas
                cmd.Parameters.Add(new SqlParameter("@CANTIDADMINUTOSTARDANZANORMALDIURNO", bePlanillaDetalle.CantidadMinutosTardanzaNormalDiurno));
                cmd.Parameters.Add(new SqlParameter("@CANTIDADMINUTOSTARDANZANORMALNOCTURNO", bePlanillaDetalle.CantidadMinutosTardanzaNormalNocturno));
                cmd.Parameters.Add(new SqlParameter("@CANTIDADMINUTOSTARDANZAFERIADODIURNO", bePlanillaDetalle.CantidadMinutosTardanzaFeriadoDiurno));
                cmd.Parameters.Add(new SqlParameter("@CANTIDADMINUTOSTARDANZAFERIADONOCTURNO", bePlanillaDetalle.CantidadMinutosTardanzaFeriadoNocturno));
                #endregion

                #region Inasistencia
                cmd.Parameters.Add(new SqlParameter("@CANTIDADMINUTOSINASISTENCIA", bePlanillaDetalle.CantidadMinutosInasistencia));
                #endregion

                rowsAffected += cmd.ExecuteNonQuery();
                bePlanillaDetalle.ID = int.Parse(cmd.Parameters["@IDPLANILLADETALLECANTIDAD"].Value.ToString());
                #endregion

                #region Registro del Detalle de Planilla
                sp = "SpTbPlanillaDetalleInsertar";

                cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = tns;

                cmd.Parameters.Add(new SqlParameter("@IDPLANILLADETALLE", bePlanillaDetalle.ID));
                cmd.Parameters["@IDPLANILLADETALLE"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add(new SqlParameter("@IDPLANILLA", idPlanilla));
                cmd.Parameters.Add(new SqlParameter("@CALCULOPOR", "M"));

                #region Empleado
                cmd.Parameters.Add(new SqlParameter("@CODIGOEMPLEADO", bePlanillaDetalle.CodigoEmpleado));
                cmd.Parameters.Add(new SqlParameter("@IDCARGO", bePlanillaDetalle.IdCargo));
                #endregion

                #region Sueldo Base
                cmd.Parameters.Add(new SqlParameter("@BASE", bePlanillaDetalle.SueldoBase));
                cmd.Parameters.Add(new SqlParameter("@ASIGNACIONFAMILIAR", bePlanillaDetalle.AsignacionFamiliar));

                cmd.Parameters.Add(new SqlParameter("@TOTALBASE", bePlanillaDetalle.TotalSueldoBase));
                #endregion

                #region Horario Normal (Asistencia y Tardanza)

                #region Asistencia

                cmd.Parameters.Add(new SqlParameter("@CANTIDADASISTENCIANORMALDIURNO", bePlanillaDetalle.CantidadMinutosAsistenciaNormalDiurno));
                cmd.Parameters.Add(new SqlParameter("@COSTOASISTENCIANORMALDIURNO", bePlanillaDetalle.CostoMinutoNormalDiurno));
                cmd.Parameters.Add(new SqlParameter("@TOTALASISTENCIANORMALDIURNO", bePlanillaDetalle.TotalMinutoAsistenciaNormalDiurno));

                cmd.Parameters.Add(new SqlParameter("@CANTIDADASISTENCIANORMALNOCTURNO", bePlanillaDetalle.CantidadMinutosAsistenciaNormalNocturno));
                cmd.Parameters.Add(new SqlParameter("@COSTOASISTENCIANORMALNOCTURNO", bePlanillaDetalle.CostoMinutoNormalNocturno));
                cmd.Parameters.Add(new SqlParameter("@TOTALASISTENCIANORMALNOCTURNO", bePlanillaDetalle.TotalMinutoAsistenciaNormalNocturno));

                cmd.Parameters.Add(new SqlParameter("@CANTIDADASISTENCIANORMALDIURNOEXTRAS1", bePlanillaDetalle.CantidadMinutosAsistenciaNormalDiurnoExtras1));
                cmd.Parameters.Add(new SqlParameter("@COSTOASISTENCIANORMALDIURNOEXTRAS1", bePlanillaDetalle.CostoMinutoNormalDiurnoExtras1));
                cmd.Parameters.Add(new SqlParameter("@TOTALASISTENCIANORMALDIURNOEXTRAS1", bePlanillaDetalle.TotalMinutoAsistenciaNormalDiurnoExtras1));

                cmd.Parameters.Add(new SqlParameter("@CANTIDADASISTENCIANORMALNOCTURNOEXTRAS1", bePlanillaDetalle.CantidadMinutosAsistenciaNormalNocturnoExtras1));
                cmd.Parameters.Add(new SqlParameter("@COSTOASISTENCIANORMALNOCTURNOEXTRAS1", bePlanillaDetalle.CostoMinutoNormalNocturnoExtras1));
                cmd.Parameters.Add(new SqlParameter("@TOTALASISTENCIANORMALNOCTURNOEXTRAS1", bePlanillaDetalle.TotalMinutoAsistenciaNormalNocturnoExtras1));

                cmd.Parameters.Add(new SqlParameter("@CANTIDADASISTENCIANORMALDIURNOEXTRAS2", bePlanillaDetalle.CantidadMinutosAsistenciaNormalDiurnoExtras2));
                cmd.Parameters.Add(new SqlParameter("@COSTOASISTENCIANORMALDIURNOEXTRAS2", bePlanillaDetalle.CostoMinutoNormalDiurnoExtras2));
                cmd.Parameters.Add(new SqlParameter("@TOTALASISTENCIANORMALDIURNOEXTRAS2", bePlanillaDetalle.TotalMinutoAsistenciaNormalDiurnoExtras2));

                cmd.Parameters.Add(new SqlParameter("@CANTIDADASISTENCIANORMALNOCTURNOEXTRAS2", bePlanillaDetalle.CantidadMinutosAsistenciaNormalNocturnoExtras2));
                cmd.Parameters.Add(new SqlParameter("@COSTOASISTENCIANORMALNOCTURNOEXTRAS2", bePlanillaDetalle.CostoMinutoNormalNocturnoExtras2));
                cmd.Parameters.Add(new SqlParameter("@TOTALASISTENCIANORMALNOCTURNOEXTRAS2", bePlanillaDetalle.TotalMinutoAsistenciaNormalNocturnoExtras2));

                #endregion

                #region Tardanza

                cmd.Parameters.Add(new SqlParameter("@CANTIDADTARDANZANORMALDIURNO", bePlanillaDetalle.CantidadMinutosTardanzaNormalDiurno));
                cmd.Parameters.Add(new SqlParameter("@DESCUENTOTARDANZANORMALDIURNO", bePlanillaDetalle.DescuentoMinutoTardanzaNormalDiurno));
                cmd.Parameters.Add(new SqlParameter("@TOTALTARDANZANORMALDIURNO", bePlanillaDetalle.TotalMinutoTardanzaNormalDiurno));

                cmd.Parameters.Add(new SqlParameter("@CANTIDADTARDANZANORMALNOCTURNO", bePlanillaDetalle.CantidadMinutosTardanzaNormalNocturno));
                cmd.Parameters.Add(new SqlParameter("@DESCUENTOTARDANZANORMALNOCTURNO", bePlanillaDetalle.DescuentoMinutoTardanzaNormalNocturno));
                cmd.Parameters.Add(new SqlParameter("@TOTALTARDANZANORMALNOCTURNO", bePlanillaDetalle.TotalMinutoTardanzaNormalNocturno));

                #endregion

                #endregion

                #region Horario Feriado (Asistencia y Tardanza)

                #region Asistencia

                cmd.Parameters.Add(new SqlParameter("@CANTIDADASISTENCIAFERIADODIURNO", bePlanillaDetalle.CantidadMinutosAsistenciaFeriadoDiurno));
                cmd.Parameters.Add(new SqlParameter("@COSTOASISTENCIAFERIADODIURNO", bePlanillaDetalle.CostoMinutoFeriadoDiurno));
                cmd.Parameters.Add(new SqlParameter("@TOTALASISTENCIAFERIADODIURNO", bePlanillaDetalle.TotalMinutoAsistenciaFeriadoDiurno));

                cmd.Parameters.Add(new SqlParameter("@CANTIDADASISTENCIAFERIADONOCTURNO", bePlanillaDetalle.CantidadMinutosAsistenciaFeriadoNocturno));
                cmd.Parameters.Add(new SqlParameter("@COSTOASISTENCIAFERIADONOCTURNO", bePlanillaDetalle.CostoMinutoFeriadoNocturno));
                cmd.Parameters.Add(new SqlParameter("@TOTALASISTENCIAFERIADONOCTURNO", bePlanillaDetalle.TotalMinutoAsistenciaFeriadoNocturno));

                cmd.Parameters.Add(new SqlParameter("@CANTIDADASISTENCIAFERIADODIURNOEXTRAS1", bePlanillaDetalle.CantidadMinutosAsistenciaFeriadoDiurnoExtras1));
                cmd.Parameters.Add(new SqlParameter("@COSTOASISTENCIAFERIADODIURNOEXTRAS1", bePlanillaDetalle.CostoMinutoFeriadoDiurnoExtras1));
                cmd.Parameters.Add(new SqlParameter("@TOTALASISTENCIAFERIADODIURNOEXTRAS1", bePlanillaDetalle.TotalMinutoAsistenciaFeriadoDiurnoExtras1));

                cmd.Parameters.Add(new SqlParameter("@CANTIDADASISTENCIAFERIADONOCTURNOEXTRAS1", bePlanillaDetalle.CantidadMinutosAsistenciaFeriadoNocturnoExtras1));
                cmd.Parameters.Add(new SqlParameter("@COSTOASISTENCIAFERIADONOCTURNOEXTRAS1", bePlanillaDetalle.CostoMinutoFeriadoNocturnoExtras1));
                cmd.Parameters.Add(new SqlParameter("@TOTALASISTENCIAFERIADONOCTURNOEXTRAS1", bePlanillaDetalle.TotalMinutoAsistenciaFeriadoNocturnoExtras1));

                cmd.Parameters.Add(new SqlParameter("@CANTIDADASISTENCIAFERIADODIURNOEXTRAS2", bePlanillaDetalle.CantidadMinutosAsistenciaFeriadoDiurnoExtras2));
                cmd.Parameters.Add(new SqlParameter("@COSTOASISTENCIAFERIADODIURNOEXTRAS2", bePlanillaDetalle.CostoMinutoFeriadoDiurnoExtras2));
                cmd.Parameters.Add(new SqlParameter("@TOTALASISTENCIAFERIADODIURNOEXTRAS2", bePlanillaDetalle.TotalMinutoAsistenciaFeriadoDiurnoExtras2));

                cmd.Parameters.Add(new SqlParameter("@CANTIDADASISTENCIAFERIADONOCTURNOEXTRAS2", bePlanillaDetalle.CantidadMinutosAsistenciaFeriadoNocturnoExtras2));
                cmd.Parameters.Add(new SqlParameter("@COSTOASISTENCIAFERIADONOCTURNOEXTRAS2", bePlanillaDetalle.CostoMinutoFeriadoNocturnoExtras2));
                cmd.Parameters.Add(new SqlParameter("@TOTALASISTENCIAFERIADONOCTURNOEXTRAS2", bePlanillaDetalle.TotalMinutoAsistenciaFeriadoNocturnoExtras2));

                #endregion

                #region Tardanza

                cmd.Parameters.Add(new SqlParameter("@CANTIDADTARDANZAFERIADODIURNO", bePlanillaDetalle.CantidadMinutosTardanzaFeriadoDiurno));
                cmd.Parameters.Add(new SqlParameter("@DESCUENTOTARDANZAFERIADODIURNO", bePlanillaDetalle.DescuentoMinutoTardanzaFeriadoDiurno));
                cmd.Parameters.Add(new SqlParameter("@TOTALTARDANZAFERIADODIURNO", bePlanillaDetalle.TotalMinutoTardanzaFeriadoDiurno));

                cmd.Parameters.Add(new SqlParameter("@CANTIDADTARDANZAFERIADONOCTURNO", bePlanillaDetalle.CantidadMinutosTardanzaFeriadoNocturno));
                cmd.Parameters.Add(new SqlParameter("@DESCUENTOTARDANZAFERIADONOCTURNO", bePlanillaDetalle.DescuentoMinutoTardanzaFeriadoNocturno));
                cmd.Parameters.Add(new SqlParameter("@TOTALTARDANZAFERIADONOCTURNO", bePlanillaDetalle.TotalMinutoTardanzaFeriadoNocturno));

                #endregion

                #endregion

                #region Inasistencia

                cmd.Parameters.Add(new SqlParameter("@CANTIDADINASISTENCIA", bePlanillaDetalle.CantidadMinutosInasistencia));
                cmd.Parameters.Add(new SqlParameter("@DESCUENTOINASISTENCIA", bePlanillaDetalle.DescuentoMinutoInasistencia));
                cmd.Parameters.Add(new SqlParameter("@TOTALINASISTENCIA", bePlanillaDetalle.TotalMinutoInasistencia));

                #endregion


                #region Bonos (Nocturno, Extras y Feriado)

                #region Bono Nocturno

                cmd.Parameters.Add(new SqlParameter("@CANTIDADBONONOCTURNONORMAL", bePlanillaDetalle.CantidadMinutosBonoNocturnoNormal));
                cmd.Parameters.Add(new SqlParameter("@TOTALBONONOCTURNONORMAL", bePlanillaDetalle.TotalMinutoBonoNocturnoNormal));

                cmd.Parameters.Add(new SqlParameter("@CANTIDADBONONOCTURNOFERIADO", bePlanillaDetalle.CantidadMinutosBonoNocturnoFeriado));
                cmd.Parameters.Add(new SqlParameter("@TOTALBONONOCTURNOFERIADO", bePlanillaDetalle.TotalMinutoBonoNocturnoFeriado));

                cmd.Parameters.Add(new SqlParameter("@CANTIDADBONONOCTURNO", bePlanillaDetalle.CantidadMinutosBonoNocturno));
                cmd.Parameters.Add(new SqlParameter("@TOTALBONONOCTURNO", bePlanillaDetalle.TotalMinutoBonoNocturno));

                #endregion

                #region Horas Extras

                cmd.Parameters.Add(new SqlParameter("@CANTIDADBONOHORASEXTRASNORMAL1", bePlanillaDetalle.CantidadMinutosBonoHorasExtrasNormal1));
                cmd.Parameters.Add(new SqlParameter("@TOTALBONOHORASEXTRASNORMAL1", bePlanillaDetalle.TotalMinutoBonoHorasExtrasNormal1));

                cmd.Parameters.Add(new SqlParameter("@CANTIDADBONOHORASEXTRASNORMAL2", bePlanillaDetalle.CantidadMinutosBonoHorasExtrasNormal2));
                cmd.Parameters.Add(new SqlParameter("@TOTALBONOHORASEXTRASNORMAL2", bePlanillaDetalle.TotalMinutoBonoHorasExtrasNormal2));

                cmd.Parameters.Add(new SqlParameter("@CANTIDADBONOHORASEXTRASFERIADO1", bePlanillaDetalle.CantidadMinutosBonoHorasExtrasFeriado1));
                cmd.Parameters.Add(new SqlParameter("@TOTALBONOHORASEXTRASFERIADO1", bePlanillaDetalle.TotalMinutoBonoHorasExtrasFeriado1));

                cmd.Parameters.Add(new SqlParameter("@CANTIDADBONOHORASEXTRASFERIADO2", bePlanillaDetalle.CantidadMinutosBonoHorasExtrasFeriado2));
                cmd.Parameters.Add(new SqlParameter("@TOTALBONOHORASEXTRASFERIADO2", bePlanillaDetalle.TotalMinutoBonoHorasExtrasFeriado2));

                cmd.Parameters.Add(new SqlParameter("@CANTIDADBONOHORASEXTRAS", bePlanillaDetalle.CantidadMinutosBonoHorasExtras));
                cmd.Parameters.Add(new SqlParameter("@TOTALBONOHORASEXTRAS", bePlanillaDetalle.TotalMinutoBonoHorasExtras));

                #endregion

                #region Bono Feriado

                cmd.Parameters.Add(new SqlParameter("@CANTIDADBONOFERIADODIURNO", bePlanillaDetalle.CantidadMinutosBonoFeriadoDiurno));
                cmd.Parameters.Add(new SqlParameter("@TOTALBONOFERIADODIURNO", bePlanillaDetalle.TotalMinutoBonoFeriadoDiurno));

                cmd.Parameters.Add(new SqlParameter("@CANTIDADFERIADONOCTURNO", bePlanillaDetalle.CantidadMinutosBonoFeriadoNocturno));
                cmd.Parameters.Add(new SqlParameter("@TOTALBONOFERIADONOCTURNO", bePlanillaDetalle.TotalMinutoBonoFeriadoNocturno));

                cmd.Parameters.Add(new SqlParameter("@CANTIDADBONOFERIADO", bePlanillaDetalle.CantidadMinutosBonoFeriado));
                cmd.Parameters.Add(new SqlParameter("@TOTALBONOFERIADO", bePlanillaDetalle.TotalMinutoBonoFeriado));

                #endregion

                cmd.Parameters.Add(new SqlParameter("@TOTALBONO", bePlanillaDetalle.TotalBono));

                #endregion

                #region Descuentos (Tardanzas e Inasistencias)

                #region Tardanza

                cmd.Parameters.Add(new SqlParameter("@CANTIDADDESCUENTOTARDANZANORMAL", bePlanillaDetalle.CantidadMinutosDescuentoTardanzaNormal));
                cmd.Parameters.Add(new SqlParameter("@TOTALDESCUENTOTARDANZANORMAL", bePlanillaDetalle.TotalMinutoDescuentoTardanzaNormal));

                cmd.Parameters.Add(new SqlParameter("@CANTIDADDESCUENTOTARDANZAFERIADO", bePlanillaDetalle.CantidadMinutosDescuentoTardanzaFeriado));
                cmd.Parameters.Add(new SqlParameter("@TOTALDESCUENTOTARDANZAFERIADO", bePlanillaDetalle.TotalMinutoDescuentoTardanzaFeriado));

                cmd.Parameters.Add(new SqlParameter("@CANTIDADDESCUENTOTARDANZA", bePlanillaDetalle.CantidadMinutosDescuentoTardanza));
                cmd.Parameters.Add(new SqlParameter("@TOTALDESCUENTOTARDANZA", bePlanillaDetalle.TotalMinutoDescuentoTardanza));

                #endregion

                #region Inasistencia

                cmd.Parameters.Add(new SqlParameter("@CANTIDADDESCUENTOINASISTENCIA", bePlanillaDetalle.CantidadMinutosDescuentoInasistencia));
                cmd.Parameters.Add(new SqlParameter("@TOTALDESCUENTOINASISTENCIA", bePlanillaDetalle.TotalMinutoInasistencia));

                #endregion

                cmd.Parameters.Add(new SqlParameter("@TOTALDESCUENTO", bePlanillaDetalle.TotalDescuento));

                #endregion

                #region Sueldo Bruto
                cmd.Parameters.Add(new SqlParameter("@TOTALSUELDOBRUTO", bePlanillaDetalle.TotalSueldoBruto));
                #endregion

                #region Pension (AFP-Privado o ONP-Publico)

                #region ONP-SNP-Publica
                cmd.Parameters.Add(new SqlParameter("@SNP", bePlanillaDetalle.Snp));
                cmd.Parameters.Add(new SqlParameter("@SNPTOTAL", bePlanillaDetalle.SnpTotal));
                #endregion

                #region AFP-SPP-Privado
                if (bePlanillaDetalle.Afp != null)
                {
                    cmd.Parameters.Add(new SqlParameter("@AFPID", bePlanillaDetalle.Afp.IdAfp));
                    cmd.Parameters.Add(new SqlParameter("@AFPTIPO", bePlanillaDetalle.AfpTipo));
                }
                else
                {
                    cmd.Parameters.Add(new SqlParameter("@AFPID", DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@AFPTIPO", DBNull.Value));
                }
                cmd.Parameters.Add(new SqlParameter("@AFPAPORTEOBLIGATORIO", bePlanillaDetalle.AfpAporteObligatorio));
                cmd.Parameters.Add(new SqlParameter("@AFPAPORTEVOLUNTARIO", bePlanillaDetalle.AfpAporteVoluntario));
                cmd.Parameters.Add(new SqlParameter("@AFPSEGURO", bePlanillaDetalle.AfpSeguro));
                cmd.Parameters.Add(new SqlParameter("@AFPCOMISION", bePlanillaDetalle.AfpComision));
                cmd.Parameters.Add(new SqlParameter("@AFPTOTAL", bePlanillaDetalle.AfpTotal));

                #endregion

                cmd.Parameters.Add(new SqlParameter("@TOTALPENSION", bePlanillaDetalle.PensionTotal));

                #endregion

                #region Impuesto (5ta Categoria)
                cmd.Parameters.Add(new SqlParameter("@TOTALIMPUESTO", bePlanillaDetalle.ImpuestoTotal));
                #endregion

                #region Sueldo Neto
                cmd.Parameters.Add(new SqlParameter("@TOTALSUELDONETO", bePlanillaDetalle.TotalSueldoNeto));
                #endregion

                #region Deduccion (Retencion Judicial, Prestamos y Adelantos)

                #region Retencion Judicial 
                cmd.Parameters.Add(new SqlParameter("@RETENCIONJUDICIALPORCENTUAL", bePlanillaDetalle.RetencionJudicialPorcentual));
                cmd.Parameters.Add(new SqlParameter("@RETENCIONJUDICIALNOMINAL", bePlanillaDetalle.RetencionJudicialNominal));

                cmd.Parameters.Add(new SqlParameter("@RETENCIONJUDICIALTOTAL", bePlanillaDetalle.RetencionJudicialTotal));
                #endregion

                #region Adelanto
                cmd.Parameters.Add(new SqlParameter("@ADELANTOEFECTIVO", bePlanillaDetalle.AdelantoEfectivo));
                cmd.Parameters.Add(new SqlParameter("@ADELANTOBANCO", bePlanillaDetalle.AdelantoBanco));

                cmd.Parameters.Add(new SqlParameter("@ADELANTOTOTAL", bePlanillaDetalle.AdelantoTotal));
                #endregion

                #region Prestamo
                cmd.Parameters.Add(new SqlParameter("@PRESTAMOTOTAL", bePlanillaDetalle.PrestamoTotal));
                #endregion

                cmd.Parameters.Add(new SqlParameter("@TOTALDEDUCCION", bePlanillaDetalle.TotalDeduccion));

                #endregion

                #region Sueldo Pago
                cmd.Parameters.Add(new SqlParameter("@TOTAPAGO", bePlanillaDetalle.TotaPago));
                #endregion

                #region Salud (EsSalud)
                cmd.Parameters.Add(new SqlParameter("@ESSALUDTOTAL", bePlanillaDetalle.EsSaludTotal));
                #endregion

                rowsAffected += cmd.ExecuteNonQuery();
                bePlanillaDetalle.ID = int.Parse(cmd.Parameters["@IDPLANILLADETALLE"].Value.ToString());
                #endregion

                #region Registro del Resumen
                sp = "SpTbPlanillaDetalleResumenInsertar";

                cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = tns;

                cmd.Parameters.Add(new SqlParameter("@IDPLANILLADETALLERESUMEN", bePlanillaDetalle.ID));
                cmd.Parameters["@IDPLANILLADETALLERESUMEN"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add(new SqlParameter("@IDPLANILLA", idPlanilla));

                cmd.Parameters.Add(new SqlParameter("@CODIGOEMPLEADO", bePlanillaDetalle.CodigoEmpleado));

                cmd.Parameters.Add(new SqlParameter("@SueldoBase", bePlanillaDetalle.TotalSueldoBase));
                cmd.Parameters.Add(new SqlParameter("@SueldoBruto", bePlanillaDetalle.TotalSueldoBruto));
                cmd.Parameters.Add(new SqlParameter("@Pension", bePlanillaDetalle.PensionTotal));
                cmd.Parameters.Add(new SqlParameter("@Impuesto", bePlanillaDetalle.ImpuestoTotal));
                cmd.Parameters.Add(new SqlParameter("@SueldoNeto", bePlanillaDetalle.TotalSueldoNeto));
                cmd.Parameters.Add(new SqlParameter("@Deduccion", bePlanillaDetalle.TotalDeduccion));
                cmd.Parameters.Add(new SqlParameter("@SueldoPago", bePlanillaDetalle.TotaPago));

                rowsAffected += cmd.ExecuteNonQuery();
                bePlanillaDetalle.ID = int.Parse(cmd.Parameters["@IDPLANILLADETALLERESUMEN"].Value.ToString());
                #endregion

                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Registrar al detalle la asistencia de planilla
        /// </summary>
        /// <param name="idPlanilla">ID de Planilla</param>
        /// <param name="bePlanillaDetalle">Objeto Asistencia de Planilla</param>
        /// <param name="cnn">Referencia al Objeto conexion</param>
        /// <param name="tns">Referencia al Objeto transaccion</param>
        /// <returns></returns>
        private int InsertarPlanillaAsistencia(int idPlanilla,
                                                BE.PlanillaAsistencia bePlanillaAsistencia,
                                                ref SqlConnection cnn,
                                                ref SqlTransaction tns)
        {
            int rowsAffected = 0;
            try
            {

                string sp = "SpTbPlanillaAsistenciaInsertar";

                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = tns;

                cmd.Parameters.Add(new SqlParameter("@IDPLANILLAASISTENCIA", bePlanillaAsistencia.ID));
                cmd.Parameters["@IDPLANILLAASISTENCIA"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add(new SqlParameter("@IDPLANILLA", idPlanilla));

                cmd.Parameters.Add(new SqlParameter("@CODIGOEMPLEADO", bePlanillaAsistencia.CodigoEmpleado));

                #region Fechas y Horas
                cmd.Parameters.Add(new SqlParameter("@FECHA", bePlanillaAsistencia.Fecha));
                cmd.Parameters.Add(new SqlParameter("@SEMANA", bePlanillaAsistencia.Semana));
                cmd.Parameters.Add(new SqlParameter("@FECHAHORAINICIO", bePlanillaAsistencia.FechaHoraInicio));
                cmd.Parameters.Add(new SqlParameter("@FECHAHORAFINAL", bePlanillaAsistencia.FechaHoraFinal));
                #endregion

                #region Asistencias
                cmd.Parameters.Add(new SqlParameter("@MINUTOSASISTENCIATOTAL", bePlanillaAsistencia.MinutosAsistenciaTotal));

                cmd.Parameters.Add(new SqlParameter("@MINUTOSASISTENCIANORMALDIURNA", bePlanillaAsistencia.MinutosAsistenciaNormalDiurna));
                cmd.Parameters.Add(new SqlParameter("@MINUTOSASISTENCIANORMALNOCTURNA", bePlanillaAsistencia.MinutosAsistenciaNormalNocturna));
                cmd.Parameters.Add(new SqlParameter("@MINUTOSASISTENCIANORMALDIURNAEXTRA1", bePlanillaAsistencia.MinutosAsistenciaNormalDiurnaExtra1));
                cmd.Parameters.Add(new SqlParameter("@MINUTOSASISTENCIANORMALNOCTURNAEXTRA1", bePlanillaAsistencia.MinutosAsistenciaNormalNocturnaExtra1));
                cmd.Parameters.Add(new SqlParameter("@MINUTOSASISTENCIANORMALDIURNAEXTRA2", bePlanillaAsistencia.MinutosAsistenciaNormalDiurnaExtra2));
                cmd.Parameters.Add(new SqlParameter("@MINUTOSASISTENCIANORMALNOCTURNAEXTRA2", bePlanillaAsistencia.MinutosAsistenciaNormalNocturnaExtra2));

                cmd.Parameters.Add(new SqlParameter("@MINUTOSASISTENCIAFERIADODIURNA", bePlanillaAsistencia.MinutosAsistenciaFeriadoDiurna));
                cmd.Parameters.Add(new SqlParameter("@MINUTOSASISTENCIAFERIADONOCTURNA", bePlanillaAsistencia.MinutosAsistenciaFeriadoNocturna));
                cmd.Parameters.Add(new SqlParameter("@MINUTOSASISTENCIAFERIADODIURNAEXTRA1", bePlanillaAsistencia.MinutosAsistenciaFeriadoDiurnaExtra1));
                cmd.Parameters.Add(new SqlParameter("@MINUTOSASISTENCIAFERIADONOCTURNAEXTRA1", bePlanillaAsistencia.MinutosAsistenciaFeriadoNocturnaExtra1));
                cmd.Parameters.Add(new SqlParameter("@MINUTOSASISTENCIAFERIADODIURNAEXTRA2", bePlanillaAsistencia.MinutosAsistenciaFeriadoDiurnaExtra2));
                cmd.Parameters.Add(new SqlParameter("@MINUTOSASISTENCIAFERIADONOCTURNAEXTRA2", bePlanillaAsistencia.MinutosAsistenciaFeriadoNocturnaExtra2));
                #endregion

                #region Tardanzas
                cmd.Parameters.Add(new SqlParameter("@MINUTOSTARDANZATOTAL", bePlanillaAsistencia.MinutosTardanzaTotal));

                cmd.Parameters.Add(new SqlParameter("@MINUTOSTARDANZANORMALDIURNA", bePlanillaAsistencia.MinutosTardanzaNormalDiurna));
                cmd.Parameters.Add(new SqlParameter("@MINUTOSTARDANZANORMALNOCTURNA", bePlanillaAsistencia.MinutosTardanzaNormalNocturna));

                cmd.Parameters.Add(new SqlParameter("@MINUTOSTARDANZAFERIADODIURNA", bePlanillaAsistencia.MinutosTardanzaFeriadoDiurna));
                cmd.Parameters.Add(new SqlParameter("@MINUTOSTARDANZAFERIADONOCTURNA", bePlanillaAsistencia.MinutosTardanzaFeriadoNocturna));
                #endregion

                #region Inasistencias
                cmd.Parameters.Add(new SqlParameter("@MINUTOSINASISTENCIATOTAL", bePlanillaAsistencia.MinutosInasistenciaTotal));
                #endregion

                rowsAffected = cmd.ExecuteNonQuery();
                bePlanillaAsistencia.ID = int.Parse(cmd.Parameters["@IDPLANILLAASISTENCIA"].Value.ToString());

                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insertar(ref BE.Planilla bePlanilla)
        {
            SqlConnection cnn = null;
            SqlTransaction tns = null;

            bool rpta = false;

            try
            {
                int rowsAffected = 0;
                string sp = "";

                using (cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();
                    tns = cnn.BeginTransaction();

                    SqlCommand cmd = null;

                    #region Cabecera de Planilla
                    sp = "SpTbPlanillaInsertar";

                    cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Transaction = tns;

                    cmd.Parameters.Add(new SqlParameter("@IDPLANILLA", bePlanilla.ID));
                    cmd.Parameters["@IDPLANILLA"].Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(new SqlParameter("@ANHO", bePlanilla.Anho));
                    cmd.Parameters.Add(new SqlParameter("@MES", bePlanilla.Mes));
                    cmd.Parameters.Add(new SqlParameter("@DIASMES", bePlanilla.Dias));
                    cmd.Parameters.Add(new SqlParameter("@DIASBASE", bePlanilla.DiasBase));
                    cmd.Parameters.Add(new SqlParameter("@HORASBASE", bePlanilla.HorasBase));
                    cmd.Parameters.Add(new SqlParameter("@SUELDOMINIMO", bePlanilla.SueldoMinimo));
                    cmd.Parameters.Add(new SqlParameter("@ASIGNACIONFAMILIAR", bePlanilla.AsignacionFamiliar));
                    cmd.Parameters.Add(new SqlParameter("@PRIMERASDOSHORASEXTRAS", bePlanilla.PrimerasDosHorasExtras));
                    cmd.Parameters.Add(new SqlParameter("@POSTERIORDOSHORASEXTRAS", bePlanilla.PosterioresDosHorasExtras));
                    cmd.Parameters.Add(new SqlParameter("@ONP", bePlanilla.Onp));
                    cmd.Parameters.Add(new SqlParameter("@ESSALUD", bePlanilla.EsSalud));
                    cmd.Parameters.Add(new SqlParameter("@HORASNOCTURNAS", bePlanilla.Nocturno));
                    cmd.Parameters.Add(new SqlParameter("@FERIADO", bePlanilla.Feriado));

                    rowsAffected += cmd.ExecuteNonQuery();
                    bePlanilla.ID = int.Parse(cmd.Parameters["@IDPLANILLA"].Value.ToString());

                    #endregion

                    #region Asistencias de Planilla
                    foreach (BE.PlanillaAsistencia bePlanillaAsistencia in bePlanilla.Asistencias)
                    {
                        rowsAffected += this.InsertarPlanillaAsistencia(bePlanilla.ID, bePlanillaAsistencia,
                                                                        ref cnn, ref tns);
                    }
                    #endregion

                    #region Detalle de Planilla
                    foreach (BE.PlanillaDetalle bePlanillaDetalle in bePlanilla.Detalles)
                    {
                        rowsAffected += this.InsertarPlanillaDetalle(bePlanilla.ID, bePlanillaDetalle,
                                                                     ref cnn, ref tns);
                    }
                    #endregion

                    rpta = rowsAffected > 0 ? true : false;

                    if (tns != null)
                        tns.Commit();
                }

                return rpta;
            }
            catch (Exception ex)
            {

                if (tns != null)
                    tns.Rollback();

                throw ex;
            }
        }


        public DataTable ListarAsistenciaResumen(int anho, int mes, string codigoEmpleado = "")
        {
            try
            {
                string sp = "SpTbPlanillaAsistenciaResumen";
                DataTable dt = new DataTable();

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ANHO", anho));
                    cmd.Parameters.Add(new SqlParameter("@MES", mes));
                    if (codigoEmpleado == null || codigoEmpleado.Trim().Length == 0)
                        cmd.Parameters.Add(new SqlParameter("@CODIGOEMPLEADO", DBNull.Value));
                    else
                        cmd.Parameters.Add(new SqlParameter("@CODIGOEMPLEADO", codigoEmpleado));

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
        /// Calculo al detalle por dia sobre : 
        /// - Horas asistidas e inasistidas en Minutos
        /// - Horas normales y extras en Minutos
        /// - Minutos de Tardanza
        /// </summary>
        /// <param name="anho">Numero del año</param>
        /// <param name="mes">Numero del mes</param>
        /// <returns></returns>
        public DataTable ListarAsistencia(int anho, int mes)
        {
            try
            {
                string sp = "SpListarAsistenciaEmpleado";
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

        public List<BE.PlanillaAsistencia> ListarPlanillaAsistencia(int idPlanilla)
        {

            var lstBePlanillaAsistencias = new List<BE.PlanillaAsistencia>();

            try
            {
                string sp = "SpTbPlanillaAsistenciaListar";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IDPLANILLA", idPlanilla));

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                        var bePlanillaAsistencia = new BE.PlanillaAsistencia();

                        bePlanillaAsistencia.ID = int.Parse(reader["IdPlanillaAsistencia"].ToString());
                        bePlanillaAsistencia.CodigoEmpleado = reader["CodigoEmpleado"].ToString();
                        bePlanillaAsistencia.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                        bePlanillaAsistencia.Semana = int.Parse(reader["Semana"].ToString());
                        bePlanillaAsistencia.FechaHoraInicio = DateTime.Parse(reader["FechaHoraInicio"].ToString());
                        bePlanillaAsistencia.FechaHoraFinal = DateTime.Parse(reader["FechaHoraFinal"].ToString());
                        //bePlanillaAsistencia.MinutosAsistenciaTotal = int.Parse(reader["MinutosAsistenciaTotal"].ToString());
                        bePlanillaAsistencia.MinutosAsistenciaNormalDiurna = int.Parse(reader["MinutosAsistenciaNormalDiurna"].ToString());
                        bePlanillaAsistencia.MinutosAsistenciaNormalNocturna = int.Parse(reader["MinutosAsistenciaNormalNocturna"].ToString());
                        bePlanillaAsistencia.MinutosAsistenciaNormalDiurnaExtra1 = int.Parse(reader["MinutosAsistenciaNormalDiurnaExtra1"].ToString());
                        bePlanillaAsistencia.MinutosAsistenciaNormalNocturnaExtra1 = int.Parse(reader["MinutosAsistenciaNormalNocturnaExtra1"].ToString());
                        bePlanillaAsistencia.MinutosAsistenciaNormalDiurnaExtra2 = int.Parse(reader["MinutosAsistenciaNormalDiurnaExtra2"].ToString());
                        bePlanillaAsistencia.MinutosAsistenciaNormalNocturnaExtra2 = int.Parse(reader["MinutosAsistenciaNormalNocturnaExtra2"].ToString());
                        bePlanillaAsistencia.MinutosAsistenciaFeriadoDiurna = int.Parse(reader["MinutosAsistenciaFeriadoDiurna"].ToString());
                        bePlanillaAsistencia.MinutosAsistenciaFeriadoNocturna = int.Parse(reader["MinutosAsistenciaFeriadoNocturna"].ToString());
                        bePlanillaAsistencia.MinutosAsistenciaFeriadoDiurnaExtra1 = int.Parse(reader["MinutosAsistenciaFeriadoDiurnaExtra1"].ToString());
                        bePlanillaAsistencia.MinutosAsistenciaFeriadoNocturnaExtra1 = int.Parse(reader["MinutosAsistenciaFeriadoNocturnaExtra1"].ToString());
                        bePlanillaAsistencia.MinutosAsistenciaFeriadoDiurnaExtra2 = int.Parse(reader["MinutosAsistenciaFeriadoDiurnaExtra2"].ToString());
                        bePlanillaAsistencia.MinutosAsistenciaFeriadoNocturnaExtra2 = int.Parse(reader["MinutosAsistenciaFeriadoNocturnaExtra2"].ToString());
                        //bePlanillaAsistencia.MinutosTardanzaTotal = int.Parse(reader["MinutosTardanzaTotal"].ToString());
                        bePlanillaAsistencia.MinutosTardanzaNormalDiurna = int.Parse(reader["MinutosTardanzaNormalDiurna"].ToString());
                        bePlanillaAsistencia.MinutosTardanzaNormalNocturna = int.Parse(reader["MinutosTardanzaNormalNocturna"].ToString());
                        bePlanillaAsistencia.MinutosTardanzaFeriadoDiurna = int.Parse(reader["MinutosTardanzaFeriadoDiurna"].ToString());
                        bePlanillaAsistencia.MinutosTardanzaFeriadoNocturna = int.Parse(reader["MinutosTardanzaFeriadoNocturna"].ToString());
                        bePlanillaAsistencia.MinutosInasistenciaTotal = int.Parse(reader["MinutosInasistenciaTotal"].ToString());

                        lstBePlanillaAsistencias.Add(bePlanillaAsistencia);
                    }

                    cnn.Close();
                }

                return lstBePlanillaAsistencias;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}

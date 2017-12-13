using System;
using System.Windows.Forms;
using System.Data;
using System.Linq;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;
using System.Collections.Generic;
using System.Drawing;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmAsignarSueldoCalc : Form
    {

        private FrmAsignarSueldoList frmList = null;

        private int Anho = 0;
        private int Mes = 0;

        //Calculo detallado de Sueldos de los Candidatos
        private List<BE.UI.SueldoCandidato> lstUiSueldosCandidatos = null;

        private List<BE.UI.CandidatoCosto> lstUiCostosCandidatos = null;
        private List<BE.UI.CandidatoAsistencia> lstUiAsistenciasCandidatos = null;

        public FrmAsignarSueldoCalc(FrmAsignarSueldoList frmList)
        {
            try
            {
                InitializeComponent();
                this.frmList = frmList;
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }

        }

        private void Limpiar()
        {
            try
            {
                this.Anho = 0;
                this.Mes = 0;

                this.CargarAnhos();
                this.CargarMes();
                this.cboAnho.SelectedValue = DateTime.Now.Year.ToString();
                this.cboMes.SelectedValue = DateTime.Now.Month.ToString();
                
                this.CargarAsistenciasPor();
                this.CargarAsistenciasCandidatos();
                this.FormatoAsistenciasCandidatos();

                this.CargarCostosPor();
                this.CargarCostosCandidatos();
                this.FormatoCostosCandidatos();

                this.CargarSueldosCandidatos();
                this.FormatoSueldosCandidatos();

                this.txtMes.Clear();
                this.txtAnho.Clear();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        private double SueldoInasistencia(string codigoCandidato)
        {
            try
            {
                double SueldoInasistencia = 0.0;

                double sueldoMinimo = 0.0;
                int diasMes = 0;
                int horasDia = 0;
                using (var beParametros = new BE.Parametros())
                {
                    sueldoMinimo = beParametros.SueldoMinimo;
                    diasMes = beParametros.BaseDias;
                    horasDia = beParametros.BaseHoras;
                }

                double costoMinuto = ((sueldoMinimo / diasMes) / horasDia) / 60;
                double penalidadNormal = costoMinuto * 3;
                double penalidadFeriado = costoMinuto * 5;

                //var lnRecibo = new LN.Recibo(this.Anho, this.Mes);

                //var uiAsistenciaResumen = lnRecibo.ObtenerResumenAsistenciaCandidato(codigoCandidato);
                //if (uiAsistenciaResumen != null)
                //{
                //    double SueldoInasistenciaNormal = uiAsistenciaResumen.CantidadInasistenciasNormales * penalidadNormal;
                //    double SueldoInasistenciaFeriado = uiAsistenciaResumen.CantidadInasistenciasFeriados * penalidadFeriado;

                //    double SueldoInasistenciaRecibo = 0.0;
                //    var uiPlanillDetalle = lnRecibo.ObtenerPlantillaDetalle(codigoCandidato);
                //    if (uiPlanillDetalle != null)
                //        SueldoInasistenciaRecibo = uiPlanillDetalle.SueldoInasistenciaTotal;

                //    SueldoInasistencia = SueldoInasistenciaNormal 
                //                          + SueldoInasistenciaFeriado 
                //                          - SueldoInasistenciaRecibo;
                //}
                //else
                //{
                //    DateTime fechaPeriodo = new DateTime(this.Anho, this.Mes, 1);
                //    string mensajeError = $"No encuentra calculo de Recibo para el periodo {fechaPeriodo.ToString("yyyy/MM")}";
                //    throw new Exception(mensajeError);
                //}
                //uiAsistenciaResumen = null;

                return SueldoInasistencia;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarAnhos()
        {
            try
            {
                int anhoInicio = 2017;
                int anhoFinal = DateTime.Now.Year + 5;

                var lstAnhos = new List<BE.Record>();
                for (int i = anhoInicio; i < anhoFinal; i++)
                {
                    lstAnhos.Add(new BE.Record() { Codigo = i.ToString(), Nombre = i.ToString() });
                }

                this.cboAnho.DataSource = lstAnhos;
                this.cboAnho.DisplayMember = "Nombre";
                this.cboAnho.ValueMember = "Codigo";

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<BE.Record> ListaCandidatos()
        {
            try
            {
                var lstCandidatos = new LN.Candidato().Combo();
                lstCandidatos = lstCandidatos.OrderBy(o => o.Codigo).ToList();
                return lstCandidatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarMes()
        {
            try
            {

                var lstMes = new List<BE.Record>();

                for (int i = 1; i <= 12; i++)
                {
                    lstMes.Add(new BE.Record() { Codigo = i.ToString(), Nombre = Util.GetNameOfMonth(i) });
                }

                this.cboMes.DataSource = lstMes;
                this.cboMes.DisplayMember = "Nombre";
                this.cboMes.ValueMember = "Codigo";

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///<summary>
        ///Cargar los tipos de Costos en combobox
        ///</summary>
        private void CargarCostosPor()
        {
            try
            {

                var lstCostoPor = new List<BE.Record>();

                lstCostoPor.Add(new BE.Record() { Codigo = "D", Nombre = "Dia" });
                lstCostoPor.Add(new BE.Record() { Codigo = "H", Nombre = "Hora" });
                lstCostoPor.Add(new BE.Record() { Codigo = "M", Nombre = "Minuto" });

                this.cboCostoPor.DataSource = lstCostoPor;
                this.cboCostoPor.DisplayMember = "Nombre";
                this.cboCostoPor.ValueMember = "Codigo";

                this.cboCostoPor.SelectedValue = "M";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///<summary>
        ///Cargar los tipos de Calculo en combobox
        ///</summary>
        private void CargarAsistenciasPor()
        {
            try
            {

                var lstCalculoPor = new List<BE.Record>();

                lstCalculoPor.Add(new BE.Record() { Codigo = "H", Nombre = "Hora" });
                lstCalculoPor.Add(new BE.Record() { Codigo = "M", Nombre = "Minuto" });

                this.cboAsistenciaPor.DataSource = lstCalculoPor;
                this.cboAsistenciaPor.DisplayMember = "Nombre";
                this.cboAsistenciaPor.ValueMember = "Codigo";

                this.cboAsistenciaPor.SelectedValue = "M";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///<summary>
        ///Obtener calculo del costo segun el tipo (D = Dia, H = Hora, M = Minuto)
        ///</summary>
        private double ObtenerCostoPor(string tipo, 
                                        double valor, 
                                        BE.Parametros beParametros)
        {
            double costoPor = 0.0;
            try
            {
                if (beParametros != null)
                {
                    switch (tipo)
                    {
                        case "D":
                            costoPor = valor / beParametros.BaseDias;
                            break;
                        case "H":
                            costoPor = (valor / beParametros.BaseDias) / beParametros.BaseHoras;
                            break;
                        case "M":
                            costoPor = ((valor / beParametros.BaseDias) / beParametros.BaseHoras) / 60;
                            break;
                        default:
                            costoPor = 0.0;
                            break;
                    }
                }

                return Math.Round(costoPor, 4);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Calcular y Mostrar la lista de los costos por Candidato
        /// </summary>
        /// <param name="anho">Año en formato de 4 digitos</param>
        /// <param name="mes">Mes en rango de 1 al 12</param>
        private void CargarCostosCandidatos(int anho = 0, int mes = 0)
        {
            try
            {

                if (anho == 0 && mes == 0) //No realiza calculo
                {
                    this.lstUiCostosCandidatos = new List<BE.UI.CandidatoCosto>();
                }
                else
                {
                    double sueldoMinimo = 0.0;
                    int dias = DateTime.DaysInMonth(anho, mes);

                    var beSueldoMinimo = new LN.SueldoMinimo().Actual(new DateTime(anho, mes, dias));
                    if (beSueldoMinimo == null)
                    {
                        string periodo = string.Format("{0:D4}/{1:D2}", anho, mes);
                        string msg = $"No existe el sueldo minimo para el periodo { periodo }";
                        throw new Exception(msg);
                    }
                    else
                        sueldoMinimo = beSueldoMinimo.Monto;

                    var beParametros = new BE.Parametros(sueldoMinimo);

                    var lstUiCandidatosSueldos = new LN.Recibo().ListarSueldos();
                    foreach (BE.UI.CandidatoSueldo uiCandidatoSueldo in lstUiCandidatosSueldos)
                    {

                        string codigoCandidato = uiCandidatoSueldo.Codigo;
                        double sueldoBase = uiCandidatoSueldo.Sueldo;
                        double asigFamBase = 0.0; //No se usa para candidatos
                        string codCostoPor = "M"; //Por Minuto = M

                        #region Calculo de Costos

                        double costoBase = this.ObtenerCostoPor(codCostoPor, (sueldoBase + asigFamBase), beParametros);

                        double normalDiurno = costoBase;
                        double normalDiurnoExtra1 = normalDiurno * beParametros.HorasExtras1Factor;
                        double normalDiurnoExtra2 = normalDiurno * beParametros.HorasExtras2Factor;
                        double normalNocturno = normalDiurno * beParametros.HorarioNocturnoFactor;
                        double normalNocturnoExtra1 = normalNocturno * beParametros.HorasExtras1Factor;
                        double normalNocturnoExtra2 = normalNocturno * beParametros.HorasExtras2Factor;

                        double feriadoDiurno = costoBase * beParametros.FeriadoFactor;
                        double feriadoDiurnoExtra1 = feriadoDiurno * beParametros.HorasExtras1Factor;
                        double feriadoDiurnoExtra2 = feriadoDiurno * beParametros.HorasExtras2Factor;
                        double feriadoNocturno = feriadoDiurno * beParametros.HorarioNocturnoFactor;
                        double feriadoNocturnoExtra1 = feriadoNocturno * beParametros.HorasExtras1Factor;
                        double feriadoNocturnoExtra2 = feriadoNocturno * beParametros.HorasExtras2Factor;

                        #endregion

                        #region Descuento

                        double descuentoBase = this.ObtenerCostoPor(codCostoPor, sueldoBase, beParametros);

                        double tardanzaNormalDiurno = descuentoBase;
                        double tardanzaNormalNocturno = tardanzaNormalDiurno * beParametros.HorarioNocturnoFactor;
                        double tardanzaFeriadoDiurno = descuentoBase * beParametros.FeriadoFactor;
                        double tardanzaFeriadoNocturno = tardanzaFeriadoDiurno * beParametros.HorarioNocturnoFactor;

                        double dominical = Math.Round(descuentoBase / beParametros.BaseDias, 4);
                        double inasistencia = descuentoBase + dominical;

                        #endregion

                        #region Cargar

                        var uiCandidatoCosto = new BE.UI.CandidatoCosto();

                        uiCandidatoCosto.Codigo = codigoCandidato;
                        uiCandidatoCosto.Sueldo = sueldoBase;
                        uiCandidatoCosto.AsignacionFamiliar = asigFamBase;
                        uiCandidatoCosto.CostosPor = codCostoPor;
                        uiCandidatoCosto.NormalDiurno = normalDiurno;
                        uiCandidatoCosto.NormalDiurnoExtra1 = normalDiurnoExtra1;
                        uiCandidatoCosto.NormalDiurnoExtra2 = normalDiurnoExtra2;
                        uiCandidatoCosto.NormalNocturno = normalNocturno;
                        uiCandidatoCosto.NormalNocturnoExtra1 = normalNocturnoExtra1;
                        uiCandidatoCosto.NormalNocturnoExtra2 = normalNocturnoExtra2;
                        uiCandidatoCosto.FeriadoDiurno = feriadoDiurno;
                        uiCandidatoCosto.FeriadoDiurnoExtra1 = feriadoDiurnoExtra1;
                        uiCandidatoCosto.FeriadoDiurnoExtra2 = feriadoDiurnoExtra2;
                        uiCandidatoCosto.FeriadoNocturno = feriadoNocturno;
                        uiCandidatoCosto.FeriadoNocturnoExtra1 = feriadoNocturnoExtra1;
                        uiCandidatoCosto.FeriadoNocturnoExtra2 = feriadoNocturnoExtra2;
                        uiCandidatoCosto.TardanzaNormalDiurno = tardanzaNormalDiurno;
                        uiCandidatoCosto.TardanzaNormalNocturno = tardanzaNormalNocturno;
                        uiCandidatoCosto.TardanzaFeriadoDiurno = tardanzaFeriadoDiurno;
                        uiCandidatoCosto.TardanzaFeriadoNocturno = tardanzaFeriadoNocturno;
                        uiCandidatoCosto.Dominical = dominical;
                        uiCandidatoCosto.Inasistencia = inasistencia;

                        this.lstUiCostosCandidatos.Add(uiCandidatoCosto);

                        #endregion

                    }
                }
                
                var sorted = new SortableBindingList<BE.UI.CandidatoCosto>(this.lstUiCostosCandidatos);
                this.dgvCostos.DataSource = sorted;

                int nroCostos = this.lstUiCostosCandidatos.Count;
                this.txtRegistrosCostos.Text = nroCostos.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///  Mostrar la lista detallada de las Asistencias de los Candidatos
        /// </summary>
        /// <param name="anho">Año en formato de 4 digitos</param>
        /// <param name="mes">Mes en rango de 1 al 12</param>
        private void CargarAsistenciasCandidatos(int anho = 0, int mes = 0)
        {
            try
            {

                if (anho == 0 && mes == 0)
                {
                    this.lstUiAsistenciasCandidatos = new List<BE.UI.CandidatoAsistencia>();
                }
                else
                {
                    this.lstUiAsistenciasCandidatos = new LN.Recibo().ListarAsistencias(this.Anho, this.Mes);
                    for (int i = 0; i < this.lstUiAsistenciasCandidatos.Count; i++)
                        this.lstUiAsistenciasCandidatos[i].FormateadoCalculo = "H";
                }

                var sorted = new SortableBindingList<BE.UI.CandidatoAsistencia>(this.lstUiAsistenciasCandidatos);
                this.dgvAsistencias.DataSource = sorted;

                int nroAsistencias = this.lstUiAsistenciasCandidatos.Count;
                this.txtRegistrosAsistencias.Text = nroAsistencias.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarSueldosCandidatos(int anho = 0, int mes = 0)
        {
            try
            {

                if (anho == 0 && mes == 0)
                {
                    this.lstUiSueldosCandidatos = new List<BE.UI.SueldoCandidato>();
                }
                else
                {

                    //Calcular

                    //Asignar valores globales de año y mes 
                    this.Anho = anho;
                    this.Mes = mes;

                    //Mostrar valores globales
                    this.txtAnho.Text = anho.ToString();
                    this.txtMes.Text = Util.GetNameOfMonth(Mes);

                }

                var sorted = new SortableBindingList<BE.UI.SueldoCandidato>(this.lstUiSueldosCandidatos);
                this.dgvSueldos.DataSource = sorted;

                int nroSueldos = this.lstUiSueldosCandidatos.Count;
                this.txtNroSueldos.Text = nroSueldos.ToString();

                double totalSueldos = this.lstUiSueldosCandidatos.Sum(x => x.TotalNeto);
                this.txtTotalSueldos.Text = totalSueldos.ToString("N2");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FormatoSueldosCandidatos()
        {
            try
            {
                Util.FormatDatagridview(ref this.dgvSueldos);

                for (int col = 0; col < this.dgvSueldos.Columns.Count; col++)
                    this.dgvSueldos.Columns[col].Visible = false;

                this.dgvSueldos.Columns["Fecha"].Visible = true;
                this.dgvSueldos.Columns["Fecha"].HeaderText = "Fecha";
                this.dgvSueldos.Columns["Fecha"].Width = 80;
                this.dgvSueldos.Columns["Fecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvSueldos.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";

                this.dgvSueldos.Columns["CandidatoCodigo"].Visible = true;
                this.dgvSueldos.Columns["CandidatoCodigo"].HeaderText = "Codigo";
                this.dgvSueldos.Columns["CandidatoCodigo"].Width = 80;
                this.dgvSueldos.Columns["CandidatoCodigo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvSueldos.Columns["CandidatoNombreCompleto"].Visible = true;
                this.dgvSueldos.Columns["CandidatoNombreCompleto"].HeaderText = "Candidato";
                this.dgvSueldos.Columns["CandidatoNombreCompleto"].Width = 200;
                this.dgvSueldos.Columns["CandidatoNombreCompleto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvSueldos.Columns["Sueldo"].Visible = true;
                this.dgvSueldos.Columns["Sueldo"].HeaderText = "Sueldo";
                this.dgvSueldos.Columns["Sueldo"].Width = 80;
                this.dgvSueldos.Columns["Sueldo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvSueldos.Columns["Sueldo"].DefaultCellStyle.Format = "N2";

                this.dgvSueldos.Columns["BonoNocturnoTotal"].Visible = true;
                this.dgvSueldos.Columns["BonoNocturnoTotal"].HeaderText = "Bono Nocturno";
                this.dgvSueldos.Columns["BonoNocturnoTotal"].Width = 80;
                this.dgvSueldos.Columns["BonoNocturnoTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvSueldos.Columns["BonoNocturnoTotal"].DefaultCellStyle.Format = "N2";

                this.dgvSueldos.Columns["BonoHorasExtrasTotal"].Visible = true;
                this.dgvSueldos.Columns["BonoHorasExtrasTotal"].HeaderText = "Bono Horas Extras";
                this.dgvSueldos.Columns["BonoHorasExtrasTotal"].Width = 80;
                this.dgvSueldos.Columns["BonoHorasExtrasTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvSueldos.Columns["BonoHorasExtrasTotal"].DefaultCellStyle.Format = "N2";

                this.dgvSueldos.Columns["BonoFeriadoTotal"].Visible = true;
                this.dgvSueldos.Columns["BonoFeriadoTotal"].HeaderText = "Bono Feriado";
                this.dgvSueldos.Columns["BonoFeriadoTotal"].Width = 80;
                this.dgvSueldos.Columns["BonoFeriadoTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvSueldos.Columns["BonoFeriadoTotal"].DefaultCellStyle.Format = "N2";

                this.dgvSueldos.Columns["DescuentoTardanzaTotal"].Visible = true;
                this.dgvSueldos.Columns["DescuentoTardanzaTotal"].HeaderText = "Descuento Tardanza";
                this.dgvSueldos.Columns["DescuentoTardanzaTotal"].Width = 80;
                this.dgvSueldos.Columns["DescuentoTardanzaTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvSueldos.Columns["DescuentoTardanzaTotal"].DefaultCellStyle.Format = "N2";

                this.dgvSueldos.Columns["DescuentoInasistenciaTotal"].Visible = true;
                this.dgvSueldos.Columns["DescuentoInasistenciaTotal"].HeaderText = "Descuento Inasistencia";
                this.dgvSueldos.Columns["DescuentoInasistenciaTotal"].Width = 80;
                this.dgvSueldos.Columns["DescuentoInasistenciaTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvSueldos.Columns["DescuentoInasistenciaTotal"].DefaultCellStyle.Format = "N2";

                Util.AutoWidthColumn(ref this.dgvSueldos, "CandidatoNombreCompleto");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FormatoAsistenciasCandidatos()
        {
            try
            {
                Util.FormatDatagridview(ref this.dgvAsistencias);

                for (int col = 0; col < this.dgvAsistencias.Columns.Count; col++)
                    this.dgvAsistencias.Columns[col].Visible = false;

                this.dgvAsistencias.Columns["Codigo"].Visible = true;
                this.dgvAsistencias.Columns["Codigo"].HeaderText = "Codigo";
                this.dgvAsistencias.Columns["Codigo"].Width = 80;
                this.dgvAsistencias.Columns["Codigo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvAsistencias.Columns["Fecha"].Visible = true;
                this.dgvAsistencias.Columns["Fecha"].Width = 70;
                this.dgvAsistencias.Columns["Fecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvAsistencias.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";

                this.dgvAsistencias.Columns["FechaHoraInicio"].Visible = true;
                this.dgvAsistencias.Columns["FechaHoraInicio"].HeaderText = "Inicio Horario";
                this.dgvAsistencias.Columns["FechaHoraInicio"].Width = 120;
                this.dgvAsistencias.Columns["FechaHoraInicio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvAsistencias.Columns["FechaHoraInicio"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";

                this.dgvAsistencias.Columns["FechaHoraFinal"].Visible = true;
                this.dgvAsistencias.Columns["FechaHoraFinal"].HeaderText = "Final Horario";
                this.dgvAsistencias.Columns["FechaHoraFinal"].Width = 120;
                this.dgvAsistencias.Columns["FechaHoraFinal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvAsistencias.Columns["FechaHoraFinal"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";

                int iniHoras = 0;
                int finHoras = 0;

                //Asistencias Normal
                iniHoras = this.dgvAsistencias.Columns["FormateadoAsistenciaNormalTotal"].Index;
                finHoras = this.dgvAsistencias.Columns["FormateadoTardanzaNormalNocturna"].Index + 1;
                for (int i = iniHoras; i < finHoras; i++)
                {
                    this.dgvAsistencias.Columns[i].Visible = true;
                    this.dgvAsistencias.Columns[i].Width = 70;
                    this.dgvAsistencias.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    this.dgvAsistencias.Columns[i].DefaultCellStyle.BackColor = Color.LightGreen;
                }

                this.dgvAsistencias.Columns["FormateadoAsistenciaNormalTotal"].Visible = false;
                this.dgvAsistencias.Columns["FormateadoAsistenciaNormalTotal"].HeaderText = "Asistencia Total";

                this.dgvAsistencias.Columns["FormateadoAsistenciaNormalDiurna"].HeaderText = "Horario Diurno";
                this.dgvAsistencias.Columns["FormateadoAsistenciaNormalNocturna"].HeaderText = "Horario Nocturno";
                this.dgvAsistencias.Columns["FormateadoAsistenciaNormalDiurnaExtra1"].HeaderText = "Extras 25% Diurno";
                this.dgvAsistencias.Columns["FormateadoAsistenciaNormalNocturnaExtra1"].HeaderText = "Extras 25% Nocturno";
                this.dgvAsistencias.Columns["FormateadoAsistenciaNormalDiurnaExtra2"].HeaderText = "Extras 35% Diurno";
                this.dgvAsistencias.Columns["FormateadoAsistenciaNormalNocturnaExtra2"].HeaderText = "Extras 35% Nocturno";

                this.dgvAsistencias.Columns["FormateadoTardanzaNormalTotal"].Visible = false;
                this.dgvAsistencias.Columns["FormateadoAsistenciaNormalTotal"].HeaderText = "Tardanza Total";

                this.dgvAsistencias.Columns["FormateadoTardanzaNormalDiurna"].HeaderText = "Tardanza Diurna";
                this.dgvAsistencias.Columns["FormateadoTardanzaNormalNocturna"].HeaderText = "Tardanza Nocturna";

                //Asistencias Feriados
                iniHoras = this.dgvAsistencias.Columns["FormateadoAsistenciaFeriadoTotal"].Index;
                finHoras = this.dgvAsistencias.Columns["FormateadoTardanzaFeriadoNocturna"].Index + 1;
                for (int i = iniHoras; i < finHoras; i++)
                {
                    this.dgvAsistencias.Columns[i].Visible = true;
                    this.dgvAsistencias.Columns[i].Width = 70;
                    this.dgvAsistencias.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    this.dgvAsistencias.Columns[i].DefaultCellStyle.BackColor = Color.LightYellow;
                }

                this.dgvAsistencias.Columns["FormateadoAsistenciaFeriadoTotal"].Visible = false;
                this.dgvAsistencias.Columns["FormateadoAsistenciaFeriadoTotal"].HeaderText = "Asistencia Total";

                this.dgvAsistencias.Columns["FormateadoAsistenciaFeriadoDiurna"].HeaderText = "Horario Diurno";
                this.dgvAsistencias.Columns["FormateadoAsistenciaFeriadoNocturna"].HeaderText = "Horario Nocturno";
                this.dgvAsistencias.Columns["FormateadoAsistenciaFeriadoDiurnaExtra1"].HeaderText = "Extras 25% Diurno";
                this.dgvAsistencias.Columns["FormateadoAsistenciaFeriadoNocturnaExtra1"].HeaderText = "Extras 25% Nocturno";
                this.dgvAsistencias.Columns["FormateadoAsistenciaFeriadoDiurnaExtra2"].HeaderText = "Extras 35% Diurno";
                this.dgvAsistencias.Columns["FormateadoAsistenciaFeriadoNocturnaExtra2"].HeaderText = "Extras 35% Nocturno";

                this.dgvAsistencias.Columns["FormateadoTardanzaFeriadoTotal"].Visible = false;
                this.dgvAsistencias.Columns["TardanzaFeriadoTotal"].HeaderText = "Tardanza Total";

                this.dgvAsistencias.Columns["FormateadoTardanzaFeriadoDiurna"].HeaderText = "Tardanza Diurna";
                this.dgvAsistencias.Columns["FormateadoTardanzaFeriadoNocturna"].HeaderText = "Tardanza Nocturna";

                //Inasistencias
                iniHoras = this.dgvAsistencias.Columns["FormateadoInasistenciaNormal"].Index;
                finHoras = this.dgvAsistencias.Columns["FormateadoInasistenciaFeriado"].Index + 1;
                for (int i = iniHoras; i < finHoras; i++)
                {
                    this.dgvAsistencias.Columns[i].Visible = true;
                    this.dgvAsistencias.Columns[i].Width = 70;
                    this.dgvAsistencias.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    this.dgvAsistencias.Columns[i].DefaultCellStyle.BackColor = Color.Red;
                }
                this.dgvAsistencias.Columns["FormateadoInasistenciaNormal"].HeaderText = "Inasistencia Normal";
                this.dgvAsistencias.Columns["FormateadoInasistenciaFeriado"].HeaderText = "Inasistencia Feriado";

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FormatoCostosCandidatos()
        {
            try
            {
                Util.FormatDatagridview(ref this.dgvCostos);

                for (int col = 0; col < this.dgvCostos.Columns.Count; col++)
                    this.dgvCostos.Columns[col].Visible = false;

                this.dgvCostos.Columns["Codigo"].Visible = true;
                this.dgvCostos.Columns["Codigo"].HeaderText = "Codigo";
                this.dgvCostos.Columns["Codigo"].Width = 80;
                this.dgvCostos.Columns["Codigo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvCostos.Columns["Sueldo"].Visible = true;
                this.dgvCostos.Columns["Sueldo"].HeaderText = "Sueldo";
                this.dgvCostos.Columns["Sueldo"].Width = 70;
                this.dgvCostos.Columns["Sueldo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvCostos.Columns["Sueldo"].DefaultCellStyle.Format = "N2";

                this.dgvCostos.Columns["AsignacionFamiliar"].Visible = true;
                this.dgvCostos.Columns["AsignacionFamiliar"].HeaderText = "Asignacion Familiar";
                this.dgvCostos.Columns["AsignacionFamiliar"].Width = 70;
                this.dgvCostos.Columns["AsignacionFamiliar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvCostos.Columns["AsignacionFamiliar"].DefaultCellStyle.Format = "N2";

                int iniInx = 0;
                int finInx = 0;

                //Costo Normal
                iniInx = this.dgvCostos.Columns["NormalDiurno"].Index;
                finInx = this.dgvCostos.Columns["NormalNocturnoExtra2"].Index + 1;
                for (int i = iniInx; i < finInx; i++)
                {
                    this.dgvCostos.Columns[i].Visible = true;
                    this.dgvCostos.Columns[i].Width = 100;
                    this.dgvCostos.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    this.dgvCostos.Columns[i].DefaultCellStyle.Format = "N4";
                    this.dgvCostos.Columns[i].DefaultCellStyle.BackColor = Color.LightGreen;
                }

                this.dgvCostos.Columns["NormalDiurno"].HeaderText = "Horario Diurno";
                this.dgvCostos.Columns["NormalDiurnoExtra1"].HeaderText = "Extras 25% Diurno";
                this.dgvCostos.Columns["NormalDiurnoExtra2"].HeaderText = "Extras 35% Diurno";
                this.dgvCostos.Columns["NormalNocturno"].HeaderText = "Horario Nocturno";
                this.dgvCostos.Columns["NormalNocturnoExtra1"].HeaderText = "Extras 25% Nocturno";
                this.dgvCostos.Columns["NormalNocturnoExtra2"].HeaderText = "Extras 35% Nocturno";

                //Costo Feriado
                iniInx = this.dgvCostos.Columns["FeriadoDiurno"].Index;
                finInx = this.dgvCostos.Columns["FeriadoNocturnoExtra2"].Index + 1;
                for (int i = iniInx; i < finInx; i++)
                {
                    this.dgvCostos.Columns[i].Visible = true;
                    this.dgvCostos.Columns[i].Width = 100;
                    this.dgvCostos.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    this.dgvCostos.Columns[i].DefaultCellStyle.Format = "N4";
                    this.dgvCostos.Columns[i].DefaultCellStyle.BackColor = Color.LightYellow;
                }

                this.dgvCostos.Columns["FeriadoDiurno"].HeaderText = "Feriado Diurno";
                this.dgvCostos.Columns["FeriadoDiurnoExtra1"].HeaderText = "Extras 25% Diurno";
                this.dgvCostos.Columns["FeriadoDiurnoExtra2"].HeaderText = "Extras 35% Diurno";
                this.dgvCostos.Columns["FeriadoNocturno"].HeaderText = "Feriado Nocturno";
                this.dgvCostos.Columns["FeriadoNocturnoExtra1"].HeaderText = "Extras 25% Nocturno";
                this.dgvCostos.Columns["FeriadoNocturnoExtra2"].HeaderText = "Extras 35% Nocturno";

                //Descuento Tardanza Normal
                iniInx = this.dgvCostos.Columns["TardanzaNormalDiurno"].Index;
                finInx = this.dgvCostos.Columns["TardanzaNormalNocturno"].Index + 1;
                for (int i = iniInx; i < finInx; i++)
                {
                    this.dgvCostos.Columns[i].Visible = true;
                    this.dgvCostos.Columns[i].Width = 100;
                    this.dgvCostos.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    this.dgvCostos.Columns[i].DefaultCellStyle.Format = "N4";
                    this.dgvCostos.Columns[i].DefaultCellStyle.BackColor = Color.Green;
                }

                this.dgvCostos.Columns["TardanzaNormalDiurno"].HeaderText = "Tardanza Diurno";
                this.dgvCostos.Columns["TardanzaNormalNocturno"].HeaderText = "Tardanza Nocturno";

                //Descuento Tardanza Feriado
                iniInx = this.dgvCostos.Columns["TardanzaFeriadoDiurno"].Index;
                finInx = this.dgvCostos.Columns["TardanzaFeriadoNocturno"].Index + 1;
                for (int i = iniInx; i < finInx; i++)
                {
                    this.dgvCostos.Columns[i].Visible = true;
                    this.dgvCostos.Columns[i].Width = 100;
                    this.dgvCostos.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    this.dgvCostos.Columns[i].DefaultCellStyle.Format = "N4";
                    this.dgvCostos.Columns[i].DefaultCellStyle.BackColor = Color.Yellow;
                }
                this.dgvCostos.Columns["TardanzaFeriadoDiurno"].HeaderText = "Tardanza Diurno";
                this.dgvCostos.Columns["TardanzaFeriadoNocturno"].HeaderText = "Tardanza Nocturno";

                //Descuento Inasistencia
                iniInx = this.dgvCostos.Columns["Dominical"].Index;
                finInx = this.dgvCostos.Columns["Inasistencia"].Index + 1;
                for (int i = iniInx; i < finInx; i++)
                {
                    this.dgvCostos.Columns[i].Visible = true;
                    this.dgvCostos.Columns[i].Width = 100;
                    this.dgvCostos.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    this.dgvCostos.Columns[i].DefaultCellStyle.Format = "N4";
                    this.dgvCostos.Columns[i].DefaultCellStyle.BackColor = Color.Red;
                }
                this.dgvCostos.Columns["Dominical"].HeaderText = "Dominical";
                this.dgvCostos.Columns["Inasistencia"].HeaderText = "Inasistencia";

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Formulario

        private void FrmAsignarSueldoCalc_Load(object sender, EventArgs e)
        {
            try
            {
                this.Limpiar();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {

                Util.PointerLoad(this);

                #region Validar Existencia del calculo

                int anho = int.Parse(this.cboAnho.SelectedValue.ToString());
                int mes = int.Parse(this.cboMes.SelectedValue.ToString());
                if (new LN.SueldoCandidato().ExisteCalculo(anho, mes))
                {
                    if (Util.ConfirmationMessage("Ya existe un calculo de Sueldos para este periodo. ¿Desea continua?") == false)
                        return;
                }

                #endregion

                #region Calcular y Mostrar

                this.CargarCostosCandidatos(anho, mes);
                this.CargarAsistenciasCandidatos(anho, mes);
                this.CargarSueldosCandidatos(anho, mes);

                ////Limpiar Lista Global de los Sueldos
                //this.lstUiSueldosCandidatos = new List<BE.UI.SueldoCandidato>();

                //int dia = DateTime.DaysInMonth(anho, mes);
                //DateTime fechaPeriodo = new DateTime(anho, mes, dia);

                ////Obtener la lista de Candidatos
                //List<BE.Record> lstCandidatos = ListaCandidatos();
                //foreach (BE.Record beCandidato in lstCandidatos)
                //{
                    
                //    var uiSueldoCandidato = new BE.UI.SueldoCandidato();

                //    uiSueldoCandidato.Fecha = fechaPeriodo;

                //    uiSueldoCandidato.CandidatoCodigo = beCandidato.Codigo;
                //    uiSueldoCandidato.CandidatoNombreCompleto = beCandidato.Nombre;

                //    //uiSueldoCandidato.Sueldo = SueldoId;
                //    //uiSueldoCandidato.SueldoTipo = SueldoTipo;
                //    //uiSueldoCandidato.SueldoNombre = SueldoNombre;

                //    //uiSueldoCandidato.Monto = SueldoMonto;
                //    //uiSueldoCandidato.Motivo = "";

                //    //if (SueldoMonto > 0.0)
                //    //    lstUiSueldosCandidatos.Add(uiSueldoCandidato);

                //}
                
                #endregion

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
            finally
            {
                Util.PointerReady(this);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.lstUiAsistenciasCandidatos.Count == 0)
                    throw new Exception("Debe realizar un calculo de Sueldos");

                if (this.lstUiCostosCandidatos.Count == 0)
                    throw new Exception("Debe realizar un calculo de Sueldos");

                if (this.lstUiSueldosCandidatos.Count == 0)
                    throw new Exception("Debe realizar un calculo de Sueldos");

                if (Util.ConfirmationMessage("¿Desea guardar los sueldos calculados?") == false)
                    return;

                bool rpta = false;
                var lnSueldoCandidato = new LN.SueldoCandidato();
                for (int i = 0; i < this.lstUiSueldosCandidatos.Count; i++)
                {
                    BE.UI.SueldoCandidato uiSueldoCandidato = this.lstUiSueldosCandidatos[i];
                    rpta = lnSueldoCandidato.Insertar(ref uiSueldoCandidato);
                    this.lstUiSueldosCandidatos[i].ID = uiSueldoCandidato.ID;
                }

                Util.InformationMessage("Se guardo los sueldos calculados");

                if (this.frmList != null)
                    this.frmList.CargarListadoSueldos();

                this.Close();

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                var rpta = Util.ConfirmationMessage($"¿Desea salir del formulario { this.Text }?");

                if (rpta == false)
                    return;

                this.Close();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }



        #endregion
        
    }
}

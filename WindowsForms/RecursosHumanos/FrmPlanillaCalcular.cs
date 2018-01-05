using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmPlanillaCalcular : Form
    {

        #region "Patron Singleton"

        private static FrmPlanillaCalcular frmInstance = null;

        public static FrmPlanillaCalcular Instance()
        {

            if (frmInstance == null || frmInstance.IsDisposed == true)
            {
                frmInstance = new FrmPlanillaCalcular();
            }

            frmInstance.BringToFront();

            return frmInstance;
        }

        #endregion

        private List<BE.UI.PlanillaAsistencia> lstUiAsistencias = null;
        private List<BE.UI.PlanillaCosto> lstUiCostos = null;

        private int anho = DateTime.Now.Year;
        private int mes = DateTime.Now.Month;

        private BE.Parametros beParametros = null; 

        public FrmPlanillaCalcular()
        {
            try
            {
                InitializeComponent();

                this.beParametros = new BE.Parametros();

                this.lstUiCostos = new List<BE.UI.PlanillaCosto>();
                this.lstUiAsistencias = new List<BE.UI.PlanillaAsistencia>();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }

        }

        #region Metodos

        /// <summary>
        /// Redondear numero decimal a 2 decimales
        /// </summary>
        /// <param name="valor">Valor decimal</param>
        /// <returns></returns>
        private double RedondeoFinal(double valor)
        {
            try
            {
                int cantidadDecimales = 2;
                return Math.Round(valor, cantidadDecimales);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///<summary>
        ///Obtener calculo del costo segun el tipo (Dia, Hora, Minuto)
        ///</summary>
        private double ObtenerCostoPor(string tipo, double valor)
        {
            double costoPor = 0.0;
            try
            {
                switch (tipo)
                {
                    case "D":
                        costoPor = valor / this.beParametros.BaseDias;
                        break;
                    case "H":
                        costoPor = (valor / this.beParametros.BaseDias) / this.beParametros.BaseHoras;
                        break;
                    case "M":
                        costoPor = ((valor / this.beParametros.BaseDias) / this.beParametros.BaseHoras) / 60;
                        break;
                    default:
                        costoPor = 0.0;
                        break;
                }

                return costoPor;
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

                this.cboCalculoPor.DataSource = lstCalculoPor;
                this.cboCalculoPor.DisplayMember = "Nombre";
                this.cboCalculoPor.ValueMember = "Codigo";

                this.cboCalculoPor.SelectedValue = "M";
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

        private void CargarMes()
        {
            try
            {

                var lstMes = new List<BE.Record>();

                lstMes.Add(new BE.Record() { Codigo = "1", Nombre = "Enero" });
                lstMes.Add(new BE.Record() { Codigo = "2", Nombre = "Febrero" });
                lstMes.Add(new BE.Record() { Codigo = "3", Nombre = "Marzo" });
                lstMes.Add(new BE.Record() { Codigo = "4", Nombre = "Abril" });
                lstMes.Add(new BE.Record() { Codigo = "5", Nombre = "Mayo" });
                lstMes.Add(new BE.Record() { Codigo = "6", Nombre = "Junio" });
                lstMes.Add(new BE.Record() { Codigo = "7", Nombre = "Julio" });
                lstMes.Add(new BE.Record() { Codigo = "8", Nombre = "Agosto" });
                lstMes.Add(new BE.Record() { Codigo = "9", Nombre = "Setiembre" });
                lstMes.Add(new BE.Record() { Codigo = "10", Nombre = "Octubre" });
                lstMes.Add(new BE.Record() { Codigo = "11", Nombre = "Noviembre" });
                lstMes.Add(new BE.Record() { Codigo = "12", Nombre = "Diciembre" });

                this.cboMes.DataSource = lstMes;
                this.cboMes.DisplayMember = "Nombre";
                this.cboMes.ValueMember = "Codigo";

                this.cboMes.SelectedValue = DateTime.Now.Month.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarAsistencias()
        {
            try
            {
                var source = new BindingSource();
                source.DataSource = this.lstUiAsistencias;
                this.dgvAsistencias.DataSource = source;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FormatoAsistencias()
        {
            try
            {

                Util.FormatDatagridview(ref this.dgvAsistencias);
                for (int i = 0; i < this.dgvAsistencias.Columns.Count; i++)
                    this.dgvAsistencias.Columns[i].Visible = false;

                this.dgvAsistencias.Columns["CodigoEmpleado"].Visible = true;
                this.dgvAsistencias.Columns["CodigoEmpleado"].HeaderText = "Codigo";
                this.dgvAsistencias.Columns["CodigoEmpleado"].Width = 80;
                this.dgvAsistencias.Columns["CodigoEmpleado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

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

        /// <summary>
        /// Cargar la lista de Asistencias en Minutos
        /// 1. Asistencia Normal y Feriado
        /// 2. Tardanzas Normal y Feriado
        /// 3. Inasistencias 
        /// Agrupados por Empleado y dia (Fecha)
        /// </summary>
        private void CalcularAsistencias()
        {
            try
            {
                #region Limpiar

                this.lstUiAsistencias.Clear();

                #endregion

                #region Obtener la lista de asistencias por minuto por Anho y Mes

                this.lstUiAsistencias = new LN.Planilla(anho, mes).ListarAsistencia();

                string calcular = this.cboCalculoPor.SelectedValue.ToString();
                for (int i = 0; i < this.lstUiAsistencias.Count; i++)
                    this.lstUiAsistencias[i].FormateadoCalculo = calcular;

                #endregion

                #region Cargar y Mostrar

                var sorted = new SortableBindingList<BE.UI.PlanillaAsistencia>(lstUiAsistencias);
                this.dgvAsistencias.DataSource = sorted;

                this.txtRegistrosAsistencias.Text = this.lstUiAsistencias.Count.ToString();
                
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void CalcularCostos()
        {
            try
            {

                #region Limpiar
                this.lstUiCostos.Clear();
                #endregion

                #region Cargar Parametros Iniciales
                int dias = DateTime.DaysInMonth(this.anho, this.mes);
                DateTime fecha = new DateTime(this.anho, this.mes, dias);

                var beSueldoMinimo = new LN.SueldoMinimo().Actual(fecha);
                if (beSueldoMinimo == null)
                    throw new Exception("No existe configurado el Sueldo Minimo");
 
                double sueldoMinimo = beSueldoMinimo.Monto;

                this.beParametros = new BE.Parametros(sueldoMinimo);
                #endregion

                var empleados = new LN.Planilla(this.anho, this.mes).ListarSueldos();
                foreach (DataRow emp in empleados.Rows)
                {
                    string codCandidato = emp["Codigo"].ToString();

                    double sueldoBase = Math.Round(double.Parse(emp["Sueldo"].ToString()), 2);
                    bool tieneHijos = bool.Parse(emp["Hijos"].ToString());
                    double asignacionFamiliar = 0.0;
                    if (tieneHijos == true)
                        asignacionFamiliar = this.beParametros.AsignacionFamiliar;

                    string codCostoPor = this.cboCostoPor.SelectedValue.ToString();

                    #region Costos
                    double costoBase = Math.Round(this.ObtenerCostoPor(codCostoPor, (sueldoBase + asignacionFamiliar)), 4);

                    double normalDiurno = costoBase;
                    double normalDiurnoExtra1 = normalDiurno * this.beParametros.HorasExtras1Factor;
                    double normalDiurnoExtra2 = normalDiurno * this.beParametros.HorasExtras2Factor;
                    double normalNocturno = normalDiurno * this.beParametros.HorarioNocturnoFactor;
                    double normalNocturnoExtra1 = normalNocturno * this.beParametros.HorasExtras1Factor;
                    double normalNocturnoExtra2 = normalNocturno * this.beParametros.HorasExtras2Factor;

                    double feriadoDiurno = costoBase * this.beParametros.FeriadoFactor;
                    double feriadoDiurnoExtra1 = feriadoDiurno * this.beParametros.HorasExtras1Factor;
                    double feriadoDiurnoExtra2 = feriadoDiurno * this.beParametros.HorasExtras2Factor;
                    double feriadoNocturno = feriadoDiurno * this.beParametros.HorarioNocturnoFactor;
                    double feriadoNocturnoExtra1 = feriadoNocturno * this.beParametros.HorasExtras1Factor;
                    double feriadoNocturnoExtra2 = feriadoNocturno * this.beParametros.HorasExtras2Factor;
                    #endregion

                    #region Descuento
                    double descuentoBase = Math.Round(this.ObtenerCostoPor(codCostoPor, sueldoBase), 4);

                    double tardanzaNormalDiurno = descuentoBase;
                    double tardanzaNormalNocturno = tardanzaNormalDiurno * this.beParametros.HorarioNocturnoFactor;
                    double tardanzaFeriadoDiurno = descuentoBase * this.beParametros.FeriadoFactor;
                    double tardanzaFeriadoNocturno = tardanzaFeriadoDiurno * this.beParametros.HorarioNocturnoFactor;

                    double dominical = Math.Round(descuentoBase / this.beParametros.BaseDias, 4);
                    double inasistencia = descuentoBase + dominical;
                    #endregion

                    #region Cargar
                    var objCosto = new BE.UI.PlanillaCosto();
                    objCosto.Codigo = codCandidato;
                    objCosto.Sueldo = sueldoBase;
                    objCosto.AsignacionFamiliar = asignacionFamiliar;
                    objCosto.CostosPor = codCostoPor;
                    objCosto.NormalDiurno = normalDiurno;
                    objCosto.NormalDiurnoExtra1 = normalDiurnoExtra1;
                    objCosto.NormalDiurnoExtra2 = normalDiurnoExtra2;
                    objCosto.NormalNocturno = normalNocturno;
                    objCosto.NormalNocturnoExtra1 = normalNocturnoExtra1;
                    objCosto.NormalNocturnoExtra2 = normalNocturnoExtra2;
                    objCosto.FeriadoDiurno = feriadoDiurno;
                    objCosto.FeriadoDiurnoExtra1 = feriadoDiurnoExtra1;
                    objCosto.FeriadoDiurnoExtra2 = feriadoDiurnoExtra2;
                    objCosto.FeriadoNocturno = feriadoNocturno;
                    objCosto.FeriadoNocturnoExtra1 = feriadoNocturnoExtra1;
                    objCosto.FeriadoNocturnoExtra2 = feriadoNocturnoExtra2;
                    objCosto.TardanzaNormalDiurno = tardanzaNormalDiurno;
                    objCosto.TardanzaNormalNocturno = tardanzaNormalNocturno;
                    objCosto.TardanzaFeriadoDiurno = tardanzaFeriadoDiurno;
                    objCosto.TardanzaFeriadoNocturno = tardanzaFeriadoNocturno;
                    objCosto.Dominical = dominical;
                    objCosto.Inasistencia = inasistencia;
                    this.lstUiCostos.Add(objCosto);
                    #endregion

                }

                #region Mostar
                var sorted = new SortableBindingList<BE.UI.PlanillaCosto>(this.lstUiCostos);
                this.dgvCostos.DataSource = sorted;
                
                this.txtRegistrosCostos.Text = this.lstUiCostos.Count.ToString();
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FormatoCostos()
        {
            try
            {

                if (this.lstUiCostos == null)
                    return;

                var source = new BindingSource();
                source.DataSource = this.lstUiCostos;
                this.dgvCostos.DataSource = source;

                this.dgvCostos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                this.dgvCostos.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
                this.dgvCostos.ReadOnly = true;
                this.dgvCostos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                this.dgvCostos.AllowUserToAddRows = false;
                this.dgvCostos.AllowUserToDeleteRows = false;
                this.dgvCostos.MultiSelect = false;
                this.dgvCostos.AllowDrop = false;
                this.dgvCostos.RowHeadersVisible = false;

                this.dgvCostos.Columns["CodigoEmpleado"].Visible = true;
                this.dgvCostos.Columns["CodigoEmpleado"].HeaderText = "Codigo";
                this.dgvCostos.Columns["CodigoEmpleado"].Width = 80;
                this.dgvCostos.Columns["CodigoEmpleado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

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

                this.dgvCostos.Columns["CostosPor"].Visible = false;
                
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

        #endregion

        #region Formulario

        private void FrmPlanillaCalcular_Load(object sender, EventArgs e)
        {
            try
            {

                this.CargarAnhos();
                this.CargarMes();

                this.cboAnho.SelectedValue = DateTime.Now.Year.ToString();
                this.cboMes.SelectedValue = DateTime.Now.Month.ToString();

                #region Pestaña Costos
                this.CargarCostosPor();

                this.FormatoCostos();
                #endregion

                #region Pestaña Asistencias

                this.CargarAsistenciasPor();

                this.lstUiAsistencias = new List<BE.UI.PlanillaAsistencia>();

                this.CargarAsistencias();
                this.FormatoAsistencias();

                #endregion

                

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                this.anho = int.Parse(this.cboAnho.SelectedValue.ToString());
                this.mes = int.Parse(this.cboMes.SelectedValue.ToString());

                this.CalcularCostos();
                this.CalcularAsistencias();

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void cboCostoPor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                this.CalcularCostos();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void cboCalculoPor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                this.CalcularAsistencias();

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void btnExportarCostoCsv_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Comma-separated Values (*.csv)|*.csv";
                sfd.FileName = "export.csv";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Util.PointerLoad(this);
                    Util.DatagridviewToCsv(this.dgvCostos, sfd.FileName);
                    Util.InformationMessage("Se exporto correctamente el archivo CSV");
                }
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

        private void btnExportarAsistenciasCsv_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Comma-separated Values (*.csv)|*.csv";
                sfd.FileName = "export.csv";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Util.PointerLoad(this);
                    Util.DatagridviewToCsv(this.dgvAsistencias, sfd.FileName);
                    Util.InformationMessage("Se exporto correctamente el archivo CSV");
                }
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

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {

                Util.PointerLoad(this);

                var lnPlanilla = new LN.Planilla(this.anho, this.mes);

                double porcentajePensionOnp = 0.0;
                double factorPensionOnp = 0.0;

                #region Validaciones de Formulario

                if (this.lstUiAsistencias == null || this.lstUiAsistencias.Count == 0)
                {
                    return;
                }

                if (this.lstUiCostos == null || this.lstUiCostos.Count == 0)
                {
                    return;
                }

                if (this.anho != int.Parse(this.cboAnho.SelectedValue.ToString()))
                {
                    return;
                }

                if (this.mes != int.Parse(this.cboMes.SelectedValue.ToString()))
                {
                    return;
                }

                var beOnpComision = new LN.OnpComision().Obtener(this.anho, this.mes);
                if (beOnpComision == null)
                {
                    throw new Exception("No existe una comisión de ONP para este periodo");
                }
                factorPensionOnp = beOnpComision.AportePorcentual / 100;
                porcentajePensionOnp = beOnpComision.AportePorcentual;
                beOnpComision = null;

                if (new LN.AfpComision().Listar(this.anho, this.mes).Count == 0)
                {
                    throw new Exception("No existe una comisión de AFP para este periodo");
                }

                if (lnPlanilla.Existe() == true)
                {
                    throw new Exception("Ya existe la planilla para dicho periodo");
                }

                #endregion

                #region Preparar listas en Minutos

                #region Clona listas de Costos y Asistencias 

                var lstCostosMinutos = new List<BE.UI.PlanillaCosto>();
                var lstAsistenciasMinutos = new List<BE.UI.PlanillaAsistencia>();

                lstCostosMinutos = this.lstUiCostos.Select(uiPlanillaCosto => (BE.UI.PlanillaCosto)uiPlanillaCosto.Clone()).ToList();
                lstAsistenciasMinutos = this.lstUiAsistencias.Select(uiPlanillaAsistencia => (BE.UI.PlanillaAsistencia)uiPlanillaAsistencia.Clone()).ToList();

                #endregion

                #region Conversion de Costos a minutos
                for (int i = 0; i < lstCostosMinutos.Count; i++)
                {
                    switch (lstCostosMinutos[i].CostosPor)
                    {
                        case "H": 
                            lstCostosMinutos[i].CostosPor = "M";
                            lstCostosMinutos[i].NormalDiurno *= 60;
                            lstCostosMinutos[i].NormalDiurnoExtra1 *= 60;
                            lstCostosMinutos[i].NormalDiurnoExtra2 *= 60;
                            lstCostosMinutos[i].NormalNocturno *= 60;
                            lstCostosMinutos[i].NormalNocturnoExtra1 *= 60;
                            lstCostosMinutos[i].NormalNocturnoExtra2 *= 60;
                            lstCostosMinutos[i].FeriadoDiurno *= 60;
                            lstCostosMinutos[i].FeriadoDiurnoExtra1 *= 60;
                            lstCostosMinutos[i].FeriadoDiurnoExtra2 *= 60;
                            lstCostosMinutos[i].FeriadoNocturno *= 60;
                            lstCostosMinutos[i].FeriadoNocturnoExtra1 *= 60;
                            lstCostosMinutos[i].FeriadoNocturnoExtra2 *= 60;
                            lstCostosMinutos[i].TardanzaNormalDiurno *= 60;
                            lstCostosMinutos[i].TardanzaNormalNocturno *= 60;
                            lstCostosMinutos[i].TardanzaFeriadoDiurno *= 60;
                            lstCostosMinutos[i].TardanzaFeriadoNocturno *= 60;
                            lstCostosMinutos[i].Dominical *= 60;
                            lstCostosMinutos[i].Inasistencia *= 60;
                            break;
                        case "D": 
                            lstCostosMinutos[i].CostosPor = "M";
                            lstCostosMinutos[i].NormalDiurno *= 480;
                            lstCostosMinutos[i].NormalDiurnoExtra1 *= 480;
                            lstCostosMinutos[i].NormalDiurnoExtra2 *= 480;
                            lstCostosMinutos[i].NormalNocturno *= 480;
                            lstCostosMinutos[i].NormalNocturnoExtra1 *= 480;
                            lstCostosMinutos[i].NormalNocturnoExtra2 *= 480;
                            lstCostosMinutos[i].FeriadoDiurno *= 480;
                            lstCostosMinutos[i].FeriadoDiurnoExtra1 *= 480;
                            lstCostosMinutos[i].FeriadoDiurnoExtra2 *= 480;
                            lstCostosMinutos[i].FeriadoNocturno *= 480;
                            lstCostosMinutos[i].FeriadoNocturnoExtra1 *= 480;
                            lstCostosMinutos[i].FeriadoNocturnoExtra2 *= 480;
                            lstCostosMinutos[i].TardanzaNormalDiurno *= 480;
                            lstCostosMinutos[i].TardanzaNormalNocturno *= 480;
                            lstCostosMinutos[i].TardanzaFeriadoDiurno *= 480;
                            lstCostosMinutos[i].TardanzaFeriadoNocturno *= 480;
                            lstCostosMinutos[i].Dominical *= 480;
                            lstCostosMinutos[i].Inasistencia *= 480;
                            break;
                        default:
                            break;
                    }
                }
                #endregion

                #endregion

                var bePlanilla = new BE.Planilla();

                #region Cabecera de Planilla

                #region Fecha del Periodo

                bePlanilla.Anho = this.anho;
                bePlanilla.Mes = this.mes;
                bePlanilla.Dias = DateTime.DaysInMonth(anho, mes);

                #endregion

                //Datos Base
                bePlanilla.DiasBase = this.beParametros.BaseDias;
                bePlanilla.HorasBase = this.beParametros.BaseHoras;

                #region Monto Sueldo Minimo

                var beSueldoMinimo = new LN.SueldoMinimo().Actual(bePlanilla.Anho, bePlanilla.Mes);
                if (beSueldoMinimo == null)
                    throw new Exception("No existe configurado el Sueldo Minimo");
                bePlanilla.SueldoMinimo = beSueldoMinimo.Monto;
                beSueldoMinimo = null;

                #endregion

                #region Porcentajes Generales

                bePlanilla.Onp = porcentajePensionOnp;
                bePlanilla.EsSalud = beParametros.EsSaludPorcentaje;
                bePlanilla.AsignacionFamiliar = beParametros.AsignacionFamiliarPorcentaje;
                bePlanilla.PrimerasDosHorasExtras = beParametros.HorasExtras1Porcentaje;
                bePlanilla.PosterioresDosHorasExtras = beParametros.HorasExtras2Porcentaje;
                bePlanilla.Nocturno = beParametros.HorarioNocturnoPorcentaje;
                bePlanilla.Feriado = beParametros.FeriadoPorcentaje;

                #endregion

                #endregion

                #region Detalle de Planilla (Costo, Cantidad, Resumen)

                var lstBePlanillaDetalle = new List<BE.PlanillaDetalle>();

                //Costos en minutos por empleado 
                foreach (BE.UI.PlanillaCosto uiPlanillaCosto in lstCostosMinutos)
                {

                    var bePlanillaDetalle = new BE.PlanillaDetalle();

                    #region Datos de Empleado
                    string codEmpleado = uiPlanillaCosto.Codigo.ToString();
                    var beEmpleado = new LN.Empleado().Obtener(codEmpleado, true);

                    bePlanillaDetalle.CodigoEmpleado = beEmpleado.Codigo;
                    bePlanillaDetalle.IdCargo = beEmpleado.Recurso.Cargo.IdCargo;
                    #endregion

                    #region Sueldo
                    bePlanillaDetalle.SueldoBase = uiPlanillaCosto.Sueldo;
                    bePlanillaDetalle.AsignacionFamiliar = uiPlanillaCosto.AsignacionFamiliar;
                    #endregion

                    #region Costos (Minutos)

                    double costoMinutoHorarioDiurno = 0.0;
                    double costoMinutoHorarioNocturno = 0.0;
                    double costoMinutoExtra25Diurno = 0.0;
                    double costoMinutoExtra25Nocturno = 0.0;
                    double costoMinutoExtra35Diurno = 0.0;
                    double costoMinutoExtra35Nocturno = 0.0;

                    #region Horario Normal
                    costoMinutoHorarioDiurno = Math.Round(uiPlanillaCosto.NormalDiurno, 4);
                    costoMinutoHorarioNocturno = Math.Round(uiPlanillaCosto.NormalNocturno, 4);
                    costoMinutoExtra25Diurno = Math.Round(uiPlanillaCosto.NormalDiurnoExtra1, 4);
                    costoMinutoExtra25Nocturno = Math.Round(uiPlanillaCosto.NormalNocturnoExtra1, 4);
                    costoMinutoExtra35Diurno = Math.Round(uiPlanillaCosto.NormalDiurnoExtra2, 4);
                    costoMinutoExtra35Nocturno = Math.Round(uiPlanillaCosto.NormalNocturnoExtra2, 4);

                    bePlanillaDetalle.CostoMinutoNormalDiurno = costoMinutoHorarioDiurno;
                    bePlanillaDetalle.CostoMinutoNormalNocturno = costoMinutoHorarioNocturno;
                    bePlanillaDetalle.CostoMinutoNormalDiurnoExtras1 = costoMinutoExtra25Diurno;
                    bePlanillaDetalle.CostoMinutoNormalNocturnoExtras1 = costoMinutoExtra25Nocturno;
                    bePlanillaDetalle.CostoMinutoNormalDiurnoExtras2 = costoMinutoExtra35Diurno;
                    bePlanillaDetalle.CostoMinutoNormalNocturnoExtras2 = costoMinutoExtra35Nocturno;
                    #endregion

                    #region Horario Feriado

                    costoMinutoHorarioDiurno = Math.Round(uiPlanillaCosto.FeriadoDiurno, 4);
                    costoMinutoHorarioNocturno = Math.Round(uiPlanillaCosto.FeriadoNocturno, 4);
                    costoMinutoExtra25Diurno = Math.Round(uiPlanillaCosto.FeriadoDiurnoExtra1, 4);
                    costoMinutoExtra25Nocturno = Math.Round(uiPlanillaCosto.FeriadoNocturnoExtra1, 4);
                    costoMinutoExtra35Diurno = Math.Round(uiPlanillaCosto.FeriadoDiurnoExtra2, 4);
                    costoMinutoExtra35Nocturno = Math.Round(uiPlanillaCosto.FeriadoNocturnoExtra2, 4);

                    bePlanillaDetalle.CostoMinutoFeriadoDiurno = costoMinutoHorarioDiurno;
                    bePlanillaDetalle.CostoMinutoFeriadoNocturno = costoMinutoHorarioNocturno;
                    bePlanillaDetalle.CostoMinutoFeriadoDiurnoExtras1 = costoMinutoExtra25Diurno;
                    bePlanillaDetalle.CostoMinutoFeriadoNocturnoExtras1 = costoMinutoExtra25Nocturno;
                    bePlanillaDetalle.CostoMinutoFeriadoDiurnoExtras2 = costoMinutoExtra35Diurno;
                    bePlanillaDetalle.CostoMinutoFeriadoNocturnoExtras2 = costoMinutoExtra35Nocturno;
                   
                    #endregion

                    #endregion

                    #region Descuentos (Minutos)

                    double descuentoMinutoHorarioDiurno = 0.0;
                    double descuentoMinutoHorarioNocturno = 0.0;

                    #region Tardanza - Horario Normal
                    descuentoMinutoHorarioDiurno = Math.Round(uiPlanillaCosto.TardanzaNormalDiurno, 4);
                    descuentoMinutoHorarioNocturno = Math.Round(uiPlanillaCosto.TardanzaNormalNocturno, 4);

                    bePlanillaDetalle.DescuentoMinutoTardanzaNormalDiurno = descuentoMinutoHorarioDiurno;
                    bePlanillaDetalle.DescuentoMinutoTardanzaNormalNocturno = descuentoMinutoHorarioNocturno;
                    #endregion

                    #region Tardanza - Horario Feriado
                    descuentoMinutoHorarioDiurno = Math.Round(uiPlanillaCosto.TardanzaFeriadoDiurno, 4);
                    descuentoMinutoHorarioNocturno = Math.Round(uiPlanillaCosto.TardanzaFeriadoNocturno, 4);

                    bePlanillaDetalle.DescuentoMinutoTardanzaFeriadoDiurno = descuentoMinutoHorarioDiurno;
                    bePlanillaDetalle.DescuentoMinutoTardanzaFeriadoNocturno = descuentoMinutoHorarioNocturno;
                    #endregion

                    double descuentoMinutoDominical = 0.0;
                    double descuentoMinutoInasistencia = 0.0;

                    #region Inasistencia
                    descuentoMinutoDominical = Math.Round(uiPlanillaCosto.Dominical, 4);
                    descuentoMinutoInasistencia = Math.Round(uiPlanillaCosto.Inasistencia, 4);

                    bePlanillaDetalle.DescuentoMinutoDominical = descuentoMinutoDominical;
                    bePlanillaDetalle.DescuentoMinutoInasistencia = descuentoMinutoInasistencia;
                    #endregion

                    #endregion

                    #region Cantidad (Minutos)

                    #region Asistencias

                    int cantidadMinutoHorarioDiurno = 0;
                    int cantidadMinutoHorarioNocturno = 0;
                    int cantidadMinutoExtra25Diurno = 0;
                    int cantidadMinutoExtra25Nocturno = 0;
                    int cantidadMinutoExtra35Diurno = 0;
                    int cantidadMinutoExtra35Nocturno = 0;

                    #region Asistencias Normal
                    cantidadMinutoHorarioDiurno = (int)lstAsistenciasMinutos.AsEnumerable().Where(x => x.Codigo == codEmpleado).Sum(x => x.AsistenciaNormalDiurna);
                    cantidadMinutoHorarioNocturno = (int)lstAsistenciasMinutos.AsEnumerable().Where(x => x.Codigo == codEmpleado).Sum(x => x.AsistenciaNormalNocturna);
                    cantidadMinutoExtra25Diurno = (int)lstAsistenciasMinutos.AsEnumerable().Where(x => x.Codigo == codEmpleado).Sum(x => x.AsistenciaNormalDiurnaExtra1);
                    cantidadMinutoExtra25Nocturno = (int)lstAsistenciasMinutos.AsEnumerable().Where(x => x.Codigo == codEmpleado).Sum(x => x.AsistenciaNormalNocturnaExtra1);
                    cantidadMinutoExtra35Diurno = (int)lstAsistenciasMinutos.AsEnumerable().Where(x => x.Codigo == codEmpleado).Sum(x => x.AsistenciaNormalDiurnaExtra2);
                    cantidadMinutoExtra35Nocturno = (int)lstAsistenciasMinutos.AsEnumerable().Where(x => x.Codigo == codEmpleado).Sum(x => x.AsistenciaNormalNocturnaExtra2);

                    bePlanillaDetalle.CantidadMinutosAsistenciaNormalDiurno = cantidadMinutoHorarioDiurno;
                    bePlanillaDetalle.CantidadMinutosAsistenciaNormalNocturno = cantidadMinutoHorarioNocturno;
                    bePlanillaDetalle.CantidadMinutosAsistenciaNormalDiurnoExtras1 = cantidadMinutoExtra25Diurno;
                    bePlanillaDetalle.CantidadMinutosAsistenciaNormalNocturnoExtras1 = cantidadMinutoExtra25Nocturno;
                    bePlanillaDetalle.CantidadMinutosAsistenciaNormalDiurnoExtras2 = cantidadMinutoExtra35Diurno;
                    bePlanillaDetalle.CantidadMinutosAsistenciaNormalNocturnoExtras2 = cantidadMinutoExtra35Nocturno;
                    #endregion

                    #region Asistencias Feriado
                    cantidadMinutoHorarioDiurno = (int)lstAsistenciasMinutos.AsEnumerable().Where(x => x.Codigo == codEmpleado).Sum(x => x.AsistenciaFeriadoDiurna);
                    cantidadMinutoHorarioNocturno = (int)lstAsistenciasMinutos.AsEnumerable().Where(x => x.Codigo == codEmpleado).Sum(x => x.AsistenciaFeriadoNocturna);
                    cantidadMinutoExtra25Diurno = (int)lstAsistenciasMinutos.AsEnumerable().Where(x => x.Codigo == codEmpleado).Sum(x => x.AsistenciaFeriadoDiurnaExtra1);
                    cantidadMinutoExtra25Nocturno = (int)lstAsistenciasMinutos.AsEnumerable().Where(x => x.Codigo == codEmpleado).Sum(x => x.AsistenciaFeriadoNocturnaExtra1);
                    cantidadMinutoExtra35Diurno = (int)lstAsistenciasMinutos.AsEnumerable().Where(x => x.Codigo == codEmpleado).Sum(x => x.AsistenciaFeriadoDiurnaExtra2);
                    cantidadMinutoExtra35Nocturno = (int)lstAsistenciasMinutos.AsEnumerable().Where(x => x.Codigo == codEmpleado).Sum(x => x.AsistenciaFeriadoNocturnaExtra2);

                    bePlanillaDetalle.CantidadMinutosAsistenciaFeriadoDiurno = cantidadMinutoHorarioDiurno;
                    bePlanillaDetalle.CantidadMinutosAsistenciaFeriadoNocturno = cantidadMinutoHorarioNocturno;
                    bePlanillaDetalle.CantidadMinutosAsistenciaFeriadoDiurnoExtras1 = cantidadMinutoExtra25Diurno;
                    bePlanillaDetalle.CantidadMinutosAsistenciaFeriadoNocturnoExtras1 = cantidadMinutoExtra25Nocturno;
                    bePlanillaDetalle.CantidadMinutosAsistenciaFeriadoDiurnoExtras2 = cantidadMinutoExtra35Diurno;
                    bePlanillaDetalle.CantidadMinutosAsistenciaFeriadoNocturnoExtras2 = cantidadMinutoExtra35Nocturno;
                    #endregion

                    #endregion

                    #region Tardanzas
                    int cantidadMinutoTardanzaDiurno = 0;
                    int cantidadMinutoTardanzaNocturno = 0;

                    #region Tardanzas Normal
                    cantidadMinutoTardanzaDiurno = (int)lstAsistenciasMinutos.AsEnumerable().Where(x => x.Codigo == codEmpleado).Sum(x => x.TardanzaNormalDiurna);
                    cantidadMinutoTardanzaNocturno = (int)lstAsistenciasMinutos.AsEnumerable().Where(x => x.Codigo == codEmpleado).Sum(x => x.TardanzaNormalNocturna);

                    bePlanillaDetalle.CantidadMinutosTardanzaNormalDiurno = cantidadMinutoTardanzaDiurno;
                    bePlanillaDetalle.CantidadMinutosTardanzaNormalNocturno = cantidadMinutoTardanzaNocturno;
                    #endregion

                    #region Tardanzas Feriado
                    cantidadMinutoTardanzaDiurno = (int)lstAsistenciasMinutos.AsEnumerable().Where(x => x.Codigo == codEmpleado).Sum(x => x.TardanzaFeriadoDiurna);
                    cantidadMinutoTardanzaNocturno = (int)lstAsistenciasMinutos.AsEnumerable().Where(x => x.Codigo == codEmpleado).Sum(x => x.TardanzaFeriadoNocturna);

                    bePlanillaDetalle.CantidadMinutosTardanzaFeriadoDiurno = cantidadMinutoTardanzaDiurno;
                    bePlanillaDetalle.CantidadMinutosTardanzaFeriadoNocturno = cantidadMinutoTardanzaNocturno;
                    #endregion

                    #endregion

                    #region Inasistencias
                    int cantidadMinutoInasistencia = (int)lstAsistenciasMinutos.AsEnumerable().Where(x => x.Codigo == codEmpleado).Sum(x => x.InasistenciaTotal);

                    bePlanillaDetalle.CantidadMinutosInasistencia = cantidadMinutoInasistencia;
                    #endregion

                    #endregion

                    #region Sudsidio por Descanso Médico (Bono)

                    bePlanillaDetalle.TotalSubsidio = 0.0; //CALCULAR

                    #endregion

                    #region Movilidad por Translado (Bono)

                    bePlanillaDetalle.TotalMovilidad = new LN.Movilidad().ObtenerTotal(this.anho, this.mes, codEmpleado);

                    #endregion

                    #region Pension (Aporte del Trabajador)
                    if (beEmpleado.Recurso.ONP == true)
                    {
                        bePlanillaDetalle.Snp = true;
                        bePlanillaDetalle.SnpTotal = Math.Round(bePlanillaDetalle.TotalSueldoBruto * factorPensionOnp, 2);
                    }
                    else
                    {
                        //Informacion de AFP
                        bePlanillaDetalle.Afp = beEmpleado.Recurso.Afp;

                        var afpComision = new LN.AfpComision().Obtener(bePlanillaDetalle.Afp.IdAfp, anho, mes);

                        #region Porcentaje de Aporte Voluntario de AFP

                        bePlanillaDetalle.AfpAporteVoluntario = 0.0; //NO DEFINIDO

                        #endregion

                        #region Porcentaje de Aporte Obligatorio de AFP

                        double factorComisionAfp = afpComision.PorcentajeFondo / 100;
                        double prcComisionAfp = bePlanillaDetalle.TotalSueldoBruto * factorComisionAfp;
                        bePlanillaDetalle.AfpAporteObligatorio = RedondeoFinal(prcComisionAfp);

                        #endregion

                        #region Porcentaje del Seguro de AFP

                        double factorSeguroAfp = afpComision.PorcentajeSeguro / 100;
                        double prcSeguroAfp = bePlanillaDetalle.TotalSueldoBruto * factorSeguroAfp;
                        bePlanillaDetalle.AfpSeguro = RedondeoFinal(prcSeguroAfp);

                        #endregion

                        #region Tipo y Porcentaje de Comision de AFP

                        bePlanillaDetalle.AfpTipo = beEmpleado.Recurso.CodComision;
                        double factorComision = 0.0;
                        switch (bePlanillaDetalle.AfpTipo)
                        {
                            case "MIXTA":
                                factorComision = afpComision.PorcentajeComisionMixta / 100;
                                break;
                            case "FLUJO":
                                factorComision = afpComision.PorcentajeComisionFlujo / 100;
                                break;
                            default:
                                factorComision = 0.0;
                                break;
                        }
                        bePlanillaDetalle.AfpComision = Math.Round(bePlanillaDetalle.TotalSueldoBruto * factorComision, 2);

                        #endregion

                        afpComision = null;
                    }

                    #endregion

                    #region Salud (Aporte del Empleador)

                    double montoEsSalud = bePlanillaDetalle.TotalSueldoBruto * this.beParametros.EsSaludFactor;
                    bePlanillaDetalle.EsSaludTotal = RedondeoFinal(montoEsSalud);

                    #endregion

                    #region Deducciones

                    #region Retencion Judicial

                    bePlanillaDetalle.RetencionJudicialNominal = beEmpleado.Recurso.RetencionJudicialNominal;
                    bePlanillaDetalle.RetencionJudicialPorcentual = beEmpleado.Recurso.RetencionJudicialPorcentual;

                    #endregion

                    #region Adelanto

                    var lnAdelanto = new LN.Adelanto();
                    double adelantoEfectivoTotal = lnAdelanto.ObtenerTotalEfectivo(bePlanilla.Anho, bePlanilla.Mes, bePlanillaDetalle.CodigoEmpleado);
                    double adelantoBancoTotal = lnAdelanto.ObtenerTotalBanco(bePlanilla.Anho, bePlanilla.Mes, bePlanillaDetalle.CodigoEmpleado);

                    bePlanillaDetalle.AdelantoEfectivo = Math.Round(adelantoEfectivoTotal, 2);
                    bePlanillaDetalle.AdelantoBanco = Math.Round(adelantoBancoTotal, 2);
                    lnAdelanto = null;

                    #endregion

                    #region Prestamos

                    double prestamoCuotaMonto = new LN.Prestamo().ObtenerCuotaTotal(bePlanilla.Anho, bePlanilla.Mes, bePlanillaDetalle.CodigoEmpleado);
                    bePlanillaDetalle.PrestamoTotal = Math.Round(prestamoCuotaMonto, 2);

                    #endregion

                    #region Movilidad

                    double movilidadTotal = new LN.Movilidad().ObtenerTotal(bePlanilla.Anho, bePlanilla.Mes, bePlanillaDetalle.CodigoEmpleado);
                    bePlanillaDetalle.TotalMovilidad = Math.Round(movilidadTotal, 2);

                    #endregion

                    #endregion

                    lstBePlanillaDetalle.Add(bePlanillaDetalle);
                }

                bePlanilla.Detalles = lstBePlanillaDetalle;

                #endregion

                #region Asistencias de Planilla (Detallada)

                List<BE.PlanillaAsistencia> asistencias = new List<BE.PlanillaAsistencia>();

                foreach (BE.UI.PlanillaAsistencia uiPlanillaAsistencia in lstAsistenciasMinutos)
                {
                    var bePlanillaAsistencia = new BE.PlanillaAsistencia();

                    #region Empleado
                    bePlanillaAsistencia.CodigoEmpleado = uiPlanillaAsistencia.Codigo;
                    #endregion

                    #region Fechas y Horas de Asistencia
                    bePlanillaAsistencia.Fecha = uiPlanillaAsistencia.Fecha;
                    bePlanillaAsistencia.Semana = uiPlanillaAsistencia.Semana;
                    bePlanillaAsistencia.FechaHoraInicio = uiPlanillaAsistencia.FechaHoraInicio;
                    bePlanillaAsistencia.FechaHoraFinal = uiPlanillaAsistencia.FechaHoraFinal;
                    #endregion

                    #region Asistencias en Minutos
                    bePlanillaAsistencia.MinutosAsistenciaNormalDiurna = uiPlanillaAsistencia.AsistenciaNormalDiurna;
                    bePlanillaAsistencia.MinutosAsistenciaNormalNocturna = uiPlanillaAsistencia.AsistenciaNormalNocturna;
                    bePlanillaAsistencia.MinutosAsistenciaNormalDiurnaExtra1 = uiPlanillaAsistencia.AsistenciaNormalDiurnaExtra1;
                    bePlanillaAsistencia.MinutosAsistenciaNormalNocturnaExtra1 = uiPlanillaAsistencia.AsistenciaNormalNocturnaExtra1;
                    bePlanillaAsistencia.MinutosAsistenciaNormalDiurnaExtra2 = uiPlanillaAsistencia.AsistenciaNormalDiurnaExtra2;
                    bePlanillaAsistencia.MinutosAsistenciaNormalNocturnaExtra2 = uiPlanillaAsistencia.AsistenciaNormalNocturnaExtra2;

                    bePlanillaAsistencia.MinutosAsistenciaFeriadoDiurna = uiPlanillaAsistencia.AsistenciaFeriadoDiurna;
                    bePlanillaAsistencia.MinutosAsistenciaFeriadoNocturna = uiPlanillaAsistencia.AsistenciaFeriadoNocturna;
                    bePlanillaAsistencia.MinutosAsistenciaFeriadoDiurnaExtra1 = uiPlanillaAsistencia.AsistenciaFeriadoDiurnaExtra1;
                    bePlanillaAsistencia.MinutosAsistenciaFeriadoNocturnaExtra1 = uiPlanillaAsistencia.AsistenciaFeriadoNocturnaExtra1;
                    bePlanillaAsistencia.MinutosAsistenciaFeriadoDiurnaExtra2 = uiPlanillaAsistencia.AsistenciaFeriadoDiurnaExtra2;
                    bePlanillaAsistencia.MinutosAsistenciaFeriadoNocturnaExtra2 = uiPlanillaAsistencia.AsistenciaFeriadoNocturnaExtra2;
                    #endregion

                    #region Tardanzas en Minutos
                    bePlanillaAsistencia.MinutosTardanzaNormalDiurna = uiPlanillaAsistencia.TardanzaNormalDiurna;
                    bePlanillaAsistencia.MinutosTardanzaNormalNocturna = uiPlanillaAsistencia.TardanzaNormalNocturna;
                    bePlanillaAsistencia.MinutosTardanzaFeriadoDiurna = uiPlanillaAsistencia.TardanzaFeriadoDiurna;
                    bePlanillaAsistencia.MinutosTardanzaFeriadoNocturna = uiPlanillaAsistencia.TardanzaFeriadoNocturna;
                    #endregion

                    #region Inasistencias en Minutos
                    bePlanillaAsistencia.MinutosInasistenciaNormal = uiPlanillaAsistencia.InasistenciaNormal;
                    bePlanillaAsistencia.MinutosInasistenciaFeriado = uiPlanillaAsistencia.InasistenciaFeriado;
                    #endregion

                    asistencias.Add(bePlanillaAsistencia);
                }

                bePlanilla.Asistencias = asistencias;

                #endregion

                bool rpta = lnPlanilla.Insertar(ref bePlanilla);

                if (rpta)
                {
                    Util.InformationMessage("Se generó la planilla correctamente");
                    this.Close();
                }

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

        #endregion

    }
}

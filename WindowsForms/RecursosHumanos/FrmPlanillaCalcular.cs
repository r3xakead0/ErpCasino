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

        private List<BE.UI.PlanillaAsistencia> lstAsistencias = null;
        private List<BE.UI.PlanillaCosto> lstCostos = null;

        private int anho = DateTime.Now.Year;
        private int mes = DateTime.Now.Month;

        private BE.Parametros beParametros = null; 

        public FrmPlanillaCalcular()
        {
            try
            {
                InitializeComponent();

                this.beParametros = new BE.Parametros();

                this.lstCostos = new List<BE.UI.PlanillaCosto>();
                this.lstAsistencias = new List<BE.UI.PlanillaAsistencia>();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }

        }

        #region Metodos

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

                lstCalculoPor.Add(new BE.Record() { Codigo = "D", Nombre = "Dia" });
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

                this.CboAnho.DataSource = lstAnhos;
                this.CboAnho.DisplayMember = "Nombre";
                this.CboAnho.ValueMember = "Codigo";
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

                this.CbxMes.DataSource = lstMes;
                this.CbxMes.DisplayMember = "Nombre";
                this.CbxMes.ValueMember = "Codigo";

                this.CbxMes.SelectedValue = DateTime.Now.Month.ToString();
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

                if (this.lstAsistencias == null)
                    return;

                var source = new BindingSource();
                source.DataSource = this.lstAsistencias;
                this.dgvAsistencias.DataSource = source;

                Util.FormatDatagridview(ref this.dgvAsistencias);

                this.dgvAsistencias.Columns["CodigoEmpleado"].Visible = true;
                this.dgvAsistencias.Columns["CodigoEmpleado"].HeaderText = "Codigo";
                this.dgvAsistencias.Columns["CodigoEmpleado"].Width = 80;
                this.dgvAsistencias.Columns["CodigoEmpleado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvAsistencias.Columns["Fecha"].Visible = true;
                this.dgvAsistencias.Columns["Fecha"].Width = 70;
                this.dgvAsistencias.Columns["Fecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvAsistencias.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";

                this.dgvAsistencias.Columns["Semana"].Visible = false;
                this.dgvAsistencias.Columns["Semana"].Width = 70;
                this.dgvAsistencias.Columns["Semana"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.dgvAsistencias.Columns["CalcularPor"].Visible = false;

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
                iniHoras = this.dgvAsistencias.Columns["AsistenciaNormalTotal"].Index;
                finHoras = this.dgvAsistencias.Columns["TardanzaNormalNocturna"].Index + 1;
                for (int i = iniHoras; i < finHoras; i++)
                {
                    this.dgvAsistencias.Columns[i].Visible = true;
                    this.dgvAsistencias.Columns[i].Width = 70;
                    this.dgvAsistencias.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    this.dgvAsistencias.Columns[i].DefaultCellStyle.Format = "N2";
                    this.dgvAsistencias.Columns[i].DefaultCellStyle.BackColor = Color.LightGreen;
                }

                this.dgvAsistencias.Columns["AsistenciaNormalTotal"].Visible = false;
                this.dgvAsistencias.Columns["AsistenciaNormalTotal"].HeaderText = "Asistencia Total";

                this.dgvAsistencias.Columns["AsistenciaNormalDiurna"].HeaderText = "Horario Diurno";
                this.dgvAsistencias.Columns["AsistenciaNormalNocturna"].HeaderText = "Horario Nocturno";
                this.dgvAsistencias.Columns["AsistenciaNormalDiurnaExtra1"].HeaderText = "Extras 25% Diurno";
                this.dgvAsistencias.Columns["AsistenciaNormalNocturnaExtra1"].HeaderText = "Extras 25% Nocturno";
                this.dgvAsistencias.Columns["AsistenciaNormalDiurnaExtra2"].HeaderText = "Extras 35% Diurno";
                this.dgvAsistencias.Columns["AsistenciaNormalNocturnaExtra2"].HeaderText = "Extras 35% Nocturno";
                
                this.dgvAsistencias.Columns["TardanzaNormalTotal"].Visible = false;
                this.dgvAsistencias.Columns["AsistenciaNormalTotal"].HeaderText = "Tardanza Total";

                this.dgvAsistencias.Columns["TardanzaNormalDiurna"].HeaderText = "Tardanza Diurna";
                this.dgvAsistencias.Columns["TardanzaNormalNocturna"].HeaderText = "Tardanza Nocturna";

                //Asistencias Feriados
                iniHoras = this.dgvAsistencias.Columns["AsistenciaFeriadoTotal"].Index;
                finHoras = this.dgvAsistencias.Columns["TardanzaFeriadoNocturna"].Index + 1;
                for (int i = iniHoras; i < finHoras; i++)
                {
                    this.dgvAsistencias.Columns[i].Visible = true;
                    this.dgvAsistencias.Columns[i].Width = 70;
                    this.dgvAsistencias.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    this.dgvAsistencias.Columns[i].DefaultCellStyle.Format = "N2";
                    this.dgvAsistencias.Columns[i].DefaultCellStyle.BackColor = Color.LightYellow;
                }

                this.dgvAsistencias.Columns["AsistenciaFeriadoTotal"].Visible = false;
                this.dgvAsistencias.Columns["AsistenciaFeriadoTotal"].HeaderText = "Asistencia Total";

                this.dgvAsistencias.Columns["AsistenciaFeriadoDiurna"].HeaderText = "Horario Diurno";
                this.dgvAsistencias.Columns["AsistenciaFeriadoNocturna"].HeaderText = "Horario Nocturno";
                this.dgvAsistencias.Columns["AsistenciaFeriadoDiurnaExtra1"].HeaderText = "Extras 25% Diurno";
                this.dgvAsistencias.Columns["AsistenciaFeriadoNocturnaExtra1"].HeaderText = "Extras 25% Nocturno";
                this.dgvAsistencias.Columns["AsistenciaFeriadoDiurnaExtra2"].HeaderText = "Extras 35% Diurno";
                this.dgvAsistencias.Columns["AsistenciaFeriadoNocturnaExtra2"].HeaderText = "Extras 35% Nocturno";

                this.dgvAsistencias.Columns["TardanzaFeriadoTotal"].Visible = false;
                this.dgvAsistencias.Columns["TardanzaFeriadoTotal"].HeaderText = "Tardanza Total";

                this.dgvAsistencias.Columns["TardanzaFeriadoDiurna"].HeaderText = "Tardanza Diurna";
                this.dgvAsistencias.Columns["TardanzaFeriadoNocturna"].HeaderText = "Tardanza Nocturna";

                //Inasistencias
                this.dgvAsistencias.Columns["InasistenciaTotal"].Visible = true;
                this.dgvAsistencias.Columns["InasistenciaTotal"].HeaderText = "Inasistencia Total";
                this.dgvAsistencias.Columns["InasistenciaTotal"].Width = 70;
                this.dgvAsistencias.Columns["InasistenciaTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvAsistencias.Columns["InasistenciaTotal"].DefaultCellStyle.Format = "N2";
                this.dgvAsistencias.Columns["InasistenciaTotal"].DefaultCellStyle.BackColor = Color.Red;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CalcularAsistencias()
        {
            try
            {
                #region Limpiar
                this.lstAsistencias.Clear();
                #endregion

                //Obtiene asistencia por minuto
                this.lstAsistencias = new LN.Planilla(anho, mes).ListarAsistencia();

                string calcular = this.cboCalculoPor.SelectedValue.ToString();
                switch (calcular)
                {
                    case "H": //Costo por Hora
                        for (int i = 0; i < this.lstAsistencias.Count; i++)
                        {
                            this.lstAsistencias[i].CalcularPor = calcular;

                            this.lstAsistencias[i].AsistenciaNormalDiurna /= 60;
                            this.lstAsistencias[i].AsistenciaNormalDiurnaExtra1 /= 60;
                            this.lstAsistencias[i].AsistenciaNormalDiurnaExtra2 /= 60;
                            this.lstAsistencias[i].AsistenciaNormalNocturna /= 60;
                            this.lstAsistencias[i].AsistenciaNormalNocturnaExtra1 /= 60;
                            this.lstAsistencias[i].AsistenciaNormalNocturnaExtra2 /= 60;
                            this.lstAsistencias[i].AsistenciaNormalTotal /= 60;

                            this.lstAsistencias[i].AsistenciaFeriadoDiurna /= 60;
                            this.lstAsistencias[i].AsistenciaFeriadoDiurnaExtra1 /= 60;
                            this.lstAsistencias[i].AsistenciaFeriadoDiurnaExtra2 /= 60;
                            this.lstAsistencias[i].AsistenciaFeriadoNocturna /= 60;
                            this.lstAsistencias[i].AsistenciaFeriadoNocturnaExtra1 /= 60;
                            this.lstAsistencias[i].AsistenciaFeriadoNocturnaExtra2 /= 60;
                            this.lstAsistencias[i].AsistenciaFeriadoTotal /= 60;

                            this.lstAsistencias[i].TardanzaFeriadoDiurna /= 60;
                            this.lstAsistencias[i].TardanzaFeriadoNocturna /= 60;
                            this.lstAsistencias[i].TardanzaFeriadoDiurna /= 60;
                            this.lstAsistencias[i].TardanzaFeriadoNocturna /= 60;

                            this.lstAsistencias[i].InasistenciaTotal /= 60;
                        }
                        break;
                    case "D": //Costo por Hora
                        for (int i = 0; i < this.lstAsistencias.Count; i++)
                        {
                            this.lstAsistencias[i].CalcularPor = calcular;

                            this.lstAsistencias[i].AsistenciaNormalDiurna /= 60 / 8;
                            this.lstAsistencias[i].AsistenciaNormalDiurnaExtra1 /= 60 / 8;
                            this.lstAsistencias[i].AsistenciaNormalDiurnaExtra2 /= 60 / 8;
                            this.lstAsistencias[i].AsistenciaNormalNocturna /= 60 / 8;
                            this.lstAsistencias[i].AsistenciaNormalNocturnaExtra1 /= 60 / 8;
                            this.lstAsistencias[i].AsistenciaNormalNocturnaExtra2 /= 60 / 8;
                            this.lstAsistencias[i].AsistenciaNormalTotal /= 60 / 8;

                            this.lstAsistencias[i].AsistenciaFeriadoDiurna /= 60 / 8;
                            this.lstAsistencias[i].AsistenciaFeriadoDiurnaExtra1 /= 60 / 8;
                            this.lstAsistencias[i].AsistenciaFeriadoDiurnaExtra2 /= 60 / 8;
                            this.lstAsistencias[i].AsistenciaFeriadoNocturna /= 60 / 8;
                            this.lstAsistencias[i].AsistenciaFeriadoNocturnaExtra1 /= 60 / 8;
                            this.lstAsistencias[i].AsistenciaFeriadoNocturnaExtra2 /= 60 / 8;
                            this.lstAsistencias[i].AsistenciaFeriadoTotal /= 60 / 8;

                            this.lstAsistencias[i].TardanzaFeriadoDiurna /= 60 / 8;
                            this.lstAsistencias[i].TardanzaFeriadoNocturna /= 60 / 8;
                            this.lstAsistencias[i].TardanzaFeriadoDiurna /= 60 / 8;
                            this.lstAsistencias[i].TardanzaFeriadoNocturna /= 60 / 8;

                            this.lstAsistencias[i].InasistenciaTotal /= 60 / 8;
                        }
                        break;
                    default:
                        break;
                }

                #region Mostrar

                var source = new BindingSource();
                source.DataSource = this.lstAsistencias;
                this.dgvAsistencias.DataSource = source;

                this.txtRegistrosAsistencias.Text = this.lstAsistencias.Count.ToString();
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
                this.lstCostos.Clear();
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
                    string codEmpleado = emp["Codigo"].ToString();

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
                    objCosto.CodigoEmpleado = codEmpleado;
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
                    this.lstCostos.Add(objCosto);
                    #endregion

                }

                #region Mostar
                var source = new BindingSource();
                source.DataSource = this.lstCostos;
                this.dgvCostos.DataSource = source;
                
                this.txtRegistrosCostos.Text = this.lstCostos.Count.ToString();
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

                if (this.lstCostos == null)
                    return;

                var source = new BindingSource();
                source.DataSource = this.lstCostos;
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

        private void FrmAfpComisionMant_Load(object sender, EventArgs e)
        {
            try
            {

                this.CargarAnhos();
                this.CargarMes();

                this.CboAnho.SelectedValue = DateTime.Now.Year.ToString();
                this.CbxMes.SelectedValue = DateTime.Now.Month.ToString();

                this.FormatoCostos();
                this.CargarCostosPor();

                this.FormatoAsistencias();
                this.CargarAsistenciasPor();

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        #endregion

        #region Botones

       
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        #endregion

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            try
            {

                Util.PointerLoad(this);

                var lnPlanilla = new LN.Planilla(this.anho, this.mes);
                double factorPension = 0.0;

                #region Validaciones de Formulario

                if (this.lstAsistencias.Count == 0)
                {
                    return;
                }

                if (this.lstCostos.Count == 0)
                {
                    return;
                }

                if (this.anho != int.Parse(this.CboAnho.SelectedValue.ToString()))
                {
                    return;
                }

                if (this.mes != int.Parse(this.CbxMes.SelectedValue.ToString()))
                {
                    return;
                }

                var beOnpComision = new LN.OnpComision().Obtener(this.anho, this.mes);
                if (beOnpComision == null)
                {
                    throw new Exception("No existe una comisión de ONP para este periodo");
                }
                factorPension = beOnpComision.AportePorcentual / 100;

                int cntAfpComision = new LN.AfpComision().Listar(this.anho, this.mes).Count;
                if (cntAfpComision == 0)
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

                lstCostosMinutos = this.lstCostos.Select(uiPlanillaCosto => (BE.UI.PlanillaCosto)uiPlanillaCosto.Clone()).ToList();
                lstAsistenciasMinutos = this.lstAsistencias.Select(uiPlanillaAsistencia => (BE.UI.PlanillaAsistencia)uiPlanillaAsistencia.Clone()).ToList();

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

                #region Conversion de Tiempo a minutos
                for (int i = 0; i < lstAsistenciasMinutos.Count; i++)
                {
                    switch (lstAsistenciasMinutos[i].CalcularPor)
                    {

                        case "H": //Hora
                            lstAsistenciasMinutos[i].CalcularPor = "M";
                            lstAsistenciasMinutos[i].AsistenciaNormalDiurna *= 60;
                            lstAsistenciasMinutos[i].AsistenciaNormalDiurnaExtra1 *= 60;
                            lstAsistenciasMinutos[i].AsistenciaNormalDiurnaExtra2 *= 60;
                            lstAsistenciasMinutos[i].AsistenciaNormalNocturna *= 60;
                            lstAsistenciasMinutos[i].AsistenciaNormalNocturnaExtra1 *= 60;
                            lstAsistenciasMinutos[i].AsistenciaNormalNocturnaExtra2 *= 60;
                            lstAsistenciasMinutos[i].AsistenciaNormalTotal *= 60;
                            lstAsistenciasMinutos[i].AsistenciaFeriadoDiurna *= 60;
                            lstAsistenciasMinutos[i].AsistenciaFeriadoDiurnaExtra1 *= 60;
                            lstAsistenciasMinutos[i].AsistenciaFeriadoDiurnaExtra2 *= 60;
                            lstAsistenciasMinutos[i].AsistenciaFeriadoNocturna *= 60;
                            lstAsistenciasMinutos[i].AsistenciaFeriadoNocturnaExtra1 *= 60;
                            lstAsistenciasMinutos[i].AsistenciaFeriadoNocturnaExtra2 *= 60;
                            lstAsistenciasMinutos[i].AsistenciaFeriadoTotal *= 60;
                            lstAsistenciasMinutos[i].TardanzaFeriadoDiurna *= 60;
                            lstAsistenciasMinutos[i].TardanzaFeriadoNocturna *= 60;
                            lstAsistenciasMinutos[i].TardanzaFeriadoDiurna *= 60;
                            lstAsistenciasMinutos[i].TardanzaFeriadoNocturna *= 60;
                            lstAsistenciasMinutos[i].InasistenciaTotal *= 60;
                            break;
                        case "D": //Dia
                            lstAsistenciasMinutos[i].CalcularPor = "M";
                            lstAsistenciasMinutos[i].AsistenciaNormalDiurna *= 480;
                            lstAsistenciasMinutos[i].AsistenciaNormalDiurnaExtra1 *= 480;
                            lstAsistenciasMinutos[i].AsistenciaNormalDiurnaExtra2 *= 480;
                            lstAsistenciasMinutos[i].AsistenciaNormalNocturna *= 480;
                            lstAsistenciasMinutos[i].AsistenciaNormalNocturnaExtra1 *= 480;
                            lstAsistenciasMinutos[i].AsistenciaNormalNocturnaExtra2 *= 480;
                            lstAsistenciasMinutos[i].AsistenciaNormalTotal *= 480;
                            lstAsistenciasMinutos[i].AsistenciaFeriadoDiurna *= 480;
                            lstAsistenciasMinutos[i].AsistenciaFeriadoDiurnaExtra1 *= 480;
                            lstAsistenciasMinutos[i].AsistenciaFeriadoDiurnaExtra2 *= 480;
                            lstAsistenciasMinutos[i].AsistenciaFeriadoNocturna *= 480;
                            lstAsistenciasMinutos[i].AsistenciaFeriadoNocturnaExtra1 *= 480;
                            lstAsistenciasMinutos[i].AsistenciaFeriadoNocturnaExtra2 *= 480;
                            lstAsistenciasMinutos[i].AsistenciaFeriadoTotal *= 480;
                            lstAsistenciasMinutos[i].TardanzaFeriadoDiurna *= 480;
                            lstAsistenciasMinutos[i].TardanzaFeriadoNocturna *= 480;
                            lstAsistenciasMinutos[i].TardanzaFeriadoDiurna *= 480;
                            lstAsistenciasMinutos[i].TardanzaFeriadoNocturna *= 480;
                            lstAsistenciasMinutos[i].InasistenciaTotal *= 480;
                            break;
                        default:
                            break;
                    }
                }
                #endregion

                #endregion

                var bePlanilla = new BE.Planilla();

                #region Cabecera de Planilla

                //Fecha
                bePlanilla.Anho = this.anho;
                bePlanilla.Mes = this.mes;
                bePlanilla.Dias = DateTime.DaysInMonth(anho, mes);

                //Datos Base
                bePlanilla.DiasBase = this.beParametros.BaseDias;
                bePlanilla.HorasBase = this.beParametros.BaseHoras;

                //Monto Sueldo Minimo
                var beSueldoMinimo = new LN.SueldoMinimo().Actual(bePlanilla.Anho, bePlanilla.Mes);
                if (beSueldoMinimo == null)
                    throw new Exception("No existe configurado el Sueldo Minimo");
                bePlanilla.SueldoMinimo = beSueldoMinimo.Monto;
                beSueldoMinimo = null;

                //Porcentajes 
                bePlanilla.Onp = beOnpComision.AportePorcentual;
                bePlanilla.EsSalud = beParametros.EsSaludPorcentaje;
                bePlanilla.AsignacionFamiliar = beParametros.AsignacionFamiliarPorcentaje;
                bePlanilla.PrimerasDosHorasExtras = beParametros.HorasExtras1Porcentaje;
                bePlanilla.PosterioresDosHorasExtras = beParametros.HorasExtras2Porcentaje;
                bePlanilla.Nocturno = beParametros.HorarioNocturnoPorcentaje;
                bePlanilla.Feriado = beParametros.FeriadoPorcentaje;

                #endregion

                #region Detalle de Planilla (Costo, Cantidad, Resumen)

                var lstBePlanillaDetalle = new List<BE.PlanillaDetalle>();

                //Costos en minutos por empleado 
                foreach (BE.UI.PlanillaCosto uiPlanillaCosto in lstCostosMinutos)
                {

                    var bePlanillaDetalle = new BE.PlanillaDetalle();

                    #region Datos de Empleado
                    string codEmpleado = uiPlanillaCosto.CodigoEmpleado.ToString();
                    var beEmpleado = new LN.Empleado().Obtener(codEmpleado);

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
                    cantidadMinutoHorarioDiurno = (int)lstAsistenciasMinutos.AsEnumerable().Where(x => x.CodigoEmpleado == codEmpleado).Sum(x => x.AsistenciaNormalDiurna);
                    cantidadMinutoHorarioNocturno = (int)lstAsistenciasMinutos.AsEnumerable().Where(x => x.CodigoEmpleado == codEmpleado).Sum(x => x.AsistenciaNormalNocturna);
                    cantidadMinutoExtra25Diurno = (int)lstAsistenciasMinutos.AsEnumerable().Where(x => x.CodigoEmpleado == codEmpleado).Sum(x => x.AsistenciaNormalDiurnaExtra1);
                    cantidadMinutoExtra25Nocturno = (int)lstAsistenciasMinutos.AsEnumerable().Where(x => x.CodigoEmpleado == codEmpleado).Sum(x => x.AsistenciaNormalNocturnaExtra1);
                    cantidadMinutoExtra35Diurno = (int)lstAsistenciasMinutos.AsEnumerable().Where(x => x.CodigoEmpleado == codEmpleado).Sum(x => x.AsistenciaNormalDiurnaExtra2);
                    cantidadMinutoExtra35Nocturno = (int)lstAsistenciasMinutos.AsEnumerable().Where(x => x.CodigoEmpleado == codEmpleado).Sum(x => x.AsistenciaNormalNocturnaExtra2);

                    bePlanillaDetalle.CantidadMinutosAsistenciaNormalDiurno = cantidadMinutoHorarioDiurno;
                    bePlanillaDetalle.CantidadMinutosAsistenciaNormalNocturno = cantidadMinutoHorarioNocturno;
                    bePlanillaDetalle.CantidadMinutosAsistenciaNormalDiurnoExtras1 = cantidadMinutoExtra25Diurno;
                    bePlanillaDetalle.CantidadMinutosAsistenciaNormalNocturnoExtras1 = cantidadMinutoExtra25Nocturno;
                    bePlanillaDetalle.CantidadMinutosAsistenciaNormalDiurnoExtras2 = cantidadMinutoExtra35Diurno;
                    bePlanillaDetalle.CantidadMinutosAsistenciaNormalNocturnoExtras2 = cantidadMinutoExtra35Nocturno;
                    #endregion

                    #region Asistencias Feriado
                    cantidadMinutoHorarioDiurno = (int)lstAsistenciasMinutos.AsEnumerable().Where(x => x.CodigoEmpleado == codEmpleado).Sum(x => x.AsistenciaFeriadoDiurna);
                    cantidadMinutoHorarioNocturno = (int)lstAsistenciasMinutos.AsEnumerable().Where(x => x.CodigoEmpleado == codEmpleado).Sum(x => x.AsistenciaFeriadoNocturna);
                    cantidadMinutoExtra25Diurno = (int)lstAsistenciasMinutos.AsEnumerable().Where(x => x.CodigoEmpleado == codEmpleado).Sum(x => x.AsistenciaFeriadoDiurnaExtra1);
                    cantidadMinutoExtra25Nocturno = (int)lstAsistenciasMinutos.AsEnumerable().Where(x => x.CodigoEmpleado == codEmpleado).Sum(x => x.AsistenciaFeriadoNocturnaExtra1);
                    cantidadMinutoExtra35Diurno = (int)lstAsistenciasMinutos.AsEnumerable().Where(x => x.CodigoEmpleado == codEmpleado).Sum(x => x.AsistenciaFeriadoDiurnaExtra2);
                    cantidadMinutoExtra35Nocturno = (int)lstAsistenciasMinutos.AsEnumerable().Where(x => x.CodigoEmpleado == codEmpleado).Sum(x => x.AsistenciaFeriadoNocturnaExtra2);

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
                    cantidadMinutoTardanzaDiurno = (int)lstAsistenciasMinutos.AsEnumerable().Where(x => x.CodigoEmpleado == codEmpleado).Sum(x => x.TardanzaNormalDiurna);
                    cantidadMinutoTardanzaNocturno = (int)lstAsistenciasMinutos.AsEnumerable().Where(x => x.CodigoEmpleado == codEmpleado).Sum(x => x.TardanzaNormalNocturna);

                    bePlanillaDetalle.CantidadMinutosTardanzaNormalDiurno = cantidadMinutoTardanzaDiurno;
                    bePlanillaDetalle.CantidadMinutosTardanzaNormalNocturno = cantidadMinutoTardanzaNocturno;
                    #endregion

                    #region Tardanzas Feriado
                    cantidadMinutoTardanzaDiurno = (int)lstAsistenciasMinutos.AsEnumerable().Where(x => x.CodigoEmpleado == codEmpleado).Sum(x => x.TardanzaFeriadoDiurna);
                    cantidadMinutoTardanzaNocturno = (int)lstAsistenciasMinutos.AsEnumerable().Where(x => x.CodigoEmpleado == codEmpleado).Sum(x => x.TardanzaFeriadoNocturna);

                    bePlanillaDetalle.CantidadMinutosTardanzaFeriadoDiurno = cantidadMinutoTardanzaDiurno;
                    bePlanillaDetalle.CantidadMinutosTardanzaFeriadoNocturno = cantidadMinutoTardanzaNocturno;
                    #endregion

                    #endregion

                    #region Inasistencias
                    int cantidadMinutoInasistencia = (int)lstAsistenciasMinutos.AsEnumerable().Where(x => x.CodigoEmpleado == codEmpleado).Sum(x => x.InasistenciaTotal);

                    bePlanillaDetalle.CantidadMinutosInasistencia = cantidadMinutoInasistencia;
                    #endregion

                    #endregion

                    #region Pension (Aporte del Trabajador)
                    if (beEmpleado.Recurso.ONP == true)
                    {
                        bePlanillaDetalle.Snp = true;
                        bePlanillaDetalle.SnpTotal = Math.Round(bePlanillaDetalle.TotalSueldoBruto * factorPension, 2);
                    }
                    else
                    {
                        //Informacion de AFP
                        bePlanillaDetalle.Afp = beEmpleado.Recurso.Afp;
                        bePlanillaDetalle.AfpAporteVoluntario = 0.0;

                        var afpComision = new LN.AfpComision().Obtener(bePlanillaDetalle.Afp.IdAfp, anho, mes);

                        double factorComisionAfp = afpComision.PorcentajeFondo / 100;
                        bePlanillaDetalle.AfpAporteObligatorio = Math.Round(bePlanillaDetalle.TotalSueldoBruto * factorComisionAfp, 2);

                        double factorSeguroAfp = afpComision.PorcentajeSeguro / 100;
                        bePlanillaDetalle.AfpSeguro = Math.Round(bePlanillaDetalle.TotalSueldoBruto * factorSeguroAfp, 2);

                        bePlanillaDetalle.AfpTipo = beEmpleado.Recurso.CodComision;

                        double factorComision = 0.0;
                        if (bePlanillaDetalle.AfpTipo == "MIXTA")
                        {
                            factorComision = afpComision.PorcentajeComisionMixta / 100;
                        }
                        else if (bePlanillaDetalle.AfpTipo == "FLUJO")
                        {
                            factorComision = afpComision.PorcentajeComisionFlujo / 100;
                        }
                        bePlanillaDetalle.AfpComision = Math.Round(bePlanillaDetalle.TotalSueldoBruto * factorComision, 2);
                    }
                    #endregion

                    #region Salud (Aporte del Empleador)

                    bePlanillaDetalle.EsSaludTotal = Math.Round(bePlanillaDetalle.TotalSueldoBruto * this.beParametros.EsSaludFactor, 2);

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

                    double prestamoTotal = new LN.Prestamo().ObtenerTotal(bePlanilla.Anho, bePlanilla.Mes, bePlanillaDetalle.CodigoEmpleado);
                    bePlanillaDetalle.PrestamoTotal = Math.Round(prestamoTotal, 2);

                    #endregion

                    #endregion

                    lstBePlanillaDetalle.Add(bePlanillaDetalle);
                }

                bePlanilla.Detalles = lstBePlanillaDetalle;

                #endregion

                #region Asistencias de Planilla (Detallada)

                List<BE.PlanillaAsistencia> asistencias = new List<BE.PlanillaAsistencia>();

                foreach (BE.UI.PlanillaAsistencia objAsistencia in lstAsistenciasMinutos)
                {
                    var asistencia = new BE.PlanillaAsistencia();

                    #region Empleado
                    asistencia.CodigoEmpleado = objAsistencia.CodigoEmpleado;
                    #endregion

                    #region Fechas y Horas de Asistencia
                    asistencia.Fecha = objAsistencia.Fecha;
                    asistencia.Semana = objAsistencia.Semana;
                    asistencia.FechaHoraInicio = objAsistencia.FechaHoraInicio;
                    asistencia.FechaHoraFinal = objAsistencia.FechaHoraFinal;
                    #endregion

                    #region Asistencias en Minutos
                    asistencia.MinutosAsistenciaNormalDiurna = (int)objAsistencia.AsistenciaNormalDiurna;
                    asistencia.MinutosAsistenciaNormalNocturna = (int)objAsistencia.AsistenciaNormalNocturna;
                    asistencia.MinutosAsistenciaNormalDiurnaExtra1 = (int)objAsistencia.AsistenciaNormalDiurnaExtra1;
                    asistencia.MinutosAsistenciaNormalNocturnaExtra1 = (int)objAsistencia.AsistenciaNormalNocturnaExtra1;
                    asistencia.MinutosAsistenciaNormalDiurnaExtra2 = (int)objAsistencia.AsistenciaNormalDiurnaExtra2;
                    asistencia.MinutosAsistenciaNormalNocturnaExtra2 = (int)objAsistencia.AsistenciaNormalNocturnaExtra2;

                    asistencia.MinutosAsistenciaFeriadoDiurna = (int)objAsistencia.AsistenciaFeriadoDiurna;
                    asistencia.MinutosAsistenciaFeriadoNocturna = (int)objAsistencia.AsistenciaFeriadoNocturna;
                    asistencia.MinutosAsistenciaFeriadoDiurnaExtra1 = (int)objAsistencia.AsistenciaFeriadoDiurnaExtra1;
                    asistencia.MinutosAsistenciaFeriadoNocturnaExtra1 = (int)objAsistencia.AsistenciaFeriadoNocturnaExtra1;
                    asistencia.MinutosAsistenciaFeriadoDiurnaExtra2 = (int)objAsistencia.AsistenciaFeriadoDiurnaExtra2;
                    asistencia.MinutosAsistenciaFeriadoNocturnaExtra2 = (int)objAsistencia.AsistenciaFeriadoNocturnaExtra2;
                    #endregion

                    #region Tardanzas en Minutos
                    asistencia.MinutosTardanzaNormalDiurna = (int)objAsistencia.TardanzaNormalDiurna;
                    asistencia.MinutosTardanzaNormalNocturna = (int)objAsistencia.TardanzaNormalNocturna;
                    asistencia.MinutosTardanzaFeriadoDiurna = (int)objAsistencia.TardanzaFeriadoDiurna;
                    asistencia.MinutosTardanzaFeriadoNocturna = (int)objAsistencia.TardanzaFeriadoNocturna;
                    #endregion

                    #region Inasistencias en Minutos
                    asistencia.MinutosInasistenciaTotal = (int)objAsistencia.InasistenciaTotal;
                    #endregion

                    asistencias.Add(asistencia);
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

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                this.anho = int.Parse(this.CboAnho.SelectedValue.ToString());
                this.mes = int.Parse(this.CbxMes.SelectedValue.ToString());

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

 
    }
}

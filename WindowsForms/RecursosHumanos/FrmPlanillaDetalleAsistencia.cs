using System;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using System.Collections.Generic;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmPlanillaDetalleAsistencia : Form
    {
        private int idPlanilla = 0;
        private int anho = 0;
        private int mes = 0;
        private string codigoEmpleado = "";
        private string nombresEmpleado = "";
        private string horarioPor = "0";
        private string calculoPor = "M";

        private List<BE.UI.PlanillaAsistencia> lstUiPlanillaAsistencia = null;

        public FrmPlanillaDetalleAsistencia(int idPlanilla, 
                                            int anho, 
                                            int mes, 
                                            string codigoEmpleado,
                                            string nombresEmpleado,
                                            string horarioPor,
                                            string calculoPor)
        {
            InitializeComponent();

            this.idPlanilla = idPlanilla;
            this.anho = anho;
            this.mes = mes;
            this.codigoEmpleado = codigoEmpleado;
            this.nombresEmpleado = nombresEmpleado;
            this.horarioPor = horarioPor;
            this.calculoPor = calculoPor;

            this.lstUiPlanillaAsistencia = new List<BE.UI.PlanillaAsistencia>();
        }

        #region Formulario
        private void FrmPlanillaDetalleAsistencia_Load(object sender, EventArgs e)
        {
            try
            {

                this.txtEmpleadoCodigo.Text = this.codigoEmpleado;
                this.txtEmpleadoNombres.Text = this.nombresEmpleado;
                this.txtPeriodo.Text = this.anho.ToString() + "/" + this.mes.ToString("00");

                this.CargarHorario();
                this.CargarCalculoPor();

                this.CargarAsistencias(true);
                this.FormatoAsistencias();

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }


        private void btnCerrar_Click(object sender, EventArgs e)
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

        #region Metodos

        ///<summary>
        ///Cargar los tipos de Calculo en combobox
        ///</summary>
        private void CargarCalculoPor()
        {
            try
            {

                var lstCalculoPor = new List<BE.Record>();

                lstCalculoPor.Add(new BE.Record() { Codigo = "H", Nombre = "Hora" });
                lstCalculoPor.Add(new BE.Record() { Codigo = "M", Nombre = "Minuto" });

                this.cboCalculoPor.DataSource = lstCalculoPor;
                this.cboCalculoPor.DisplayMember = "Nombre";
                this.cboCalculoPor.ValueMember = "Codigo";

                this.cboCalculoPor.SelectedValue = this.calculoPor;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///<summary>
        ///Cargar los filtros de tipos de horario en combobox
        ///</summary>
        private void CargarHorario()
        {
            try
            {

                var lstHorario = new List<BE.Record>();

                lstHorario.Add(new BE.Record() { Codigo = "0", Nombre = "Todos" });
                lstHorario.Add(new BE.Record() { Codigo = "1", Nombre = "Horario Nocturno" });
                lstHorario.Add(new BE.Record() { Codigo = "2", Nombre = "Horas Extras" });
                lstHorario.Add(new BE.Record() { Codigo = "3", Nombre = "Feriado" });
                lstHorario.Add(new BE.Record() { Codigo = "4", Nombre = "Tardanzas" });
                lstHorario.Add(new BE.Record() { Codigo = "5", Nombre = "Inasistencias" });

                this.cboHorario.DataSource = lstHorario;
                this.cboHorario.DisplayMember = "Nombre";
                this.cboHorario.ValueMember = "Codigo";

                this.cboHorario.SelectedValue = this.horarioPor;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CargarAsistencias(bool refrescar = false)
        {
            try
            {
                if (refrescar == true)
                {
                    var lnPlanilla = new LN.Planilla(this.anho, this.mes);

                    string horario = this.cboHorario.SelectedValue.ToString();
                    switch (horario)
                    {
                        case "1": //Horario Nocturno
                            this.lstUiPlanillaAsistencia = lnPlanilla.ListarAsistenciaHorarioNocturno(this.idPlanilla, this.codigoEmpleado);
                            break;
                        case "2": //Horas Extras
                            this.lstUiPlanillaAsistencia = lnPlanilla.ListarAsistenciaHorasExtras(this.idPlanilla, this.codigoEmpleado);
                            break;
                        case "3": //Feriado
                            this.lstUiPlanillaAsistencia = lnPlanilla.ListarAsistenciaFeriado(this.idPlanilla, this.codigoEmpleado);
                            break;
                        case "4": //Tardanzas
                            this.lstUiPlanillaAsistencia = lnPlanilla.ListarAsistenciaTardanzas(this.idPlanilla, this.codigoEmpleado);
                            break;
                        case "5": //Inasistencias
                            this.lstUiPlanillaAsistencia = lnPlanilla.ListarAsistenciaFaltas(this.idPlanilla, this.codigoEmpleado);
                            break;
                        default: //Todos
                            this.lstUiPlanillaAsistencia = lnPlanilla.ListarAsistencia(this.idPlanilla, this.codigoEmpleado);
                            break;
                    }
                    
                }

                int nroRegistros = this.lstUiPlanillaAsistencia.Count;

                #region Conversion de tiempo

                //Costo por Minuto
                var lstUiPlanillaAsistenciaConvertido = this.lstUiPlanillaAsistencia.Select(uiPlanillaAsistencia => (BE.UI.PlanillaAsistencia)uiPlanillaAsistencia.Clone()).ToList();

                string calcular = this.cboCalculoPor.SelectedValue.ToString();
                
                for (int i = 0; i < lstUiPlanillaAsistenciaConvertido.Count; i++)
                {
                    lstUiPlanillaAsistenciaConvertido[i].FormateadoCalculo = calcular;
                }
                
                #endregion

                var source = new BindingSource();
                source.DataSource = lstUiPlanillaAsistenciaConvertido;

                this.dgvAsistencias.DataSource = source;

                this.txtNroRegistros.Text = nroRegistros.ToString();
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

                for (int col = 0; col < this.dgvAsistencias.Columns.Count; col++)
                    this.dgvAsistencias.Columns[col].Visible = false;

                this.dgvAsistencias.Columns["Fecha"].Visible = true;
                this.dgvAsistencias.Columns["Fecha"].HeaderText = "Fecha";
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
                this.dgvAsistencias.Columns["FormateadoTardanzaFeriadoTotal"].HeaderText = "Tardanza Total";

                this.dgvAsistencias.Columns["FormateadoTardanzaFeriadoDiurna"].HeaderText = "Tardanza Diurna";
                this.dgvAsistencias.Columns["FormateadoTardanzaFeriadoNocturna"].HeaderText = "Tardanza Nocturna";

                //Inasistencias
                this.dgvAsistencias.Columns["FormateadoInasistenciaTotal"].Visible = true;
                this.dgvAsistencias.Columns["FormateadoInasistenciaTotal"].HeaderText = "Inasistencia Total";
                this.dgvAsistencias.Columns["FormateadoInasistenciaTotal"].Width = 70;
                this.dgvAsistencias.Columns["FormateadoInasistenciaTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvAsistencias.Columns["FormateadoInasistenciaTotal"].DefaultCellStyle.BackColor = Color.Red;

                Util.AutoWidthColumn(ref this.dgvAsistencias, "Fecha");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        private void cboCalculoPor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                this.CargarAsistencias(false);
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void cboHorario_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                this.CargarAsistencias(true);
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
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
        }
    }
}

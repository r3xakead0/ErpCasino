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

                lstCalculoPor.Add(new BE.Record() { Codigo = "D", Nombre = "Dia" });
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
                switch (calcular)
                {
                    case "H": //Costo por Hora
                        for (int i = 0; i < lstUiPlanillaAsistenciaConvertido.Count; i++)
                        {
                            lstUiPlanillaAsistenciaConvertido[i].CalcularPor = calcular;

                            lstUiPlanillaAsistenciaConvertido[i].AsistenciaNormalDiurna /= 60;
                            lstUiPlanillaAsistenciaConvertido[i].AsistenciaNormalDiurnaExtra1 /= 60;
                            lstUiPlanillaAsistenciaConvertido[i].AsistenciaNormalDiurnaExtra2 /= 60;
                            lstUiPlanillaAsistenciaConvertido[i].AsistenciaNormalNocturna /= 60;
                            lstUiPlanillaAsistenciaConvertido[i].AsistenciaNormalNocturnaExtra1 /= 60;
                            lstUiPlanillaAsistenciaConvertido[i].AsistenciaNormalNocturnaExtra2 /= 60;
                            lstUiPlanillaAsistenciaConvertido[i].AsistenciaNormalTotal /= 60;

                            lstUiPlanillaAsistenciaConvertido[i].AsistenciaFeriadoDiurna /= 60;
                            lstUiPlanillaAsistenciaConvertido[i].AsistenciaFeriadoDiurnaExtra1 /= 60;
                            lstUiPlanillaAsistenciaConvertido[i].AsistenciaFeriadoDiurnaExtra2 /= 60;
                            lstUiPlanillaAsistenciaConvertido[i].AsistenciaFeriadoNocturna /= 60;
                            lstUiPlanillaAsistenciaConvertido[i].AsistenciaFeriadoNocturnaExtra1 /= 60;
                            lstUiPlanillaAsistenciaConvertido[i].AsistenciaFeriadoNocturnaExtra2 /= 60;
                            lstUiPlanillaAsistenciaConvertido[i].AsistenciaFeriadoTotal /= 60;

                            lstUiPlanillaAsistenciaConvertido[i].TardanzaFeriadoDiurna /= 60;
                            lstUiPlanillaAsistenciaConvertido[i].TardanzaFeriadoNocturna /= 60;
                            lstUiPlanillaAsistenciaConvertido[i].TardanzaFeriadoDiurna /= 60;
                            lstUiPlanillaAsistenciaConvertido[i].TardanzaFeriadoNocturna /= 60;

                            lstUiPlanillaAsistenciaConvertido[i].InasistenciaTotal /= 60;
                        }
                        break;
                    case "D": //Costo por Dia
                        for (int i = 0; i < lstUiPlanillaAsistenciaConvertido.Count; i++)
                        {
                            lstUiPlanillaAsistenciaConvertido[i].CalcularPor = calcular;

                            lstUiPlanillaAsistenciaConvertido[i].AsistenciaNormalDiurna /= 60 / 8;
                            lstUiPlanillaAsistenciaConvertido[i].AsistenciaNormalDiurnaExtra1 /= 60 / 8;
                            lstUiPlanillaAsistenciaConvertido[i].AsistenciaNormalDiurnaExtra2 /= 60 / 8;
                            lstUiPlanillaAsistenciaConvertido[i].AsistenciaNormalNocturna /= 60 / 8;
                            lstUiPlanillaAsistenciaConvertido[i].AsistenciaNormalNocturnaExtra1 /= 60 / 8;
                            lstUiPlanillaAsistenciaConvertido[i].AsistenciaNormalNocturnaExtra2 /= 60 / 8;
                            lstUiPlanillaAsistenciaConvertido[i].AsistenciaNormalTotal /= 60 / 8;

                            lstUiPlanillaAsistenciaConvertido[i].AsistenciaFeriadoDiurna /= 60 / 8;
                            lstUiPlanillaAsistenciaConvertido[i].AsistenciaFeriadoDiurnaExtra1 /= 60 / 8;
                            lstUiPlanillaAsistenciaConvertido[i].AsistenciaFeriadoDiurnaExtra2 /= 60 / 8;
                            lstUiPlanillaAsistenciaConvertido[i].AsistenciaFeriadoNocturna /= 60 / 8;
                            lstUiPlanillaAsistenciaConvertido[i].AsistenciaFeriadoNocturnaExtra1 /= 60 / 8;
                            lstUiPlanillaAsistenciaConvertido[i].AsistenciaFeriadoNocturnaExtra2 /= 60 / 8;
                            lstUiPlanillaAsistenciaConvertido[i].AsistenciaFeriadoTotal /= 60 / 8;

                            lstUiPlanillaAsistenciaConvertido[i].TardanzaFeriadoDiurna /= 60 / 8;
                            lstUiPlanillaAsistenciaConvertido[i].TardanzaFeriadoNocturna /= 60 / 8;
                            lstUiPlanillaAsistenciaConvertido[i].TardanzaFeriadoDiurna /= 60 / 8;
                            lstUiPlanillaAsistenciaConvertido[i].TardanzaFeriadoNocturna /= 60 / 8;

                            lstUiPlanillaAsistenciaConvertido[i].InasistenciaTotal /= 60 / 8;
                        }
                        break;
                    default:
                        break;
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


    }
}

using System;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;
using System.IO;
using System.Data;
using System.Drawing;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmHorarioSemanalMant : Form
    {

        private DateTime fechaInicio;
        private DateTime fechaFin;

        private FrmHorarioSemanalList frmList = null;

        private BE.UI.HorarioSemanal uiHorarioSemanal = new BE.UI.HorarioSemanal();
        private List<BE.UI.Horario> lstUiHorario = new List<BE.UI.Horario>();

        private List<BE.UI.Horario> lstUiHorarioNuevos = new List<BE.UI.Horario>();
        private List<BE.UI.Horario> lstUiHorarioEliminados = new List<BE.UI.Horario>();

        private int idHorario = 0;

        public FrmHorarioSemanalMant(FrmHorarioSemanalList frmList)
        {
            try
            {
                InitializeComponent();

                this.frmList = frmList;

                this.CargarAnhos();
                this.CargarSemanas(DateTime.Now.Year);

                int anho = DateTime.Now.Year;
                int semana = 1;
                this.CargarRangoFechas(anho, semana);

                this.CargarSalas(true);
                this.CargarCargos(true);
                this.CargarDias(true);
                this.CargarEmpleados(true);

                BindingSource source = new BindingSource();
                source.DataSource = this.lstUiHorario;

                this.dgvHorarios.DataSource = source;
                this.FormatoHorarios();

                this.txtNroRegistros.Text = this.lstUiHorario.Count.ToString();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }

        }


        public void Cargar(BE.UI.HorarioSemanal uiHorarioSemanal)
        {
            try
            {

                this.uiHorarioSemanal = uiHorarioSemanal;

                this.lblHorarios.Text = "Año : " + this.uiHorarioSemanal.Anho.ToString() + " | "
                                      + "Semana : " + this.uiHorarioSemanal.Semana.ToString() + " | "
                                      + "Rango : " + this.uiHorarioSemanal.FechaInicio.ToString("dd/MM/yyyy") + " - " + this.uiHorarioSemanal.FechaFinal.ToString("dd/MM/yyyy") + " | "
                                      + "Sala : " + this.uiHorarioSemanal.SalaNombre;
                this.grpDatosHorario.Enabled = true;

                this.CargarHorarios();

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void CargarSemanas(int anho)
        {

            CultureInfo myCI = new CultureInfo("es-PE");
            Calendar myCal = myCI.Calendar;
            DateTime LastDay = new DateTime(anho, 12, 31);
            CalendarWeekRule myCWR = myCI.DateTimeFormat.CalendarWeekRule;
            DayOfWeek myFirstDOW = myCI.DateTimeFormat.FirstDayOfWeek;
            int totalSemanas = myCal.GetWeekOfYear(LastDay, myCWR, myFirstDOW);

            var lstSemanas = new List<BE.Record>();
            for (int i = 1; i <= totalSemanas; i++)
            {
                lstSemanas.Add(new BE.Record() { Codigo = i.ToString(), Nombre = i.ToString() });
            }

            this.cboSemana.DataSource = lstSemanas;
            this.cboSemana.DisplayMember = "Nombre";
            this.cboSemana.ValueMember = "Codigo";
        }

        public void CargarRangoFechas(int anho, int semana)
        {
            Calendar calendar = CultureInfo.CurrentCulture.Calendar;

            DateTime jan1 = new DateTime(anho, 1, 1);

            int daysOffset = DayOfWeek.Monday - jan1.DayOfWeek;
            DateTime firstMonday = jan1.AddDays(daysOffset);
            int firstMondayWeekNum = calendar.GetWeekOfYear(firstMonday, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            DateTime firstWeekDay = firstMonday.AddDays((semana - firstMondayWeekNum) * 7);
            DateTime LastWeekDay = firstWeekDay.AddDays(6);

            string dateRange = firstWeekDay.ToString("dd/MM/yyyy") + " - " + LastWeekDay.ToString("dd/MM/yyyy");

            this.fechaInicio = firstWeekDay;
            this.fechaFin = LastWeekDay;
            this.txtRangoFechas.Text = dateRange;
        }

        private void CargarAnhos()
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

        private void CargarCargos(bool Seleccione = false)
        {
            var lstUiCargos = new LN.Cargo().ListarCombo();

            lstUiCargos = lstUiCargos.OrderBy(o => o.Nombre).Distinct().ToList();

            if (Seleccione == true)
                lstUiCargos.Insert(0, new BE.UI.Cargo() { Id = 0, Nombre = "Seleccione", Descripcion = "" });

            this.CboCargo.DataSource = lstUiCargos;
            this.CboCargo.DisplayMember = "Nombre";
            this.CboCargo.ValueMember = "Id";
        }

        private void CargarEmpleados(bool Seleccione = false)
        {
            try
            {
                var lstEmpleados = new LN.Empleado().Combo();
                var lstCandidatos = new LN.Candidato().Combo();
                lstEmpleados.AddRange(lstCandidatos);
                var lstTrabajadores = lstEmpleados.OrderBy(o => o.Nombre).Distinct().ToList();

                if (Seleccione == true)
                    lstTrabajadores.Insert(0, new BE.Record() { Codigo = "0", Nombre = "Seleccione" });

                this.cboEmpleado.DataSource = lstTrabajadores;
                this.cboEmpleado.DisplayMember = "Nombre";
                this.cboEmpleado.ValueMember = "Codigo";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarSalas(bool Seleccione = false)
        {
            var lstSalas = new LN.Sala().ListaSimple();

            if (Seleccione == true)
                lstSalas.Insert(0, new BE.Sala() { IdSala = 0, Nombre = "Seleccione" });

            this.cboSala.DataSource = lstSalas;
            this.cboSala.DisplayMember = "Nombre";
            this.cboSala.ValueMember = "IdSala";
        }

        private void CargarDias(bool Seleccione = false)
        {

            var lstDias = new List<BE.Record>();
            for (int i = 1; i < 8; i++)
            {
                lstDias.Add(new BE.Record() {
                    Codigo = i.ToString(),
                    Nombre = this.ObtenerDia(i)
                });
            }

            if (Seleccione == true)
                lstDias.Insert(0, new BE.Record() { Codigo = "0", Nombre = "Seleccione" });

            this.CboDia.DataSource = lstDias;
            this.CboDia.DisplayMember = "Nombre";
            this.CboDia.ValueMember = "Codigo";
        }

        private string ObtenerDia(int dia)
        {
            string nombreDia = "";

            switch (dia)
            {
                case 1:
                    nombreDia = "Lunes";
                    break;
                case 2:
                    nombreDia = "Martes";
                    break;
                case 3:
                    nombreDia = "Miercoles";
                    break;
                case 4:
                    nombreDia = "Jueves";
                    break;
                case 5:
                    nombreDia = "Viernes";
                    break;
                case 6:
                    nombreDia = "Sabado";
                    break;
                default:
                    nombreDia = "Domingo";
                    break;
            }

            return nombreDia;
        }

        private void CargarHorarios()
        {
            try
            {

                this.lstUiHorario = new LN.Horario().ListarSemana(this.uiHorarioSemanal);

                BindingSource source = new BindingSource();
                source.DataSource = this.lstUiHorario;

                this.dgvHorarios.DataSource = source;
                this.FormatoHorarios();

                this.txtNroRegistros.Text = this.lstUiHorario.Count.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FormatoHorarios()
        {
            try
            {
                Util.FormatDatagridview(ref this.dgvHorarios);

                for (int i = 0; i < this.dgvHorarios.Columns.Count; i++)
                    this.dgvHorarios.Columns[i].Visible = false;

                this.dgvHorarios.Columns["FechaHoraInicio"].Visible = true;
                this.dgvHorarios.Columns["FechaHoraInicio"].HeaderText = "Fecha Hora Inicial";
                this.dgvHorarios.Columns["FechaHoraInicio"].Width = 120;
                this.dgvHorarios.Columns["FechaHoraInicio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvHorarios.Columns["FechaHoraInicio"].DefaultCellStyle.Format = "dd/MM/yyyy - HH:mm";

                this.dgvHorarios.Columns["FechaHoraFinal"].Visible = true;
                this.dgvHorarios.Columns["FechaHoraFinal"].HeaderText = "Fecha Hora Final";
                this.dgvHorarios.Columns["FechaHoraFinal"].Width = 120;
                this.dgvHorarios.Columns["FechaHoraFinal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvHorarios.Columns["FechaHoraFinal"].DefaultCellStyle.Format = "dd/MM/yyyy - HH:mm";

                this.dgvHorarios.Columns["EmpleadoCodigo"].Visible = true;
                this.dgvHorarios.Columns["EmpleadoCodigo"].HeaderText = "Codigo";
                this.dgvHorarios.Columns["EmpleadoCodigo"].Width = 100;
                this.dgvHorarios.Columns["EmpleadoCodigo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvHorarios.Columns["EmpleadoNombreCompleto"].Visible = true;
                this.dgvHorarios.Columns["EmpleadoNombreCompleto"].HeaderText = "Empleado";
                this.dgvHorarios.Columns["EmpleadoNombreCompleto"].Width = 200;
                this.dgvHorarios.Columns["EmpleadoNombreCompleto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvHorarios.Columns["CargoNombre"].Visible = true;
                this.dgvHorarios.Columns["CargoNombre"].HeaderText = "Cargo";
                this.dgvHorarios.Columns["CargoNombre"].Width = 150;
                this.dgvHorarios.Columns["CargoNombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvHorarios.Columns["Fecha"].Visible = true;
                this.dgvHorarios.Columns["Fecha"].Width = 100;
                this.dgvHorarios.Columns["Fecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvHorarios.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";

                this.dgvHorarios.Columns["DiaNombre"].Visible = true;
                this.dgvHorarios.Columns["DiaNombre"].HeaderText = "Dia";
                this.dgvHorarios.Columns["DiaNombre"].Width = 70;
                this.dgvHorarios.Columns["DiaNombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                
                this.dgvHorarios.Columns["Turno"].Visible = true;
                this.dgvHorarios.Columns["Turno"].HeaderText = "Turno";
                this.dgvHorarios.Columns["Turno"].Width = 50;
                this.dgvHorarios.Columns["Turno"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.dgvHorarios.Columns["Horas"].Visible = true;
                this.dgvHorarios.Columns["Horas"].HeaderText = "Horas";
                this.dgvHorarios.Columns["Horas"].Width = 50;
                this.dgvHorarios.Columns["Horas"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                Util.AutoWidthColumn(ref this.dgvHorarios, "EmpleadoNombreCompleto");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        private void LimpiarHorario()
        {
            try
            {
                this.idHorario = 0;
                this.CboCargo.SelectedIndex = 0;
                this.txtEmpleadoCodigo.Clear();
                this.cboEmpleado.SelectedIndex = 0;
                this.CboDia.SelectedIndex = 0;
                this.txtFechaDia.Clear();
                this.nudTurno.Value = 1;
                this.txtHoras.Text = "0";
                this.dtpTurnoDesde.Value = DateTime.Now;
                this.dtpTurnoHasta.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lblHorarios.Text.Length == 0)
                {
                    return;
                }

                if (Util.ConfirmationMessage("¿Desea guardar el horario semanal?") == false)
                {
                    return;
                }

                for (int i = 0; i < this.lstUiHorarioNuevos.Count; i++)
                {
                    BE.UI.Horario uiHorarioNuevo = this.lstUiHorarioNuevos[i];
                    bool exito = new LN.Horario().Insertar(ref uiHorarioNuevo);
                }

                for (int i = 0; i < this.lstUiHorarioEliminados.Count; i++)
                {
                    BE.UI.Horario uiHorarioEliminado = this.lstUiHorarioEliminados[i];
                    bool exito = new LN.Horario().Eliminar(uiHorarioEliminado.IdHorario);
                }

                Util.InformationMessage("Se guardo el horario semanal");

                this.frmList.CargarListadoHorarios();

                this.Close();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (Util.ConfirmationMessage("¿Desea salir sin guardar?") == false)
                {
                    return;
                }

                this.Close();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void btnHorarioLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                this.LimpiarHorario();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void btnHorarioAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                #region Validaciones

                if (this.CboCargo.SelectedIndex == 0)
                {
                    return;
                }

                if (this.cboEmpleado.SelectedIndex == 0)
                {
                    return;
                }

                if (this.CboDia.SelectedIndex == 0)
                {
                    return;
                }

                #endregion

                var uiHorario = new BE.UI.Horario();
                uiHorario.IdHorario = this.idHorario;
                uiHorario.Anho = this.uiHorarioSemanal.Anho;
                uiHorario.Semana = this.uiHorarioSemanal.Semana;
                uiHorario.SalaId = this.uiHorarioSemanal.SalaId;
                uiHorario.FechaHoraInicio = this.dtpTurnoDesde.Value;
                uiHorario.FechaHoraFinal = this.dtpTurnoHasta.Value;

                var uiCargo = (BE.UI.Cargo)this.CboCargo.SelectedItem;
                uiHorario.CargoId = uiCargo.Id;
                uiHorario.CargoNombre = uiCargo.Nombre;

                uiHorario.Fecha = DateTime.Parse(this.txtFechaDia.Text);

                var beEmpleado = (BE.Record)this.cboEmpleado.SelectedItem;
                uiHorario.EmpleadoCodigo = beEmpleado.Codigo;
                uiHorario.EmpleadoNombreCompleto = beEmpleado.Nombre;

                var beDia = (BE.Record)this.CboDia.SelectedItem;
                uiHorario.DiaNumero = byte.Parse(beDia.Codigo);
                uiHorario.DiaNombre = beDia.Nombre;

                uiHorario.Turno = byte.Parse(this.nudTurno.Value.ToString());
                uiHorario.Horas = byte.Parse(this.txtHoras.Text);

                this.lstUiHorario.Add(uiHorario);
                this.lstUiHorarioNuevos.Add(uiHorario);

                BindingSource source = new BindingSource();
                source.DataSource = this.lstUiHorario;
                this.dgvHorarios.DataSource = source;

                this.txtNroRegistros.Text = this.lstUiHorario.Count.ToString();

                int lastRowIndex = this.dgvHorarios.Rows.Count - 1;
                this.dgvHorarios.Rows[lastRowIndex].Selected = true;
                this.dgvHorarios.FirstDisplayedScrollingRowIndex = lastRowIndex;
                this.dgvHorarios.Update();

                this.LimpiarHorario();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvHorarios.CurrentRow != null)
                {
                    var uiHorario = (BE.UI.Horario)this.dgvHorarios.CurrentRow.DataBoundItem;

                    this.idHorario = uiHorario.IdHorario;

                    this.CboCargo.SelectedValue = uiHorario.CargoId;
                    this.CboDia.SelectedValue = uiHorario.DiaNumero.ToString();
                    this.txtFechaDia.Text = uiHorario.Fecha.ToString("dd/MM/yyyy");
                    this.txtEmpleadoCodigo.Text = uiHorario.EmpleadoCodigo;
                    this.cboEmpleado.SelectedValue = uiHorario.EmpleadoCodigo;

                    this.nudTurno.Value = uiHorario.Turno;
                    this.txtHoras.Text = uiHorario.Horas.ToString();
                    this.dtpTurnoDesde.Value = uiHorario.FechaHoraInicio;
                    this.dtpTurnoHasta.Value = uiHorario.FechaHoraFinal;
                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void btnHorarioQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvHorarios.CurrentRow != null)
                {

                    if (Util.ConfirmationMessage("¿Desea eliminar el horario seleccionado?") == false)
                        return;

                    var uiHorario = (BE.UI.Horario)this.dgvHorarios.CurrentRow.DataBoundItem;

                    if (uiHorario.IdHorario > 0)
                        this.lstUiHorarioEliminados.Add(uiHorario);
                    else
                        this.lstUiHorarioNuevos.Remove(uiHorario);

                    this.lstUiHorario.Remove(uiHorario);

                    BindingSource source = new BindingSource();
                    source.DataSource = this.lstUiHorario;
                    this.dgvHorarios.DataSource = source;

                    this.txtNroRegistros.Text = this.lstUiHorario.Count.ToString();
                }

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void CboDia_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (this.CboDia.SelectedIndex > 0)
                {
                    int idDia = int.Parse(this.CboDia.SelectedValue.ToString()) - 1;
                    DateTime fechaDia = this.fechaInicio.AddDays((double)idDia);

                    this.txtFechaDia.Text = fechaDia.ToString("dd/MM/yyyy");
                    this.dtpTurnoDesde.Value = fechaDia;
                    this.dtpTurnoHasta.Value = fechaDia;
                }
                else
                {
                    this.txtFechaDia.Clear();
                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void dtpTurnoDesdeHasta_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                var desde = this.dtpTurnoDesde.Value;
                var hasta = this.dtpTurnoHasta.Value;
                int houras = (int)(hasta - desde).TotalHours;

                this.txtHoras.Text = houras.ToString();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void FrmHorarioSemanalMant_Load(object sender, EventArgs e)
        {
            try
            {

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

                if (this.cboSala.SelectedIndex == 0)
                {
                    this.cboSala.Focus();
                    throw new Exception("Seleccione una sala");
                }

                if (this.lblHorarios.Text.Length > 0)
                {
                    if (Util.ConfirmationMessage("¿Desea deshacer los cambios de la semana?") == false)
                        return;
                }

                int idAnho = int.Parse(cboAnho.SelectedValue.ToString());
                byte idSemana = byte.Parse(cboSemana.SelectedValue.ToString());

                var beSala = (BE.Sala)this.cboSala.SelectedItem;
                int idSala = beSala.IdSala;
                string dscSala = beSala.Nombre;

                this.uiHorarioSemanal = new BE.UI.HorarioSemanal();
                uiHorarioSemanal.Anho = idAnho;
                uiHorarioSemanal.Semana = idSemana;
                uiHorarioSemanal.SalaId = idSala;
                uiHorarioSemanal.SalaNombre = dscSala;
                uiHorarioSemanal.FechaInicio = this.fechaInicio;
                uiHorarioSemanal.FechaFinal = this.fechaFin;

                this.Cargar(this.uiHorarioSemanal);

                this.grpDatosHorario.Enabled = true;
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void cboAnhoSemana_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                int idAnho = int.Parse(cboAnho.SelectedValue.ToString());
                byte idSemana = byte.Parse(cboSemana.SelectedValue.ToString());

                this.CargarRangoFechas(idAnho, idSemana);
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void FrmHorarioSemanalMant_ResizeEnd(object sender, EventArgs e)
        {
            try
            {
                Util.AutoWidthColumn(ref this.dgvHorarios, "EmpleadoNombreCompleto");
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void txtEmpleadoCodigo_Leave(object sender, EventArgs e)
        {
            try
            {
                string codigo = this.txtEmpleadoCodigo.Text.Trim();

                var lst = (List<BE.Record>)this.cboEmpleado.DataSource;

                if(lst.Where(x => x.Codigo == codigo).Count() > 0)
                {
                    this.txtEmpleadoCodigo.Text = codigo;
                    this.cboEmpleado.SelectedValue = codigo;
                }
                else
                {
                    this.txtEmpleadoCodigo.Clear();
                    this.cboEmpleado.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void cboEmpleado_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (this.cboEmpleado.SelectedIndex > 0)
                {
                    this.txtEmpleadoCodigo.Text = this.cboEmpleado.SelectedValue.ToString();
                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void btnVista_Click(object sender, EventArgs e)
        {
            try
            {

                var frmView = new FrmHorarioSemanalVista();
                frmView.MdiParent = this.MdiParent;
                frmView.StartPosition = FormStartPosition.CenterScreen;
                frmView.Show();

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        
    }
}

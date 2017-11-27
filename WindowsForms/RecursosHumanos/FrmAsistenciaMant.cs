using System;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Globalization;
using System.Collections.Generic;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;
using System.ComponentModel;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmAsistenciaMant : Form
    {

        #region "Patron Singleton"

        private static FrmAsistenciaMant frmInstance = null;

        public static FrmAsistenciaMant Instance()
        {

            if (frmInstance == null || frmInstance.IsDisposed == true)
            {
                frmInstance = new FrmAsistenciaMant();
            }

            frmInstance.BringToFront();

            return frmInstance;
        }

        #endregion

        private List<BE.UI.Asistencia> lstUiAsistencias = null;

        public FrmAsistenciaList frmList = null;

        public FrmAsistenciaMant()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }

        }

        #region Metodos

        private void CargarTurnos()
        {
            int cntTurnos = 5;

            for (int i = 0; i < cntTurnos; i++)
            {
                int turno = i + 1;
                this.cboTurno.Items.Add(turno);
            }

            this.cboTurno.SelectedIndex = 0;
        }

        private List<BE.Record> ListadoEmpleados()
        {
            try
            {

                var lstEmpleados = new LN.Empleado().Combo();
                var lstCandidatos = new LN.Candidato().Combo();
                lstEmpleados.AddRange(lstCandidatos);

                var lstBeRegistros = new List<BE.Record>();
                lstBeRegistros = lstEmpleados.OrderBy(o => o.Codigo).Distinct().ToList();

                return lstBeRegistros;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarEmpleados()
        {
            try
            {
                var lstTrabajadores = this.ListadoEmpleados();

                lstTrabajadores.Insert(0, new BE.Record() { Codigo = "", Nombre = "Seleccione" });

                this.cboEmpleado.DataSource = lstTrabajadores;
                this.cboEmpleado.DisplayMember = "Nombre";
                this.cboEmpleado.ValueMember = "Codigo";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<BE.UI.Asistencia> CargarArchivo (string rutaArchivo)
        {
            var lstUiAsistencias = new List<BE.UI.Asistencia>();

            try
            {
                var lstEmpleados = this.ListadoEmpleados();

                using (var fs = File.OpenRead(rutaArchivo))
                using (var reader = new StreamReader(fs))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');

                        if (values.Length != 4)
                            throw new Exception("El registro debe contener Codigo de Empleado, Fecha y Hora Ingreso, Fecha y Hora Salida y Turno");

                        string codigoEmpleado = values[0].ToString().Trim();
                        string nombreEmpleado = "";

                        var beEmpleado = lstEmpleados.FirstOrDefault(x => x.Codigo.Equals(codigoEmpleado));
                        if (beEmpleado != null)
                            nombreEmpleado = beEmpleado.Nombre;
                        beEmpleado = null;

                        string formatoFecha = "dd/MM/yyyy HH:mm:ss";
                        DateTime ingreso;
                        if (DateTime.TryParseExact(values[1].ToString(), formatoFecha, CultureInfo.InvariantCulture, DateTimeStyles.None, out ingreso) == false)
                            throw new Exception("La fecha y hora de ingreso del empleado " + codigoEmpleado +  " es incorrecta");

                        DateTime salida;
                        if (DateTime.TryParseExact(values[2], "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out salida) == false)
                            throw new Exception("La fecha y hora de salida del empleado " + codigoEmpleado + " es incorrecta");

                        TimeSpan tiempo = salida.Subtract(ingreso);
                        if (tiempo.TotalSeconds < 0)
                            throw new Exception("El tiempo de trabajo del empleado " + codigoEmpleado + " es incorrecto");

                        int turno = 0;
                        if (int.TryParse(values[3].ToString(), out turno) == false)
                            throw new Exception("El turno del empleado " + codigoEmpleado + " es incorrecto");

                        var uiAsistencia = new BE.UI.Asistencia();
                        uiAsistencia.ID = 0;
                        uiAsistencia.EmpleadoCodigo = codigoEmpleado;
                        uiAsistencia.EmpleadoNombreCompleto = nombreEmpleado;
                        uiAsistencia.Turno = turno;
                        uiAsistencia.FechaHoraEntrada = ingreso;
                        uiAsistencia.FechaHoraSalida = salida;
                        uiAsistencia.Tiempo = tiempo;
                        uiAsistencia.Origen = "C";

                        lstUiAsistencias.Add(uiAsistencia);

                    }

                    return lstUiAsistencias;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarListadoAsistencia(List<BE.UI.Asistencia> lstUiAsistencias = null)
        {
            try
            {
                if (lstUiAsistencias == null)
                    this.lstUiAsistencias = new List<BE.UI.Asistencia>();
                else
                    this.lstUiAsistencias = lstUiAsistencias;

                var sorted = new SortableBindingList<BE.UI.Asistencia>(this.lstUiAsistencias);

                this.dgvRegistroAsistencias.DataSource = sorted;
                this.txtNroRegistros.Text = this.lstUiAsistencias.Count.ToString();

                if (this.lstUiAsistencias.Count > 0)
                    this.dtpFechaRegistroAsistencia.Value = this.lstUiAsistencias.Min(x => x.FechaHoraEntrada);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void LimpiarRegistroManual()
        {
            try
            {
                this.cboEmpleado.SelectedIndex = 0;
                this.cboEmpleado.Focus();
                this.txtEmpleadoCodigo.Clear();

                this.cboTurno.SelectedIndex = 0;

                this.DtpFechaHoraEntrada.Value = DateTime.Now;
                this.DtpFechaHoraSalida.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Cargar(List<BE.UI.Asistencia> lstUiAsistencias)
        {
            try
            {

                if (lstUiAsistencias != null)
                {

                    this.CargarListadoAsistencia(lstUiAsistencias);

                    if (this.lstUiAsistencias.Count > 0)
                    {
                        DateTime fechaRegistro = this.lstUiAsistencias[0].Fecha;
                        this.dtpFechaRegistroAsistencia.Value = fechaRegistro;
                    }

                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }

        }

        private void FormatoListadoAsistencias()
        {
            try
            {
                Util.FormatDatagridview(ref this.dgvRegistroAsistencias);

                for (int i = 0; i < this.dgvRegistroAsistencias.Columns.Count; i++)
                {
                    this.dgvRegistroAsistencias.Columns[i].Visible = false;
                }

                this.dgvRegistroAsistencias.Columns["EmpleadoCodigo"].Visible = true;
                this.dgvRegistroAsistencias.Columns["EmpleadoCodigo"].HeaderText = "Codigo";
                this.dgvRegistroAsistencias.Columns["EmpleadoCodigo"].Width = 80;
                this.dgvRegistroAsistencias.Columns["EmpleadoCodigo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvRegistroAsistencias.Columns["EmpleadoNombreCompleto"].Visible = true;
                this.dgvRegistroAsistencias.Columns["EmpleadoNombreCompleto"].HeaderText = "Empleado";
                this.dgvRegistroAsistencias.Columns["EmpleadoNombreCompleto"].Width = 150;
                this.dgvRegistroAsistencias.Columns["EmpleadoNombreCompleto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dgvRegistroAsistencias.Columns["EmpleadoNombreCompleto"].DefaultCellStyle.BackColor = Color.LightGray;

                this.dgvRegistroAsistencias.Columns["Turno"].Visible = true;
                this.dgvRegistroAsistencias.Columns["Turno"].HeaderText = "Turno";
                this.dgvRegistroAsistencias.Columns["Turno"].Width = 40;
                this.dgvRegistroAsistencias.Columns["Turno"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.dgvRegistroAsistencias.Columns["FechaHoraEntrada"].Visible = true;
                this.dgvRegistroAsistencias.Columns["FechaHoraEntrada"].HeaderText = "Ingreso";
                this.dgvRegistroAsistencias.Columns["FechaHoraEntrada"].Width = 120;
                this.dgvRegistroAsistencias.Columns["FechaHoraEntrada"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
                this.dgvRegistroAsistencias.Columns["FechaHoraEntrada"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.dgvRegistroAsistencias.Columns["FechaHoraSalida"].Visible = true;
                this.dgvRegistroAsistencias.Columns["FechaHoraSalida"].HeaderText = "Salida";
                this.dgvRegistroAsistencias.Columns["FechaHoraSalida"].Width = 120;
                this.dgvRegistroAsistencias.Columns["FechaHoraSalida"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
                this.dgvRegistroAsistencias.Columns["FechaHoraSalida"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.dgvRegistroAsistencias.Columns["Tiempo"].Visible = true;
                this.dgvRegistroAsistencias.Columns["Tiempo"].HeaderText = "Tiempo";
                this.dgvRegistroAsistencias.Columns["Tiempo"].Width = 50;
                this.dgvRegistroAsistencias.Columns["Tiempo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvRegistroAsistencias.Columns["Tiempo"].DefaultCellStyle.BackColor = Color.LightGray;

                Util.AutoWidthColumn(ref this.dgvRegistroAsistencias, "EmpleadoNombreCompleto");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Formulario

        private void FrmAsistenciaMant_Load(object sender, EventArgs e)
        {
            try
            {

                this.CargarEmpleados();
                this.CargarTurnos();

                this.dtpFechaRegistroAsistencia.Value = DateTime.Now;
                this.DtpFechaHoraEntrada.Value = DateTime.Now;
                this.DtpFechaHoraSalida.Value = DateTime.Now;

                this.CargarListadoAsistencia();
                this.FormatoListadoAsistencias();

                this.DtpFechaHoraEntrada.ValueChanged += DtpFechaHoraEntradaSalida_ValueChanged;
                this.DtpFechaHoraSalida.ValueChanged += DtpFechaHoraEntradaSalida_ValueChanged;
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void FrmAsistenciaMant_ResizeEnd(object sender, EventArgs e)
        {
            try
            {
                Util.AutoWidthColumn(ref this.dgvRegistroAsistencias, "EmpleadoNombreCompleto");
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                int idUsuarioSesion = ((MdiMain)this.MdiParent).uiUsuario.ID;
                bool rpta = false;

                for (int i = 0; i < this.dgvRegistroAsistencias.Rows.Count; i++)
                {

                    var uiAsistencia = (BE.UI.Asistencia)this.dgvRegistroAsistencias.Rows[i].DataBoundItem;
                    uiAsistencia.Fecha = this.dtpFechaRegistroAsistencia.Value;

                    if (uiAsistencia.ID == 0)
                        rpta = new LN.Asistencia().Insertar(ref uiAsistencia, idUsuarioSesion);
                    //else
                    //    rpta = new LN.Asistencia().Actualizar(uiAsistencia, idUsuarioSesion);

                }

                int anho = this.dtpFechaRegistroAsistencia.Value.Year;
                int mes = this.dtpFechaRegistroAsistencia.Value.Month;
                this.frmList.CargarAsistencias(anho, mes);

                if (rpta)
                {
                    Util.InformationMessage("Se guardo los datos de la asistencia");
                    this.Close();
                }


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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.cboEmpleado.SelectedIndex == 0)
                {
                    this.cboEmpleado.Focus();
                    throw new Exception("Seleccione un empleado");
                }

                DateTime ingreso = this.DtpFechaHoraEntrada.Value;
                DateTime salida = this.DtpFechaHoraSalida.Value;
                if (ingreso > salida)
                {
                    this.DtpFechaHoraEntrada.Focus();
                    throw new Exception("La fecha y hora de ingreso es mayor a la fecha y hora de salida");
                }
                TimeSpan tiempo = salida.Subtract(ingreso);

                string codigoEmpleado = this.cboEmpleado.SelectedValue.ToString();
                string nombreEmpleado = new LN.Empleado().ObtenerNombreCompleto(codigoEmpleado);
                int turno = this.cboTurno.SelectedIndex + 1;
                
                var uiAsistencia = new BE.UI.Asistencia();
                uiAsistencia.ID = 0;
                uiAsistencia.EmpleadoCodigo = codigoEmpleado;
                uiAsistencia.EmpleadoNombreCompleto = nombreEmpleado;
                uiAsistencia.Turno = turno;
                uiAsistencia.FechaHoraEntrada = ingreso;
                uiAsistencia.FechaHoraSalida = salida;
                uiAsistencia.Tiempo = tiempo;
                uiAsistencia.Origen = "M";
                uiAsistencia.Fecha = this.DtpFechaHoraEntrada.Value;

                this.lstUiAsistencias.Add(uiAsistencia);
    
                this.CargarListadoAsistencia(this.lstUiAsistencias);
                this.LimpiarRegistroManual();

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void BtnFile_Click(object sender, EventArgs e)
        {
            try
            {

                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Archivo CSV (*.csv)|*.csv";
                dialog.Title = "Seleccione el archivo de carga";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                 
                    var rutaArchivo = dialog.FileName;

                    Util.PointerLoad(this);

                    this.TxtArchivo.Text = rutaArchivo;

                    var lstUiAsistencias = this.CargarArchivo(rutaArchivo);

                    this.CargarListadoAsistencia(lstUiAsistencias);
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

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvRegistroAsistencias.CurrentRow != null)
                {
                    var uiAsistencia = (BE.UI.Asistencia)this.dgvRegistroAsistencias.CurrentRow.DataBoundItem;

                    if (uiAsistencia.ID > 0)
                    {
                        bool rpta = new LN.Asistencia().Eliminar(uiAsistencia.ID);

                        if (rpta == true && this.frmList != null)
                        {
                            int anho = this.dtpFechaRegistroAsistencia.Value.Year;
                            int mes = this.dtpFechaRegistroAsistencia.Value.Month;
                            this.frmList.CargarAsistencias(anho, mes);
                        }
                    }

                    int i = this.dgvRegistroAsistencias.CurrentRow.Index;
                    this.dgvRegistroAsistencias.Rows.RemoveAt(i);

                    this.txtNroRegistros.Text = this.lstUiAsistencias.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        #endregion

        private void DtpFechaHoraEntradaSalida_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime ingreso = this.DtpFechaHoraEntrada.Value;
                DateTime salida = this.DtpFechaHoraSalida.Value;

                if (ingreso > salida)
                    return;

                TimeSpan tiempo = salida.Subtract(ingreso);

                this.txtTiempo.Text = new DateTime(tiempo.Ticks).ToString("HH:mm:ss");
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }

        }

        private void dtpFechaRegistroAsistencia_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.lstUiAsistencias != null)
                {
                    for (int i = 0; i < this.lstUiAsistencias.Count; i++)
                    {
                        this.lstUiAsistencias[i].Fecha = dtpFechaRegistroAsistencia.Value;
                    }
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
                    string codigoEmpleado = this.cboEmpleado.SelectedValue.ToString().Trim();
                    this.txtEmpleadoCodigo.Text = codigoEmpleado;
                }
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
                string codigoEmpleado = this.txtEmpleadoCodigo.Text.Trim();

                var lst = (List<BE.Record>)this.cboEmpleado.DataSource;

                if (lst.Where(x => x.Codigo == codigoEmpleado).Count() > 0)
                {
                    this.txtEmpleadoCodigo.Text = codigoEmpleado;
                    this.cboEmpleado.SelectedValue = codigoEmpleado;
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

        private void dgvRegistroAsistencias_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                var col = this.dgvRegistroAsistencias.Columns[e.ColumnIndex];
                ListSortDirection dir;

                switch (col.HeaderCell.SortGlyphDirection)
                {
                    case SortOrder.Ascending:
                        dir = ListSortDirection.Ascending;
                        break;
                    default:
                        dir = ListSortDirection.Descending;
                        break;
                }

                this.dgvRegistroAsistencias.Sort(col, dir);
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void btnExportarCsv_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Comma-separated Values (*.csv)|*.csv";
                sfd.FileName = "export.csv";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Util.PointerLoad(this);
                    Util.DatagridviewToCsv(this.dgvRegistroAsistencias, sfd.FileName);
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
    }
}

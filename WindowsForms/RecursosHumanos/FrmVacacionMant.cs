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
    public partial class FrmVacacionMant : Form
    {

        #region "Patron Singleton"

        private static FrmVacacionMant frmInstance = null;

        public static FrmVacacionMant Instance()
        {

            if (frmInstance == null || frmInstance.IsDisposed == true)
            {
                frmInstance = new FrmVacacionMant();
            }

            frmInstance.BringToFront();

            return frmInstance;
        }

        #endregion

        public FrmVacacionList frmList = null;

        private BE.UI.Vacacion uiVacacion = new BE.UI.Vacacion();

        public FrmVacacionMant()
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

        public void Cargar(BE.UI.Vacacion uiVacacion = null)
        {
            try
            {

                if (uiVacacion != null)
                {

                    this.uiVacacion = uiVacacion;

                   

                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }

        }

        /// <summary>
        /// Cargar solo empleados que cumplan mas de 1 año de ingreso o de vacaciones
        /// </summary>
        private void CargarEmpleados()
        {
            try
            {
                var fechaActual = DateTime.Now;
                var lstUiEmpleadosVacaciones = new LN.Empleado().ListarVacaciones(fechaActual);
                lstUiEmpleadosVacaciones.Insert(0, new BE.UI.EmpleadoVacacion() {
                    Id = 0,
                    EmpleadoCodigo = "0",
                    EmpleadoApellidosNombres = "Seleccione",
                    EmpleadoFechaIngreso = DateTime.Now,
                    EmpleadoFechaVacacion = null
                });

                this.cboEmpleado.DataSource = lstUiEmpleadosVacaciones;
                this.cboEmpleado.DisplayMember = "EmpleadoApellidosNombres";
                this.cboEmpleado.ValueMember = "EmpleadoCodigo";
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void CargarListadoVacaciones()
        {
            try
            {

                var source = new BindingSource();
                source.DataSource = this.uiVacacion.Detalle;

                this.dgvDetalles.DataSource = source;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FormatoListadoVacaciones()
        {
            try
            {
                Util.FormatDatagridview(ref this.dgvDetalles);
                this.dgvDetalles.ReadOnly = false;

                for (int col = 0; col < this.dgvDetalles.Columns.Count; col++)
                    this.dgvDetalles.Columns[col].Visible = false;

                this.dgvDetalles.Columns["Numero"].Visible = true;
                this.dgvDetalles.Columns["Numero"].HeaderText = "Nro.";
                this.dgvDetalles.Columns["Numero"].Width = 30;
                this.dgvDetalles.Columns["Numero"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dgvDetalles.Columns["Numero"].DefaultCellStyle.BackColor = Color.LightGray;
                this.dgvDetalles.Columns["Numero"].ReadOnly = true;

                this.dgvDetalles.Columns["Anho"].Visible = true;
                this.dgvDetalles.Columns["Anho"].HeaderText = "Año";
                this.dgvDetalles.Columns["Anho"].Width = 50;
                this.dgvDetalles.Columns["Anho"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvDetalles.Columns["Anho"].DefaultCellStyle.BackColor = Color.LightGray;
                this.dgvDetalles.Columns["Anho"].ReadOnly = true;

                this.dgvDetalles.Columns["MesNombre"].Visible = true;
                this.dgvDetalles.Columns["MesNombre"].HeaderText = "Mes";
                this.dgvDetalles.Columns["MesNombre"].Width = 100;
                this.dgvDetalles.Columns["MesNombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvDetalles.Columns["MesNombre"].DefaultCellStyle.BackColor = Color.LightGray;
                this.dgvDetalles.Columns["MesNombre"].ReadOnly = true;

                this.dgvDetalles.Columns["HorasExtrasMonto"].Visible = true;
                this.dgvDetalles.Columns["HorasExtrasMonto"].HeaderText = "Horas Extras";
                this.dgvDetalles.Columns["HorasExtrasMonto"].Width = 100;
                this.dgvDetalles.Columns["HorasExtrasMonto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvDetalles.Columns["HorasExtrasMonto"].DefaultCellStyle.Format = "N2";

                this.dgvDetalles.Columns["BonificacionMonto"].Visible = true;
                this.dgvDetalles.Columns["BonificacionMonto"].HeaderText = "Bonificaciones";
                this.dgvDetalles.Columns["BonificacionMonto"].Width = 100;
                this.dgvDetalles.Columns["BonificacionMonto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvDetalles.Columns["BonificacionMonto"].DefaultCellStyle.Format = "N2";

                Util.AutoWidthColumn(ref this.dgvDetalles, "MesNombre");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #region Formulario

        private void FrmVacacionMant_Load(object sender, EventArgs e)
        {
            try
            {

                this.txtFechaIngreso.Clear();
                this.txtFechaUltimaVacacion.Clear();

                this.txtDiasVacacion.Text = "0";
                this.dtpInicioVacacion.Value = DateTime.Now;
                this.txtFinVacacion.Text = DateTime.Now.ToString("dd/MM/yyyy");

                this.CargarEmpleados();

                this.CargarListadoVacaciones();
                this.FormatoListadoVacaciones();

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

                #region Validaciones

                if (this.cboEmpleado.SelectedIndex == 0)
                {
                    this.cboEmpleado.Focus();
                    throw new Exception("Seleccione un empleado");
                }

                if (this.txtDiasVacacion.Text.Length == 0)
                {
                    this.txtDiasVacacion.Focus();
                    throw new Exception("Ingrese la cantidad de días de vacaciones");
                }
                else 
                {
                    int dias = 0;
                    if (int.TryParse(this.txtDiasVacacion.Text, out dias) == false)
                    {
                        this.txtDiasVacacion.Focus();
                        throw new Exception("Ingrese el número de días de vacaciones");
                    }
                    else if (dias < 0 || dias > 30)
                    {
                        this.txtDiasVacacion.Focus();
                        throw new Exception("Ingrese solo entre 1 y 30 días de vacaciones");
                    }
                }

                #endregion

                #region Guardar

                #region Obtener datos

                var lnEmpleado = new LN.Empleado();

                string codigoEmpleado = this.txtEmpleadoCodigo.Text;
                string nombreCompletoEmpleado = lnEmpleado.ObtenerNombreCompleto(codigoEmpleado);
                double sueldo = 0.0;
                double asignacionFamiliar = 0.0;
                var beEmpleadoRecurso = lnEmpleado.ObtenerRecurso(codigoEmpleado);
                if (beEmpleadoRecurso != null)
                {
                    sueldo = beEmpleadoRecurso.Sueldo;
                    asignacionFamiliar = lnEmpleado.ObtenerAsignacionFamiliar(codigoEmpleado);
                }
                lnEmpleado = null;
                beEmpleadoRecurso = null;

                DateTime vacacionFechaInicio = this.dtpInicioVacacion.Value.Date;
                DateTime vacacionFechaFinal = Util.ParseStringToDatetime(this.txtFinVacacion.Text);
                int vacacionDias = int.Parse(this.txtDiasVacacion.Text);

                #endregion

                this.uiVacacion.PeriodoFechaInicial = DateTime.Now;
                this.uiVacacion.PeriodoFechaFinal = DateTime.Now;
                this.uiVacacion.PeriodoDias = 0;

                this.uiVacacion.VacacionFechaInicial = vacacionFechaInicio.Date;
                this.uiVacacion.VacacionFechaFinal = vacacionFechaFinal.Date;
                this.uiVacacion.VacacionDias = vacacionDias;

                this.uiVacacion.EmpleadoCodigo = codigoEmpleado;
                this.uiVacacion.EmpleadoNombreCompleto = nombreCompletoEmpleado;
                this.uiVacacion.EmpleadoSueldo = sueldo;
                this.uiVacacion.EmpleadoAsignacionFamiliar = asignacionFamiliar;

                this.uiVacacion.PromedioHorasExtras = 0.0;
                this.uiVacacion.PromedioBonificacion = 0.0;
                this.uiVacacion.OtrosMonto = 0.0;
                this.uiVacacion.TotalBruto = 0.0;
                this.uiVacacion.PensionTipo = "";
                this.uiVacacion.PensionPorcentaje = 0.0;
                this.uiVacacion.PensionTotal = 0.0;
                this.uiVacacion.RetencionJudicialMonto = 0.0;
                this.uiVacacion.TotalDescuento = 0.0;
                this.uiVacacion.TotalNeto = 0.0;


                bool rpta = false;
                string msg = "";
                var lnVacacion = new LN.Vacacion();
                if (this.uiVacacion.Id == 0) //Nuevo
                {
                    rpta = lnVacacion.Insertar(ref this.uiVacacion);
                    if (true)
                        msg = "Se registro el nuevo Vacacion";
                }
                else  //Actualizar
                {
                    rpta = lnVacacion.Actualizar(this.uiVacacion);
                    if (true)
                        msg = "Se actualizo el Vacacion";
                }

                if (rpta == true)
                {
                    Util.InformationMessage(msg);
                    this.frmList.CargarListadoVacaciones();
                    this.Close();
                }
                    
                #endregion

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

                var rpta = Util.ConfirmationMessage("¿Desea salir del formulario de mantenimiento de Vacacion?");

                if (rpta == false)
                    return;

                this.Close();

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void txtDiasVacacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void txtDiasVacacion_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate
            {
                txtDiasVacacion.SelectAll();
            });
        }


        private void txtDiasVacacion_Leave(object sender, EventArgs e)
        {
            try
            {
                int dias = 0;

                if(int.TryParse(this.txtDiasVacacion.Text, out dias) == true)
                {
                    if (dias < 0 || dias > 30) //Entre 1 y 30 dias
                        dias = 0;
                }

                this.txtFinVacacion.Text = this.dtpInicioVacacion.Value.AddDays(dias).ToString("dd/MM/yyyy");
                this.txtDiasVacacion.Text = dias.ToString();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void dgvDetalles_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                int colBonificacion = this.dgvDetalles.Columns["BonificacionMonto"].Index;
                int colHorasExtras = this.dgvDetalles.Columns["HorasExtrasMonto"].Index;
                if (this.dgvDetalles.CurrentCell.ColumnIndex == colBonificacion 
                    || this.dgvDetalles.CurrentCell.ColumnIndex == colHorasExtras)
                {
                    e.Control.KeyPress += new KeyPressEventHandler(dgvDetalles_KeyPress);
                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void dgvDetalles_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void cboEmpleado_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (this.cboEmpleado.SelectedIndex > 0)
                {
                    var uiEmpleadoVacacion = (BE.UI.EmpleadoVacacion)this.cboEmpleado.SelectedItem;

                    this.txtEmpleadoCodigo.Text = uiEmpleadoVacacion.EmpleadoCodigo;
                    this.txtFechaIngreso.Text = uiEmpleadoVacacion.EmpleadoFechaIngreso.ToString("dd/MM/yyyy");

                    DateTime? fechaVacacion = uiEmpleadoVacacion.EmpleadoFechaVacacion;
                    if (fechaVacacion != null)
                        this.txtFechaUltimaVacacion.Text = ((DateTime)fechaVacacion).ToString("dd/MM/yyyy");
                }
                else
                {
                    this.txtEmpleadoCodigo.Clear();
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

                var lstUiEmpleadosVacaciones = (List<BE.UI.EmpleadoVacacion>)this.cboEmpleado.DataSource;

                var uiEmpleadoVacacion = lstUiEmpleadosVacaciones.FirstOrDefault(x => x.EmpleadoCodigo.Contains(codigoEmpleado));

                if (uiEmpleadoVacacion != null)
                {
                    this.txtEmpleadoCodigo.Text = uiEmpleadoVacacion.EmpleadoCodigo;
                    this.cboEmpleado.SelectedValue = uiEmpleadoVacacion.EmpleadoCodigo;
                    this.txtFechaIngreso.Text = uiEmpleadoVacacion.EmpleadoFechaIngreso.ToString("dd/MM/yyyy");

                    DateTime? fechaVacacion = uiEmpleadoVacacion.EmpleadoFechaVacacion;
                    if (fechaVacacion != null)
                        this.txtFechaUltimaVacacion.Text = ((DateTime)fechaVacacion).ToString("dd/MM/yyyy");
                }
                else
                {
                    this.txtEmpleadoCodigo.Clear();
                    this.cboEmpleado.SelectedIndex = 0;
                    this.txtFechaIngreso.Clear();
                    this.txtFechaUltimaVacacion.Clear();
                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void FrmVacacionMant_ResizeEnd(object sender, EventArgs e)
        {
            try
            {
                Util.AutoWidthColumn(ref this.dgvDetalles, "MesNombre");
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void dtpInicioVacacion_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaInicioVacacion = this.dtpInicioVacacion.Value.Date;
                int cntMeses = 6;

                this.uiVacacion.Detalle.Clear();

                for (int i = 0; i < cntMeses; i++)
                {
                    var uiDetalle = new BE.UI.VacacionDetalle();

                    uiDetalle.Id = 0;
                    uiDetalle.Numero = i + 1;
                    uiDetalle.Anho = fechaInicioVacacion.AddMonths(i - cntMeses).Year;
                    uiDetalle.MesNumero = fechaInicioVacacion.AddMonths(i - cntMeses).Month;
                    uiDetalle.MesNombre = Util.GetNameOfMonth(uiDetalle.MesNumero);
                    uiDetalle.HorasExtrasMonto = 0.0;
                    uiDetalle.BonificacionMonto = 0.0;

                    this.uiVacacion.Detalle.Add(uiDetalle);
                }

                this.CargarListadoVacaciones();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        #endregion

    }
}

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

        private bool calculado = false;
        private BE.UI.Vacacion uiVacacion = null;
        
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

        #region Metodos

        /// <summary>
        /// Cargar solo empleados que cumplan mas de 1 año de ingreso o de vacaciones
        /// </summary>
        private void CargarComboEmpleados()
        {
            try
            {
                var fechaActual = DateTime.Now;

                var lstUiEmpleadosVacaciones = new LN.Empleado().ListarVacaciones(fechaActual);

                lstUiEmpleadosVacaciones = lstUiEmpleadosVacaciones.OrderBy(x => x.EmpleadoApellidosNombres).ToList();

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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LimpiarCabecera()
        {
            try
            {

                var fechaConsulta = DateTime.Now;
                int diasMaxVacaciones = 30;

                this.txtEmpleadoCodigo.Clear();
                this.cboEmpleado.SelectedIndex = 0;

                this.txtFechaIngreso.Clear();
                this.txtFechaUltimaVacacion.Clear();

                this.dtpPeriodoInicio.Value = fechaConsulta;
                this.dtpVacacionSalida.Value = fechaConsulta;

                this.dtpVacacionSalida.Value = fechaConsulta;
                this.txtVacacionesDias.Text = diasMaxVacaciones.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LimpiarCalculo()
        {
            try
            {
                this.grpEmpleado.Enabled = true;

                this.txtCodigo.Clear();
                this.txtNombres.Clear();
                this.txtPeriodoInicio.Clear();
                this.txtPeriodoFinal.Clear();
                this.txtDescansoInicio.Clear();
                this.txtDescansoFin.Clear();

                this.txtSueldo.Text = "0.00";
                this.txtAsignacionFamiliar.Text = "0.00";
                this.txtPromedioBonificaciones.Text = "0.00";
                this.txtPromedioHorasExtras.Text = "0.00";
                this.txtTotalBruto.Text = "0.00";

                this.txtRetencionJudicial.Text = "0.00";
                this.txtPensionTipo.Text = "0.00";
                this.txtPensionDescipcion.Text = "0.00";
                this.txtPensionMonto.Text = "0.00";
                this.txtPensionPorcentaje.Text = "0.00 %";
                this.txtTotalNeto.Text = "0.00";

                this.calculado = false;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Cargar la lista de los ultimos 6 meses de bonos y horas extras en base 
        /// a la fecha de consulta
        /// </summary>
        /// <param name="fechaConsulta">Fecha de Consulta</param>
        public void CargarListadoVacaciones(DateTime fechaConsulta)
        {
            try
            {
                int cntMeses = 6;
                double sumBono = 0.0;
                double sumHoEx = 0.0;

                this.uiVacacion.Detalle.Clear();

                for (int i = 0; i < cntMeses; i++)
                {
                    var uiDetalle = new BE.UI.VacacionDetalle();

                    uiDetalle.Id = 0;
                    uiDetalle.Numero = i + 1;
                    uiDetalle.Anho = fechaConsulta.AddMonths(i - cntMeses).Year;
                    uiDetalle.MesNumero = fechaConsulta.AddMonths(i - cntMeses).Month;
                    uiDetalle.MesNombre = Util.GetNameOfMonth(uiDetalle.MesNumero);

                    uiDetalle.HorasExtrasMonto = 0.0; //Calcular
                    sumHoEx += uiDetalle.HorasExtrasMonto;
                    uiDetalle.BonificacionMonto = 0.0; //Calcular
                    sumBono += uiDetalle.BonificacionMonto;

                    this.uiVacacion.Detalle.Add(uiDetalle);
                }

                this.txtCantidadMeses.Text = cntMeses.ToString();
                this.txtSumaBonos.Text = sumBono.ToString("N2");
                this.txtSumaHorasExtras.Text = sumHoEx.ToString("N2");

                var source = new BindingSource();
                source.DataSource = this.uiVacacion.Detalle;

                this.dgvDetalles.DataSource = source;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Dar formato a la grilla 
        /// </summary>
        private void FormatoListadoVacaciones()
        {
            try
            {
                Util.FormatDatagridview(ref this.dgvDetalles);
                this.dgvDetalles.ReadOnly = false;

                for (int col = 0; col < this.dgvDetalles.Columns.Count; col++)
                    this.dgvDetalles.Columns[col].Visible = false;
                
                this.dgvDetalles.Columns["Anho"].Visible = true;
                this.dgvDetalles.Columns["Anho"].HeaderText = "Año";
                this.dgvDetalles.Columns["Anho"].Width = 35;
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
                this.dgvDetalles.Columns["HorasExtrasMonto"].Width = 65;
                this.dgvDetalles.Columns["HorasExtrasMonto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvDetalles.Columns["HorasExtrasMonto"].DefaultCellStyle.Format = "N2";

                this.dgvDetalles.Columns["BonificacionMonto"].Visible = true;
                this.dgvDetalles.Columns["BonificacionMonto"].HeaderText = "Bonificacion";
                this.dgvDetalles.Columns["BonificacionMonto"].Width = 65;
                this.dgvDetalles.Columns["BonificacionMonto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvDetalles.Columns["BonificacionMonto"].DefaultCellStyle.Format = "N2";

                Util.AutoWidthColumn(ref this.dgvDetalles, "MesNombre");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool Calcular(string codigoEmpleado, DateTime fechaConsulta)
        {
            bool calculado = false;
            try
            {
                using (var lnEmpleado = new LN.Empleado())
                {
                    var uiEmpleadoCompleto = lnEmpleado.ObtenerEmpleadoCompleto(codigoEmpleado, fechaConsulta);

                    if (uiEmpleadoCompleto != null)
                    {
                        //Rescartar el detalle
                        var lstUiVacacionDetalle = this.uiVacacion.Detalle;

                        //Limpiar 
                        this.uiVacacion = new BE.UI.Vacacion();

                        //Asignar nuevos valores
                        this.uiVacacion.Detalle = lstUiVacacionDetalle;

                        this.uiVacacion.PeriodoFechaInicial = this.dtpPeriodoInicio.Value.Date;
                        this.uiVacacion.PeriodoFechaFinal = this.dtpPeriodoFinal.Value.Date;

                        var fechaVacacionInicio = this.dtpVacacionSalida.Value;
                        int diasVacaciones = int.Parse(this.txtDescansoDias.Text);
                        this.uiVacacion.VacacionFechaInicial = fechaVacacionInicio.Date;
                        this.uiVacacion.VacacionFechaFinal = fechaVacacionInicio.AddDays(diasVacaciones).Date;
                        this.uiVacacion.VacacionDias = diasVacaciones;

                        this.uiVacacion.EmpleadoCodigo = uiEmpleadoCompleto.Codigo;
                        this.uiVacacion.EmpleadoNombreCompleto = $"{uiEmpleadoCompleto.Apellidos}, {uiEmpleadoCompleto.Nombres}";

                        this.uiVacacion.EmpleadoSueldo = uiEmpleadoCompleto.Sueldo;
                        this.uiVacacion.EmpleadoAsignacionFamiliar = lnEmpleado.ObtenerAsignacionFamiliar(codigoEmpleado);

                        double sumHorasExtras = double.Parse(this.txtSumaHorasExtras.Text);
                        double sumBoninificaciones = double.Parse(this.txtSumaBonos.Text);
                        int numMeses = int.Parse(this.txtCantidadMeses.Text);

                        double promHorasExtras = sumHorasExtras / numMeses;
                        double promBoninificaciones = sumBoninificaciones / numMeses;
                        this.uiVacacion.PromedioHorasExtras = promHorasExtras;
                        this.uiVacacion.PromedioBonificacion = promBoninificaciones;

                        this.uiVacacion.PensionTipo = uiEmpleadoCompleto.PensionTipo;
                        if (uiEmpleadoCompleto.PensionTipo == BE.UI.TipoPensionEnum.AFP)
                        {
                            this.uiVacacion.PensionId = uiEmpleadoCompleto.AfpId;
                            this.uiVacacion.PensionNombre = uiEmpleadoCompleto.AfpNombre;
                            this.uiVacacion.PensionTipoComision = uiEmpleadoCompleto.AfpComisionCodigo;
                            this.uiVacacion.PensionPorcentaje = uiEmpleadoCompleto.AfpComisionPorcentaje;
                        }
                        else
                        {
                            this.uiVacacion.PensionId = 0;
                            this.uiVacacion.PensionNombre = "ONP";
                            this.uiVacacion.PensionTipoComision = "";
                            this.uiVacacion.PensionPorcentaje = uiEmpleadoCompleto.OnpComisionPorcentaje;
                        }

                        double factorPension = this.uiVacacion.PensionPorcentaje / 100;
                        double totalPension = this.uiVacacion.TotalBruto;
                        this.uiVacacion.PensionMonto = totalPension * factorPension;

                        this.uiVacacion.RetencionJudicialMonto = uiEmpleadoCompleto.RetencionJudicialNominal;

                        calculado = true;
                    }

                }

                return calculado;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void MostrarCalculo()
        {
            try
            {
                if (this.uiVacacion == null)
                    return;

                this.grpEmpleado.Enabled = false;

                this.txtCodigo.Text = this.uiVacacion.EmpleadoCodigo;
                this.txtNombres.Text = this.uiVacacion.EmpleadoNombreCompleto;

                this.txtPeriodoInicio.Text = this.uiVacacion.PeriodoFechaInicial.ToString("dd/MM/yyyy");
                this.txtPeriodoFinal.Text = this.uiVacacion.PeriodoFechaFinal.ToString("dd/MM/yyyy");

                this.txtDescansoInicio.Text = this.uiVacacion.VacacionFechaInicial.ToString("dd/MM/yyyy");
                this.txtDescansoFin.Text = this.uiVacacion.VacacionFechaFinal.ToString("dd/MM/yyyy");
                this.txtDescansoDias.Text = this.uiVacacion.VacacionDias.ToString();

                this.txtSueldo.Text = this.uiVacacion.EmpleadoSueldo.ToString("N2");
                this.txtAsignacionFamiliar.Text = this.uiVacacion.EmpleadoAsignacionFamiliar.ToString("N2");
                this.txtPromedioBonificaciones.Text = this.uiVacacion.PromedioBonificacion.ToString("N2");
                this.txtPromedioHorasExtras.Text = this.uiVacacion.PromedioHorasExtras.ToString("N2");

                this.txtRedondeo.ReadOnly = false;
                this.txtRedondeo.Text = this.uiVacacion.Redondeo.ToString("N2");

                this.txtTotalBruto.Text = this.uiVacacion.TotalBruto.ToString("N2");

                this.txtRetencionJudicial.Text = this.uiVacacion.RetencionJudicialMonto.ToString("N2");

                this.txtPensionTipo.Text = this.uiVacacion.PensionTipo.ToString();
                this.txtPensionDescipcion.Text = this.uiVacacion.PensionNombre;
                this.txtPensionMonto.Text = this.uiVacacion.PensionMonto.ToString("N2");
                this.txtPensionPorcentaje.Text = $"{this.uiVacacion.PensionPorcentaje.ToString("N2")} %";
                this.txtTotalNeto.Text = this.uiVacacion.TotalNeto.ToString("N2");

                this.calculado = true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Formulario

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


        private void FrmVacacionMant_Load(object sender, EventArgs e)
        {
            try
            {

                this.uiVacacion = new BE.UI.Vacacion();

                #region Cabecera

                this.CargarComboEmpleados();

                this.LimpiarCabecera();

                #endregion

                var fechaConsulta = DateTime.Now;
                this.CargarListadoVacaciones(fechaConsulta);
                this.FormatoListadoVacaciones();

                #region Calculo

                this.LimpiarCalculo();

                #endregion

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        
        private void txtVacacionesDias_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtVacacionesDias_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate
            {
                txtDescansoDias.SelectAll();
            });
        }


        private void txtVacacionesDias_Leave(object sender, EventArgs e)
        {
            try
            {
                int dias = 0;

                if(int.TryParse(this.txtDescansoDias.Text, out dias) == true)
                {
                    if (dias < 0 || dias > 30) //Entre 1 y 30 dias
                        dias = 0;
                }

                this.txtVacacionesDias.Text = dias.ToString();

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void dgvDetalle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int colBonificacion = this.dgvDetalles.Columns["BonificacionMonto"].Index;
                int colHorasExtras = this.dgvDetalles.Columns["HorasExtrasMonto"].Index;
                if (this.dgvDetalles.CurrentCell.ColumnIndex == colBonificacion)
                {
                    double montoBono = this.uiVacacion.Detalle.Sum(x => x.BonificacionMonto);
                    this.txtSumaBonos.Text = montoBono.ToString("N2");
                }
                else if (this.dgvDetalles.CurrentCell.ColumnIndex == colHorasExtras)
                {
                    double montoHorasExtras = this.uiVacacion.Detalle.Sum(x => x.HorasExtrasMonto);
                    this.txtSumaHorasExtras.Text = montoHorasExtras.ToString("N2");
                }
                
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

                    #region Cargar Datos Empleado Vacacion

                    var uiEmpleadoVacacion = (BE.UI.EmpleadoVacacion)this.cboEmpleado.SelectedItem;

                    this.txtEmpleadoCodigo.Text = uiEmpleadoVacacion.EmpleadoCodigo;
                    this.txtFechaIngreso.Text = uiEmpleadoVacacion.EmpleadoFechaIngreso.ToString("dd/MM/yyyy");

                    DateTime? fechaVacacion = uiEmpleadoVacacion.EmpleadoFechaVacacion;
                    if (fechaVacacion != null)
                        this.txtFechaUltimaVacacion.Text = ((DateTime)fechaVacacion).ToString("dd/MM/yyyy");

                    DateTime fechaPeriodo = fechaVacacion != null ? (DateTime)fechaVacacion : uiEmpleadoVacacion.EmpleadoFechaIngreso;

                    this.dtpPeriodoInicio.Value = fechaPeriodo;
                    this.dtpPeriodoFinal.Value = fechaPeriodo.AddYears(1);

                    DateTime fechaVacacionSalida = fechaPeriodo.AddYears(1);
                    this.dtpVacacionSalida.Value = fechaVacacionSalida;

                    this.CargarListadoVacaciones(fechaVacacionSalida);

                    #endregion

                }
                else
                {
                    this.LimpiarCabecera();

                    DateTime fechaConsulta = DateTime.Now;
                    this.CargarListadoVacaciones(fechaConsulta);
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
                    this.cboEmpleado.SelectedValue = codigoEmpleado;
                    this.cboEmpleado_SelectionChangeCommitted(null, null);
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

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {

                #region Validaciones

                if (this.cboEmpleado.SelectedIndex == 0)
                {
                    this.cboEmpleado.Focus();
                    throw new Exception("Seleccione un empleado");
                }

                if (this.txtVacacionesDias.Text.Length == 0)
                {
                    this.txtVacacionesDias.Focus();
                    throw new Exception("Ingrese la cantidad de días de vacaciones");
                }
                else
                {
                    int dias = 0;
                    if (int.TryParse(this.txtVacacionesDias.Text, out dias) == false)
                    {
                        this.txtVacacionesDias.Focus();
                        throw new Exception("Ingrese el número de días de vacaciones");
                    }
                    else if (dias < 0 || dias > 30)
                    {
                        this.txtVacacionesDias.Focus();
                        throw new Exception("Ingrese solo entre 1 y 30 días de vacaciones");
                    }
                }

                if (this.dtpPeriodoInicio.Value.Date > this.dtpPeriodoFinal.Value.Date)
                {
                    this.dtpPeriodoInicio.Focus();
                    throw new Exception("La fecha del periodo inicial no debe ser mayor a la fecha del periodo final");
                }

                if (this.dtpVacacionSalida.Value.Date < this.dtpPeriodoFinal.Value.Date)
                {
                    this.dtpVacacionSalida.Focus();
                    throw new Exception("La fecha de la salida de vacaciones no debe ser mayor a la fecha del periodo final");
                }

                #endregion

                #region Calcular

                string codigoEmpleado = this.txtEmpleadoCodigo.Text.Trim();
                DateTime fechaConsulta = this.dtpVacacionSalida.Value;

                bool calculado = this.Calcular(codigoEmpleado, fechaConsulta);

                if (calculado)
                    this.MostrarCalculo();
                else
                    this.LimpiarCalculo();

                #endregion

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

                if (this.calculado == false)
                    throw new Exception("Primero realice el calculo de vacaciones");

                if (this.txtPensionTipo.Text.Length == 0)
                    throw new Exception("No se asigno el tipo de pensión");

                if (this.txtPensionDescipcion.Text.Length == 0)
                    throw new Exception("No se asigno la entidad de pensión");

                #endregion

                #region Guardar

                if (this.uiVacacion.Id == 0) //Nuevo
                {
                    bool rpta = false;
                    rpta = new LN.Vacacion().Insertar(ref this.uiVacacion);

                    if (rpta == true)
                    {
                        Util.InformationMessage("Se registro el calculo de Vacaciones");
                        this.frmList.CargarListadoVacaciones();
                        this.Close();
                    }
                }

                #endregion

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void dtpVacacionSalida_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                var fechaConsulta = this.dtpVacacionSalida.Value;
                this.CargarListadoVacaciones(fechaConsulta);
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void txtRedondeo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void txtRedondeo_Enter(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke((Action)delegate
                {
                    txtRedondeo.SelectAll();
                });
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void txtRedondeo_Leave(object sender, EventArgs e)
        {
            try
            {
                if (this.txtRedondeo.Text.Length > 0)
                    this.uiVacacion.Redondeo = double.Parse(this.txtRedondeo.Text);

                this.txtRedondeo.Text = this.uiVacacion.Redondeo.ToString("N2");

                this.MostrarCalculo();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.calculado == true)
                    this.LimpiarCalculo();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        #endregion

    }
}

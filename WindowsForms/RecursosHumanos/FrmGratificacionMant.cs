using System;
using System.Windows.Forms;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmGratificacionMant : Form
    {

        private FrmGratificacionList frmList = null;

        private BE.UI.Gratificacion uiGratificacion = null;

        public FrmGratificacionMant(FrmGratificacionList frmList)
        {
            try
            {
                InitializeComponent();
                this.frmList = frmList;
                this.uiGratificacion = new BE.UI.Gratificacion();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }

        }

        public void Cargar(BE.UI.Gratificacion uiGratificacion)
        {
            try
            {
             
                if (uiGratificacion != null)
                {
                    this.uiGratificacion = new LN.Gratificacion().Obtener(uiGratificacion.Id);

                    this.txtPeriodo.Text = this.uiGratificacion.Periodo;
                    this.txtDias.Text = this.uiGratificacion.Dias.ToString();
                    this.txtFechaInicial.Text = this.uiGratificacion.FechaInicial.ToString("dd/MM/yyyy");
                    this.txtFechaFinal.Text = this.uiGratificacion.FechaFinal.ToString("dd/MM/yyyy");
                    this.txtEmpleadoCodigo.Text = this.uiGratificacion.EmpleadoCodigo;
                    this.txtEmpleadoNombres.Text = this.uiGratificacion.EmpleadoNombres;

                    this.txtSueldoBase.Text = this.uiGratificacion.SueldoBase.ToString("N2");
                    this.txtSueldoAsigFam.Text = this.uiGratificacion.AsignacionFamiliar.ToString("N2");
                    this.txtBonoNocturno.Text = this.uiGratificacion.BonoNocturno.ToString("N2");
                    this.txtBonoExtra.Text = this.uiGratificacion.BonoHorasExtras.ToString("N2");
                    this.txtDescuentoRJ.Text = this.uiGratificacion.DescuentoRetencioJudicial.ToString("N2");
                    this.txtDescuentoImpuesto.Text = this.uiGratificacion.DescuentoImpuestos.ToString("N2");
                    this.txtDescuentoImpuesto.ReadOnly = false;

                    this.txtGratificacionBruta.Text = this.uiGratificacion.GratificacionBruta.ToString("N2");
                    this.txtGratificacionBonificacion.Text = this.uiGratificacion.GratificacionBono.ToString("N2");
                    this.txtGratificacionNeta.Text = this.uiGratificacion.GratificacionNeta.ToString("N2");
                    this.txtGratificacionPago.Text = this.uiGratificacion.GratificacionPago.ToString("N2");

                    if (this.uiGratificacion.Detalle == null)
                        this.uiGratificacion.Detalle = new List<BE.UI.GratificacionDetalle>();

                    double bonoNocturno = 0.0;
                    double bonoHorasExtra = 0.0;
                    int diasCalculo = 0;

                    foreach (BE.UI.GratificacionDetalle uiGratificacionDetalle in this.uiGratificacion.Detalle)
                    {
                        bonoNocturno += uiGratificacionDetalle.BonoNocturno;
                        bonoHorasExtra += uiGratificacionDetalle.BonoHorasExtras;
                        diasCalculo += uiGratificacionDetalle.DiasCalculo;
                    }

                    this.txtDetalleBonoNocturno.Text = bonoNocturno.ToString("N2");
                    this.txtDetalleBonoHorasExtras.Text = bonoHorasExtra.ToString("N2");
                    this.txtDetalleDiasCalculo.Text = diasCalculo.ToString();

                    var source = new BindingSource();
                    source.DataSource = this.uiGratificacion.Detalle;

                    this.dgvDetalleGratificaciones.DataSource = source;

                    this.FormatoDetalleGratificacion();
                }
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
                //Limpiar objeto
                this.uiGratificacion = new BE.UI.Gratificacion();

                this.CargarEmpleados();
                this.CargarPeriodos();

                foreach (Control crtl in this.grpGratificacion.Controls)
                {
                    if (crtl is TextBox)
                    {
                        ((TextBox)crtl).Clear();
                        ((TextBox)crtl).ReadOnly = true;
                    }
                }

                foreach (Control crtl in this.grpSueldo.Controls)
                {
                    if (crtl is TextBox)
                    {
                        ((TextBox)crtl).Text = "0.0";
                        ((TextBox)crtl).ReadOnly = true;
                    }
                }

                foreach (Control crtl in this.grpBonos.Controls)
                {
                    if (crtl is TextBox)
                    {
                        ((TextBox)crtl).Text = "0.0";
                        ((TextBox)crtl).ReadOnly = true;
                    }
                }

                foreach (Control crtl in this.grpDescuentos.Controls)
                {
                    if (crtl is TextBox)
                    {
                        ((TextBox)crtl).Text = "0.0";
                        ((TextBox)crtl).ReadOnly = true;
                    }
                }

                foreach (Control crtl in this.grpResumen.Controls)
                {
                    if (crtl is TextBox)
                    {
                        ((TextBox)crtl).Text = "0.0";
                        ((TextBox)crtl).ReadOnly = true;
                    }
                }

                var lstUiGratificacionDetalle = new List<BE.UI.GratificacionDetalle>();
                var source = new BindingSource();
                source.DataSource = lstUiGratificacionDetalle;
                this.dgvDetalleGratificaciones.DataSource = source;

                this.FormatoDetalleGratificacion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarEmpleados()
        {
            var lstEmpleados = new LN.Empleado().Combo();
            var lstCandidatos = new LN.Candidato().Combo();
            lstEmpleados.AddRange(lstCandidatos);
            var lstTrabajador = lstEmpleados.OrderBy(o => o.Codigo).Distinct().ToList();

            lstTrabajador.Insert(0, new BE.Record() { Codigo = "", Nombre = "Seleccione" });

            this.cboEmpleadoFiltro.DataSource = lstTrabajador;
            this.cboEmpleadoFiltro.DisplayMember = "Nombre";
            this.cboEmpleadoFiltro.ValueMember = "Codigo";
        }

        private void CargarPeriodos()
        {
            try
            {
                var lstPeriodos = new List<BE.Record>();

                int anhoIni = 2017;
                int anhoFin = DateTime.Now.Year + 1;
                for (int anho = anhoIni; anho <= anhoFin; anho++)
                {
                    for (int periodo = 1; periodo < 3; periodo++)
                    {
                        var beRecord = new BE.Record();
                        beRecord.Codigo = anho + "-0" + periodo;
                        beRecord.Nombre = anho + "-0" + periodo;
                        lstPeriodos.Add(beRecord);
                    }
                }

                lstPeriodos.Insert(0, new BE.Record() { Codigo = "", Nombre = "Seleccione" });

                this.cboPeriodoFiltro.DataSource = lstPeriodos;
                this.cboPeriodoFiltro.DisplayMember = "Nombre";
                this.cboPeriodoFiltro.ValueMember = "Codigo";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FormatoDetalleGratificacion()
        {
            try
            {
                Util.FormatDatagridview(ref this.dgvDetalleGratificaciones);
                this.dgvDetalleGratificaciones.ReadOnly = false;
                this.dgvDetalleGratificaciones.AllowUserToResizeColumns = false;

                for (int col = 0; col < this.dgvDetalleGratificaciones.Columns.Count; col++)
                    this.dgvDetalleGratificaciones.Columns[col].Visible = false;

                this.dgvDetalleGratificaciones.Columns["MesNombre"].Visible = true;
                this.dgvDetalleGratificaciones.Columns["MesNombre"].HeaderText = "Mes";
                this.dgvDetalleGratificaciones.Columns["MesNombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvDetalleGratificaciones.Columns["MesNombre"].Width = 150;
                this.dgvDetalleGratificaciones.Columns["MesNombre"].ReadOnly = true;
                this.dgvDetalleGratificaciones.Columns["MesNombre"].DefaultCellStyle.BackColor = Color.LightGray;

                this.dgvDetalleGratificaciones.Columns["BonoNocturno"].Visible = true;
                this.dgvDetalleGratificaciones.Columns["BonoNocturno"].HeaderText = "Bono Nocturno";
                this.dgvDetalleGratificaciones.Columns["BonoNocturno"].Width = 120;
                this.dgvDetalleGratificaciones.Columns["BonoNocturno"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvDetalleGratificaciones.Columns["BonoNocturno"].DefaultCellStyle.Format = "N2";

                this.dgvDetalleGratificaciones.Columns["BonoHorasExtras"].Visible = true;
                this.dgvDetalleGratificaciones.Columns["BonoHorasExtras"].HeaderText = "Bono Horas Extras";
                this.dgvDetalleGratificaciones.Columns["BonoHorasExtras"].Width = 120;
                this.dgvDetalleGratificaciones.Columns["BonoHorasExtras"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvDetalleGratificaciones.Columns["BonoHorasExtras"].DefaultCellStyle.Format = "N2";

                this.dgvDetalleGratificaciones.Columns["DiasCalculo"].Visible = true;
                this.dgvDetalleGratificaciones.Columns["DiasCalculo"].HeaderText = "Dias Calculo";
                this.dgvDetalleGratificaciones.Columns["DiasCalculo"].Width = 120;
                this.dgvDetalleGratificaciones.Columns["DiasCalculo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                Util.AutoWidthColumn(ref this.dgvDetalleGratificaciones, "MesNombre", false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Formulario

        private void FrmAfpComisionMant_Load(object sender, EventArgs e)
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                #region Validaciones
                if (this.uiGratificacion == null 
                    || this.uiGratificacion.EmpleadoCodigo.Length == 0 
                    || this.uiGratificacion.Periodo.Length == 0)
                {
                    throw new Exception("Realice una busqueda por empleado y periodo");
                }
                #endregion

                #region Guardar

                this.uiGratificacion.SueldoBase = double.Parse(this.txtSueldoBase.Text);
                this.uiGratificacion.AsignacionFamiliar = double.Parse(this.txtSueldoAsigFam.Text);
                this.uiGratificacion.BonoNocturno = double.Parse(this.txtBonoNocturno.Text);
                this.uiGratificacion.BonoHorasExtras = double.Parse(this.txtBonoExtra.Text);
                this.uiGratificacion.DescuentoRetencioJudicial = double.Parse(this.txtDescuentoRJ.Text);
                this.uiGratificacion.DescuentoImpuestos = double.Parse(this.txtDescuentoImpuesto.Text);
                this.uiGratificacion.GratificacionBruta = double.Parse(this.txtGratificacionBruta.Text);
                this.uiGratificacion.GratificacionBono = double.Parse(this.txtGratificacionBonificacion.Text);
                this.uiGratificacion.GratificacionNeta = double.Parse(this.txtGratificacionNeta.Text);
                this.uiGratificacion.GratificacionPago = double.Parse(this.txtGratificacionPago.Text);

                bool rpta = false;
                string msg = "";
                var lnGratificacion = new LN.Gratificacion();
                if (this.uiGratificacion.Id == 0) //Nuevo
                {
                    rpta = lnGratificacion.Insertar(ref this.uiGratificacion);
                    if (true)
                        msg = "Se registro la gratificacion";
                }
                else  //Actualizar
                {
                    rpta = lnGratificacion.Actualizar(this.uiGratificacion);
                    if (true)
                        msg = "Se actualizo la gratificacion";
                }

                if (rpta == true)
                {
                    Util.InformationMessage(msg);
                    this.frmList.CargarGratificaciones();
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

                var rpta = Util.ConfirmationMessage("¿Desea salir del formulario de mantenimiento de Gratificacion?");

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

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cboPeriodoFiltro_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (this.cboPeriodoFiltro.SelectedIndex == 0)
                {
                    this.txtFechaInicialFiltro.Clear();
                    this.txtFechaFinalFiltro.Clear();

                    return;
                }

                string strPeriodo = this.cboPeriodoFiltro.SelectedValue.ToString();
                string[] anhoPeriodo = strPeriodo.Split('-');

                int anho = int.Parse(anhoPeriodo[0].ToString());
                int periodo = int.Parse(anhoPeriodo[1].ToString());

                int mesIni = periodo == 1 ? 1 : 7;
                int mesFin = periodo == 1 ? 6 : 12;

                int diaIni = 1;
                int diaFin = periodo == 1 ? 30 : 31;

                #region Cargar Objeto Gratificacion
                if (this.uiGratificacion != null)
                {
                    this.uiGratificacion.Anho = anho;
                    this.uiGratificacion.Periodo = strPeriodo;
                    this.uiGratificacion.FechaInicial = new DateTime(anho, mesIni, diaIni);
                    this.uiGratificacion.FechaFinal = new DateTime(anho, mesFin, diaFin);
                    this.uiGratificacion.Dias = this.uiGratificacion.FechaFinal.Date.Subtract(this.uiGratificacion.FechaInicial.Date).Days;
                }
                #endregion

                this.txtFechaInicialFiltro.Text = this.uiGratificacion.FechaInicial.ToString("dd/MM/yyyy");
                this.txtFechaFinalFiltro.Text = this.uiGratificacion.FechaFinal.ToString("dd/MM/yyyy");

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

                #region Validar
                if (this.cboPeriodoFiltro.SelectedIndex == 0)
                {
                    this.cboPeriodoFiltro.Focus();
                    throw new Exception("Seleccione un periodo");
                }

                if (this.cboEmpleadoFiltro.SelectedIndex == 0)
                {
                    this.cboEmpleadoFiltro.Focus();
                    throw new Exception("Seleccione un empleado");
                }
                #endregion

                #region Cargar en memoria
                var beRecord = (BE.Record)this.cboEmpleadoFiltro.SelectedItem;
                this.uiGratificacion.EmpleadoCodigo = beRecord.Codigo;
                this.uiGratificacion.EmpleadoNombres = beRecord.Nombre;

                var beEmpleado = new LN.Empleado().Obtener(beRecord.Codigo);
                this.uiGratificacion.SueldoBase = beEmpleado.Recurso.Sueldo;
                this.uiGratificacion.DescuentoRetencioJudicial = 0.0;

                var beSueldoMinimo = new LN.SueldoMinimo().Actual(DateTime.Now);
                var beParametros = new BE.Parametros(beSueldoMinimo.Monto);
                this.uiGratificacion.AsignacionFamiliar = beParametros.AsignacionFamiliar;
                #endregion

                #region Resumen y Detalle

                this.txtPeriodo.Text = this.uiGratificacion.Periodo;
                this.txtDias.Text = this.uiGratificacion.Dias.ToString();
                this.txtFechaInicial.Text = this.uiGratificacion.FechaInicial.ToString("dd/MM/yyyy");
                this.txtFechaFinal.Text = this.uiGratificacion.FechaFinal.ToString("dd/MM/yyyy");
                this.txtEmpleadoCodigo.Text = this.uiGratificacion.EmpleadoCodigo;
                this.txtEmpleadoNombres.Text = this.uiGratificacion.EmpleadoNombres;
                this.txtSueldoBase.Text = this.uiGratificacion.SueldoBase.ToString("N2");
                this.txtSueldoAsigFam.Text = this.uiGratificacion.AsignacionFamiliar.ToString("N2");

                int anho = this.uiGratificacion.Anho;
                int mesIni = this.uiGratificacion.FechaInicial.Month;
                int mesFin = this.uiGratificacion.FechaFinal.Month;
                string codEmpleado = this.uiGratificacion.EmpleadoCodigo;
                double bonoNocturnoTotal = 0;
                double bonoHorasExtrasTotal = 0;
                int diasCalculo = 0;

                this.uiGratificacion.Detalle = new List<BE.UI.GratificacionDetalle>();
                for (int mes = mesIni; mes <= mesFin; mes++)
                {

                    double bonoNocturno = 0;
                    double bonoHorasExtras = 0;
                    int diasMes = DateTime.DaysInMonth(anho, mes);
                    int diasInasistencias = 0;

                    var uiPlantillaDetalle = new LN.Planilla(anho, mes).ObtenerPlantillaDetalle(codEmpleado);
                    if (uiPlantillaDetalle != null)
                    {
                        bonoNocturno = uiPlantillaDetalle.BonoNocturnoTotal;
                        bonoHorasExtras = uiPlantillaDetalle.BonoHorasExtrasTotal;

                        double inasistencias = uiPlantillaDetalle.DescuentoInasistenciaCantidad;
                        switch (uiPlantillaDetalle.CalcularPor)
                        {
                            case "M":
                                diasInasistencias = (int)inasistencias / 360;
                                break;
                            case "H":
                                diasInasistencias = (int)inasistencias / 60;
                                break;
                            default:
                                diasInasistencias = (int)inasistencias;
                                break;
                        }
                    }

                    bonoNocturnoTotal += bonoNocturno;
                    bonoHorasExtrasTotal += bonoHorasExtras;
                    diasCalculo += diasMes - diasInasistencias;

                    var uiGratificacionDetalle = new BE.UI.GratificacionDetalle();
                    uiGratificacionDetalle.Anho = anho;
                    uiGratificacionDetalle.MesId = mes;
                    uiGratificacionDetalle.MesNombre = Util.GetNameOfMonth(mes);
                    uiGratificacionDetalle.EmpleadoCodigo = codEmpleado;
                    uiGratificacionDetalle.BonoNocturno = bonoNocturno;
                    uiGratificacionDetalle.BonoHorasExtras = bonoHorasExtras;
                    uiGratificacionDetalle.DiasMes = DateTime.DaysInMonth(anho, mes);
                    uiGratificacionDetalle.DiasInasistencias = diasInasistencias;
                    uiGratificacionDetalle.DiasCalculo = uiGratificacionDetalle.DiasMes - uiGratificacionDetalle.DiasInasistencias;

                    this.uiGratificacion.Detalle.Add(uiGratificacionDetalle);
                }

                var source = new BindingSource();
                source.DataSource = this.uiGratificacion.Detalle;
                this.dgvDetalleGratificaciones.DataSource = source;

                this.FormatoDetalleGratificacion();

                this.txtDetalleBonoNocturno.Text = bonoNocturnoTotal.ToString("N2");
                this.txtDetalleBonoHorasExtras.Text = bonoHorasExtrasTotal.ToString("N2");
                this.txtDetalleDiasCalculo.Text = diasCalculo.ToString();

                this.uiGratificacion.BonoNocturno = bonoNocturnoTotal / 6;
                this.uiGratificacion.BonoHorasExtras = bonoHorasExtrasTotal / 6;
                this.uiGratificacion.DiasCalculo = diasCalculo;

                this.txtBonoNocturno.Text = this.uiGratificacion.BonoNocturno.ToString("N2");
                this.txtBonoExtra.Text = this.uiGratificacion.BonoHorasExtras.ToString("N2");

                this.txtDescuentoRJ.Text = this.uiGratificacion.DescuentoRetencioJudicial.ToString("N2");
                this.txtDescuentoImpuesto.Text = this.uiGratificacion.DescuentoImpuestos.ToString("N2");

                double gratificacionBruta = this.uiGratificacion.BonoNocturno
                                          + this.uiGratificacion.BonoHorasExtras
                                          + this.uiGratificacion.SueldoBase
                                          + this.uiGratificacion.AsignacionFamiliar;
                this.uiGratificacion.GratificacionBruta = (gratificacionBruta / this.uiGratificacion.Dias) * this.uiGratificacion.DiasCalculo;

                this.txtGratificacionBruta.Text = this.uiGratificacion.GratificacionBruta.ToString("N2");

                this.uiGratificacion.GratificacionBono = gratificacionBruta * beParametros.EsSaludFactor;
                this.txtGratificacionBonificacion.Text = this.uiGratificacion.GratificacionBono.ToString("N2");

                this.uiGratificacion.GratificacionNeta = this.uiGratificacion.GratificacionBruta + this.uiGratificacion.GratificacionBono;
                this.txtGratificacionNeta.Text = this.uiGratificacion.GratificacionNeta.ToString("N2");

                this.uiGratificacion.GratificacionPago = this.uiGratificacion.GratificacionNeta
                                                    - this.uiGratificacion.DescuentoRetencioJudicial
                                                    - this.uiGratificacion.DescuentoImpuestos;

                this.txtGratificacionPago.Text = this.uiGratificacion.GratificacionPago.ToString("N2");

                #endregion

                this.txtDescuentoImpuesto.ReadOnly = false;
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void txtDescuentoImpuesto_Leave(object sender, EventArgs e)
        {
            try
            {
                double impuesto = double.Parse(this.txtDescuentoImpuesto.Text);
                double neta = double.Parse(this.txtGratificacionNeta.Text);

                double gratificacionPagar = neta
                                          - this.uiGratificacion.DescuentoRetencioJudicial
                                          - impuesto;

                this.txtGratificacionPago.Text = gratificacionPagar.ToString("N2");

                this.txtDescuentoImpuesto.Text = impuesto.ToString("N2");
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void txtDescuentoImpuesto_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate
            {
                txtDescuentoImpuesto.SelectAll();
            });
        }

        private void txtNumeroDecimal_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtNumeroEntero_KeyPress(object sender, KeyPressEventArgs e)
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

        private void dgvDetalleGratificaciones_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                int colBonoNocturno = this.dgvDetalleGratificaciones.Columns["BonoNocturno"].Index;
                int colBonoHorasExtras = this.dgvDetalleGratificaciones.Columns["BonoHorasExtras"].Index;
                int colDiasCalculo = this.dgvDetalleGratificaciones.Columns["DiasCalculo"].Index;

                if (this.dgvDetalleGratificaciones.CurrentCell.ColumnIndex == colBonoNocturno 
                    || this.dgvDetalleGratificaciones.CurrentCell.ColumnIndex == colBonoHorasExtras)
                {
                    e.Control.KeyPress += new KeyPressEventHandler(txtNumeroDecimal_KeyPress);
                }
                else if (this.dgvDetalleGratificaciones.CurrentCell.ColumnIndex == colDiasCalculo)
                {
                    e.Control.KeyPress += new KeyPressEventHandler(txtNumeroEntero_KeyPress);
                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void dgvDetalleGratificaciones_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int colBonoNocturno = this.dgvDetalleGratificaciones.Columns["BonoNocturno"].Index;
                int colBonoHorasExtras = this.dgvDetalleGratificaciones.Columns["BonoHorasExtras"].Index;
                int colDiasCalculo = this.dgvDetalleGratificaciones.Columns["DiasCalculo"].Index;

                double bonoNocturno = 0.0;
                double bonoHorasExtra = 0.0;
                int diasCalculo = 0;

                foreach (DataGridViewRow row in this.dgvDetalleGratificaciones.Rows)
                {
                    bonoNocturno += (double)row.Cells[colBonoNocturno].Value;
                    bonoHorasExtra += (double)row.Cells[colBonoHorasExtras].Value;
                    diasCalculo += (int)row.Cells[colDiasCalculo].Value;
                }

                this.txtDetalleBonoNocturno.Text = bonoNocturno.ToString("N2");
                this.txtDetalleBonoHorasExtras.Text = bonoHorasExtra.ToString("N2");
                this.txtDetalleDiasCalculo.Text = diasCalculo.ToString();

                if (this.uiGratificacion != null)
                {
                    this.uiGratificacion.BonoNocturno = bonoNocturno / 6;
                    this.uiGratificacion.BonoHorasExtras = bonoHorasExtra / 6;
                    this.uiGratificacion.DiasCalculo = diasCalculo;

                    double gratificacionBruta = this.uiGratificacion.BonoNocturno
                                          + this.uiGratificacion.BonoHorasExtras
                                          + this.uiGratificacion.SueldoBase
                                          + this.uiGratificacion.AsignacionFamiliar;
                    this.uiGratificacion.GratificacionBruta = (gratificacionBruta / this.uiGratificacion.Dias) * this.uiGratificacion.DiasCalculo;

                    this.uiGratificacion.GratificacionBono = gratificacionBruta * new BE.Parametros().EsSaludFactor;
                    this.uiGratificacion.GratificacionNeta = this.uiGratificacion.GratificacionBruta + this.uiGratificacion.GratificacionBono;
                    this.uiGratificacion.GratificacionPago = this.uiGratificacion.GratificacionNeta
                                                           - this.uiGratificacion.DescuentoRetencioJudicial
                                                           - this.uiGratificacion.DescuentoImpuestos;

                    this.txtBonoNocturno.Text = this.uiGratificacion.BonoNocturno.ToString("N2");
                    this.txtBonoExtra.Text = this.uiGratificacion.BonoHorasExtras.ToString("N2");
                    this.txtDetalleDiasCalculo.Text = diasCalculo.ToString();
                    this.txtGratificacionBruta.Text = this.uiGratificacion.GratificacionBruta.ToString("N2");  
                    this.txtGratificacionBonificacion.Text = this.uiGratificacion.GratificacionBono.ToString("N2");
                    this.txtGratificacionNeta.Text = this.uiGratificacion.GratificacionNeta.ToString("N2");
                    this.txtGratificacionPago.Text = this.uiGratificacion.GratificacionPago.ToString("N2");

                }

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }
    }
}

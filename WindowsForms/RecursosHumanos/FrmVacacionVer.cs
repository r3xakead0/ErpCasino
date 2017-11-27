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
    public partial class FrmVacacionVer : Form
    {

        #region "Patron Singleton"

        private static FrmVacacionVer frmInstance = null;

        public static FrmVacacionVer Instance()
        {

            if (frmInstance == null || frmInstance.IsDisposed == true)
            {
                frmInstance = new FrmVacacionVer();
            }

            frmInstance.BringToFront();

            return frmInstance;
        }

        #endregion

        public FrmVacacionList frmList = null;

        private BE.UI.Vacacion uiVacacion = null;

        public FrmVacacionVer()
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

        public void Cargar(BE.UI.Vacacion uiVacacion)
        {
            try
            {
                if (uiVacacion != null)
                {

                    this.uiVacacion = new LN.Vacacion().Obtener(uiVacacion.Id);

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
                    this.txtRedondeo.Text = this.uiVacacion.Redondeo.ToString("N2");
                    this.txtTotalBruto.Text = this.uiVacacion.TotalBruto.ToString("N2");

                    this.txtRetencionJudicial.Text = this.uiVacacion.RetencionJudicialMonto.ToString("N2");

                    this.txtPensionTipo.Text = this.uiVacacion.PensionTipo.ToString();
                    this.txtPensionDescipcion.Text = this.uiVacacion.PensionNombre;
                    this.txtPensionMonto.Text = this.uiVacacion.PensionMonto.ToString("N2");
                    this.txtPensionPorcentaje.Text = $"{this.uiVacacion.PensionPorcentaje.ToString("N2")} %";

                    this.txtTotalDescuento.Text = this.uiVacacion.TotalDescuento.ToString("N2");

                    this.txtTotalNeto.Text = this.uiVacacion.TotalNeto.ToString("N2");

                    this.CargarListadoVacaciones();
                }

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
                this.txtRedondeo.Text = "0.00";
                this.txtTotalBruto.Text = "0.00";

                this.txtRetencionJudicial.Text = "0.00";
                this.txtPensionTipo.Text = "0.00";
                this.txtPensionDescipcion.Text = "0.00";
                this.txtPensionMonto.Text = "0.00";
                this.txtPensionPorcentaje.Text = "0.00 %";
                this.txtTotalDescuento.Text = "0.00";

                this.txtTotalNeto.Text = "0.00";
                
            }
            catch (Exception ex)
            {
                throw ex;
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
                
                for (int col = 0; col < this.dgvDetalles.Columns.Count; col++)
                    this.dgvDetalles.Columns[col].Visible = false;
                
                this.dgvDetalles.Columns["Anho"].Visible = true;
                this.dgvDetalles.Columns["Anho"].HeaderText = "Año";
                this.dgvDetalles.Columns["Anho"].Width = 35;
                this.dgvDetalles.Columns["Anho"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvDetalles.Columns["Anho"].DefaultCellStyle.BackColor = Color.LightGray;
                
                this.dgvDetalles.Columns["MesNombre"].Visible = true;
                this.dgvDetalles.Columns["MesNombre"].HeaderText = "Mes";
                this.dgvDetalles.Columns["MesNombre"].Width = 100;
                this.dgvDetalles.Columns["MesNombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvDetalles.Columns["MesNombre"].DefaultCellStyle.BackColor = Color.LightGray;
                
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

        #endregion

        #region Formulario

        private void FrmVacacionVer_ResizeEnd(object sender, EventArgs e)
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


        private void FrmVacacionVer_Load(object sender, EventArgs e)
        {
            try
            {

                this.uiVacacion = new BE.UI.Vacacion();

                this.LimpiarCalculo();
                this.CargarListadoVacaciones();
                this.FormatoListadoVacaciones();

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

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.uiVacacion == null)
                    return;

                if (Util.ConfirmationMessage("¿Desea imprimir el Calculo de Vacaciones?") == false)
                    return;

                //Obtener o Calcular Recibo 

                BE.UI.VacacionRecibo uiVacacionRecibo = new LN.Vacacion().ObtenerRecibo(this.uiVacacion.Id);
                if (uiVacacionRecibo == null)
                {
                    uiVacacionRecibo = new BE.UI.VacacionRecibo();

                    uiVacacionRecibo.Id = 0;
                    uiVacacionRecibo.IdVacacion = this.uiVacacion.Id;

                    uiVacacionRecibo.Anho = this.uiVacacion.VacacionFechaInicial.Year;
                    uiVacacionRecibo.Mes = this.uiVacacion.VacacionFechaInicial.Month;
                    uiVacacionRecibo.MesNombre = Util.GetNameOfMonth(this.uiVacacion.VacacionFechaInicial.Month);

                    var beEmpresa = new LN.Empresa().Obtener();
                    uiVacacionRecibo.EmpresaNombre = beEmpresa.NombreComercial;
                    uiVacacionRecibo.EmpresaDistrito = beEmpresa.Ubigeo.Nombre;
                    beEmpresa = null;

                    var beEmpleado = new LN.Empleado().Obtener(this.uiVacacion.EmpleadoCodigo);
                    uiVacacionRecibo.EmpleadoCodigo = beEmpleado.Codigo;
                    uiVacacionRecibo.EmpleadoNombres = beEmpleado.Nombres;
                    uiVacacionRecibo.EmpleadoApellidos = $"{beEmpleado.ApellidoPaterno} {beEmpleado.ApellidoMaterno}";
                    uiVacacionRecibo.EmpleadoNroDocumento = beEmpleado.NumeroDocumento;
                    beEmpleado = null;

                    uiVacacionRecibo.Detalle = "Vacaciones correspondiente al ejercicio " + DateTime.Now.Year.ToString();
                    uiVacacionRecibo.PeriodoInicio = this.uiVacacion.PeriodoFechaInicial;
                    uiVacacionRecibo.PeriodoFinal = this.uiVacacion.PeriodoFechaFinal;
                    uiVacacionRecibo.VacacionInicio = this.uiVacacion.VacacionFechaInicial;
                    uiVacacionRecibo.VacacionFinal = this.uiVacacion.VacacionFechaInicial;
                    uiVacacionRecibo.Sueldo = this.uiVacacion.EmpleadoSueldo;
                    uiVacacionRecibo.AsignacionFamiliar = this.uiVacacion.EmpleadoAsignacionFamiliar;
                    uiVacacionRecibo.PromedioHorasExtras = this.uiVacacion.PromedioHorasExtras;
                    uiVacacionRecibo.PromedioBonificacion = this.uiVacacion.PromedioBonificacion;
                    uiVacacionRecibo.Redondeo = this.uiVacacion.Redondeo;
                    uiVacacionRecibo.TotalBruto = this.uiVacacion.TotalBruto;

                    uiVacacionRecibo.RetencionJudicialMonto = this.uiVacacion.RetencionJudicialMonto;

                    string pensionEntidad = "";
                    if (this.uiVacacion.PensionTipo == BE.UI.TipoPensionEnum.AFP)
                        pensionEntidad = $"AFP - {this.uiVacacion.PensionNombre}";
                    else if (this.uiVacacion.PensionTipo == BE.UI.TipoPensionEnum.ONP)
                        pensionEntidad = "ONP";
                    uiVacacionRecibo.PensionEntidad = pensionEntidad;
                    uiVacacionRecibo.PensionMonto = this.uiVacacion.PensionMonto;

                    uiVacacionRecibo.TotalDescuento = this.uiVacacion.TotalDescuento;

                    uiVacacionRecibo.TotalNeto = this.uiVacacion.TotalNeto;
                    uiVacacionRecibo.TotalNetoLiteral = new NumeroLetras().Convertir(this.uiVacacion.TotalNeto);

                    bool rpta = new LN.Vacacion().RegistrarRecibo(uiVacacionRecibo);
                    if (rpta == false)
                        return;

                }

                //Mostrar
                var frmPlanillaVista = FrmImpresion.Instance();
                frmPlanillaVista.MdiParent = this.MdiParent;
                frmPlanillaVista.Show();
                frmPlanillaVista.ImpresionVacacion(this.uiVacacion.Id);

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        #endregion

    }
}

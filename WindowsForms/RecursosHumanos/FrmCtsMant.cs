using System;
using System.Windows.Forms;
using System.Data;
using System.Linq;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;
using System.Collections.Generic;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmCtsMant : Form
    {

        #region "Patron Singleton"

        private static FrmCtsMant frmInstance = null;

        public static FrmCtsMant Instance()
        {

            if (frmInstance == null || frmInstance.IsDisposed == true)
            {
                frmInstance = new FrmCtsMant();
            }

            frmInstance.BringToFront();

            return frmInstance;
        }

        #endregion

        public FrmCtsList frmList = null;

        private BE.UI.CTS uiCts = new BE.UI.CTS();

        public FrmCtsMant()
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

        public void Cargar(BE.UI.CTS beCts)
        {
            try
            {

                if (beCts != null)
                {

                    this.uiCts = beCts;

                    //FALTA

                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }

        }

        private void CargarEmpleados()
        {
            var lstEmpleados = new LN.Empleado().Combo();
            var lstCandidatos = new LN.Candidato().Combo();
            lstEmpleados.AddRange(lstCandidatos);
            var lstTrabajador = lstEmpleados.OrderBy(o => o.Codigo).Distinct().ToList();

            lstTrabajador.Insert(0, new BE.Record() { Codigo = "", Nombre = "Seleccione" });

            this.cboEmpleado.DataSource = lstTrabajador;
            this.cboEmpleado.DisplayMember = "Nombre";
            this.cboEmpleado.ValueMember = "Codigo";
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

        private void CargarPeriodos()
        {
            try
            {
                var lstAnhos = new List<BE.Record>();

                lstAnhos.Add(new BE.Record() { Codigo = "1", Nombre = "Mayo - Octubre" });
                lstAnhos.Add(new BE.Record() { Codigo = "2", Nombre = "Noviembre - Abril" });

                this.cboPeriodo.DataSource = lstAnhos;
                this.cboPeriodo.DisplayMember = "Nombre";
                this.cboPeriodo.ValueMember = "Codigo";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Formulario

        private void FrmCtsMant_Load(object sender, EventArgs e)
        {
            try
            {
                this.uiCts = new BE.UI.CTS();

                this.dtpDepositoFecha.Value = DateTime.Now;

                this.CargarEmpleados();
                this.CargarAnhos();
                this.CargarPeriodos();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {

                #region Validaciones
                if (this.cboEmpleado.SelectedIndex == 0)
                {
                    this.cboEmpleado.Focus();
                    throw new Exception("Seleccione un empleado");
                }

                if (this.txtEmpleadoCodigo.Text.Trim().Length == 0)
                {
                    this.cboEmpleado.Focus();
                    throw new Exception("Seleccione un empleado");
                }

                if (this.txtDepositoMonto.Text.Trim().Length == 0)
                {
                    this.txtDepositoMonto.Focus();
                    throw new Exception("Ingrese el monto del cts");
                }

                if (double.Parse(this.txtDepositoMonto.Text) == 0.0)
                {
                    this.txtDepositoMonto.Focus();
                    throw new Exception("Ingrese el monto del cts");
                }
                #endregion

                #region Guardar
 
                //falta

                bool rpta = false;
                string msg = "";
                var lnCts = new LN.CTS();
                if (this.uiCts.Id == 0) //Nuevo
                {
                    rpta = lnCts.Insertar(ref this.uiCts);
                    if (true)
                        msg = "Se registro la CTS";
                }
                else  //Actualizar
                {
                    rpta = lnCts.Actualizar(this.uiCts);
                    if (true)
                        msg = "Se actualizo la CTS";
                }

                if (rpta == true)
                {
                    Util.InformationMessage(msg);
                    this.frmList.CargarListadoCts();
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

        private void txtMonto_Leave(object sender, EventArgs e)
        {
            try
            {
                double monto = 0.0;

                if (this.txtDepositoMonto.Text.Length > 0)
                    monto = double.Parse(this.txtDepositoMonto.Text);

                this.txtDepositoMonto.Text = monto.ToString("N2");
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void txtMonto_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate
            {
                txtDepositoMonto.SelectAll();
            });
        }

        private void cboEmpleado_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (this.cboEmpleado.SelectedIndex == 0)
                {
                    this.txtEmpleadoCodigo.Clear();
                    this.txtEmpleadoFechaIngreso.Clear();
                    this.txtEmpleadoSueldo.Text = "0.00";
                    this.txtEmpleadoAsignacionFamilar.Text = "0.00";

                    this.txtBancoNombre.Clear();
                    this.txtBancoCuenta.Clear();
                }
                else
                {
                    var beRecord = (BE.Record)this.cboEmpleado.SelectedItem;

                    var beEmpleado = new LN.Empleado().Obtener(beRecord.Codigo, true);

                    if (beEmpleado != null && beEmpleado.Recurso != null)
                    {
                        this.txtEmpleadoCodigo.Text = beEmpleado.Codigo;

                        this.txtEmpleadoFechaIngreso.Text = beEmpleado.Recurso.FechaInicio.ToString("dd/MM/yyyy");
                        this.txtEmpleadoSueldo.Text = beEmpleado.Recurso.Sueldo.ToString("N2");

                        double asigFam = 0.0;
                        if (beEmpleado.Recurso.NumeroHijos > 0)
                        {
                            var beSueldo = new LN.SueldoMinimo().Actual(DateTime.Now);
                            if (beSueldo != null)
                                asigFam = beSueldo.Monto / 10;
                        }
                        this.txtEmpleadoAsignacionFamilar.Text = asigFam.ToString("N2");

                        this.txtBancoNombre.Text = beEmpleado.Recurso.BancoCTS.Nombre;
                        this.txtBancoCuenta.Text = beEmpleado.Recurso.CuentaCTS;
                    }

                }
                
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void cboAnhoPeriodo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (this.cboPeriodo.SelectedIndex == 0)
                {
                    this.txtRangoFechas.Clear();
                }
                else
                {
                    int periodo = int.Parse(this.cboPeriodo.SelectedValue.ToString());
                    int anho = int.Parse(this.cboAnho.SelectedValue.ToString());

                    switch (periodo)
                    {
                        case 1:
                            this.txtRangoFechas.Text = "01/05/" + anho.ToString() + " AL 30/09/" + anho.ToString();
                            break;
                        case 2:
                            this.txtRangoFechas.Text = "01/10/" + anho.ToString() + " AL 30/04/" + (anho + 1).ToString();
                            break;
                        default:
                            this.txtRangoFechas.Clear();
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        #endregion


    }
}

using System;
using System.Windows.Forms;
using System.Data;
using System.Linq;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmCtsMant : Form
    {

        private FrmCtsList frmList = null;

        private BE.UI.CTS beCts = new BE.UI.CTS();

        public FrmCtsMant(FrmCtsList frmList)
        {
            try
            {
                InitializeComponent();
                this.frmList = frmList;
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

                    this.beCts = beCts;

                    this.dtpFecha.Value = this.beCts.FechaDeposito;
                    this.txtEmpleado.Text = this.beCts.EmpleadoCodigo;
                    this.cboEmpleado.SelectedValue = this.beCts.EmpleadoCodigo;
                    this.txtMonto.Text = this.beCts.Monto.ToString("N2");
                    this.dtpPeriodoInicial.Value = this.beCts.FechaPeriodoInicial;
                    this.dtpPeriodoFinal.Value = this.beCts.FechaPeriodoFinal;

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
                this.beCts = new BE.UI.CTS();

                //Limpiar controles de edicion
                this.dtpFecha.Value = DateTime.Now;
                this.dtpPeriodoInicial.Value = DateTime.Now;
                this.dtpPeriodoFinal.Value = DateTime.Now;

                this.txtEmpleado.Clear();
                this.txtMonto.Text = "0.00";

                this.CargarEmpleados();

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

            this.cboEmpleado.DataSource = lstTrabajador;
            this.cboEmpleado.DisplayMember = "Nombre";
            this.cboEmpleado.ValueMember = "Codigo";
        }

        #region Formulario

        private void FrmCtsMant_Load(object sender, EventArgs e)
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

                if (this.txtEmpleado.Text.Trim().Length == 0)
                {
                    this.cboEmpleado.Focus();
                    throw new Exception("Seleccione un empleado");
                }

                if (this.txtMonto.Text.Trim().Length == 0)
                {
                    this.txtMonto.Focus();
                    throw new Exception("Ingrese el monto del cts");
                }

                if (double.Parse(this.txtMonto.Text) == 0.0)
                {
                    this.txtMonto.Focus();
                    throw new Exception("Ingrese el monto del cts");
                }
                #endregion

                #region Guardar
 
                this.beCts.FechaDeposito = this.dtpFecha.Value;
                var beRecord = (BE.Record)this.cboEmpleado.SelectedItem;
                this.beCts.EmpleadoCodigo = beRecord.Codigo;
                this.beCts.EmpleadoNombre = beRecord.Nombre;
                this.beCts.Monto = double.Parse(this.txtMonto.Text);
                this.beCts.FechaPeriodoInicial = this.dtpPeriodoInicial.Value;
                this.beCts.FechaPeriodoFinal = this.dtpPeriodoFinal.Value;

                bool rpta = false;
                string msg = "";
                var lnCts = new LN.CTS();
                if (this.beCts.IdCts == 0) //Nuevo
                {
                    rpta = lnCts.Insertar(ref this.beCts);
                    if (true)
                        msg = "Se registro la CTS";
                }
                else  //Actualizar
                {
                    rpta = lnCts.Actualizar(this.beCts);
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

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            try
            {

                var rpta = Util.ConfirmationMessage("¿Desea salir del formulario de mantenimiento de Cts?");

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

                if (this.txtMonto.Text.Length > 0)
                    monto = double.Parse(this.txtMonto.Text);

                this.txtMonto.Text = monto.ToString("N2");
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
                txtMonto.SelectAll();
            });
        }

        private void cboEmpleado_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                var beRecord = (BE.Record)this.cboEmpleado.SelectedItem;
                this.txtEmpleado.Text = beRecord.Codigo;
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        #endregion
    }
}

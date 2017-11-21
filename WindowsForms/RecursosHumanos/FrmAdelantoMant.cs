using System;
using System.Windows.Forms;
using System.Data;
using System.Linq;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;
using System.Collections.Generic;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmAdelantoMant : Form
    {

        #region "Patron Singleton"

        private static FrmAdelantoMant frmInstance = null;

        public static FrmAdelantoMant Instance()
        {

            if (frmInstance == null || frmInstance.IsDisposed == true)
            {
                frmInstance = new FrmAdelantoMant();
            }

            frmInstance.BringToFront();

            return frmInstance;
        }

        #endregion

        public FrmAdelantoList frmList = null;

        private BE.UI.Adelanto beAdelanto = new BE.UI.Adelanto();

        public FrmAdelantoMant()
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

        public void Cargar(BE.UI.Adelanto beAdelanto = null)
        {
            try
            {

                if (beAdelanto != null)
                {

                    this.beAdelanto = beAdelanto;

                    this.dtpFecha.Value = this.beAdelanto.Fecha;

                    this.txtEmpleadoCodigo.Text = this.beAdelanto.CodigoEmpleado;
                    this.cboEmpleado.SelectedValue = this.beAdelanto.CodigoEmpleado;

                    this.cboTipos.SelectedValue = this.beAdelanto.CodigoTipo;
                    this.cboBancos.SelectedValue = this.beAdelanto.IdBanco;

                    this.txtNumero.Text = this.beAdelanto.Numero;
                    this.txtMonto.Text = this.beAdelanto.Monto.ToString("N2");

                    string codTipoBanco = "BAN";
                    string codTipoSeleccionado = this.beAdelanto.CodigoTipo;
                    this.cboBancos.Enabled = codTipoSeleccionado.Equals(codTipoBanco);

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
                this.beAdelanto = new BE.UI.Adelanto();

                //Limpiar controles de edicion
                this.dtpFecha.Value = DateTime.Now;

                this.txtNumero.Clear();
                this.txtMonto.Text = "0.00";

                this.CargarEmpleados();
                this.CargarBancos();
                this.CargarTipos();


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

        private void CargarBancos()
        {
            var lstBancos = new LN.Banco().Listar();

            lstBancos.Insert(0, new BE.Banco() { IdBanco = 0, Nombre = "Seleccione" });

            this.cboBancos.DataSource = lstBancos;
            this.cboBancos.DisplayMember = "Nombre";
            this.cboBancos.ValueMember = "IdBanco";
        }

        private void CargarTipos()
        {
            var lstTipos = new LN.Record().ListarTiposAdelantos();

            lstTipos.Insert(0, new BE.Record() { Codigo = "0", Nombre = "Seleccione" });

            this.cboTipos.DataSource = lstTipos;
            this.cboTipos.DisplayMember = "Nombre";
            this.cboTipos.ValueMember = "Codigo";
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

                if (this.cboTipos.SelectedIndex == 0)
                {
                    this.cboTipos.Focus();
                    throw new Exception("Seleccione un tipo");
                }
                else if (this.cboTipos.SelectedValue.ToString() == "BAN")
                {
                    if (this.cboBancos.SelectedIndex == 0)
                    {
                        this.cboBancos.Focus();
                        throw new Exception("Seleccione un banco");
                    }
                }

                if (this.txtNumero.Text.Trim().Length == 0)
                {
                    this.txtNumero.Focus();
                    throw new Exception("Ingrese la descripcion del bono");
                }

                if (this.txtMonto.Text.Trim().Length == 0)
                {
                    this.txtMonto.Focus();
                    throw new Exception("Ingrese el monto del bono");
                }

                if (double.Parse(this.txtMonto.Text) == 0.0)
                {
                    this.txtMonto.Focus();
                    throw new Exception("Ingrese el monto del bono");
                }
                #endregion

                #region Guardar
 
                this.beAdelanto.Fecha = this.dtpFecha.Value;
                this.beAdelanto.CodigoEmpleado = this.cboEmpleado.SelectedValue.ToString();
                this.beAdelanto.CodigoTipo = this.cboTipos.SelectedValue.ToString();
                this.beAdelanto.Numero = this.txtNumero.Text;
                this.beAdelanto.Monto = double.Parse(this.txtMonto.Text);
                this.beAdelanto.IdBanco = int.Parse(this.cboBancos.SelectedValue.ToString());

                bool rpta = false;
                string msg = "";
                var lnAdelanto = new LN.Adelanto();
                if (this.beAdelanto.IdAdelanto == 0) //Nuevo
                {
                    rpta = lnAdelanto.Insertar(ref this.beAdelanto);
                    if (true)
                        msg = "Se registro el nuevo adelanto";
                }
                else  //Actualizar
                {
                    rpta = lnAdelanto.Actualizar(this.beAdelanto);
                    if (true)
                        msg = "Se actualizo el adelanto";
                }

                if (rpta == true)
                {
                    Util.InformationMessage(msg);
                    this.frmList.CargarListadoAdelantos();
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

        private void txtMonto_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate
            {
                txtMonto.SelectAll();
            });
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

        private void cboTipos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                string codTipoBanco = "BAN";
                var codTipo = this.cboTipos.SelectedValue.ToString();
                this.cboBancos.Enabled = codTipo.Equals(codTipoBanco);
                this.cboBancos.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        #endregion

        private void cboEmpleado_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (this.cboEmpleado.SelectedIndex > 0)
                {
                    string codigoEmpleado = this.cboEmpleado.SelectedValue.ToString().Trim();
                    this.txtEmpleadoCodigo.Text = codigoEmpleado;
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

                var lst = (List<BE.Record>)this.cboEmpleado.DataSource;

                var beEmpleado = lst.FirstOrDefault(x => x.Codigo.Contains(codigoEmpleado));

                if (beEmpleado != null)
                {
                    this.txtEmpleadoCodigo.Text = beEmpleado.Codigo;
                    this.cboEmpleado.SelectedValue = beEmpleado.Codigo;
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

    }
}

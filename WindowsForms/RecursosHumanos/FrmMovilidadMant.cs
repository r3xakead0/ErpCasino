using System;
using System.Windows.Forms;
using System.Data;
using System.Linq;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;
using System.Collections.Generic;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmPlanillaMovilidadMant : Form
    {

        #region "Patron Singleton"

        private static FrmPlanillaMovilidadMant frmInstance = null;

        public static FrmPlanillaMovilidadMant Instance()
        {

            if (frmInstance == null || frmInstance.IsDisposed == true)
            {
                frmInstance = new FrmPlanillaMovilidadMant();
            }

            frmInstance.BringToFront();

            return frmInstance;
        }

        #endregion

        public FrmPlanillaMovilidadList frmList = null;

        private BE.UI.Movilidad uiMovilidadTranslado = null;

        public FrmPlanillaMovilidadMant()
        {
            try
            {
                InitializeComponent();

                this.uiMovilidadTranslado = new BE.UI.Movilidad();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }

        }

        public void Cargar(BE.UI.Movilidad uiMovilidad = null)
        {
            try
            {

                if (uiMovilidad != null)
                {

                    this.uiMovilidadTranslado = uiMovilidad;

                    this.cboAnho.SelectedValue = this.uiMovilidadTranslado.Anho.ToString();
                    this.cboMes.SelectedValue = this.uiMovilidadTranslado.MesNumero.ToString();
                    this.txtEmpleadoCodigo.Text = this.uiMovilidadTranslado.EmpleadoCodigo;
                    this.cboEmpleado.SelectedValue = this.uiMovilidadTranslado.EmpleadoCodigo;
                    this.txtMonto.Text = this.uiMovilidadTranslado.Monto.ToString("N2");

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

        private void CargarMes()
        {
            try
            {

                var lstMes = new List<BE.Record>();

                lstMes.Add(new BE.Record() { Codigo = "1", Nombre = "Enero" });
                lstMes.Add(new BE.Record() { Codigo = "2", Nombre = "Febrero" });
                lstMes.Add(new BE.Record() { Codigo = "3", Nombre = "Marzo" });
                lstMes.Add(new BE.Record() { Codigo = "4", Nombre = "Abril" });
                lstMes.Add(new BE.Record() { Codigo = "5", Nombre = "Mayo" });
                lstMes.Add(new BE.Record() { Codigo = "6", Nombre = "Junio" });
                lstMes.Add(new BE.Record() { Codigo = "7", Nombre = "Julio" });
                lstMes.Add(new BE.Record() { Codigo = "8", Nombre = "Agosto" });
                lstMes.Add(new BE.Record() { Codigo = "9", Nombre = "Setiembre" });
                lstMes.Add(new BE.Record() { Codigo = "10", Nombre = "Octubre" });
                lstMes.Add(new BE.Record() { Codigo = "11", Nombre = "Noviembre" });
                lstMes.Add(new BE.Record() { Codigo = "12", Nombre = "Diciembre" });

                this.cboMes.DataSource = lstMes;
                this.cboMes.DisplayMember = "Nombre";
                this.cboMes.ValueMember = "Codigo";

                this.cboMes.SelectedValue = DateTime.Now.Month.ToString();
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
                this.CargarAnhos();
                this.cboAnho.SelectedValue = DateTime.Now.Year.ToString();

                this.CargarMes();
                this.cboMes.SelectedValue = DateTime.Now.Month.ToString();

                this.CargarEmpleados();
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
 
                this.uiMovilidadTranslado.Anho = int.Parse(this.cboAnho.SelectedValue.ToString());

                var beMes = (BE.Record)this.cboMes.SelectedItem;
                this.uiMovilidadTranslado.MesNumero = int.Parse(beMes.Codigo);
                this.uiMovilidadTranslado.MesNombre = beMes.Nombre;

                this.uiMovilidadTranslado.EmpleadoCodigo = this.cboEmpleado.SelectedValue.ToString();
                this.uiMovilidadTranslado.Monto = double.Parse(this.txtMonto.Text);
                
                bool rpta = false;
                string msg = "";
                var lnMovilidad = new LN.Movilidad();
                if (this.uiMovilidadTranslado.Id == 0) //Nuevo
                {
                    rpta = lnMovilidad.Insertar(ref this.uiMovilidadTranslado);
                    if (true)
                        msg = "Se registro la nuevo movilidad";
                }
                else  //Actualizar
                {
                    rpta = lnMovilidad.Actualizar(this.uiMovilidadTranslado);
                    if (true)
                        msg = "Se actualizo la Movilidad";
                }

                if (rpta == true)
                {
                    Util.InformationMessage(msg);
                    this.frmList.CargarListadoMovilidades();
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

        #endregion



    }
}

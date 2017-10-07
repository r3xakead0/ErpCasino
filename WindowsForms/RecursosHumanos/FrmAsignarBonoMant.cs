using System;
using System.Windows.Forms;
using System.Data;
using System.Linq;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;
using System.Collections.Generic;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmAsignarBonoMant : Form
    {

        private FrmAsignarBonoList frmList = null;

        private BE.UI.BonoEmpleado uiBonoEmpleado = null;

        public FrmAsignarBonoMant(FrmAsignarBonoList frmList)
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

        public void Cargar(BE.UI.BonoEmpleado uiBonoEmpleado = null)
        {
            try
            {

                if (uiBonoEmpleado != null)
                {

                    this.uiBonoEmpleado = uiBonoEmpleado;

                    this.dtpFecha.Value = this.uiBonoEmpleado.Fecha;
                    this.txtEmpleadoCodigo.Text = this.uiBonoEmpleado.EmpleadoCodigo;
                    this.cboEmpleado.SelectedValue = this.uiBonoEmpleado.EmpleadoCodigo;
                    this.cboBono.SelectedValue = this.uiBonoEmpleado.BonoID;
                    this.txtMonto.Text = this.uiBonoEmpleado.Monto.ToString("N2");

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void Limpiar()
        {
            try
            {
                //Limpiar objeto
                this.uiBonoEmpleado = new BE.UI.BonoEmpleado();

                //Limpiar controles de edicion
                this.dtpFecha.Value = DateTime.Now;
                this.txtEmpleadoCodigo.Clear();
                this.CargarEmpleados();
                this.CargarTiposBonos();
                this.txtMotivo.Clear();
                this.txtMonto.Text = "0.00";
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

        private void CargarTiposBonos()
        {
            try
            {
                var lstTipos = new LN.Bono().Listar();
                lstTipos = lstTipos.Where(x => x.Calculado == false).ToList();

                lstTipos.Insert(0, new BE.UI.Bono() { Id = 0, Nombre = "Seleccione" });

                this.cboBono.DataSource = lstTipos;
                this.cboBono.DisplayMember = "Nombre";
                this.cboBono.ValueMember = "Id";
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

                if (this.cboEmpleado.SelectedIndex == 0)
                {
                    this.cboEmpleado.Focus();
                    throw new Exception("Seleccione un empleado");
                }
                
                if (this.cboBono.SelectedIndex == 0)
                {
                    this.cboBono.Focus();
                    throw new Exception("Seleccione un tipo de Bono");
                }

                if (this.txtMotivo.Text.Trim().Length == 0)
                {
                    this.txtMotivo.Focus();
                    throw new Exception("Ingrese el motivo del Bono");
                }

                if (this.txtMonto.Text.Trim().Length == 0)
                {
                    this.txtMonto.Focus();
                    throw new Exception("Ingrese el monto del Bono");
                }

                double monto = 0; 
                if (double.TryParse(this.txtMonto.Text, out monto) == false)
                {
                    this.txtMonto.Focus();
                    throw new Exception("Ingrese el monto del Bono");
                }

                #endregion

                #region Guardar

                this.uiBonoEmpleado.Fecha = this.dtpFecha.Value;
                this.uiBonoEmpleado.EmpleadoCodigo = ((BE.Record)this.cboEmpleado.SelectedItem).Codigo;
                this.uiBonoEmpleado.EmpleadoNombreCompleto = ((BE.Record)this.cboEmpleado.SelectedItem).Nombre;
                this.uiBonoEmpleado.BonoID = ((BE.UI.Bono)this.cboBono.SelectedItem).Id;
                this.uiBonoEmpleado.BonoTipo = ((BE.UI.Bono)this.cboBono.SelectedItem).Calculado ? "Calculado" : "Manual"; //Manual o Calculado
                this.uiBonoEmpleado.BonoNombre = ((BE.UI.Bono)this.cboBono.SelectedItem).Nombre;
                this.uiBonoEmpleado.Monto = double.Parse(this.txtMonto.Text);
                this.uiBonoEmpleado.Motivo = this.txtMotivo.Text;

                bool rpta = false;
                string msg = "";
                var lnBonoEmpleado = new LN.BonoEmpleado();
                if (this.uiBonoEmpleado.ID == 0) //Nuevo
                {
                    rpta = lnBonoEmpleado.Insertar(ref this.uiBonoEmpleado);
                    if (true)
                        msg = "Se registro el nuevo bono";
                }
                else  //Actualizar
                {
                    rpta = lnBonoEmpleado.Actualizar(this.uiBonoEmpleado);
                    if (true)
                        msg = "Se actualizo el bono";
                }

                if (rpta == true)
                {
                    Util.InformationMessage(msg);
                    this.frmList.CargarListadoBonos();
                    this.Close();
                }

                #endregion

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

        private void cboBono_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        #endregion

    }
}

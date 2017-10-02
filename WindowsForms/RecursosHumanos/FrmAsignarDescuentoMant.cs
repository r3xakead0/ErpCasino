using System;
using System.Windows.Forms;
using System.Data;
using System.Linq;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;
using System.Collections.Generic;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmAsignarDescuentoMant : Form
    {

        private FrmAsignarDescuentoList frmList = null;

        private BE.UI.DescuentoEmpleado uiDescuentoEmpleado = null;

        public FrmAsignarDescuentoMant(FrmAsignarDescuentoList frmList)
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

        public void Cargar(BE.UI.DescuentoEmpleado uiDescuentoEmpleado = null)
        {
            try
            {

                if (uiDescuentoEmpleado != null)
                {

                    this.uiDescuentoEmpleado = uiDescuentoEmpleado;

                    this.dtpFecha.Value = this.uiDescuentoEmpleado.Fecha;
                    this.txtEmpleadoCodigo.Text = this.uiDescuentoEmpleado.EmpleadoCodigo;
                    this.cboEmpleado.SelectedValue = this.uiDescuentoEmpleado.EmpleadoCodigo;
                    this.cboDescuento.SelectedValue = this.uiDescuentoEmpleado.DescuentoID;
                    this.txtMotivo.Text = this.uiDescuentoEmpleado.Motivo;
                    this.txtMonto.Text = this.uiDescuentoEmpleado.Monto.ToString("N2");

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
                this.uiDescuentoEmpleado = new BE.UI.DescuentoEmpleado();

                //Limpiar controles de edicion
                this.dtpFecha.Value = DateTime.Now;
                this.txtEmpleadoCodigo.Clear();
                this.CargarEmpleados();
                this.CargarTiposDescuentos();
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

        private void CargarTiposDescuentos()
        {
            try
            {
                var lstTipos = new LN.Descuento().Listar();

                lstTipos.Insert(0, new BE.Descuento() { IdDescuento = 0, Nombre = "Seleccione" });

                this.cboDescuento.DataSource = lstTipos;
                this.cboDescuento.DisplayMember = "Nombre";
                this.cboDescuento.ValueMember = "IdDescuento";
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
                
                if (this.cboDescuento.SelectedIndex == 0)
                {
                    this.cboDescuento.Focus();
                    throw new Exception("Seleccione un tipo de descuento");
                }

                if (this.txtMotivo.Text.Trim().Length == 0)
                {
                    this.txtMotivo.Focus();
                    throw new Exception("Ingrese el motivo del descuento");
                }

                if (this.txtMonto.Text.Trim().Length == 0)
                {
                    this.txtMonto.Focus();
                    throw new Exception("Ingrese el monto del descuento");
                }

                double monto = 0; 
                if (double.TryParse(this.txtMonto.Text, out monto) == false)
                {
                    this.txtMonto.Focus();
                    throw new Exception("Ingrese el monto del descuento");
                }

                #endregion

                #region Guardar

                this.uiDescuentoEmpleado.Fecha = this.dtpFecha.Value;
                this.uiDescuentoEmpleado.EmpleadoCodigo = ((BE.Record)this.cboEmpleado.SelectedItem).Codigo;
                this.uiDescuentoEmpleado.EmpleadoNombreCompleto = ((BE.Record)this.cboEmpleado.SelectedItem).Nombre;
                this.uiDescuentoEmpleado.DescuentoID = ((BE.Descuento)this.cboDescuento.SelectedItem).IdDescuento;
                this.uiDescuentoEmpleado.DescuentoNombre = ((BE.Descuento)this.cboDescuento.SelectedItem).Nombre;
                this.uiDescuentoEmpleado.Motivo = this.txtMotivo.Text.Trim();
                this.uiDescuentoEmpleado.Monto = double.Parse(this.txtMonto.Text);

                bool rpta = false;
                string msg = "";
                var lnDescuentoEmpleado = new LN.DescuentoEmpleado();
                if (this.uiDescuentoEmpleado.ID == 0) //Nuevo
                {
                    rpta = lnDescuentoEmpleado.Insertar(ref this.uiDescuentoEmpleado);
                    if (true)
                        msg = "Se registro el nuevo adelanto";
                }
                else  //Actualizar
                {
                    rpta = lnDescuentoEmpleado.Actualizar(this.uiDescuentoEmpleado);
                    if (true)
                        msg = "Se actualizo el adelanto";
                }

                if (rpta == true)
                {
                    Util.InformationMessage(msg);
                    this.frmList.CargarListadoDescuentos();
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

        private void cboDescuento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (this.cboDescuento.SelectedIndex > 0)
                {
                    int idDescuento = int.Parse(this.cboDescuento.SelectedValue.ToString());
                    var beDescuento = new LN.Descuento().Obtener(idDescuento);

                    double monto = 0.0;
                    if (beDescuento != null)
                        monto = beDescuento.Monto;

                    this.txtMonto.Text = monto.ToString("N2");
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

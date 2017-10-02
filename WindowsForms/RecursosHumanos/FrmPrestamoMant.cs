using System;
using System.Windows.Forms;
using System.Data;
using System.Linq;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;
using System.Collections.Generic;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmPrestamoMant : Form
    {

        private List<BE.UI.Cuota> lstIdCuotasNuevas = new List<BE.UI.Cuota>();
        private List<BE.UI.Cuota> lstIdCuotasEliminadas = new List<BE.UI.Cuota>();

        private FrmPrestamoList frmList = null;

        private BE.UI.Prestamo bePrestamo = new BE.UI.Prestamo();

        public FrmPrestamoMant(FrmPrestamoList frmList)
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

        public void Cargar(BE.UI.Prestamo bePrestamo = null)
        {
            try
            {

                if (bePrestamo != null)
                {

                    this.bePrestamo = bePrestamo;

                    this.dtpFecha.Value = this.bePrestamo.Fecha;
                    this.cboEmpleado.SelectedValue = this.bePrestamo.CodigoEmpleado;
                    this.txtMotivo.Text = this.bePrestamo.Motivo;
                    this.txtMonto.Text = this.bePrestamo.Monto.ToString("###,###.00");
                    this.chkPagado.Checked = this.bePrestamo.Pagado;

                    this.CargarCuotas(bePrestamo.IdPrestamo);

                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }

        }

        private void CargarCuotas(int idPrestamo = 0)
        {
            try
            {

                if (idPrestamo > 0)
                {
                    var lstCuotas = new LN.Prestamo().ListarCuotas(idPrestamo);
                    this.bePrestamo.Cuotas = lstCuotas;
                }
                else
                {
                    if (this.bePrestamo.Cuotas == null)
                        this.bePrestamo.Cuotas = new List<BE.UI.Cuota>();
                }

                int nroCuotas = this.bePrestamo.Cuotas.Count();

                BindingSource source = new BindingSource();
                source.DataSource = this.bePrestamo.Cuotas;

                this.dgvCuotas.DataSource = source;
                this.txtCantidadCuotas.Text = nroCuotas.ToString();

                this.FormatoCuotas();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FormatoCuotas()
        {
            try
            {
                Util.FormatDatagridview(ref this.dgvCuotas);

                this.dgvCuotas.Columns["IdCuota"].Visible = false;

                this.dgvCuotas.Columns["Numero"].Visible = true;
                this.dgvCuotas.Columns["Numero"].HeaderText = "Numero";
                this.dgvCuotas.Columns["Numero"].Width = 70;
                this.dgvCuotas.Columns["Numero"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                this.dgvCuotas.Columns["Fecha"].Visible = true;
                this.dgvCuotas.Columns["Fecha"].HeaderText = "Fecha";
                this.dgvCuotas.Columns["Fecha"].Width = 150;
                this.dgvCuotas.Columns["Fecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvCuotas.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";

                this.dgvCuotas.Columns["Importe"].Visible = true;
                this.dgvCuotas.Columns["Importe"].HeaderText = "Monto";
                this.dgvCuotas.Columns["Importe"].Width = 100;
                this.dgvCuotas.Columns["Importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvCuotas.Columns["Importe"].DefaultCellStyle.Format = "N2";

                this.dgvCuotas.Columns["Pagado"].Visible = true;
                this.dgvCuotas.Columns["Pagado"].HeaderText = "Pagado";
                this.dgvCuotas.Columns["Pagado"].Width = 70;
                this.dgvCuotas.Columns["Pagado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                Util.AutoWidthColumn(ref this.dgvCuotas, "Fecha");
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
                this.bePrestamo = new BE.UI.Prestamo();

                //Limpiar controles de edicion
                this.bePrestamo.IdPrestamo = 0;
                this.dtpFecha.Value = DateTime.Now;
                this.txtMonto.Text = "0.00";
                this.txtMotivo.Clear();
                this.chkPagado.Checked = false;

                this.CargarEmpleados();

                this.CargarCuotas(this.bePrestamo.IdPrestamo);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarEmpleados()
        {
            try
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Formulario

        private void FrmPrestamoMant_Load(object sender, EventArgs e)
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

                if (int.Parse(this.txtCantidadCuotas.Text) == 0.0 
                    || this.bePrestamo.Cuotas.Count == 0)
                {
                    throw new Exception("Ingrese una o mas cuotas");
                }


                #endregion

                #region Guardar

                this.bePrestamo.Fecha = this.dtpFecha.Value;
                this.bePrestamo.CodigoEmpleado = this.cboEmpleado.SelectedValue.ToString();
                this.bePrestamo.Motivo = this.txtMotivo.Text;
                this.bePrestamo.Monto = double.Parse(this.txtMonto.Text);
                this.bePrestamo.Pagado = this.chkPagado.Checked;
                this.bePrestamo.NumeroCuotas = int.Parse(this.txtCantidadCuotas.Text);

                bool rpta = false;
                string msg = "";
                var lnPrestamo = new LN.Prestamo();
                if (this.bePrestamo.IdPrestamo == 0) //Nuevo
                {
                    rpta = lnPrestamo.Insertar(ref this.bePrestamo);
                    if (true)
                        msg = "Se registro el nuevo adelanto";
                }
                else  //Actualizar
                {
                    rpta = lnPrestamo.Actualizar(this.bePrestamo, 
                        this.lstIdCuotasNuevas, 
                        this.lstIdCuotasEliminadas);
                    if (true)
                        msg = "Se actualizo el adelanto";
                }

                if (rpta == true)
                {
                    Util.InformationMessage(msg);
                    this.frmList.CargarListadoPrestamos();
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

                var rpta = Util.ConfirmationMessage("¿Desea salir del formulario de mantenimiento de Prestamo?");

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

        private void txtMontoCuota_Leave(object sender, EventArgs e)
        {
            double value = double.Parse(txtMontoCuota.Text);
            txtMontoCuota.Text = String.Format("{0:#,##0.00}", value);
        }

        private void txtMontoCuota_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtMontoCuota_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate
            {
                txtMontoCuota.SelectAll();
            });
        }

        private void btnCuotaAgregar_Click(object sender, EventArgs e)
        {
            try
            {

                #region Validaciones

                if (this.txtMontoCuota.Text.Trim().Length == 0)
                {
                    this.txtMontoCuota.Focus();
                    throw new Exception("Ingrese el monto de la cuota");
                }

                if (double.Parse(this.txtMontoCuota.Text) == 0.0)
                {
                    this.txtMontoCuota.Focus();
                    throw new Exception("Ingrese el monto de la cuota");
                }

                #endregion

                var uiCuota = new BE.UI.Cuota();
                uiCuota.Numero = this.bePrestamo.Cuotas.Count + 1;
                uiCuota.Fecha = this.dtpFechaCuota.Value;
                uiCuota.Importe = double.Parse(this.txtMontoCuota.Text);
                uiCuota.Pagado = this.chkPagadoCuota.Checked;

                if (this.bePrestamo.Cuotas == null)
                    this.bePrestamo.Cuotas = new List<BE.UI.Cuota>();
                this.bePrestamo.Cuotas.Add(uiCuota);

                if (this.bePrestamo.IdPrestamo > 0)
                {
                    if (uiCuota.IdCuota == 0)
                        this.lstIdCuotasNuevas.Add(uiCuota);
                }

                double totalImporte = this.bePrestamo.Cuotas.Sum(x => x.Importe);
                this.txtMonto.Text = totalImporte.ToString("###,###.00");

                this.CargarCuotas(); 

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void btnCuotaEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvCuotas.CurrentRow != null)
                {

                    if (Util.ConfirmationMessage("¿Desea eliminar la cuota seleccionado?") == false)
                        return;

                    var uiCuota = (BE.UI.Cuota)this.dgvCuotas.CurrentRow.DataBoundItem;

                    bool rpta = true;

                    if (this.bePrestamo.IdPrestamo > 0)
                    {
                        if (uiCuota.IdCuota > 0)
                            this.lstIdCuotasEliminadas.Add(uiCuota);
                        else
                            this.lstIdCuotasNuevas.Remove(uiCuota);
                    } 

                    this.bePrestamo.Cuotas.Remove(uiCuota);
                    for (int i = 0; i < this.bePrestamo.Cuotas.Count; i++)
                    {
                        this.bePrestamo.Cuotas[i].Numero = i + 1;
                    }

                    if (rpta)
                    {

                        double totalImporte = this.bePrestamo.Cuotas.Sum(x => x.Importe);
                        this.txtMonto.Text = totalImporte.ToString("###,###.00");

                        this.CargarCuotas();
                    }
                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

    }
}

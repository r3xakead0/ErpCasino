using System;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmTipoDescuentoMant : Form
    {

        private BE.Descuento beDescuento = new BE.Descuento();

        public FrmTipoDescuentoMant()
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

        private void Limpiar()
        {
            try
            {
                //Limpiar objeto
                this.beDescuento = new BE.Descuento();

                //Limpiar controles de edicion
                this.txtNombre.Clear();
                this.txtDescripcion.Clear();
                this.txtMonto.Text = "0.00";
                this.chkActivo.Checked = false;

                //Cargar lista de descuentos
                this.CargarListadoDescuentos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarListadoDescuentos()
        {
            try
            {
                var lstDescuentos = new LN.Descuento().Listar();

                var source = new BindingSource();
                source.DataSource = lstDescuentos;

                this.dgvListadoDescuentos.DataSource = source;

                this.FormatoListadoDescuentos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FormatoListadoDescuentos()
        {
            try
            {
                Util.FormatDatagridview(ref this.dgvListadoDescuentos);

                for (int col = 0; col < this.dgvListadoDescuentos.Columns.Count; col++)
                    this.dgvListadoDescuentos.Columns[col].Visible = false;

                this.dgvListadoDescuentos.Columns["Nombre"].Visible = true;
                this.dgvListadoDescuentos.Columns["Nombre"].HeaderText = "Nombre";
                this.dgvListadoDescuentos.Columns["Nombre"].Width = 150;
                this.dgvListadoDescuentos.Columns["Nombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvListadoDescuentos.Columns["Descripcion"].Visible = true;
                this.dgvListadoDescuentos.Columns["Descripcion"].HeaderText = "Descripción";
                this.dgvListadoDescuentos.Columns["Descripcion"].Width = 300;
                this.dgvListadoDescuentos.Columns["Descripcion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvListadoDescuentos.Columns["Monto"].Visible = true;
                this.dgvListadoDescuentos.Columns["Monto"].HeaderText = "Monto";
                this.dgvListadoDescuentos.Columns["Monto"].Width = 70;
                this.dgvListadoDescuentos.Columns["Monto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvListadoDescuentos.Columns["Monto"].DefaultCellStyle.Format = "N2";

                this.dgvListadoDescuentos.Columns["Activo"].Visible = true;
                this.dgvListadoDescuentos.Columns["Activo"].HeaderText = "Activo";
                this.dgvListadoDescuentos.Columns["Activo"].Width = 50;
                this.dgvListadoDescuentos.Columns["Activo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                Util.AutoWidthColumn(ref this.dgvListadoDescuentos, "Descripcion");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Formulario

        private void FrmTipoDescuentoMant_Load(object sender, EventArgs e)
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
                if (this.txtNombre.Text.Trim().Length == 0)
                {
                    this.txtNombre.Focus();
                    throw new Exception("Ingrese el nombre del descuento");
                }

                if (this.txtDescripcion.Text.Trim().Length == 0)
                {
                    this.txtDescripcion.Focus();
                    throw new Exception("Ingrese la descripcion del descuento");
                }

                if (this.txtMonto.Text.Trim().Length == 0)
                {
                    this.txtMonto.Focus();
                    throw new Exception("Ingrese el monto del descuento");
                }

                if (double.Parse(this.txtMonto.Text) == 0.0)
                {
                    this.txtMonto.Focus();
                    throw new Exception("Ingrese el monto del descuento");
                }
                #endregion

                #region Guardar

                this.beDescuento.Nombre = this.txtNombre.Text;
                this.beDescuento.Descripcion = this.txtDescripcion.Text;
                this.beDescuento.Monto = double.Parse(this.txtMonto.Text);
                this.beDescuento.Activo = this.chkActivo.Checked;

                bool rpta = false;
                string msg = "";
                var lnDescuento = new LN.Descuento();
                if (this.beDescuento.IdDescuento == 0) //Nuevo
                {
                    rpta = lnDescuento.Insertar(ref this.beDescuento);
                    if (true)
                        msg = "Se registro el nuevo descuento";
                }
                else  //Actualizar
                {
                    rpta = lnDescuento.Actualizar(this.beDescuento);
                    if (true)
                        msg = "Se actualizo el descuento";
                }

                if (rpta == true)
                    Util.InformationMessage(msg);
                #endregion

                this.Limpiar();

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

                var rpta = Util.ConfirmationMessage("¿Desea salir del formulario de Descuentos?");

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

        private void txtMonto_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate
            {
                txtMonto.SelectAll();
            });
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                bool rpta = false;

                if (this.beDescuento != null && this.beDescuento.IdDescuento > 0)
                {
                    int id = this.beDescuento.IdDescuento;
                    rpta = new LN.Descuento().Eliminar(id);
                }

                if (rpta == true)
                    Util.InformationMessage("Se eliminó el descuento");

                this.Limpiar();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void dgvListadoDescuentos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var beDescuentoTmp = (BE.Descuento)this.dgvListadoDescuentos.CurrentRow.DataBoundItem;

                this.txtNombre.Text = beDescuentoTmp.Nombre;
                this.txtDescripcion.Text = beDescuentoTmp.Descripcion;
                this.txtMonto.Text = beDescuentoTmp.Monto.ToString("N2");
                this.chkActivo.Checked = beDescuentoTmp.Activo;

                this.beDescuento = beDescuentoTmp;
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
    }
}

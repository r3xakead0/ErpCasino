using System;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmTipoBonoMant : Form
    {

        private BE.Bono beBono = new BE.Bono();

        public FrmTipoBonoMant()
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
                this.beBono = new BE.Bono();

                //Limpiar controles de edicion
                this.txtNombre.Clear();
                this.txtDescripcion.Clear();
                this.txtMonto.Text = "0.00";
                this.chkActivo.Checked = false;

                //Cargar lista de bonos
                this.CargarListadoBonos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarListadoBonos()
        {
            try
            {
                var lstBonos = new LN.Bono().Listar();

                var source = new BindingSource();
                source.DataSource = lstBonos;

                this.dgvListadoBonos.DataSource = source;

                this.FormatoListadoBonos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FormatoListadoBonos()
        {
            try
            {
                Util.FormatDatagridview(ref this.dgvListadoBonos);

                for (int col = 0; col < this.dgvListadoBonos.Columns.Count; col++)
                    this.dgvListadoBonos.Columns[col].Visible = false;

                this.dgvListadoBonos.Columns["Nombre"].Visible = true;
                this.dgvListadoBonos.Columns["Nombre"].HeaderText = "Nombre";
                this.dgvListadoBonos.Columns["Nombre"].Width = 150;
                this.dgvListadoBonos.Columns["Nombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvListadoBonos.Columns["Descripcion"].Visible = true;
                this.dgvListadoBonos.Columns["Descripcion"].HeaderText = "Descripción";
                this.dgvListadoBonos.Columns["Descripcion"].Width = 300;
                this.dgvListadoBonos.Columns["Descripcion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvListadoBonos.Columns["Monto"].Visible = true;
                this.dgvListadoBonos.Columns["Monto"].HeaderText = "Monto";
                this.dgvListadoBonos.Columns["Monto"].Width = 70;
                this.dgvListadoBonos.Columns["Monto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvListadoBonos.Columns["Monto"].DefaultCellStyle.Format = "N2";

                this.dgvListadoBonos.Columns["Activo"].Visible = true;
                this.dgvListadoBonos.Columns["Activo"].HeaderText = "Activo";
                this.dgvListadoBonos.Columns["Activo"].Width = 50;
                this.dgvListadoBonos.Columns["Activo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                Util.AutoWidthColumn(ref this.dgvListadoBonos, "Descripcion");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Formulario

        private void FrmTipoBonoMant_Load(object sender, EventArgs e)
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
                    throw new Exception("Ingrese el nombre del bono");
                }

                if (this.txtDescripcion.Text.Trim().Length == 0)
                {
                    this.txtDescripcion.Focus();
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

                this.beBono.Nombre = this.txtNombre.Text;
                this.beBono.Descripcion = this.txtDescripcion.Text;
                this.beBono.Monto = double.Parse(this.txtMonto.Text);
                this.beBono.Activo = this.chkActivo.Checked;

                bool rpta = false;
                string msg = "";
                var lnBono = new LN.Bono();
                if (this.beBono.IdBono == 0) //Nuevo
                {
                    rpta = lnBono.Insertar(ref this.beBono);
                    if (true)
                        msg = "Se registro el nuevo bono";
                }
                else  //Actualizar
                {
                    rpta = lnBono.Actualizar(this.beBono);
                    if (true)
                        msg = "Se actualizo el bono";
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

                var rpta = Util.ConfirmationMessage("¿Desea salir del formulario de Bonos?");

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

                if (this.beBono != null && this.beBono.IdBono > 0)
                {
                    int id = this.beBono.IdBono;
                    rpta = new LN.Bono().Eliminar(id);
                }

                if (rpta == true)
                    Util.InformationMessage("Se eliminó el bono");

                this.Limpiar();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void dgvListadoBonos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var beBonoTmp = (BE.Bono)this.dgvListadoBonos.CurrentRow.DataBoundItem;

                this.txtNombre.Text = beBonoTmp.Nombre;
                this.txtDescripcion.Text = beBonoTmp.Descripcion;
                this.txtMonto.Text = beBonoTmp.Monto.ToString("N2");
                this.chkActivo.Checked = beBonoTmp.Activo;

                this.beBono = beBonoTmp;
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

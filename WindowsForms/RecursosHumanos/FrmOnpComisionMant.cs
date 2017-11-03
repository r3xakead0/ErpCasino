using System;
using System.Windows.Forms;
using System.Collections.Generic;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmOnpComisionMant : Form
    {

        public FrmOnpComisionMant()
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

        public void CargarListadoComisionesONP()
        {
            try
            {

                var lstUiComisiones = new LN.OnpComision().Listar();
                this.txtNroRegistros.Text = lstUiComisiones.Count.ToString();

                var sorted = new SortableBindingList<BE.UI.OnpComision>(lstUiComisiones);
                this.dgvComisiones.DataSource = sorted;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FormatoListadoComisionesONP()
        {
            try
            {
                Util.FormatDatagridview(ref this.dgvComisiones);

                this.dgvComisiones.Columns["IdOnpComision"].Visible = false;

                this.dgvComisiones.Columns["Anho"].Visible = true;
                this.dgvComisiones.Columns["Anho"].HeaderText = "Año";
                this.dgvComisiones.Columns["Anho"].Width = 80;
                this.dgvComisiones.Columns["Anho"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.dgvComisiones.Columns["MesNumero"].Visible = false;

                this.dgvComisiones.Columns["MesNombre"].Visible = true;
                this.dgvComisiones.Columns["MesNombre"].HeaderText = "Mes";
                this.dgvComisiones.Columns["MesNombre"].Width = 80;
                this.dgvComisiones.Columns["MesNombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.dgvComisiones.Columns["AportePorcentual"].Visible = true;
                this.dgvComisiones.Columns["AportePorcentual"].HeaderText = "Aporte %";
                this.dgvComisiones.Columns["AportePorcentual"].Width = 80;
                this.dgvComisiones.Columns["AportePorcentual"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvComisiones.Columns["AportePorcentual"].DefaultCellStyle.Format = "N2";

                Util.AutoWidthColumn(ref this.dgvComisiones, "AportePorcentual");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Formulario

        private void FrmOnpComisionMant_Load(object sender, EventArgs e)
        {
            try
            {

                this.CargarAnhos();
                this.cboAnho.SelectedValue = DateTime.Now.Year.ToString();

                this.CargarMes();
                this.cboMes.SelectedValue = DateTime.Now.Month.ToString();

                this.CargarListadoComisionesONP();
                this.FormatoListadoComisionesONP();
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

                var rpta = Util.ConfirmationMessage("¿Desea salir del mantenimiento de comisiones de ONPs?");

                if (rpta == false)
                    return;

                this.Close();

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvComisiones.CurrentRow != null)
                {

                    if (Util.ConfirmationMessage("¿Desea eliminar la comision de ONP seleccionada?") == false)
                        return;

                    var uiAdelato = (BE.UI.OnpComision)this.dgvComisiones.CurrentRow.DataBoundItem;

                    int idOnpComision = uiAdelato.IdOnpComision;
                    bool rpta = new LN.OnpComision().Eliminar(idOnpComision);

                    if (rpta == true)
                    {
                        Util.InformationMessage("Se eliminó la comisión de la ONP");
                        this.CargarListadoComisionesONP();
                    }
                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.txtAportePrc.Text.Trim().Length == 0)
                {
                    this.txtAportePrc.Focus();
                    throw new Exception("Ingrese el monto del aporte");
                }

                if (double.Parse(this.txtAportePrc.Text) == 0.0)
                {
                    this.txtAportePrc.Focus();
                    throw new Exception("Ingrese el monto del aporte");
                }

                int anho = int.Parse(this.cboAnho.SelectedValue.ToString());
                int mes = int.Parse(this.cboMes.SelectedValue.ToString());

                var lnOnpComision = new LN.OnpComision();
                BE.UI.OnpComision beOnpComision = null;

                beOnpComision = lnOnpComision.Obtener(anho, mes);
                if (beOnpComision != null)
                {
                    throw new Exception("Existe una comisión de ONP para el periodo seleccionado");
                }

                beOnpComision = new BE.UI.OnpComision();
                beOnpComision.Anho = anho;
                beOnpComision.MesNumero = mes;
                beOnpComision.AportePorcentual = double.Parse(this.txtAportePrc.Text);
                if (lnOnpComision.Insertar(ref beOnpComision))
                {
                    Util.InformationMessage("Se registro la nueva comision de ONP");
                    this.CargarListadoComisionesONP();
                }

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }


        private void txtAportePrc_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate
            {
                txtAportePrc.SelectAll();
            });
        }

        private void txtAportePrc_Leave(object sender, EventArgs e)
        {
            try
            {
                double monto = 0.0;

                if (this.txtAportePrc.Text.Length > 0)
                    monto = double.Parse(this.txtAportePrc.Text);

                this.txtAportePrc.Text = monto.ToString("N2");
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void txtAportePrc_KeyPress(object sender, KeyPressEventArgs e)
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

        #endregion

    }
}

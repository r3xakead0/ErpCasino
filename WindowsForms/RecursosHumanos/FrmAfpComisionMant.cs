using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmAfpComisionMant : Form
    {

        private List<BE.UI.AfpComision> lstUiComisiones = new List<BE.UI.AfpComision>();

        public FrmAfpComisionMant()
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

        public void CargarComisiones()
        {
            try
            {

                int anho = int.Parse(this.cboAnho.SelectedValue.ToString());
                int mes = int.Parse(this.cboMes.SelectedValue.ToString());

                List<BE.AfpComision> lstBeComisiones = new LN.AfpComision().Listar(
                    new BE.AfpComision() { Anho = anho, Mes = mes }
                );

                this.lstUiComisiones = new List<BE.UI.AfpComision>();

                if (lstBeComisiones.Count > 0)
                {
                    foreach (BE.AfpComision beComision in lstBeComisiones)
                    {
                        var uiComision = new BE.UI.AfpComision();
                        uiComision.IdAfpComision = beComision.IdAfpComision;
                        uiComision.AfpID = beComision.Afp.IdAfp;
                        uiComision.AfpNombre = beComision.Afp.Nombre;
                        //uiComision.Anho = beComision.Anho;
                        //uiComision.Mes = beComision.Mes;
                        uiComision.PorcentajeFondo = beComision.PorcentajeFondo;
                        uiComision.PorcentajeSeguro = beComision.PorcentajeSeguro;
                        uiComision.PorcentajeComisionFlujo = beComision.PorcentajeComisionFlujo;
                        uiComision.PorcentajeComisionMixta = beComision.PorcentajeComisionMixta;
                        lstUiComisiones.Add(uiComision);
                    }
                }
                else
                {
                    var lstBeAfp = new LN.Afp().ListarCombo();
                    foreach (BE.Afp beAfp in lstBeAfp)
                    {
                        var uiComision = new BE.UI.AfpComision();
                        uiComision.IdAfpComision = 0;
                        uiComision.AfpID = beAfp.IdAfp;
                        uiComision.AfpNombre = beAfp.Nombre;
                        //uiComision.Anho = beComision.Anho;
                        //uiComision.Mes = beComision.Mes;
                        uiComision.PorcentajeFondo = 0.0;
                        uiComision.PorcentajeSeguro = 0.0;
                        uiComision.PorcentajeComisionFlujo = 0.0;
                        uiComision.PorcentajeComisionMixta = 0.0;
                        lstUiComisiones.Add(uiComision);
                    }
                }

                var source = new BindingSource();
                source.DataSource = lstUiComisiones;

                this.dgvComisiones.DataSource = source;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FormatoComisiones()
        {
            try
            {
                Util.FormatDatagridview(ref this.dgvComisiones);
                this.dgvComisiones.ReadOnly = false;

                this.dgvComisiones.Columns["IdAfpComision"].Visible = false;

                this.dgvComisiones.Columns["AfpID"].Visible = false;

                this.dgvComisiones.Columns["AfpNombre"].Visible = true;
                this.dgvComisiones.Columns["AfpNombre"].HeaderText = "AFP";
                this.dgvComisiones.Columns["AfpNombre"].Width = 100;
                this.dgvComisiones.Columns["AfpNombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dgvComisiones.Columns["AfpNombre"].ReadOnly = true;
                this.dgvComisiones.Columns["AfpNombre"].DefaultCellStyle.BackColor = Color.LightGray;

                this.dgvComisiones.Columns["PorcentajeFondo"].Visible = true;
                this.dgvComisiones.Columns["PorcentajeFondo"].HeaderText = "% Fondo";
                this.dgvComisiones.Columns["PorcentajeFondo"].Width = 90;
                this.dgvComisiones.Columns["PorcentajeFondo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvComisiones.Columns["PorcentajeFondo"].DefaultCellStyle.Format = "N2";

                this.dgvComisiones.Columns["PorcentajeSeguro"].Visible = true;
                this.dgvComisiones.Columns["PorcentajeSeguro"].HeaderText = "% Seguro";
                this.dgvComisiones.Columns["PorcentajeSeguro"].Width = 90;
                this.dgvComisiones.Columns["PorcentajeSeguro"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvComisiones.Columns["PorcentajeSeguro"].DefaultCellStyle.Format = "N2";

                this.dgvComisiones.Columns["PorcentajeComisionFlujo"].Visible = true;
                this.dgvComisiones.Columns["PorcentajeComisionFlujo"].HeaderText = "% Flujo";
                this.dgvComisiones.Columns["PorcentajeComisionFlujo"].Width = 90;
                this.dgvComisiones.Columns["PorcentajeComisionFlujo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvComisiones.Columns["PorcentajeComisionFlujo"].DefaultCellStyle.Format = "N2";

                this.dgvComisiones.Columns["PorcentajeComisionMixta"].Visible = true;
                this.dgvComisiones.Columns["PorcentajeComisionMixta"].HeaderText = "% Mixta";
                this.dgvComisiones.Columns["PorcentajeComisionMixta"].Width = 90;
                this.dgvComisiones.Columns["PorcentajeComisionMixta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvComisiones.Columns["PorcentajeComisionMixta"].DefaultCellStyle.Format = "N2";

                Util.AutoWidthColumn(ref this.dgvComisiones, "AfpNombre");
            }
            catch (Exception ex)
            {
                throw ex;
            }
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

        

        #endregion

        #region Formulario

        private void FrmAfpComisionMant_Load(object sender, EventArgs e)
        {
            try
            {

                this.CargarAnhos();
                this.CargarMes();

                this.cboAnho.SelectedValue = DateTime.Now.Year.ToString();
                this.cboMes.SelectedValue = DateTime.Now.Month.ToString();

                this.CargarComisiones();
                this.FormatoComisiones();
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

                int anho = int.Parse(this.cboAnho.SelectedValue.ToString());
                int mes = int.Parse(this.cboMes.SelectedValue.ToString());

                foreach (BE.UI.AfpComision uiComision in this.lstUiComisiones)
                {

                    var beAfp = new BE.Afp()
                    {
                        IdAfp = uiComision.AfpID,
                        Nombre = uiComision.AfpNombre
                    };

                    var beComision = new BE.AfpComision
                    {
                        Afp = beAfp,
                        IdAfpComision = uiComision.IdAfpComision,
                        Anho = anho,
                        Mes = mes,
                        PorcentajeFondo = uiComision.PorcentajeFondo,
                        PorcentajeSeguro = uiComision.PorcentajeSeguro,
                        PorcentajeComisionFlujo = uiComision.PorcentajeComisionFlujo,
                        PorcentajeComisionMixta = uiComision.PorcentajeComisionMixta,
                    };

                    var lnComision = new LN.AfpComision();
                    if (beComision.IdAfpComision > 0)
                    {
                        lnComision.Actualizar(beComision);
                    }
                    else
                    {
                        lnComision.Insertar(ref beComision);
                    }
                }

                Util.InformationMessage("Se guardo los datos de la Comision");

                this.CargarComisiones();

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

        private void DgvComisiones_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (dgvComisiones.CurrentCell.ColumnIndex > 4)
                {
                    e.Control.KeyPress += new KeyPressEventHandler(DgvComisiones_KeyPress);
                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void DgvComisiones_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CbxAnhoMes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                CargarComisiones();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        #endregion

    }
}

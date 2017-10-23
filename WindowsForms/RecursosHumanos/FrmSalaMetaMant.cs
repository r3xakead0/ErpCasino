using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmSalaMetaMant : Form
    {

        private List<BE.UI.MetaSala> lstUiMetasSalas = null;

        public FrmSalaMetaMant()
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

        public void CargarListaMetas()
        {
            try
            {

                int anho = int.Parse(this.cboAnho.SelectedValue.ToString());
                int mes = int.Parse(this.cboMes.SelectedValue.ToString());

                this.lstUiMetasSalas = new LN.MetaSala().Listar(anho, mes);

                if (this.lstUiMetasSalas.Count == 0)
                {
                    var lstUiSalas = new LN.Sala().Listar();

                    foreach (BE.UI.Sala uiSala in lstUiSalas)
                    {
                        var uiMetaSala = new BE.UI.MetaSala();

                        uiMetaSala.SalaId = uiSala.ID;
                        uiMetaSala.SalaNombre = uiSala.Nombre;
                        uiMetaSala.Anho = anho;
                        uiMetaSala.Mes = mes;

                        this.lstUiMetasSalas.Add(uiMetaSala);
                    }
                }

                var source = new BindingSource();
                source.DataSource = this.lstUiMetasSalas;

                this.dgvMetaSala.DataSource = source;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FormatoListaMetas()
        {
            try
            {
                Util.FormatDatagridview(ref this.dgvMetaSala);

                this.dgvMetaSala.ReadOnly = false;

                for (int i = 0; i < this.dgvMetaSala.Columns.Count; i++)
                    this.dgvMetaSala.Columns[i].Visible = false;

                this.dgvMetaSala.Columns["SalaNombre"].Visible = true;
                this.dgvMetaSala.Columns["SalaNombre"].HeaderText = "Sala";
                this.dgvMetaSala.Columns["SalaNombre"].Width = 100;
                this.dgvMetaSala.Columns["SalaNombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dgvMetaSala.Columns["SalaNombre"].ReadOnly = true;
                this.dgvMetaSala.Columns["SalaNombre"].DefaultCellStyle.BackColor = Color.LightGray;

                this.dgvMetaSala.Columns["CantidadPersonal"].Visible = true;
                this.dgvMetaSala.Columns["CantidadPersonal"].HeaderText = "Nro. Empleados";
                this.dgvMetaSala.Columns["CantidadPersonal"].Width = 70;
                this.dgvMetaSala.Columns["CantidadPersonal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvMetaSala.Columns["CantidadPersonal"].ReadOnly = false;
                
                this.dgvMetaSala.Columns["MontoPersonal"].Visible = true;
                this.dgvMetaSala.Columns["MontoPersonal"].HeaderText = "Monto Personal";
                this.dgvMetaSala.Columns["MontoPersonal"].Width = 70;
                this.dgvMetaSala.Columns["MontoPersonal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvMetaSala.Columns["MontoPersonal"].ReadOnly = false;
                this.dgvMetaSala.Columns["MontoPersonal"].DefaultCellStyle.Format = "N2";

                this.dgvMetaSala.Columns["MontoGrupal"].Visible = true;
                this.dgvMetaSala.Columns["MontoGrupal"].HeaderText = "Monto Grupal";
                this.dgvMetaSala.Columns["MontoGrupal"].Width = 70;
                this.dgvMetaSala.Columns["MontoGrupal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvMetaSala.Columns["MontoGrupal"].ReadOnly = false;
                this.dgvMetaSala.Columns["MontoGrupal"].DefaultCellStyle.Format = "N2";

                this.dgvMetaSala.Columns["Cumplido"].Visible = true;
                this.dgvMetaSala.Columns["Cumplido"].HeaderText = "Cumplido";
                this.dgvMetaSala.Columns["Cumplido"].Width = 70;
                this.dgvMetaSala.Columns["Cumplido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvMetaSala.Columns["Cumplido"].ReadOnly = false;

                Util.AutoWidthColumn(ref this.dgvMetaSala, "SalaNombre");
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

        private void FrmSalaMetaMant_Load(object sender, EventArgs e)
        {
            try
            {

                this.CargarAnhos();
                this.cboAnho.SelectedValue = DateTime.Now.Year.ToString();

                this.CargarMes();
                this.cboMes.SelectedValue = DateTime.Now.Month.ToString();

                this.lstUiMetasSalas = new List<BE.UI.MetaSala>();
                this.CargarListaMetas();
                this.FormatoListaMetas();
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

                int anho = int.Parse(this.cboAnho.SelectedValue.ToString());
                int mes = int.Parse(this.cboMes.SelectedValue.ToString());

                bool rpta = false;

                var lnMetaSala = new LN.MetaSala();
                for (int i = 0; i < this.lstUiMetasSalas.Count; i++)
                {
                    var uiMetaSala = this.lstUiMetasSalas[i];
                    if (uiMetaSala.Id > 0)
                    {
                        rpta = lnMetaSala.Actualizar(uiMetaSala);
                    }
                    else
                    {
                        rpta = lnMetaSala.Insertar(ref uiMetaSala);
                        this.lstUiMetasSalas[i].Id = uiMetaSala.Id;
                    }
                }     

                if (rpta)
                {
                    Util.InformationMessage("Se guardo las metas por salas");
                    this.CargarListaMetas();
                }

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {

                var rpta = Util.ConfirmationMessage("¿Desea salir del mantenimiento de comisiones de AFP?");

                if (rpta == false)
                    return;

                this.Close();

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void dgvMetaSala_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                int colCantidadPersonal = this.dgvMetaSala.Columns["CantidadPersonal"].Index;
                int colMontoPersonal = this.dgvMetaSala.Columns["MontoPersonal"].Index;
                int colMontoGrupal = this.dgvMetaSala.Columns["MontoGrupal"].Index;

                if (this.dgvMetaSala.CurrentCell.ColumnIndex == colMontoPersonal 
                    || this.dgvMetaSala.CurrentCell.ColumnIndex == colMontoGrupal)
                {
                    e.Control.KeyPress += new KeyPressEventHandler(dgvMetaSalaOnlyDecimal_KeyPress);
                }
                else if (this.dgvMetaSala.CurrentCell.ColumnIndex == colCantidadPersonal)
                {
                    e.Control.KeyPress += new KeyPressEventHandler(dgvMetaSalaOnlyInteger_KeyPress);
                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void dgvMetaSalaOnlyDecimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void dgvMetaSalaOnlyInteger_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void CbxAnhoMes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                CargarListaMetas();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;
using System.Linq;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmAdelantoList : Form
    {

        #region "Patron Singleton"

        private static FrmAdelantoList frmInstance = null;

        public static FrmAdelantoList Instance()
        {

            if (frmInstance == null || frmInstance.IsDisposed == true)
            {
                frmInstance = new FrmAdelantoList();
            }

            frmInstance.BringToFront();

            return frmInstance;
        }

        #endregion

        public FrmAdelantoList()
        {
            InitializeComponent();
        }

        #region Formulario

        private void FrmAdelantoList_ResizeEnd(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvAdelantos.DataSource != null)
                {
                    Util.AutoWidthColumn(ref this.dgvAdelantos, "NombreCompletoEmpleado");
                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void FrmPostulanteList_Load(object sender, EventArgs e)
        {
            try
            {

                this.CargarAnhos();
                this.CargarMes();

                this.cboAnho.SelectedValue = DateTime.Now.Year.ToString();
                this.cboMes.SelectedValue = DateTime.Now.Month.ToString();

                this.CargarListadoAdelantos();
                this.FormatoListadoAdelantos();

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void dgvAdelantos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;

                var uiAdelanto = (BE.UI.Adelanto)this.dgvAdelantos.CurrentRow.DataBoundItem;

                this.Editar(uiAdelanto);

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void cboAnhoMes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                this.CargarListadoAdelantos();

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                var frmAdelantoMant = FrmAdelantoMant.Instance();
                frmAdelantoMant.MdiParent = this.MdiParent;
                frmAdelantoMant.Show();

                frmAdelantoMant.frmList = this;
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.dgvAdelantos.CurrentRow != null)
                {
                    var uiAdelanto = (BE.UI.Adelanto)this.dgvAdelantos.CurrentRow.DataBoundItem;

                    this.Editar(uiAdelanto);
                }
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
                if (this.dgvAdelantos.CurrentRow != null)
                {

                    if (Util.ConfirmationMessage("¿Desea eliminar al adelanto seleccionado?") == false)
                        return;

                    var uiAdelato = (BE.UI.Adelanto)this.dgvAdelantos.CurrentRow.DataBoundItem;

                    int idAdelanto = uiAdelato.IdAdelanto;
                    bool rpta = new LN.Adelanto().Eliminar(idAdelanto);

                    if (rpta == true)
                    {
                        Util.InformationMessage("Se eliminó el adelanto");
                        this.CargarListadoAdelantos();
                    }
                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }


        #endregion

        #region Metodos

        private void Editar(BE.UI.Adelanto uiAdelanto)
        {
            try
            {
                var frmAdelantoMant = FrmAdelantoMant.Instance();
                frmAdelantoMant.MdiParent = this.MdiParent;
                frmAdelantoMant.Show();

                frmAdelantoMant.frmList = this;
                frmAdelantoMant.Cargar(uiAdelanto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void CargarListadoAdelantos()
        {
            try
            {

                int anho = int.Parse(this.cboAnho.SelectedValue.ToString());
                int mes = int.Parse(this.cboMes.SelectedValue.ToString());

                var lstUiAdelantos = new LN.Adelanto().Listar(anho, mes);

                var source = new BindingSource();
                source.DataSource = lstUiAdelantos;

                this.dgvAdelantos.DataSource = source;

                int nroRegistros = lstUiAdelantos.Count;
                double totalAdelantos = lstUiAdelantos.Sum(x => x.Monto);

                this.txtNroRegistros.Text = nroRegistros.ToString();
                this.txtTotalAdelantos.Text = totalAdelantos.ToString("N2");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FormatoListadoAdelantos()
        {
            try
            {
                Util.FormatDatagridview(ref this.dgvAdelantos);

                for (int col = 0; col < this.dgvAdelantos.Columns.Count; col++)
                    this.dgvAdelantos.Columns[col].Visible = false;

                this.dgvAdelantos.Columns["Fecha"].Visible = true;
                this.dgvAdelantos.Columns["Fecha"].HeaderText = "Fecha";
                this.dgvAdelantos.Columns["Fecha"].Width = 100;
                this.dgvAdelantos.Columns["Fecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvAdelantos.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";

                this.dgvAdelantos.Columns["CodigoEmpleado"].Visible = true;
                this.dgvAdelantos.Columns["CodigoEmpleado"].HeaderText = "Codigo";
                this.dgvAdelantos.Columns["CodigoEmpleado"].Width = 80;
                this.dgvAdelantos.Columns["CodigoEmpleado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvAdelantos.Columns["NombreCompletoEmpleado"].Visible = true;
                this.dgvAdelantos.Columns["NombreCompletoEmpleado"].HeaderText = "Empleado";
                this.dgvAdelantos.Columns["NombreCompletoEmpleado"].Width = 200;
                this.dgvAdelantos.Columns["NombreCompletoEmpleado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvAdelantos.Columns["NombreTipo"].Visible = true;
                this.dgvAdelantos.Columns["NombreTipo"].HeaderText = "Tipo";
                this.dgvAdelantos.Columns["NombreTipo"].Width = 50;
                this.dgvAdelantos.Columns["NombreTipo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.dgvAdelantos.Columns["NombreBanco"].Visible = true;
                this.dgvAdelantos.Columns["NombreBanco"].HeaderText = "Banco";
                this.dgvAdelantos.Columns["NombreBanco"].Width = 100;
                this.dgvAdelantos.Columns["NombreBanco"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvAdelantos.Columns["Numero"].Visible = true;
                this.dgvAdelantos.Columns["Numero"].HeaderText = "Numero";
                this.dgvAdelantos.Columns["Numero"].Width = 80;
                this.dgvAdelantos.Columns["Numero"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvAdelantos.Columns["Monto"].Visible = true;
                this.dgvAdelantos.Columns["Monto"].HeaderText = "Monto";
                this.dgvAdelantos.Columns["Monto"].Width = 80;
                this.dgvAdelantos.Columns["Monto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvAdelantos.Columns["Monto"].DefaultCellStyle.Format = "N2";

                Util.AutoWidthColumn(ref this.dgvAdelantos, "NombreCompletoEmpleado");
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
                    
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        private void btnCargar_Click(object sender, EventArgs e)
        {
            try
            {
                var frmAdelantoCargar = FrmAdelantoCarga.Instance();
                frmAdelantoCargar.MdiParent = this.MdiParent;
                frmAdelantoCargar.Show();

                frmAdelantoCargar.frmList = this;
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }
    }
}

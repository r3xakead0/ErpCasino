using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmAsignarSueldoList : Form
    {

        #region "Patron Singleton"

        private static FrmAsignarSueldoList frmInstance = null;

        public static FrmAsignarSueldoList Instance()
        {

            if (frmInstance == null || frmInstance.IsDisposed == true)
            {
                frmInstance = new FrmAsignarSueldoList();
            }

            frmInstance.BringToFront();

            return frmInstance;
        }

        #endregion

        public FrmAsignarSueldoList()
        {
            InitializeComponent();
        }

        #region Formulario

        private void FrmAsignarSueldoList_ResizeEnd(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvSueldos.DataSource != null)
                {
                    Util.AutoWidthColumn(ref this.dgvSueldos, "CandidatoNombreCompleto");
                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void FrmAsignarSueldoList_Load(object sender, EventArgs e)
        {
            try
            {

                this.CargarAnhos();
                this.CargarMes();

                this.cboAnho.SelectedValue = DateTime.Now.Year.ToString();
                this.cboMes.SelectedValue = DateTime.Now.Month.ToString();

                this.CargarCandidatos();

                this.CargarListadoSueldos();
                this.FormatoListadoSueldos();

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void dgvSueldos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                var col = this.dgvSueldos.Columns[e.ColumnIndex];
                ListSortDirection dir;

                switch (col.HeaderCell.SortGlyphDirection)
                {
                    case SortOrder.Ascending:
                        dir = ListSortDirection.Ascending;
                        break;
                    default:
                        dir = ListSortDirection.Descending;
                        break;
                }

                this.dgvSueldos.Sort(col, dir);
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void dgvSueldos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;

                var uiSueldoCandidato = (BE.UI.SueldoCandidato)this.dgvSueldos.CurrentRow.DataBoundItem;

                this.Detalle(uiSueldoCandidato);

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
                this.CargarListadoSueldos();

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                var frmSueldoCalc = new FrmAsignarSueldoCalc(this);
                frmSueldoCalc.MdiParent = this.MdiParent;
                frmSueldoCalc.Show();

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvSueldos.CurrentRow != null)
                {
                    var uiSueldoCandidato = (BE.UI.SueldoCandidato)this.dgvSueldos.CurrentRow.DataBoundItem;

                    this.Detalle(uiSueldoCandidato);
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
                if (this.dgvSueldos.CurrentRow != null)
                {

                    if (Util.ConfirmationMessage("¿Desea eliminar el Sueldo seleccionado?") == false)
                        return;

                    var uiSueldoCandidato = (BE.UI.SueldoCandidato)this.dgvSueldos.CurrentRow.DataBoundItem;

                    int idSueldo = uiSueldoCandidato.ID;
                    bool rpta = new LN.SueldoCandidato().Eliminar(idSueldo);

                    if (rpta == true)
                    {
                        Util.InformationMessage("Se eliminó el Sueldo seleccionado");
                        this.CargarListadoSueldos();
                    }
                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Comma-separated Values (*.csv)|*.csv";
                sfd.FileName = "export.csv";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Util.PointerLoad(this);
                    Util.DatagridviewToCsv(this.dgvSueldos, sfd.FileName);
                    Util.InformationMessage("Se exporto correctamente el archivo CSV");
                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
            finally
            {
                Util.PointerReady(this);
            }
        }

        private void cboCandidato_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (this.cboCandidato.SelectedIndex > 0)
                {
                    string codigoCandidato = this.cboCandidato.SelectedValue.ToString().Trim();
                    this.txtCandidatoCodigo.Text = codigoCandidato;
                }
                else
                {
                    this.txtCandidatoCodigo.Clear();
                }

                this.CargarListadoSueldos();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }

        }

        private void txtCandidatoCodigo_Leave(object sender, EventArgs e)
        {
            try
            {
                string codigoCandidato = this.txtCandidatoCodigo.Text.Trim();

                var lst = (List<BE.Record>)this.cboCandidato.DataSource;

                if (lst.Where(x => x.Codigo == codigoCandidato).Count() > 0)
                {
                    this.txtCandidatoCodigo.Text = codigoCandidato;
                    this.cboCandidato.SelectedValue = codigoCandidato;
                }
                else
                {
                    this.txtCandidatoCodigo.Clear();
                    this.cboCandidato.SelectedIndex = 0;
                }

                this.CargarListadoSueldos();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }

        }

        #endregion

        #region Metodos

        private void Detalle(BE.UI.SueldoCandidato uiSueldoCandidato)
        {
            try
            {
                var frmSueldoMant = FrmAsignarSueldoView.Instance();
                frmSueldoMant.MdiParent = this.MdiParent;
                frmSueldoMant.Show();

                frmSueldoMant.Cargar(uiSueldoCandidato);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void CargarListadoSueldos()
        {
            try
            {

                int anho = int.Parse(this.cboAnho.SelectedValue.ToString());
                int mes = int.Parse(this.cboMes.SelectedValue.ToString());

                var lstUiSueldos = new LN.SueldoCandidato().Listar(anho, mes);
                var cntSueldos = lstUiSueldos.Count;
                var sumSueldos = lstUiSueldos.Sum(x => x.TotalNeto);

                var sorted = new SortableBindingList<BE.UI.SueldoCandidato>(lstUiSueldos);

                this.dgvSueldos.DataSource = sorted;
                this.txtNroRegistros.Text = cntSueldos.ToString();
                this.txtTotal.Text = sumSueldos.ToString("N2");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FormatoListadoSueldos()
        {
            try
            {
                Util.FormatDatagridview(ref this.dgvSueldos);

                for (int col = 0; col < this.dgvSueldos.Columns.Count; col++)
                    this.dgvSueldos.Columns[col].Visible = false;

                this.dgvSueldos.Columns["Fecha"].Visible = true;
                this.dgvSueldos.Columns["Fecha"].HeaderText = "Fecha";
                this.dgvSueldos.Columns["Fecha"].Width = 100;
                this.dgvSueldos.Columns["Fecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvSueldos.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";

                this.dgvSueldos.Columns["CandidatoCodigo"].Visible = true;
                this.dgvSueldos.Columns["CandidatoCodigo"].HeaderText = "Codigo";
                this.dgvSueldos.Columns["CandidatoCodigo"].Width = 80;
                this.dgvSueldos.Columns["CandidatoCodigo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvSueldos.Columns["CandidatoNombreCompleto"].Visible = true;
                this.dgvSueldos.Columns["CandidatoNombreCompleto"].HeaderText = "Candidato";
                this.dgvSueldos.Columns["CandidatoNombreCompleto"].Width = 200;
                this.dgvSueldos.Columns["CandidatoNombreCompleto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvSueldos.Columns["TotalBase"].Visible = true;
                this.dgvSueldos.Columns["TotalBase"].HeaderText = "Sueldo";
                this.dgvSueldos.Columns["TotalBase"].Width = 80;
                this.dgvSueldos.Columns["TotalBase"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                this.dgvSueldos.Columns["TotalBase"].DefaultCellStyle.Format = "N2";

                this.dgvSueldos.Columns["TotalBonos"].Visible = true;
                this.dgvSueldos.Columns["TotalBonos"].HeaderText = "Bonos";
                this.dgvSueldos.Columns["TotalBonos"].Width = 80;
                this.dgvSueldos.Columns["TotalBonos"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                this.dgvSueldos.Columns["TotalBonos"].DefaultCellStyle.Format = "N2";

                this.dgvSueldos.Columns["TotalDescuentos"].Visible = true;
                this.dgvSueldos.Columns["TotalDescuentos"].HeaderText = "Descuentos";
                this.dgvSueldos.Columns["TotalDescuentos"].Width = 80;
                this.dgvSueldos.Columns["TotalDescuentos"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                this.dgvSueldos.Columns["TotalDescuentos"].DefaultCellStyle.Format = "N2";

                this.dgvSueldos.Columns["TotalNeto"].Visible = true;
                this.dgvSueldos.Columns["TotalNeto"].HeaderText = "Total";
                this.dgvSueldos.Columns["TotalNeto"].Width = 80;
                this.dgvSueldos.Columns["TotalNeto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                this.dgvSueldos.Columns["TotalNeto"].DefaultCellStyle.Format = "N2";

                Util.AutoWidthColumn(ref this.dgvSueldos, "CandidatoNombreCompleto");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarCandidatos()
        {
            try
            {
                var lstCandidatos = new LN.Candidato().Combo();
                lstCandidatos = lstCandidatos.OrderBy(o => o.Codigo).ToList();
                lstCandidatos.Insert(0, new BE.Record() { Codigo = "", Nombre = "Seleccione" });

                this.cboCandidato.DataSource = lstCandidatos;
                this.cboCandidato.DisplayMember = "Nombre";
                this.cboCandidato.ValueMember = "Codigo";
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

    }
}

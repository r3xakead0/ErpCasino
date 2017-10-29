using System;
using System.Windows.Forms;
using System.Drawing;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;
using System.ComponentModel;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmPostulanteList : Form
    {

        #region "Patron Singleton"

        private static FrmPostulanteList frmInstance = null;

        public static FrmPostulanteList Instance()
        {

            if (frmInstance == null || frmInstance.IsDisposed == true)
            {
                frmInstance = new FrmPostulanteList();
            }

            frmInstance.BringToFront();

            return frmInstance;
        }

        #endregion

        public FrmPostulanteList()
        {
            InitializeComponent();
        }

        #region Formulario
        private void FrmPostulanteList_Load(object sender, EventArgs e)
        {
            try
            {
                this.CargarPostulantes();
                this.FormatoPostulantes();

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
                var frmPostulanteNew = FrmPostulanteMant.Instance();
                frmPostulanteNew.MdiParent = this.MdiParent;
                frmPostulanteNew.Show();

                frmPostulanteNew.Cargar();
                frmPostulanteNew.frmList = this;
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

                if (this.dgvPostulantes.CurrentRow != null)
                {
                    var uiPostulante = (BE.UI.Postulante)this.dgvPostulantes.CurrentRow.DataBoundItem;

                    var bePostulante = new LN.Postulante().Obtener(uiPostulante.Id);

                    var frmPostulanteEdit = FrmPostulanteMant.Instance();
                    frmPostulanteEdit.MdiParent = this.MdiParent;
                    frmPostulanteEdit.Show();

                    frmPostulanteEdit.Cargar(bePostulante);
                    frmPostulanteEdit.frmList = this;
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
                if (this.dgvPostulantes.CurrentRow != null)
                {

                    if (Util.ConfirmationMessage("¿Desea eliminar al Postulante seleccionado?") == false)
                        return;

                    var uiPostulante = (BE.UI.Postulante)this.dgvPostulantes.CurrentRow.DataBoundItem;

                    var lnPostulante = new LN.Postulante();

                    var bePostulante = lnPostulante.Obtener(uiPostulante.Id);
                    if (bePostulante == null)
                        return;

                    bool rpta = lnPostulante.Eliminar(bePostulante);
                    if (rpta)
                    {
                        Util.InformationMessage("Se elimino el postulante seleccionado");
                        this.CargarPostulantes();
                    }

                    
                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void BtnCandidato_Click(object sender, EventArgs e)
        {

            try
            {
                if (this.dgvPostulantes.CurrentRow != null)
                {
                    var uiPostulante = (BE.UI.Postulante)this.dgvPostulantes.CurrentRow.DataBoundItem;

                    #region Validaciones

                    var candidato = uiPostulante.Candidato == "Si" ? true : false;

                    if (candidato == true)
                    {
                        Util.ErrorMessage("El Postulante ya se le canditeo");
                        return;
                    }

                    #endregion

                    if (Util.ConfirmationMessage("¿Desea contratar al Postulante seleccionado?") == false)
                        return;

                    var frmCandidatoContratar = new FrmCandidatoMant();
                    frmCandidatoContratar.MdiParent = this.MdiParent;
                    frmCandidatoContratar.Show();

                    var bePostulante = new LN.Postulante().Obtener(uiPostulante.Id);
                    frmCandidatoContratar.Contratar(bePostulante);

                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        #endregion

        private void dgvPostulante_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                var col = dgvPostulantes.Columns[e.ColumnIndex];
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

                dgvPostulantes.Sort(col, dir);
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void FrmPostulanteList_ResizeEnd(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvPostulantes.DataSource != null)
                    Util.AutoWidthColumn(ref this.dgvPostulantes, "EstadoDescipcion");
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        #region Metodos
        public void CargarPostulantes()
        {
            try
            {
                var lstPostulantes = new LN.Postulante().Listar();
                var nroPostulantes = lstPostulantes.Count.ToString();

                var sorted = new SortableBindingList<BE.UI.Postulante>(lstPostulantes);

                this.dgvPostulantes.DataSource = sorted;
                this.txtNroPostulantes.Text = nroPostulantes;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FormatoPostulantes()
        {
            try
            {
                Util.FormatDatagridview(ref dgvPostulantes);

                for (int col = 0; col < this.dgvPostulantes.Columns.Count; col++)
                    this.dgvPostulantes.Columns[col].Visible = false;

                this.dgvPostulantes.Columns["DocumentoCodigo"].Visible = true;
                this.dgvPostulantes.Columns["DocumentoCodigo"].HeaderText = "Documento";
                this.dgvPostulantes.Columns["DocumentoCodigo"].Width = 70;

                this.dgvPostulantes.Columns["DocumentoNumero"].Visible = true;
                this.dgvPostulantes.Columns["DocumentoNumero"].HeaderText = "Numero";
                this.dgvPostulantes.Columns["DocumentoNumero"].Width = 70;

                this.dgvPostulantes.Columns["Nombres"].Visible = true;
                this.dgvPostulantes.Columns["Nombres"].HeaderText = "Nombres";
                this.dgvPostulantes.Columns["Nombres"].Width = 120;

                this.dgvPostulantes.Columns["Apellidos"].Visible = true;
                this.dgvPostulantes.Columns["Apellidos"].HeaderText = "Apellidos";
                this.dgvPostulantes.Columns["Apellidos"].Width = 120;

                this.dgvPostulantes.Columns["SexoNombre"].Visible = true;
                this.dgvPostulantes.Columns["SexoNombre"].HeaderText = "Sexo";
                this.dgvPostulantes.Columns["SexoNombre"].Width = 70;

                this.dgvPostulantes.Columns["Activo"].Visible = true;
                this.dgvPostulantes.Columns["Activo"].HeaderText = "Activo";
                this.dgvPostulantes.Columns["Activo"].Width = 70;
                this.dgvPostulantes.Columns["Activo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.dgvPostulantes.Columns["Candidato"].Visible = true;
                this.dgvPostulantes.Columns["Candidato"].HeaderText = "Candidato";
                this.dgvPostulantes.Columns["Candidato"].Width = 70;
                this.dgvPostulantes.Columns["Candidato"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvPostulantes.Columns["Candidato"].DefaultCellStyle.BackColor = Color.Yellow;
                
                this.dgvPostulantes.Columns["EstadoDescipcion"].Visible = true;
                this.dgvPostulantes.Columns["EstadoDescipcion"].HeaderText = "Estado";
                this.dgvPostulantes.Columns["EstadoDescipcion"].Width = 200;
                this.dgvPostulantes.Columns["EstadoDescipcion"].DefaultCellStyle.BackColor = Color.Yellow;

                Util.AutoWidthColumn(ref dgvPostulantes, "EstadoDescipcion");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        
    }
}

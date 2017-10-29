using System;
using System.Windows.Forms;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;
using System.ComponentModel;
using System.Drawing;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmCandidatoList : Form
    {

        #region "Patron Singleton"

        private static FrmCandidatoList frmInstance = null;

        public static FrmCandidatoList Instance()
        {

            if (frmInstance == null || frmInstance.IsDisposed == true)
            {
                frmInstance = new FrmCandidatoList();
            }

            frmInstance.BringToFront();

            return frmInstance;
        }

        #endregion

        public FrmCandidatoList()
        {
            InitializeComponent();
        }

        #region Formulario
        private void FrmCandidatoList_Load(object sender, EventArgs e)
        {
            try
            {

                this.CargarCandidatos();
                this.FormatoCandidatos();

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

                var frmCandidatoNew = FrmCandidatoMant.Instance();
                frmCandidatoNew.MdiParent = this.MdiParent;
                frmCandidatoNew.Show();

                frmCandidatoNew.Cargar();
                frmCandidatoNew.frmList = this;
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

                if (this.dgvCandidatos.CurrentRow != null)
                {
                    var uiCandidato = (BE.UI.Candidato)this.dgvCandidatos.CurrentRow.DataBoundItem;

                    var frmCandidatoEdit = FrmCandidatoMant.Instance();
                    frmCandidatoEdit.MdiParent = this.MdiParent;
                    frmCandidatoEdit.Show();

                    frmCandidatoEdit.frmList = this;

                    var beCandidato = new LN.Candidato().Obtener(uiCandidato.Id);
                    frmCandidatoEdit.Cargar(beCandidato);
                    
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
                if (this.dgvCandidatos.CurrentRow != null)
                {

                    if (Util.ConfirmationMessage("¿Desea eliminar al Candidato seleccionado?") == false)
                        return;

                    var uiCandidato = (BE.UI.Candidato)this.dgvCandidatos.CurrentRow.DataBoundItem;

                    var lnCandidato = new LN.Candidato();

                    var beCandidato = lnCandidato.Obtener(uiCandidato.Id);
                    bool rpta = lnCandidato.Eliminar(beCandidato);

                    if (rpta)
                    {
                        Util.InformationMessage("Se elimino el candidato seleccionado");
                        this.CargarCandidatos();
                    }

                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }
        private void BtnContratar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvCandidatos.CurrentRow != null)
                {
                    var uiCandidato = (BE.UI.Candidato)this.dgvCandidatos.CurrentRow.DataBoundItem;

                    #region Validar Contratacion

                    var activo = uiCandidato.Activo == "Si" ? true : false;
                    var induccion = uiCandidato.Induccion == "Si" ? true : false;
                    var disciplina = uiCandidato.Disciplina == "Si" ? true : false;
                    var informe = uiCandidato.Informe == "Si" ? true : false;
                    var documento = uiCandidato.Documentacion == "Si" ? true : false;
                    var contratado = uiCandidato.Contratado == "Si" ? true : false;

                    if (activo == false || 
                        induccion == false ||
                        disciplina == false ||
                        informe == false ||
                        documento == false)
                    {
                        Util.ErrorMessage("No cumplio los requisitos para contratación");
                        return;
                    }

                    if (contratado == true)
                    {
                        Util.ErrorMessage("El candidato ya se le contrato");
                        return;
                    }

                    #endregion

                    if (Util.ConfirmationMessage("¿Desea contratar al Candidato seleccionado?") == false)
                        return;

                    var frmEmpleadoContratar = new FrmEmpleadoMant();
                    frmEmpleadoContratar.MdiParent = this.MdiParent;
                    frmEmpleadoContratar.Show();

                    var beCandidato = new LN.Candidato().Obtener(uiCandidato.Id);
                    frmEmpleadoContratar.Contratar(beCandidato);

                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void dgvCandidato_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                var col = dgvCandidatos.Columns[e.ColumnIndex];
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

                dgvCandidatos.Sort(col, dir);
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        #endregion

        #region Metodos
        public void CargarCandidatos()
        {
            try
            {
                var lstCandidatos = new LN.Candidato().Listar();
                var nroCandidatos = lstCandidatos.Count.ToString();

                var sorted = new SortableBindingList<BE.UI.Candidato>(lstCandidatos);

                this.dgvCandidatos.DataSource = sorted;
                this.txtNroCandidatos.Text = nroCandidatos;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FormatoCandidatos()
        {
            try
            {
                Util.FormatDatagridview(ref dgvCandidatos);

                for (int col = 0; col < this.dgvCandidatos.Columns.Count; col++)
                    this.dgvCandidatos.Columns[col].Visible = false;

                this.dgvCandidatos.Columns["Codigo"].Visible = true;
                this.dgvCandidatos.Columns["Codigo"].HeaderText = "Codigo";
                this.dgvCandidatos.Columns["Codigo"].Width = 80;

                this.dgvCandidatos.Columns["Nombres"].Visible = true;
                this.dgvCandidatos.Columns["Nombres"].HeaderText = "Nombres";
                this.dgvCandidatos.Columns["Nombres"].Width = 150;

                this.dgvCandidatos.Columns["Apellidos"].Visible = true;
                this.dgvCandidatos.Columns["Apellidos"].HeaderText = "Apellidos";
                this.dgvCandidatos.Columns["Apellidos"].Width = 150;

                this.dgvCandidatos.Columns["SexoNombre"].Visible = true;
                this.dgvCandidatos.Columns["SexoNombre"].HeaderText = "Sexo";
                this.dgvCandidatos.Columns["SexoNombre"].Width = 70;

                this.dgvCandidatos.Columns["Activo"].Visible = true;
                this.dgvCandidatos.Columns["Activo"].HeaderText = "Activo";
                this.dgvCandidatos.Columns["Activo"].Width = 50;
                this.dgvCandidatos.Columns["Activo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.dgvCandidatos.Columns["Induccion"].Visible = true;
                this.dgvCandidatos.Columns["Induccion"].HeaderText = "Induccion";
                this.dgvCandidatos.Columns["Induccion"].Width = 90;
                
                this.dgvCandidatos.Columns["Disciplina"].Visible = true;
                this.dgvCandidatos.Columns["Disciplina"].HeaderText = "Disciplina";
                this.dgvCandidatos.Columns["Disciplina"].Width = 90;
                
                this.dgvCandidatos.Columns["Informe"].Visible = true;
                this.dgvCandidatos.Columns["Informe"].HeaderText = "Informe";
                this.dgvCandidatos.Columns["Informe"].Width = 90;
                
                this.dgvCandidatos.Columns["Documentacion"].Visible = true;
                this.dgvCandidatos.Columns["Documentacion"].HeaderText = "Documentacion";
                this.dgvCandidatos.Columns["Documentacion"].Width = 90;
                
                this.dgvCandidatos.Columns["Contratado"].Visible = true;
                this.dgvCandidatos.Columns["Contratado"].HeaderText = "Contratado";
                this.dgvCandidatos.Columns["Contratado"].Width = 90;

                int colInicioEstados = this.dgvCandidatos.Columns["Induccion"].Index;
                int colFinalEstados = this.dgvCandidatos.Columns["Contratado"].Index;
                for (int i = colInicioEstados; i <= colFinalEstados; i++)
                {
                    this.dgvCandidatos.Columns[i].DefaultCellStyle.BackColor = Color.Yellow;
                    this.dgvCandidatos.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                Util.AutoWidthColumn(ref dgvCandidatos, "Apellidos");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


    }
}

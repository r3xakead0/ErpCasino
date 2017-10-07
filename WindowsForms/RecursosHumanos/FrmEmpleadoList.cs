using System;
using System.Windows.Forms;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmEmpleadoList : Form
    {
        public FrmEmpleadoList()
        {
            InitializeComponent();
        }

        #region Formulario
        private void FrmEmpleadoList_Load(object sender, EventArgs e)
        {
            try
            {

                this.CargarTiposFiltro();
                this.CargarFiltros();

                this.CargarEmpleados();
                this.FormatoEmpleados();

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void dgvEmpleados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;

                var uiEmpleado = (BE.UI.Empleado)this.dgvEmpleados.Rows[e.RowIndex].DataBoundItem;

                this.Editar(uiEmpleado);
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void cboFiltro_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                string filtro = this.cboTipoFiltro.SelectedValue.ToString();
                string valor = this.cboFiltro.SelectedValue.ToString();

                this.CargarEmpleados(filtro, valor);
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void cboTipoFiltro_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                string filtro = this.cboTipoFiltro.SelectedValue.ToString();

                this.CargarFiltros(filtro);

                if (filtro.Length == 0)
                    this.CargarEmpleados();
                
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
                var frmEmpleadoNew = new FrmEmpleadoMant();
                frmEmpleadoNew.MdiParent = this.MdiParent;
                frmEmpleadoNew.Show();
                frmEmpleadoNew.Cargar(null);
                frmEmpleadoNew.frmList = this;
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void FrmEmpleadoList_ResizeEnd(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvEmpleados.DataSource != null)
                    Util.AutoWidthColumn(ref this.dgvEmpleados, "Apellidos");
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

                if (this.dgvEmpleados.CurrentRow != null)
                {
                    var uiEmpleado = (BE.UI.Empleado)this.dgvEmpleados.CurrentRow.DataBoundItem;

                    this.Editar(uiEmpleado);
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
                if (this.dgvEmpleados.CurrentRow != null)
                {

                    if (Util.ConfirmationMessage("¿Desea eliminar al empleado seleccionado?") == false)
                        return;

                    var uiEmpleado = (BE.UI.Empleado)this.dgvEmpleados.CurrentRow.DataBoundItem;

                    var beEmpleado = new LN.Empleado().Obtener(uiEmpleado.Id);
                    bool rpta = new LN.Empleado().Eliminar(beEmpleado);

                    if (true)
                    {
                        Util.InformationMessage("Se elimino el empleado seleccionado");
                        this.CargarEmpleados();
                    }

                    
                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void dgvEmpleado_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                var col = dgvEmpleados.Columns[e.ColumnIndex];
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

                dgvEmpleados.Sort(col, dir);
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }
        #endregion

        #region Metodos

        private void Editar(BE.UI.Empleado uiEmpleado)
        {
            try
            {
                var beEmpleado = new LN.Empleado().Obtener(uiEmpleado.Id);

                var frmEmpleadoEdit = new FrmEmpleadoMant();
                frmEmpleadoEdit.MdiParent = this.MdiParent;
                frmEmpleadoEdit.Show();
                frmEmpleadoEdit.Cargar(beEmpleado);
                frmEmpleadoEdit.frmList = this;
            }
            catch (Exception ex)
            {
                throw ex;
                throw;
            }
        }

        private void CargarFiltros(string codigo = "")
        {
            var lstFiltro = new List<BE.Record>();

            switch (codigo)
            {
                case "1": //Documento
                    lstFiltro = new LN.Record().ListarTipoDocumento();
                    break;
                case "2": //Sala
                    var lstBeSalas = new LN.Sala().ListaSimple();
                    foreach (BE.Sala beSala in lstBeSalas)
                    {
                        lstFiltro.Add(new BE.Record()
                        {
                            Codigo = beSala.IdSala.ToString(),
                            Nombre = beSala.Nombre
                        });
                    }
                    break;
                case "3": //Sexo
                    lstFiltro = new LN.Record().ListarSexos();
                    break;
                case "4": //Activo
                    lstFiltro.Add(new BE.Record() { Codigo = "Si", Nombre = "Si" });
                    lstFiltro.Add(new BE.Record() { Codigo = "No", Nombre = "No" });
                    break;
                case "5": //Cargo
                    var lstUiCargos = new LN.Cargo().Listar();
                    foreach (BE.UI.Cargo uiCargo in lstUiCargos)
                    {
                        lstFiltro.Add(new BE.Record() {
                            Codigo = uiCargo.Id.ToString(),
                            Nombre = uiCargo.Nombre
                        });
                    }
                    break;
                default: //Todos
                    break;
            }

            lstFiltro.Insert(0, new BE.Record() { Codigo = "", Nombre = "Todos" });

            this.cboFiltro.DataSource = lstFiltro;
            this.cboFiltro.DisplayMember = "Nombre";
            this.cboFiltro.ValueMember = "Codigo";
        }

        private void CargarTiposFiltro()
        {
            var lstTipos = new List<BE.Record>();

            lstTipos.Add(new BE.Record() { Codigo = "", Nombre = "Todos" });
            lstTipos.Add(new BE.Record() { Codigo = "1", Nombre = "Documento" });
            lstTipos.Add(new BE.Record() { Codigo = "2", Nombre = "Sala" });
            lstTipos.Add(new BE.Record() { Codigo = "3", Nombre = "Sexo" });
            lstTipos.Add(new BE.Record() { Codigo = "4", Nombre = "Activo" });
            lstTipos.Add(new BE.Record() { Codigo = "5", Nombre = "Cargo" });

            this.cboTipoFiltro.DataSource = lstTipos;
            this.cboTipoFiltro.DisplayMember = "Nombre";
            this.cboTipoFiltro.ValueMember = "Codigo";
        }

        public void CargarEmpleados(string filtro = "", string valor = "", int idEmpleado = 0)
        {
            try
            {
                Util.PointerLoad(this);

                var lstEmpleados = new LN.Empleado().Listar();

                if (valor.Length > 0)
                {
                    switch (filtro)
                    {
                        case "1": //Documento
                            lstEmpleados = lstEmpleados.Where(x => x.DocumentoCodigo == valor).ToList();
                            break;
                        case "2": //Sala
                            int idSala = int.Parse(valor);
                            lstEmpleados = lstEmpleados.Where(x => x.SalaId == idSala).ToList();
                            break;
                        case "3": //Sexo
                            lstEmpleados = lstEmpleados.Where(x => x.SexoCodigo == valor).ToList();
                            break;
                        case "4": //Activo
                            lstEmpleados = lstEmpleados.Where(x => x.Activo == valor).ToList();
                            break;
                        case "5": //Cargo
                            int idCargo = int.Parse(valor);
                            lstEmpleados = lstEmpleados.Where(x => x.CargoId == idCargo).ToList();
                            break;
                        default: //Todos
                            break;
                    }
                }

                var nroEmpleados = lstEmpleados.Count.ToString();

                var sorted = new SortableBindingList<BE.UI.Empleado>(lstEmpleados);        

                this.dgvEmpleados.DataSource = sorted;
                this.txtNroEmpleados.Text = nroEmpleados;

                if (idEmpleado > 0)
                {
                    this.dgvEmpleados.Rows.OfType<DataGridViewRow>().Where(x => (int)x.Cells["Id"].Value == idEmpleado).ToArray<DataGridViewRow>()[0].Selected = true;
                    this.dgvEmpleados.FirstDisplayedScrollingRowIndex = this.dgvEmpleados.SelectedRows[0].Index;
                    this.dgvEmpleados.Update();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Util.PointerReady(this);
            }
        }

        private void FormatoEmpleados()
        {
            try
            {
                Util.FormatDatagridview(ref dgvEmpleados);

                for (int col = 0; col < this.dgvEmpleados.Columns.Count; col++)
                    this.dgvEmpleados.Columns[col].Visible = false;

                this.dgvEmpleados.Columns["DocumentoCodigo"].Visible = true;
                this.dgvEmpleados.Columns["DocumentoCodigo"].HeaderText = "Documento";
                this.dgvEmpleados.Columns["DocumentoCodigo"].Width = 70;

                this.dgvEmpleados.Columns["DocumentoNumero"].Visible = true;
                this.dgvEmpleados.Columns["DocumentoNumero"].HeaderText = "Numero";
                this.dgvEmpleados.Columns["DocumentoNumero"].Width = 70;

                this.dgvEmpleados.Columns["Codigo"].Visible = true;
                this.dgvEmpleados.Columns["Codigo"].HeaderText = "Codigo";
                this.dgvEmpleados.Columns["Codigo"].Width = 80;

                this.dgvEmpleados.Columns["Nombres"].Visible = true;
                this.dgvEmpleados.Columns["Nombres"].HeaderText = "Nombres";
                this.dgvEmpleados.Columns["Nombres"].Width = 150;

                this.dgvEmpleados.Columns["Apellidos"].Visible = true;
                this.dgvEmpleados.Columns["Apellidos"].HeaderText = "Apellidos";
                this.dgvEmpleados.Columns["Apellidos"].Width = 150;

                this.dgvEmpleados.Columns["SalaNombre"].Visible = true;
                this.dgvEmpleados.Columns["SalaNombre"].HeaderText = "Sala";
                this.dgvEmpleados.Columns["SalaNombre"].Width = 70;

                this.dgvEmpleados.Columns["CargoNombre"].Visible = true;
                this.dgvEmpleados.Columns["CargoNombre"].HeaderText = "Cargo";
                this.dgvEmpleados.Columns["CargoNombre"].Width = 120;

                this.dgvEmpleados.Columns["SexoNombre"].Visible = true;
                this.dgvEmpleados.Columns["SexoNombre"].HeaderText = "Sexo";
                this.dgvEmpleados.Columns["SexoNombre"].Width = 70;

                this.dgvEmpleados.Columns["Activo"].Visible = true;
                this.dgvEmpleados.Columns["Activo"].HeaderText = "Activo";
                this.dgvEmpleados.Columns["Activo"].Width = 50;
                this.dgvEmpleados.Columns["Activo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                Util.AutoWidthColumn(ref dgvEmpleados, "Apellidos");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        #endregion

    }
}

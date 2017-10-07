using System;
using System.Windows.Forms;
using System.Collections.Generic;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;
using System.Drawing;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmCargoMant : Form
    {

        private string valorInicialNombre = "";
        private string valorInicialDescripcion = "";

        private Color ColorFilaModificada = Color.LightGoldenrodYellow;

        private List<BE.UI.Cargo> lstUiCargos = new List<BE.UI.Cargo>();

        private List<BE.UI.Cargo> lstCreados = new List<BE.UI.Cargo>();
        private List<BE.UI.Cargo> lstModificados = new List<BE.UI.Cargo>();
        private List<BE.UI.Cargo> lstEliminados = new List<BE.UI.Cargo>();

        public FrmCargoMant()
        {
            InitializeComponent();
        }

        #region Formulario
        private void FrmCargoMant_Load(object sender, EventArgs e)
        {
            try
            {
                var uiCargo = new BE.UI.Cargo();
                this.valorInicialNombre = uiCargo.Nombre;
                this.valorInicialDescripcion = uiCargo.Descripcion;
                
                this.CargarListadoCargos();
                
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void FrmCargoMant_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                int cntCreados = this.lstCreados.Count;
                int cntModificados = this.lstModificados.Count;
                int cntEliminar = this.lstEliminados.Count;
                if (cntCreados + cntModificados + cntEliminar > 0)
                {
                    if (Util.ConfirmationMessage("¿Desea salir sin guardar los cambios realizados?") == false)
                    {
                        e.Cancel = true;
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void dgvCargoes_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dgvCargos.IsCurrentRowDirty)
                {
                    var uiCargo = (BE.UI.Cargo)this.dgvCargos.CurrentRow.DataBoundItem;

                    if (uiCargo.Nombre.Equals(this.valorInicialNombre) 
                        || uiCargo.Descripcion.Equals(this.valorInicialDescripcion))
                    {
                        this.dgvCargos.AllowUserToAddRows = false;
                        return;
                    }
                    else
                    {
                        this.dgvCargos.AllowUserToAddRows = true;
                    }

                    if (uiCargo.Id > 0)
                    {
                        if (this.lstModificados.Contains(uiCargo) == false)
                            this.lstModificados.Add(uiCargo);
                    }
                    else
                    {
                        if (this.lstCreados.Contains(uiCargo) == false)
                            this.lstCreados.Add(uiCargo);
                    }

                    this.dgvCargos.CurrentRow.DefaultCellStyle.BackColor = this.ColorFilaModificada;

                    this.dgvCargos.EndEdit();
                }
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
                if (Util.ConfirmationMessage("¿Desea guardar los cambios realizados?") == false)
                    return;

                //Util.ConfirmationMessage("Cant. Creados : " + this.lstCreados.Count);
                //Util.ConfirmationMessage("Cant. Modificados : " + this.lstModificados.Count);
                //Util.ConfirmationMessage("Cant. Eliminados : " + this.lstEliminados.Count);

                bool rpta = false;
                var lnCargo = new LN.Cargo();

                for (int i = 0; i < this.lstCreados.Count; i++)
                {
                    var uiCargoCreada = this.lstCreados[i];
                    rpta = lnCargo.Insertar(ref uiCargoCreada);
                }

                this.lstCreados.Clear();

                for (int i = 0; i < this.lstModificados.Count; i++)
                {
                    var uiCargoModificado = this.lstModificados[i];
                    rpta = lnCargo.Actualizar(uiCargoModificado);
                }

                this.lstModificados.Clear();

                for (int i = 0; i < this.lstEliminados.Count; i++)
                {
                    int idCargo = this.lstEliminados[i].Id;
                    rpta = lnCargo.Eliminar(idCargo);
                }

                this.lstEliminados.Clear();

                this.CargarListadoCargos();

                Util.InformationMessage("Se guardaron todos los cambios realizados");
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

                try
                {
                    if (this.dgvCargos.CurrentRow != null)
                    {

                        var uiCargo = (BE.UI.Cargo)this.dgvCargos.CurrentRow.DataBoundItem;

                        if (Util.ConfirmationMessage("¿Desea eliminar la observación seleccionada?") == false)
                            return;

                        if (uiCargo.Id > 0)
                        {
                            this.lstEliminados.Add(uiCargo);
                        }

                        this.lstCreados.Remove(uiCargo);
                        this.lstModificados.Remove(uiCargo);

                        this.dgvCargos.Rows.RemoveAt(this.dgvCargos.CurrentRow.Index);
                    }
                }
                catch (Exception ex)
                {
                    Util.ErrorMessage(ex.Message);
                }

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }
        
        #endregion

        #region Metodos
        
        private void CargarListadoCargos()
        {
            try
            {
                this.lstUiCargos = new LN.Cargo().Listar();
                
                var source = new BindingSource();
                source.DataSource = lstUiCargos;

                this.dgvCargos.Columns.Clear();
                this.dgvCargos.AutoGenerateColumns = false;
                this.dgvCargos.AutoSize = true;
                this.dgvCargos.DataSource = source;
                this.dgvCargos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                DataGridViewColumn colNombre = new DataGridViewTextBoxColumn();
                colNombre.DataPropertyName = "Nombre";
                colNombre.Name = "Nombre";
                colNombre.Width = 200;
                this.dgvCargos.Columns.Add(colNombre);

                DataGridViewColumn colDescripcion = new DataGridViewTextBoxColumn();
                colDescripcion.DataPropertyName = "Descripcion";
                colDescripcion.Name = "Descripcion";
                colDescripcion.Width = 300;
                this.dgvCargos.Columns.Add(colDescripcion);

                DataGridViewColumn colBono = new DataGridViewTextBoxColumn();
                colBono.DataPropertyName = "Bono";
                colBono.Name = "Bono";
                colBono.Width = 100;
                colBono.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                colBono.DefaultCellStyle.Format = "N2";
                this.dgvCargos.Columns.Add(colBono);

                DataGridViewColumn colActivo = new DataGridViewCheckBoxColumn();
                colActivo.DataPropertyName = "Activo";
                colActivo.Name = "Activo";
                colActivo.Width = 70;
                this.dgvCargos.Columns.Add(colActivo);

                Util.AutoWidthColumn(ref this.dgvCargos, "Descripcion");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void dgvCargos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvCargos.Columns[dgvCargos.CurrentCell.ColumnIndex].Name == "Monto")
            {
                e.Control.KeyPress += new KeyPressEventHandler(dgvCargos_KeyPress);
                e.Control.Leave += new EventHandler(dgvCargos_Leave);
            }
        }

        private void dgvCargos_Leave(object sender, EventArgs e)
        {
            if (dgvCargos.Columns[dgvCargos.CurrentCell.ColumnIndex].Name == "Monto")
            {
                (sender as DataGridViewTextBoxEditingControl).KeyPress -= new KeyPressEventHandler(dgvCargos_KeyPress);
            }
        }

        private void dgvCargos_KeyPress(object sender, KeyPressEventArgs e)
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

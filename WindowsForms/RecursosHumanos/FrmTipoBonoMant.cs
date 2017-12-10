using System;
using System.Windows.Forms;
using System.Collections.Generic;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;
using System.Drawing;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmTipoBonoMant : Form
    {

        private string valorInicialNombre = "";
        private string valorInicialDescripcion = "";

        private Color ColorFilaModificada = Color.LightGoldenrodYellow;

        private List<BE.UI.Bono> lstUiBonoes = new List<BE.UI.Bono>();

        private List<BE.UI.Bono> lstCreados = new List<BE.UI.Bono>();
        private List<BE.UI.Bono> lstModificados = new List<BE.UI.Bono>();
        private List<BE.UI.Bono> lstEliminados = new List<BE.UI.Bono>();

        public FrmTipoBonoMant()
        {
            InitializeComponent();
        }

        #region Formulario
        private void FrmTipoBonoMant_Load(object sender, EventArgs e)
        {
            try
            {
                var uiBono = new BE.UI.Bono();
                this.valorInicialNombre = uiBono.Nombre;
                this.valorInicialDescripcion = uiBono.Descripcion;
                
                this.CargarListadoBonos();
                
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void FrmTipoBonoMant_FormClosing(object sender, FormClosingEventArgs e)
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

        private void dgvBonoes_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dgvBonos.IsCurrentRowDirty)
                {
                    var uiBono = (BE.UI.Bono)this.dgvBonos.CurrentRow.DataBoundItem;

                    if (uiBono.Nombre.Equals(this.valorInicialNombre) 
                        || uiBono.Descripcion.Equals(this.valorInicialDescripcion))
                    {
                        this.dgvBonos.AllowUserToAddRows = false;
                        return;
                    }
                    else
                    {
                        this.dgvBonos.AllowUserToAddRows = true;
                    }

                    if (uiBono.Id > 0)
                    {
                        if (this.lstModificados.Contains(uiBono) == false)
                            this.lstModificados.Add(uiBono);
                    }
                    else
                    {
                        if (this.lstCreados.Contains(uiBono) == false)
                            this.lstCreados.Add(uiBono);
                    }

                    this.dgvBonos.CurrentRow.DefaultCellStyle.BackColor = this.ColorFilaModificada;

                    this.dgvBonos.EndEdit();
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
                var lnBono = new LN.Bono();

                for (int i = 0; i < this.lstCreados.Count; i++)
                {
                    var uiBonoCreada = this.lstCreados[i];
                    rpta = lnBono.Insertar(ref uiBonoCreada);
                }

                this.lstCreados.Clear();

                for (int i = 0; i < this.lstModificados.Count; i++)
                {
                    var uiBonoModificado = this.lstModificados[i];
                    rpta = lnBono.Actualizar(uiBonoModificado);
                }

                this.lstModificados.Clear();

                for (int i = 0; i < this.lstEliminados.Count; i++)
                {
                    int idBono = this.lstEliminados[i].Id;
                    rpta = lnBono.Eliminar(idBono);
                }

                this.lstEliminados.Clear();

                this.CargarListadoBonos();

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
                if (this.dgvBonos.CurrentRow != null)
                {

                    var uiBono = (BE.UI.Bono)this.dgvBonos.CurrentRow.DataBoundItem;

                    if (uiBono.Calculado == true)
                        throw new Exception("No se puede eliminar una bono calculado");

                    if (Util.ConfirmationMessage("¿Desea eliminar el bono seleccionado?") == false)
                        return;

                    if (uiBono.Id > 0)
                    {
                        this.lstEliminados.Add(uiBono);
                    }

                    this.lstCreados.Remove(uiBono);
                    this.lstModificados.Remove(uiBono);

                    this.dgvBonos.Rows.RemoveAt(this.dgvBonos.CurrentRow.Index);
                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }

        }
        
        #endregion

        #region Metodos
        
        private void CargarListadoBonos()
        {
            try
            {
                this.lstUiBonoes = new LN.Bono().Listar();
                
                var source = new BindingSource();
                source.DataSource = lstUiBonoes;

                this.dgvBonos.Columns.Clear();
                this.dgvBonos.AutoGenerateColumns = false;
                this.dgvBonos.AutoSize = true;
                this.dgvBonos.DataSource = source;
                this.dgvBonos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                DataGridViewColumn colNombre = new DataGridViewTextBoxColumn();
                colNombre.DataPropertyName = "Nombre";
                colNombre.Name = "Nombre";
                colNombre.Width = 200;
                this.dgvBonos.Columns.Add(colNombre);

                DataGridViewColumn colDescripcion = new DataGridViewTextBoxColumn();
                colDescripcion.DataPropertyName = "Descripcion";
                colDescripcion.Name = "Descripcion";
                colDescripcion.Width = 300;
                this.dgvBonos.Columns.Add(colDescripcion);

                DataGridViewColumn colMonto = new DataGridViewTextBoxColumn();
                colMonto.DataPropertyName = "Monto";
                colMonto.Name = "Monto";
                colMonto.Width = 100;
                colMonto.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                colMonto.DefaultCellStyle.Format = "N2";
                this.dgvBonos.Columns.Add(colMonto);

                DataGridViewColumn colActivo = new DataGridViewCheckBoxColumn();
                colActivo.DataPropertyName = "Activo";
                colActivo.Name = "Activo";
                colActivo.Width = 70;
                this.dgvBonos.Columns.Add(colActivo);

                Util.AutoWidthColumn(ref this.dgvBonos, "Descripcion");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void dgvBonos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvBonos.Columns[dgvBonos.CurrentCell.ColumnIndex].Name == "Monto")
            {
                e.Control.KeyPress += new KeyPressEventHandler(dgvBonos_KeyPress);
                e.Control.Leave += new EventHandler(dgvBonos_Leave);
            }
        }

        private void dgvBonos_Leave(object sender, EventArgs e)
        {
            if (dgvBonos.Columns[dgvBonos.CurrentCell.ColumnIndex].Name == "Monto")
            {
                (sender as DataGridViewTextBoxEditingControl).KeyPress -= new KeyPressEventHandler(dgvBonos_KeyPress);
            }
        }

        private void dgvBonos_KeyPress(object sender, KeyPressEventArgs e)
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

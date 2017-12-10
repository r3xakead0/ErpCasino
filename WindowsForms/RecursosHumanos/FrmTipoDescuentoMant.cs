using System;
using System.Windows.Forms;
using System.Collections.Generic;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;
using System.Drawing;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmTipoDescuentoMant : Form
    {

        #region "Patron Singleton"

        private static FrmTipoDescuentoMant frmInstance = null;

        public static FrmTipoDescuentoMant Instance()
        {

            if (frmInstance == null || frmInstance.IsDisposed == true)
            {
                frmInstance = new FrmTipoDescuentoMant();
            }

            frmInstance.BringToFront();

            return frmInstance;
        }

        #endregion

        private string valorInicialNombre = "";
        private string valorInicialDescripcion = "";

        private Color ColorFilaModificada = Color.LightGoldenrodYellow;

        private List<BE.UI.Descuento> lstUiDescuentos = new List<BE.UI.Descuento>();

        private List<BE.UI.Descuento> lstCreados = new List<BE.UI.Descuento>();
        private List<BE.UI.Descuento> lstModificados = new List<BE.UI.Descuento>();
        private List<BE.UI.Descuento> lstEliminados = new List<BE.UI.Descuento>();

        public FrmTipoDescuentoMant()
        {
            InitializeComponent();
        }

        #region Formulario
        private void FrmTipoDescuentoMant_Load(object sender, EventArgs e)
        {
            try
            {
                var uiDescuento = new BE.UI.Descuento();
                this.valorInicialNombre = uiDescuento.Nombre;
                this.valorInicialDescripcion = uiDescuento.Descripcion;
                uiDescuento = null;

                this.CargarListadoDescuentoes();
                
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void FrmTipoDescuentoMant_FormClosing(object sender, FormClosingEventArgs e)
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

        private void dgvDescuentos_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dgvDescuentos.IsCurrentRowDirty)
                {
                    var uiDescuento = (BE.UI.Descuento)this.dgvDescuentos.CurrentRow.DataBoundItem;

                    if (uiDescuento.Nombre.Equals(this.valorInicialNombre) 
                        || uiDescuento.Descripcion.Equals(this.valorInicialDescripcion))
                    {
                        this.dgvDescuentos.AllowUserToAddRows = false;
                        return;
                    }
                    else
                    {
                        this.dgvDescuentos.AllowUserToAddRows = true;
                    }

                    if (uiDescuento.Id > 0)
                    {
                        if (this.lstModificados.Contains(uiDescuento) == false)
                            this.lstModificados.Add(uiDescuento);
                    }
                    else
                    {
                        if (this.lstCreados.Contains(uiDescuento) == false)
                            this.lstCreados.Add(uiDescuento);
                    }

                    this.dgvDescuentos.CurrentRow.DefaultCellStyle.BackColor = this.ColorFilaModificada;

                    this.dgvDescuentos.EndEdit();
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

                bool rpta = false;
                var lnDescuento = new LN.Descuento();

                for (int i = 0; i < this.lstCreados.Count; i++)
                {
                    var uiDescuentoCreada = this.lstCreados[i];
                    rpta = lnDescuento.Insertar(ref uiDescuentoCreada);
                }

                this.lstCreados.Clear();

                for (int i = 0; i < this.lstModificados.Count; i++)
                {
                    var uiDescuentoModificado = this.lstModificados[i];
                    rpta = lnDescuento.Actualizar(uiDescuentoModificado);
                }

                this.lstModificados.Clear();

                for (int i = 0; i < this.lstEliminados.Count; i++)
                {
                    var uiDescuentoEliminado = this.lstEliminados[i];
                    rpta = lnDescuento.Eliminar(uiDescuentoEliminado);
                }

                this.lstEliminados.Clear();

                this.CargarListadoDescuentoes();

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
                if (this.dgvDescuentos.CurrentRow != null)
                {

                    if (Util.ConfirmationMessage("¿Desea eliminar el descuento seleccionado?") == false)
                        return;

                    var uiDescuento = (BE.UI.Descuento)this.dgvDescuentos.CurrentRow.DataBoundItem;

                    if (uiDescuento.Calculado == true)
                        throw new Exception("No se puede eliminar un descuento calculado");

                    if (uiDescuento.Id > 0)
                        this.lstEliminados.Add(uiDescuento);
                    
                    this.lstCreados.Remove(uiDescuento);
                    this.lstModificados.Remove(uiDescuento);

                    this.dgvDescuentos.Rows.RemoveAt(this.dgvDescuentos.CurrentRow.Index);
                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
            
        }
        
        #endregion

        #region Metodos
        
        private void CargarListadoDescuentoes()
        {
            try
            {
                this.lstUiDescuentos = new LN.Descuento().Listar();
                
                var source = new BindingSource();
                source.DataSource = lstUiDescuentos;

                this.dgvDescuentos.Columns.Clear();
                this.dgvDescuentos.AutoGenerateColumns = false;
                this.dgvDescuentos.AutoSize = true;
                this.dgvDescuentos.DataSource = source;
                this.dgvDescuentos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                var colNombre = new DataGridViewTextBoxColumn();
                colNombre.DataPropertyName = "Nombre";
                colNombre.Name = "Nombre";
                colNombre.Width = 200;
                this.dgvDescuentos.Columns.Add(colNombre);

                var colDescripcion = new DataGridViewTextBoxColumn();
                colDescripcion.DataPropertyName = "Descripcion";
                colDescripcion.Name = "Descripcion";
                colDescripcion.Width = 300;
                this.dgvDescuentos.Columns.Add(colDescripcion);

                var colMonto = new DataGridViewTextBoxColumn();
                colMonto.DataPropertyName = "Monto";
                colMonto.Name = "Monto";
                colMonto.Width = 70;
                colMonto.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                colMonto.DefaultCellStyle.Format = "N2";
                this.dgvDescuentos.Columns.Add(colMonto);

                var colActivo = new DataGridViewCheckBoxColumn();
                colActivo.DataPropertyName = "Activo";
                colActivo.Name = "Activo";
                colActivo.Width = 70;
                this.dgvDescuentos.Columns.Add(colActivo);

                Util.AutoWidthColumn(ref this.dgvDescuentos, "Descripcion");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion


    }
}

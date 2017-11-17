using System;
using System.Windows.Forms;
using System.Collections.Generic;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;
using System.Drawing;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmTipoObservacionMant : Form
    {

        private int idUsuario = 0;
        private string valorInicialNombre = "";
        private string valorInicialDescripcion = "";

        private Color ColorFilaModificada = Color.LightGoldenrodYellow;

        private List<BE.UI.Observacion> lstUiObservaciones = new List<BE.UI.Observacion>();

        private List<BE.UI.Observacion> lstCreados = new List<BE.UI.Observacion>();
        private List<BE.UI.Observacion> lstModificados = new List<BE.UI.Observacion>();
        private List<BE.UI.Observacion> lstEliminados = new List<BE.UI.Observacion>();

        public FrmTipoObservacionMant()
        {
            InitializeComponent();
        }

        #region Formulario
        private void FrmTipoObservacionMant_Load(object sender, EventArgs e)
        {
            try
            {
                this.idUsuario = 0;

                var uiObservacion = new BE.UI.Observacion();
                this.valorInicialNombre = uiObservacion.Nombre;
                this.valorInicialDescripcion = uiObservacion.Descripcion;
                uiObservacion = null;

                this.CargarListadoObservaciones();
                
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void FrmTipoObservacionMant_FormClosing(object sender, FormClosingEventArgs e)
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

        private void dgvObservaciones_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dgvObservaciones.IsCurrentRowDirty)
                {
                    var uiObservacion = (BE.UI.Observacion)this.dgvObservaciones.CurrentRow.DataBoundItem;

                    if (uiObservacion.Nombre.Equals(this.valorInicialNombre) 
                        || uiObservacion.Descripcion.Equals(this.valorInicialDescripcion))
                    {
                        this.dgvObservaciones.AllowUserToAddRows = false;
                        return;
                    }
                    else
                    {
                        this.dgvObservaciones.AllowUserToAddRows = true;
                    }

                    if (uiObservacion.Id > 0)
                    {
                        if (this.lstModificados.Contains(uiObservacion) == false)
                            this.lstModificados.Add(uiObservacion);
                    }
                    else
                    {
                        if (this.lstCreados.Contains(uiObservacion) == false)
                            this.lstCreados.Add(uiObservacion);
                    }

                    this.dgvObservaciones.CurrentRow.DefaultCellStyle.BackColor = this.ColorFilaModificada;

                    this.dgvObservaciones.EndEdit();
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
                var lnObservacion = new LN.Observacion(this.idUsuario);

                for (int i = 0; i < this.lstCreados.Count; i++)
                {
                    var uiObservacionCreada = this.lstCreados[i];
                    rpta = lnObservacion.Insertar(ref uiObservacionCreada);
                }

                this.lstCreados.Clear();

                for (int i = 0; i < this.lstModificados.Count; i++)
                {
                    var uiObservacionModificado = this.lstModificados[i];
                    rpta = lnObservacion.Actualizar(uiObservacionModificado);
                }

                this.lstModificados.Clear();

                for (int i = 0; i < this.lstEliminados.Count; i++)
                {
                    var uiObservacionEliminado = this.lstEliminados[i];
                    rpta = lnObservacion.Eliminar(uiObservacionEliminado);
                }

                this.lstEliminados.Clear();

                this.CargarListadoObservaciones();

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
                if (this.dgvObservaciones.CurrentRow != null)
                {

                    if (Util.ConfirmationMessage("¿Desea eliminar la observación seleccionada?") == false)
                        return;

                    var uiObservacion = (BE.UI.Observacion)this.dgvObservaciones.CurrentRow.DataBoundItem;
                    if (uiObservacion.Id > 0)
                    {
                        this.lstEliminados.Add(uiObservacion);
                    }

                    this.lstCreados.Remove(uiObservacion);
                    this.lstModificados.Remove(uiObservacion);

                    this.dgvObservaciones.Rows.RemoveAt(this.dgvObservaciones.CurrentRow.Index);
                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
            
        }
        
        #endregion

        #region Metodos
        
        private void CargarListadoObservaciones()
        {
            try
            {
                this.lstUiObservaciones = new LN.Observacion(this.idUsuario).Listar();
                
                var source = new BindingSource();
                source.DataSource = lstUiObservaciones;

                this.dgvObservaciones.Columns.Clear();
                this.dgvObservaciones.AutoGenerateColumns = false;
                this.dgvObservaciones.AutoSize = true;
                this.dgvObservaciones.DataSource = source;
                this.dgvObservaciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                DataGridViewColumn colNombre = new DataGridViewTextBoxColumn();
                colNombre.DataPropertyName = "Nombre";
                colNombre.Name = "Nombre";
                colNombre.Width = 200;
                this.dgvObservaciones.Columns.Add(colNombre);

                DataGridViewColumn colDescripcion = new DataGridViewTextBoxColumn();
                colDescripcion.DataPropertyName = "Descripcion";
                colDescripcion.Name = "Descripcion";
                colDescripcion.Width = 300;
                this.dgvObservaciones.Columns.Add(colDescripcion);

                DataGridViewComboBoxColumn colActivo = new DataGridViewComboBoxColumn();
                colActivo.DataSource = Enum.GetValues(typeof(BE.UI.ActivoEnum));
                colActivo.DataPropertyName = "Activo";
                colActivo.Name = "Activo";
                colActivo.Width = 70;
                this.dgvObservaciones.Columns.Add(colActivo);

                Util.AutoWidthColumn(ref this.dgvObservaciones, "Descripcion");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion


    }
}

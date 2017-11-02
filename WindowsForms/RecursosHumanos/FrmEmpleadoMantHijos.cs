using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmEmpleadoMantHijos : Form
    {

        #region "Patron Singleton"

        private static FrmEmpleadoMantHijos frmInstance = null;

        public static FrmEmpleadoMantHijos Instance()
        {

            if (frmInstance == null || frmInstance.IsDisposed == true)
            {
                frmInstance = new FrmEmpleadoMantHijos();
            }

            frmInstance.BringToFront();

            return frmInstance;
        }

        #endregion

        private List<BE.UI.EmpleadoHijo> lstUiHijos = null;

        public FrmEmpleadoMantHijos()
        {
            try
            {
                InitializeComponent();
                this.lstUiHijos = new List<BE.UI.EmpleadoHijo>();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }

        }

        #region Metodos

        public void CargarListadoHijos()
        {
            try
            {

                this.lstUiHijos = new List<BE.UI.EmpleadoHijo>();

                var sorted = new SortableBindingList<BE.UI.EmpleadoHijo>(lstUiHijos);

                this.dgvHijos.DataSource = sorted;

                this.txtEmpleadoNroHijos.Text = lstUiHijos.Count.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarEmpleados()
        {
            var lstEmpleados = new LN.Empleado().Combo();
            var lstCandidatos = new LN.Candidato().Combo();
            lstEmpleados.AddRange(lstCandidatos);
            var lstTrabajador = lstEmpleados.OrderBy(o => o.Codigo).Distinct().ToList();

            lstTrabajador.Insert(0, new BE.Record() { Codigo = "", Nombre = "Seleccione" });

            this.cboEmpleado.DataSource = lstTrabajador;
            this.cboEmpleado.DisplayMember = "Nombre";
            this.cboEmpleado.ValueMember = "Codigo";
        }

        private void FormatoEmpleadoHijo()
        {
            try
            {
                Util.FormatDatagridview(ref this.dgvHijos);
                for (int i = 0; i < this.dgvHijos.Columns.Count; i++)
                    this.dgvHijos.Columns[i].Visible = false;

                this.dgvHijos.Columns["HijoNombre"].Visible = true;
                this.dgvHijos.Columns["HijoNombre"].HeaderText = "Nombres";
                this.dgvHijos.Columns["HijoNombre"].Width = 150;

                this.dgvHijos.Columns["HijoApellidoPaterno"].Visible = true;
                this.dgvHijos.Columns["HijoApellidoPaterno"].HeaderText = "Apellido Paterno";
                this.dgvHijos.Columns["HijoApellidoPaterno"].Width = 150;

                this.dgvHijos.Columns["HijoApellidoMaterno"].Visible = true;
                this.dgvHijos.Columns["HijoApellidoMaterno"].HeaderText = "Apellido Materno";
                this.dgvHijos.Columns["HijoApellidoMaterno"].Width = 150;

                this.dgvHijos.Columns["HijoFechaNacimiento"].Visible = true;
                this.dgvHijos.Columns["HijoFechaNacimiento"].HeaderText = "Nacimiento";
                this.dgvHijos.Columns["HijoFechaNacimiento"].Width = 70;
                this.dgvHijos.Columns["HijoFechaNacimiento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvHijos.Columns["HijoFechaNacimiento"].DefaultCellStyle.Format = "dd/MM/yyyy";

                this.dgvHijos.Columns["HijoEdad"].Visible = true;
                this.dgvHijos.Columns["HijoEdad"].HeaderText = "Edad";
                this.dgvHijos.Columns["HijoEdad"].Width = 50;
                this.dgvHijos.Columns["HijoEdad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                this.dgvHijos.Columns["HijoEstudia"].Visible = true;
                this.dgvHijos.Columns["HijoEstudia"].HeaderText = "Estudia";
                this.dgvHijos.Columns["HijoEstudia"].Width = 50;
                this.dgvHijos.Columns["HijoEstudia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                Util.AutoWidthColumn(ref this.dgvHijos, "HijoNombre");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        

        #endregion

        #region Formulario

        private void FrmEmpleadoMantHijos_Load(object sender, EventArgs e)
        {
            try
            {
                this.CargarEmpleados();

                this.CargarListadoHijos();
                this.FormatoEmpleadoHijo();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
               

                Util.InformationMessage("Se guardo los datos de la Comision");

                this.CargarListadoHijos();

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
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

        private void cboEmpleado_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (this.cboEmpleado.SelectedIndex > 0)
                {
                    string codigoEmpleado = this.cboEmpleado.SelectedValue.ToString().Trim();
                    this.txtEmpleadoCodigo.Text = codigoEmpleado;
                }
                else
                {
                    this.txtEmpleadoCodigo.Clear();
                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void txtEmpleadoCodigo_Leave(object sender, EventArgs e)
        {
            try
            {
                string codigoEmpleado = this.txtEmpleadoCodigo.Text.Trim();

                var lst = (List<BE.Record>)this.cboEmpleado.DataSource;

                var beEmpleado = lst.FirstOrDefault(x => x.Codigo.Contains(codigoEmpleado));

                if (beEmpleado != null)
                {
                    this.txtEmpleadoCodigo.Text = beEmpleado.Codigo;
                    this.cboEmpleado.SelectedValue = beEmpleado.Codigo;
                }
                else
                {
                    this.txtEmpleadoCodigo.Clear();
                    this.cboEmpleado.SelectedIndex = 0;
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

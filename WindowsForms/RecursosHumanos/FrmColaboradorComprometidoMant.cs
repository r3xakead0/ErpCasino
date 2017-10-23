using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmColaboradorComprometidoMant : Form
    {

        private List<BE.UI.Comprometido> lstUiComprometidos = null;

        public FrmColaboradorComprometidoMant()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }

        }

        #region Metodos

        private void CargarSalas()
        {
            var lstBeSalas = new LN.Sala().ListaSimple();
            
            this.cboSalas.DataSource = lstBeSalas;
            this.cboSalas.DisplayMember = "Nombre";
            this.cboSalas.ValueMember = "IdSala";
        }

        public void CargarListaComprometidos()
        {
            try
            {

                int anho = int.Parse(this.cboAnho.SelectedValue.ToString());
                int mes = int.Parse(this.cboMes.SelectedValue.ToString());
                BE.Sala beSala = (BE.Sala)this.cboSalas.SelectedItem;

                this.lstUiComprometidos = new LN.Comprometido().Listar(anho, mes, beSala.IdSala);

                if (this.lstUiComprometidos.Count == 0)
                {
                    var lstColaborados = new LN.Horario().ListarColaborados(anho, mes, beSala.IdSala);

                    foreach (BE.Record beColaborador in lstColaborados)
                    {
                        var uiComprometido = new BE.UI.Comprometido();

                        uiComprometido.SalaId = beSala.IdSala;
                        uiComprometido.SalaNombre = beSala.Nombre;
                        uiComprometido.Anho = anho;
                        uiComprometido.Mes = mes;
                        uiComprometido.EmpleadoCodigo = beColaborador.Codigo;
                        uiComprometido.EmpleadoNombreCompleto = beColaborador.Nombre;

                        this.lstUiComprometidos.Add(uiComprometido);
                    }
                }

                var source = new BindingSource();
                source.DataSource = this.lstUiComprometidos;

                this.dgvComprometidos.DataSource = source;
                this.txtNroRegistros.Text = this.lstUiComprometidos.Count.ToString(); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FormatoListaComprometidos()
        {
            try
            {
                Util.FormatDatagridview(ref this.dgvComprometidos);

                this.dgvComprometidos.ReadOnly = false;

                for (int i = 0; i < this.dgvComprometidos.Columns.Count; i++)
                    this.dgvComprometidos.Columns[i].Visible = false;

                this.dgvComprometidos.Columns["EmpleadoCodigo"].Visible = true;
                this.dgvComprometidos.Columns["EmpleadoCodigo"].HeaderText = "Codigo";
                this.dgvComprometidos.Columns["EmpleadoCodigo"].Width = 80;
                this.dgvComprometidos.Columns["EmpleadoCodigo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dgvComprometidos.Columns["EmpleadoCodigo"].ReadOnly = true;

                this.dgvComprometidos.Columns["EmpleadoNombreCompleto"].Visible = true;
                this.dgvComprometidos.Columns["EmpleadoNombreCompleto"].HeaderText = "Codigo";
                this.dgvComprometidos.Columns["EmpleadoNombreCompleto"].Width = 200;
                this.dgvComprometidos.Columns["EmpleadoNombreCompleto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dgvComprometidos.Columns["EmpleadoNombreCompleto"].ReadOnly = true;

                this.dgvComprometidos.Columns["Estado"].Visible = true;
                this.dgvComprometidos.Columns["Estado"].HeaderText = "Comprometido";
                this.dgvComprometidos.Columns["Estado"].Width = 80;
                this.dgvComprometidos.Columns["Estado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvComprometidos.Columns["Estado"].ReadOnly = false;

                Util.AutoWidthColumn(ref this.dgvComprometidos, "EmpleadoNombreCompleto");
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

                this.cboMes.SelectedValue = DateTime.Now.Month.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        

        #endregion

        #region Formulario

        private void FrmColaboradorComprometidoMant_Load(object sender, EventArgs e)
        {
            try
            {

                this.CargarAnhos();
                this.cboAnho.SelectedValue = DateTime.Now.Year.ToString();

                this.CargarMes();
                this.cboMes.SelectedValue = DateTime.Now.Month.ToString();

                this.CargarSalas();

                this.lstUiComprometidos = new List<BE.UI.Comprometido>();
                this.CargarListaComprometidos();
                this.FormatoListaComprometidos();
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

                bool rpta = false;

                var lnComprometido = new LN.Comprometido();
                for (int i = 0; i < this.lstUiComprometidos.Count; i++)
                {
                    var uiComprometido = this.lstUiComprometidos[i];
                    if (uiComprometido.Id > 0)
                    {
                        rpta = lnComprometido.Actualizar(uiComprometido);
                    }
                    else
                    {
                        rpta = lnComprometido.Insertar(ref uiComprometido);
                        this.lstUiComprometidos[i].Id = uiComprometido.Id;
                    }
                }     

                if (rpta)
                {
                    Util.InformationMessage("Se guardo los colaboradores comprometidos");
                    this.CargarListaComprometidos();
                }

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {

                var rpta = Util.ConfirmationMessage("¿Desea salir del mantenimiento de colaboradores comprometidos?");

                if (rpta == false)
                    return;

                this.Close();

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }
        
        private void CbxAnhoMesSala_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                CargarListaComprometidos();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void FrmColaboradorComprometidoMant_ResizeEnd(object sender, EventArgs e)
        {
            try
            {
                Util.AutoWidthColumn(ref this.dgvComprometidos, "EmpleadoNombreCompleto");
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        #endregion


    }
}

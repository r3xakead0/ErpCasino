using System;
using System.Windows.Forms;
using System.Data;
using System.Linq;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;
using System.Collections.Generic;
using System.IO;
using System.Globalization;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmAdelantoCarga : Form
    {

        #region "Patron Singleton"

        private static FrmAdelantoCarga frmInstance = null;

        public static FrmAdelantoCarga Instance()
        {

            if (frmInstance == null || frmInstance.IsDisposed == true)
            {
                frmInstance = new FrmAdelantoCarga();
            }

            frmInstance.BringToFront();

            return frmInstance;
        }

        #endregion

        public FrmAdelantoList frmList = null;

        private string codTipoBanco = "BAN";
        private List<BE.UI.Adelanto> lstUiAdelantos = null;

        public FrmAdelantoCarga()
        {
            try
            {
                InitializeComponent();
                this.lstUiAdelantos = new List<BE.UI.Adelanto>();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }

        }

        private void CargarArchivo(string rutaArchivo)
        {
            try
            {

                this.lstUiAdelantos.Clear();

                using (var fs = File.OpenRead(rutaArchivo))
                using (var reader = new StreamReader(fs))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();

                        BE.UI.Adelanto uiAdelanto = this.CSVtoUI(line);

                        this.lstUiAdelantos.Add(uiAdelanto);
                    }
                }

                this.CargarListadoAdelantos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private BE.UI.Adelanto CSVtoUI(string line, char separator = ',')
        {
            try
            {
                var beTipoAdelanto = (BE.Record)this.cboTipos.SelectedItem;
                var lstBeTrabajadores = this.ListadoTrabajadores();
                var lstBeBancos = new LN.Banco().Listar();

                #region Obtener datos de la fila

                var values = line.Split(separator);

                string codEmpleado = values[0].ToString();
                DateTime fecha = DateTime.ParseExact(values[1].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                double monto = double.Parse(values[3].ToString());

                string codBanco = "";
                string nroOperacion = "";
                if (beTipoAdelanto.Codigo == this.codTipoBanco)
                {
                    codBanco = values[4].ToString();
                    nroOperacion = values[5].ToString();
                }

                #endregion

                #region Cargar Registro

                var uiAdelanto = new BE.UI.Adelanto();

                uiAdelanto.IdAdelanto = 0;
                uiAdelanto.CodigoTipo = beTipoAdelanto.Codigo;
                uiAdelanto.NombreTipo = beTipoAdelanto.Nombre;
                uiAdelanto.Fecha = fecha;
                uiAdelanto.Monto = monto;

                uiAdelanto.CodigoEmpleado = codEmpleado;
                var beTrabajador = lstBeTrabajadores.FirstOrDefault(x => x.Codigo.Equals(codEmpleado));
                if (beTrabajador != null)
                    uiAdelanto.NombreCompletoEmpleado = beTrabajador.Nombre;
                beTrabajador = null;

                if (beTipoAdelanto.Codigo == this.codTipoBanco)
                {
                    var beBanco = lstBeBancos.FirstOrDefault(x => x.Codigo.Equals(codBanco));

                    if (beBanco != null)
                    {
                        uiAdelanto.IdBanco = beBanco.IdBanco;
                        uiAdelanto.NombreBanco = beBanco.Nombre;
                    }
                    beBanco = null;

                    uiAdelanto.Numero = nroOperacion;
                }

                #endregion

                return uiAdelanto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<BE.Record> ListadoTrabajadores()
        {
            var lstEmpleados = new LN.Empleado().Combo();
            var lstCandidatos = new LN.Candidato().Combo();

            lstEmpleados.AddRange(lstCandidatos);

            var lstTrabajadores = lstEmpleados.OrderBy(o => o.Nombre).Distinct().ToList();

            return lstTrabajadores;
        }

        private void CargarTipos()
        {
            var lstTipos = new LN.Record().ListarTiposAdelantos();

            lstTipos.Insert(0, new BE.Record() { Codigo = "0", Nombre = "Seleccione" });

            this.cboTipos.DataSource = lstTipos;
            this.cboTipos.DisplayMember = "Nombre";
            this.cboTipos.ValueMember = "Codigo";
        }

        public void CargarListadoAdelantos()
        {
            try
            {
                
                var source = new BindingSource();
                source.DataSource = this.lstUiAdelantos;

                this.dgvAdelantos.DataSource = source;

                int nroRegistros = this.lstUiAdelantos.Count;
                double total = this.lstUiAdelantos.Sum(x => x.Monto);

                this.txtNroRegistros.Text = nroRegistros.ToString();
                this.txtTotalMonto.Text = total.ToString("N2");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FormatoListadoAdelantos()
        {
            try
            {
                Util.FormatDatagridview(ref this.dgvAdelantos);

                for (int col = 0; col < this.dgvAdelantos.Columns.Count; col++)
                    this.dgvAdelantos.Columns[col].Visible = false;

                this.dgvAdelantos.Columns["Fecha"].Visible = true;
                this.dgvAdelantos.Columns["Fecha"].HeaderText = "Fecha";
                this.dgvAdelantos.Columns["Fecha"].Width = 100;
                this.dgvAdelantos.Columns["Fecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvAdelantos.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";

                this.dgvAdelantos.Columns["CodigoEmpleado"].Visible = true;
                this.dgvAdelantos.Columns["CodigoEmpleado"].HeaderText = "Codigo";
                this.dgvAdelantos.Columns["CodigoEmpleado"].Width = 80;
                this.dgvAdelantos.Columns["CodigoEmpleado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvAdelantos.Columns["NombreCompletoEmpleado"].Visible = true;
                this.dgvAdelantos.Columns["NombreCompletoEmpleado"].HeaderText = "Empleado";
                this.dgvAdelantos.Columns["NombreCompletoEmpleado"].Width = 200;
                this.dgvAdelantos.Columns["NombreCompletoEmpleado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvAdelantos.Columns["NombreTipo"].Visible = true;
                this.dgvAdelantos.Columns["NombreTipo"].HeaderText = "Tipo";
                this.dgvAdelantos.Columns["NombreTipo"].Width = 50;
                this.dgvAdelantos.Columns["NombreTipo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.dgvAdelantos.Columns["NombreBanco"].Visible = true;
                this.dgvAdelantos.Columns["NombreBanco"].HeaderText = "Banco";
                this.dgvAdelantos.Columns["NombreBanco"].Width = 100;
                this.dgvAdelantos.Columns["NombreBanco"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvAdelantos.Columns["Numero"].Visible = true;
                this.dgvAdelantos.Columns["Numero"].HeaderText = "Numero";
                this.dgvAdelantos.Columns["Numero"].Width = 80;
                this.dgvAdelantos.Columns["Numero"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvAdelantos.Columns["Monto"].Visible = true;
                this.dgvAdelantos.Columns["Monto"].HeaderText = "Monto";
                this.dgvAdelantos.Columns["Monto"].Width = 80;
                this.dgvAdelantos.Columns["Monto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvAdelantos.Columns["Monto"].DefaultCellStyle.Format = "N2";

                Util.AutoWidthColumn(ref this.dgvAdelantos, "NombreCompletoEmpleado");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Formulario

        private void FrmAfpComisionMant_Load(object sender, EventArgs e)
        {
            try
            {
                this.CargarTipos();
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

                if (this.lstUiAdelantos.Count == 0)
                {
                    throw new Exception("No se cargo los adelantos");
                }

                Util.PointerLoad(this);

                bool rpta = new LN.Adelanto().Insertar(ref this.lstUiAdelantos);

                if (rpta)
                {
                    this.frmList.CargarListadoAdelantos();

                    Util.InformationMessage("Se guardo los adelantos");

                    this.Close();
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {

                var rpta = Util.ConfirmationMessage("¿Desea salir del formulario de Carga de Adelantos?");

                if (rpta == false)
                    return;

                this.Close();

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            try
            {

                #region Validaciones

                if (this.cboTipos.SelectedIndex == 0)
                {
                    this.cboTipos.Focus();
                    throw new Exception("Seleccione una tipo");
                }

                if (this.txtArchivo.Text.Length == 0)
                {
                    this.btnArchivo.Focus();
                    throw new Exception("Seleccione un archivo de carga");
                }

                #endregion

                Util.PointerLoad(this);

                this.CargarArchivo(this.txtArchivo.Text);

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

        #endregion
    }
}

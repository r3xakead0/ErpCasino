using System;
using System.Windows.Forms;
using System.Data;
using System.Linq;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;
using System.Collections.Generic;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmAsignarBonoCalcular : Form
    {

        private FrmAsignarBonoList frmList = null;

        private int Anho = 0;
        private int Mes = 0;
        private List<BE.UI.Cargo> lstUiCargos = null; //Lista temporal de datos de cargos

        private List<BE.UI.BonoEmpleado> lstUiBonosEmpleados = null;

        public FrmAsignarBonoCalcular(FrmAsignarBonoList frmList)
        {
            try
            {
                InitializeComponent();
                this.frmList = frmList;
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }

        }

        private void Limpiar()
        {
            try
            {

                this.CargarAnhos();
                this.CargarMes();
                this.cboAnho.SelectedValue = DateTime.Now.Year.ToString();
                this.cboMes.SelectedValue = DateTime.Now.Month.ToString();

                this.CargarTiposBonos();

                this.lstUiBonosEmpleados = new List<BE.UI.BonoEmpleado>();
                var source = new BindingSource();
                source.DataSource = this.lstUiBonosEmpleados;
                this.dgvBonos.DataSource = source;
                this.txtNroBonos.Text = this.lstUiBonosEmpleados.Count.ToString();

                this.FormatoBonosEmpleados();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Monto de bono que se le asigna por cargo o función.
        /// </summary>
        /// <param name="codigoEmpleado">Codigo de Empleado o Candidato</param>
        /// <returns></returns>
        private double BonoCargo(string codigoEmpleado)
        {
            try
            {

                double bonoXcargo = 0.0;

                var beEmpleado = new LN.Empleado().Obtener(codigoEmpleado);
                if (beEmpleado != null)
                {
                    var beEmpleadoRecurso = new LN.Empleado().ObtenerRecurso(beEmpleado.IdEmpleado);
                    if (beEmpleadoRecurso != null)
                    {
                        if (beEmpleadoRecurso.Cargo != null)
                        {
                            if (lstUiCargos == null)
                                lstUiCargos = new LN.Cargo().Listar();

                            int idCargo = beEmpleadoRecurso.Cargo.IdCargo;
                            var uiBono = lstUiCargos.SingleOrDefault(x => x.Id == idCargo);
                            if (uiBono != null)
                                bonoXcargo = uiBono.Bono;
                        }
                    }
                }

                return bonoXcargo;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Bono que se da si cumple 3 condiciones :
        /// 1. Tener maximo de 3 tardanzas por mes
        /// 2. Tener máximo de 1 falta por mes
        /// 3. Tener máximo de 5 observaciones por mes
        /// </summary>
        /// <param name="codigoEmpleado">Codigo de Empleado o Candidato</param>
        private double BonoDisciplina(string codigoEmpleado)
        {
            try
            {

                bool cumpleDisciplina = false;

                double bonoDisciplina = 150.0;
                int maxTardanzas = 3;
                int maxFaltas = 1;
                int maxObservaciones = 5;

                var uiAsistenciaResumen = new LN.Planilla(this.Anho, this.Mes).ObtenerResumenAsistenciaEmpleado(codigoEmpleado);

                if (uiAsistenciaResumen != null)
                {
                    // 1. Tener maximo de 3 tardanzas por mes
                    if (uiAsistenciaResumen.CantidadTardanzas <= maxTardanzas)
                        cumpleDisciplina = true;

                    // 2. Tener máximo de 1 falta por mes   
                    if (uiAsistenciaResumen.CantidadInasistencias <= maxFaltas)
                        cumpleDisciplina = true;
                }

                uiAsistenciaResumen = null;

                // 3. Tener máximo de 5 observaciones por mes
                int cntObservaciones = new LN.ObservacionEmpleado().CantidadObservacionesEmpleado(this.Anho, this.Mes, codigoEmpleado);
                if (cntObservaciones <= maxObservaciones)
                    cumpleDisciplina = true;

                if (cumpleDisciplina == false)
                    bonoDisciplina = 0.0;

                return bonoDisciplina;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private double BonoMeta(int idSala, string codigoEmpleado)
        {
            try
            {
                double bonoMeta = 0.0;

                if (this.BonoMetaIndividual(codigoEmpleado) == true)
                    bonoMeta = this.BonoMetaGrupal(idSala);

                return bonoMeta;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Bono que se da si cumple con las siguientes condiciones
        /// 1. Grupal :
        /// 1.1. Alcanzar la meta de la sala.
        /// 1.2. Tener un máximo de 30% de tardanzas por sala
        /// 1.3. Tener un máximo de 30% de faltas por sala
        /// 1.4. Tener un máximo de 30% de observaciones.
        /// </summary>
        /// <param name="idSala">ID de la Sala</param>
        /// <returns></returns>
        private double BonoMetaGrupal(int idSala)
        {
            try
            {
                
                double bonoMeta = 0.0;

                #region Obtener Monto de Bono Grupal

                var beBono = new LN.Bono().Obtener(2);
                if (beBono != null)
                    bonoMeta = beBono.Monto;
                beBono = null;

                #endregion

                #region Meta Grupal

                bool cumpleMetaGrupal = false;
                int cantidadTrabajadoresSala = 0;

                // Alcanzar la meta de la sala
                bool cumpleMetaSala = false;
                var beMetaSala = new LN.MetaSala().Obtener(idSala, this.Anho, this.Mes);
                if (beMetaSala != null)
                {
                    cumpleMetaSala = beMetaSala.Cumplido;
                    bonoMeta = beMetaSala.MontoPersonal;
                    cantidadTrabajadoresSala = beMetaSala.CantidadPersonal;
                }
                else
                {
                    throw new Exception("No existe una meta definida para esta sala y periodo");
                }
                beMetaSala = null;

                //Tener un máximo de 30% de tardanzas por sala
                bool cumpleMetaTardanzas = false;
                double maxPorcentajeTardanzas = 30.0;
                double porcentajeTardanzas = 0;
                if (porcentajeTardanzas <= maxPorcentajeTardanzas)
                    cumpleMetaTardanzas = true;
                //FALTA

                //Tener un máximo de 30% de faltas por sala
                bool cumpleMetaFaltas = false;
                double maxPorcentajeFaltas = 30.0;
                double porcentajeFaltas = 0.0;
                if (porcentajeFaltas <= maxPorcentajeFaltas)
                    cumpleMetaFaltas = true;
                //FALTA

                //Tener un máximo de 30% de observaciones
                bool cumpleMetaObservaciones = false;
                double maxPorcentajeObservaciones = 30.0;
                
                int cntObservacionesSala = new LN.ObservacionEmpleado().CantidadObservacionesSala(this.Anho, this.Mes, idSala);
                double porcentajeObservaciones = (cntObservacionesSala / cantidadTrabajadoresSala) * 100; 
                if (porcentajeObservaciones <= maxPorcentajeObservaciones)
                    cumpleMetaObservaciones = true;

                if (cumpleMetaSala == true && 
                    cumpleMetaFaltas == true &&
                    cumpleMetaTardanzas == true &&
                    cumpleMetaObservaciones == true)
                {
                    cumpleMetaGrupal = true;
                }

                #endregion

                if (cumpleMetaGrupal == false)
                    bonoMeta = 0.0;

                return bonoMeta;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Bono que se da si cumple con las siguientes condiciones
        /// 1. Individual :
        /// 1.1. Tener maximo de 3 tardanzas por mes
        /// 1.2. Tener máximo de 1 falta por mes
        /// 1.3. Tener máximo de 5 observaciones por mes
        /// 1.4. Señalar que esta comprometido a través de tareas adicionales.
        /// </summary>
        /// <param name="codigoEmpleado">Codigo de Empleado o Candidato</param>
        /// <returns></returns>
        private bool BonoMetaIndividual(string codigoEmpleado)
        {
            try
            {

                bool bonoMetaIndividual = false;

                #region Meta Individual

                bool cumpleMetaIndividual = false;
                if (this.BonoDisciplina(codigoEmpleado) > 0.0)
                    cumpleMetaIndividual = true;

                bool cumpleMetaComprometido = false;
                var lstUiComprometidos = new LN.Comprometido().Listar(this.Anho, this.Mes, null, codigoEmpleado);
                foreach (BE.UI.Comprometido uiComprometido in lstUiComprometidos)
                {
                    if (uiComprometido.Estado == false)
                    {
                        cumpleMetaComprometido = false;
                        break;
                    }

                    cumpleMetaComprometido = uiComprometido.Estado;
                }
                #endregion

                if (cumpleMetaIndividual == true && cumpleMetaComprometido == true)
                    bonoMetaIndividual = true;

                return bonoMetaIndividual;

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

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarTiposBonos()
        {
            try
            {
                var lstTipos = new LN.Bono().Listar();
                lstTipos = lstTipos.Where(x => x.Calculado == true).ToList();

                lstTipos.Insert(0, new BE.UI.Bono() { Id = 0, Nombre = "Seleccione" });

                this.cboBono.DataSource = lstTipos;
                this.cboBono.DisplayMember = "Nombre";
                this.cboBono.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FormatoBonosEmpleados()
        {
            try
            {
                Util.FormatDatagridview(ref this.dgvBonos);

                for (int col = 0; col < this.dgvBonos.Columns.Count; col++)
                    this.dgvBonos.Columns[col].Visible = false;

                this.dgvBonos.Columns["Fecha"].Visible = true;
                this.dgvBonos.Columns["Fecha"].HeaderText = "Fecha";
                this.dgvBonos.Columns["Fecha"].Width = 80;
                this.dgvBonos.Columns["Fecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvBonos.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";

                this.dgvBonos.Columns["EmpleadoCodigo"].Visible = true;
                this.dgvBonos.Columns["EmpleadoCodigo"].HeaderText = "Codigo";
                this.dgvBonos.Columns["EmpleadoCodigo"].Width = 80;
                this.dgvBonos.Columns["EmpleadoCodigo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvBonos.Columns["EmpleadoNombreCompleto"].Visible = true;
                this.dgvBonos.Columns["EmpleadoNombreCompleto"].HeaderText = "Empleado";
                this.dgvBonos.Columns["EmpleadoNombreCompleto"].Width = 200;
                this.dgvBonos.Columns["EmpleadoNombreCompleto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvBonos.Columns["BonoNombre"].Visible = true;
                this.dgvBonos.Columns["BonoNombre"].HeaderText = "Bono";
                this.dgvBonos.Columns["BonoNombre"].Width = 100;
                this.dgvBonos.Columns["BonoNombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.dgvBonos.Columns["Monto"].Visible = true;
                this.dgvBonos.Columns["Monto"].HeaderText = "Monto";
                this.dgvBonos.Columns["Monto"].Width = 100;
                this.dgvBonos.Columns["Monto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvBonos.Columns["Monto"].DefaultCellStyle.Format = "N2";

                Util.AutoWidthColumn(ref this.dgvBonos, "EmpleadoNombreCompleto");
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
                this.Limpiar();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {

                #region Validaciones
                
                if (this.cboBono.SelectedIndex == 0)
                {
                    this.cboBono.Focus();
                    throw new Exception("Seleccione un tipo de Bono");
                }

                #endregion

                Util.PointerLoad(this);

                #region Calcular

                this.Anho = int.Parse(this.cboAnho.SelectedValue.ToString());
                this.Mes  = int.Parse(this.cboMes.SelectedValue.ToString());
                int dia = DateTime.DaysInMonth(this.Anho, this.Mes);
                DateTime fechaPeriodo = new DateTime(this.Anho, this.Mes, dia);

                var beBono = ((BE.UI.Bono)this.cboBono.SelectedItem);
                int bonoId = beBono.Id;
                string bonoTipo = beBono.Calculado ? "Calculado" : "Manual"; //Manual o Calculado
                string bonoNombre = beBono.Nombre;
                double bonoMonto = 0.0;
                beBono = null;

                List<BE.Record> lstTrabajadores = new List<BE.Record>();
                var lstEmpleados = new LN.Empleado().Combo();
                var lstCandidatos = new LN.Candidato().Combo();
                lstEmpleados.AddRange(lstCandidatos);
                lstTrabajadores = lstEmpleados.OrderBy(o => o.Codigo).Distinct().ToList();
                lstEmpleados = null;
                lstCandidatos = null;

                this.lstUiBonosEmpleados = new List<BE.UI.BonoEmpleado>();

                foreach (BE.Record beTrabajador in lstTrabajadores)
                {
                    var uiBonoEmpleado = new BE.UI.BonoEmpleado();

                    uiBonoEmpleado.Fecha = fechaPeriodo;
                    uiBonoEmpleado.EmpleadoCodigo = beTrabajador.Codigo;
                    uiBonoEmpleado.EmpleadoNombreCompleto = beTrabajador.Nombre;
                    uiBonoEmpleado.BonoID = bonoId;
                    uiBonoEmpleado.BonoTipo = bonoTipo;
                    uiBonoEmpleado.BonoNombre = bonoNombre;

                    switch (bonoId)
                    {
                        case 1: //Disciplina
                            bonoMonto = this.BonoDisciplina(beTrabajador.Codigo);
                            break;
                        case 2: //Meta
                            int idSalaTrabajador = 0;
                            var beEmpleadoRecurso = new LN.Empleado().ObtenerRecurso(beTrabajador.Codigo);
                            if (beEmpleadoRecurso != null)
                            {
                                idSalaTrabajador = beEmpleadoRecurso.Sala.IdSala;
                                bonoMonto = this.BonoMeta(idSalaTrabajador, beTrabajador.Codigo);
                            }
                            beEmpleadoRecurso = null;
                            break;
                        case 3: //Cargo
                            bonoMonto = this.BonoCargo(beTrabajador.Codigo);
                            break;
                        default:
                            bonoMonto = 0.0;
                            break;
                    }

                    uiBonoEmpleado.Monto = bonoMonto;
                    uiBonoEmpleado.Motivo = "";

                    lstUiBonosEmpleados.Add(uiBonoEmpleado);

                }

                #endregion

                #region Mostrar 

                this.txtAnhoMes.Text = fechaPeriodo.ToString("yyyy/MM");
                this.txtTipoBono.Text = bonoNombre;

                var source = new BindingSource();
                source.DataSource = this.lstUiBonosEmpleados;
                this.dgvBonos.DataSource = source;

                this.txtNroBonos.Text = this.lstUiBonosEmpleados.Count.ToString();

                #endregion

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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }



        #endregion
        
    }
}

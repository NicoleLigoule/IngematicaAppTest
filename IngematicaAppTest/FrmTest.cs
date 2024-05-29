using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IngematicaAppTest.Model;
using IngematicaAppTest.Service;

namespace IngematicaAppTest
{
    public partial class FrmTest : Form
    {
        public FrmTest()
        {
            InitializeComponent();

            InitializeCombos();
        }


        private void InitializeCombos()
        {
            InitializeComboTipoTransporte();

            InitializeCoboLocalidad();

            InitializeCoboEleccionVia();
        }

        private void InitializeComboTipoTransporte()
        {
            List<TipoTransporteModel> tipoTransporteList = new List<TipoTransporteModel>();
            TipoTransporteService tipoTransporteService = new TipoTransporteService();
            tipoTransporteList = tipoTransporteService.GetList();

            var bindingSourceTipoTransporte = new BindingSource();
            bindingSourceTipoTransporte.DataSource = tipoTransporteList;

            cbTipoTransporte.DataSource = bindingSourceTipoTransporte;
            cbTipoTransporte.DisplayMember = "Nombre";
            cbTipoTransporte.ValueMember = "Id";
        }

        private void InitializeCoboLocalidad()
        {
            List<LocalidadModel> localidadList = new List<LocalidadModel>();
            LocalidadService localidadService = new LocalidadService();
            localidadList = localidadService.GetList();

            var bindingSourceLocalidad = new BindingSource();
            bindingSourceLocalidad.DataSource = localidadList;

            cbLocalidadDestino.DataSource = bindingSourceLocalidad;
            cbLocalidadDestino.DisplayMember = "Nombre";
            cbLocalidadDestino.ValueMember = "Id";
        }

        private void InitializeCoboEleccionVia()
        {
            List<EleccionViaModel> eleccionList = new List<EleccionViaModel>();
            EleccionViaService eleccionService = new EleccionViaService();
            eleccionList = eleccionService.GetList();

            var bindingSourceEleccionVia = new BindingSource();
            bindingSourceEleccionVia.DataSource = eleccionList;

            cbEleccionVia.DataSource = bindingSourceEleccionVia;
            cbEleccionVia.DisplayMember = "Nombre";
            cbEleccionVia.ValueMember = "Id";
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaPartida = dtpFechaInicial.Value;

                var selectedTipoTransporte = (TipoTransporteModel)cbTipoTransporte.SelectedItem;
                int idTipoTransporte = selectedTipoTransporte.IdTipoTransporte;

                var selectedLocalidad = (LocalidadModel)cbLocalidadDestino.SelectedItem;
                int idLocalidad = selectedLocalidad.IdLocalidad;

                bool porRuta = ((EleccionViaModel)cbEleccionVia.SelectedItem).Nombre == "Ruta";

                CalculoService calculosService = new CalculoService();
                DateTime fechaLlegada = calculosService.CalcularFechaLlegada(fechaPartida, idLocalidad, idTipoTransporte, porRuta);

                txtFechaLlegada.Text = fechaLlegada.ToShortDateString();
                txtDiasDemora.Text = (fechaLlegada - fechaPartida).TotalDays.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo realizar el cálculo correctamente debido al error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (cbTipoTransporte.Items.Count > 0)
            {
                cbTipoTransporte.SelectedIndex = 0;
            }
            if (cbLocalidadDestino.Items.Count > 0)
            {
                cbLocalidadDestino.SelectedIndex = 0;
            }
            if (cbEleccionVia.Items.Count > 0)
            {
                cbEleccionVia.SelectedIndex = 0;
            }

            dtpFechaInicial.Value = DateTime.Now;

            txtFechaLlegada.Text = string.Empty;
            txtDiasDemora.Text = string.Empty;
        }
    }
}
